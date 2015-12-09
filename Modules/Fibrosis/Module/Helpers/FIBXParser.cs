using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Drawing;
using System.Linq;
using System.Xml;
using Fibrosis.Repositories;

namespace Fibrosis.Helpers
{
    using FibroscanProcessor;
    using Models;
    using System.Globalization;
    using System.Windows;
    using System.Xml.Linq;

    public class FibxParser
    {
        private static volatile FibxParser _instance;
        private static object _syncRoot = new object();

        //private readonly ILog _log;

        public FibxParser()
        {
        //    _log = LogManager.GetLogger("FibxParser");
        }

        public static FibxParser Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new FibxParser();
                    }
                }

                return _instance;
            }
        }

        public bool Import(string fileName, int patientId, int physicianId = 0)
        {
            if (string.IsNullOrEmpty(fileName) || patientId <= 0)
            {
                return false;
            }
            
            var tempPath = Path.GetTempPath();
            var slash = Path.DirectorySeparatorChar;

            if (string.IsNullOrEmpty(tempPath))
            {
                return false;
            }

            Examine e = null;

            tempPath += slash + "Balder";
            Directory.CreateDirectory(tempPath);

            tempPath += slash + Guid.NewGuid().ToString();
            Directory.CreateDirectory(tempPath);

            ZipFile.ExtractToDirectory(fileName, tempPath);

            var examReportFile = $"{tempPath}{slash}ExamReport.xml";
            if (File.Exists(examReportFile))
            {
                XDocument xml;
                try
                {
                    xml = XDocument.Load(examReportFile);
                }
                catch (XmlException)
                {
                   // _log.ErrorFormat("Can't parse ExamReport.xml in \"{0}\": {1}", fileName, exception.Message);
                    MessageBox.Show("FIBX-файл повреждён или имеет неизвестный формат");

                    return false;
                }

                try
                {
                    e = new Examine
                    {
                        PatientId = patientId,
                        PhysicianId = physicianId
                    };

                    var exam = xml.Descendants("Exam").FirstOrDefault();
                    
                    e.CreatedAt = DateTime.Parse(exam.Descendants("Date").FirstOrDefault()?.Value);

                    var result = exam.Descendants("Result").FirstOrDefault();

                    SensorType sensorType;
                    switch (exam.Descendants("ExamType").FirstOrDefault()?.Value)
                    {
                        case "S":
                        case "Small":
                            sensorType = SensorType.Small;
                            break;
                        case "M":
                        case "Medium":
                            sensorType = SensorType.Medium;
                            break;
                        case "XL":
                            sensorType = SensorType.Xl;
                            break;
                        default:
                            sensorType = SensorType.Small;
                            break;
                    }

                    e.SensorType = sensorType;
                    e.Iqr = double.Parse(result.Descendants("StiffnessIQR").FirstOrDefault()?.Value, CultureInfo.InvariantCulture);
                    e.Med = double.Parse(result.Descendants("StiffnessMedian").FirstOrDefault()?.Value, CultureInfo.InvariantCulture);
                    e.Duration = int.Parse(result.Descendants("ExamDuration").FirstOrDefault()?.Value);
                    e.WhiskerPlot = ImageFileToByteArray(tempPath + slash + result.Descendants("WhiskerPlotImageLink").FirstOrDefault()?.Value);
                    e.ExpertStatus = ExpertStatus.Pending;

                    e.Measures = new List<Measure>();

                    var measuresCorrect = true;
                    foreach (var measure in exam.Descendants("Measurements").FirstOrDefault().Descendants("Measure"))
                    {
                        var m = new Measure();

                        m.CreatedAt = DateTime.Parse(exam.Descendants("Time").FirstOrDefault().Value);
                        m.Stiffness = double.Parse(measure.Descendants("Stiffness").FirstOrDefault().Value, CultureInfo.InvariantCulture);

                        var sourceFile = tempPath + slash + measure.Descendants("ImageLink").FirstOrDefault().Value;

                        Image source = Image.FromFile(sourceFile);

                        FibroscanImage prod = new FibroscanImage(source);
                        m.ResultMerged = ImageToByteArray(prod.Merged);
                        m.Source = ImageFileToByteArray(sourceFile);
                        m.ValidationElasto = prod.ElastoStatus;
                        m.ValidationModeA = prod.UltrasoundModeAStatus;
                        m.ValidationModeM = prod.UltrasoundModeMStatus;

                        if (measuresCorrect)
                        {
                            measuresCorrect = m.IsCorrect;
                        }

                        e.Measures.Add(m);
                    }

                    e.Valid = e.Validate() && measuresCorrect;

                    return FibrosisRepository.Instance.AddExamine(e) != 0;
                }
                catch (Exception exception)
                {
                    MessageBox.Show($"Не удалось распознать FIBX-файл:\n\n{exception.Message}");
                }
            }
            else
            {
                MessageBox.Show($"ExamReport.xml не найден в файле\n\n{fileName}\n\nОперация прервана.");
            }

            Directory.Delete(tempPath, true);

            return false;
        }

        private static byte[] ImageFileToByteArray(string fileName)
        {
            using (var image = Image.FromFile(fileName))
            {
                using (var m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    var imageBytes = m.ToArray();

                    m.Close();

                    return imageBytes;
                }
            }
        }

        private static byte[] ImageToByteArray(Image image)
        {
            using (image)
            {
                using (var m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    var imageBytes = m.ToArray();

                    m.Close();

                    return imageBytes;
                }
            }
        }
    }
}
