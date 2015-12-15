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

            tempPath += slash + "Esculabs";
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
                    var e = new Examine
                    {
                        PatientId = patientId,
                        PhysicianId = physicianId
                    };

                    var examNode = xml.Descendants("Exam").FirstOrDefault();

                    if (examNode == null)
                    {
                        throw new Exception("Ветка Exam не найдена");
                    }

                    e.CreatedAt = DateTime.Parse(examNode.Descendants("Date").FirstOrDefault()?.Value);

                    var resultNode = examNode.Descendants("Result").FirstOrDefault();

                    if (resultNode == null)
                    {
                        throw new Exception("Ветка Result не найдена");
                    }

                    SensorType sensorType;
                    switch (examNode.Descendants("ExamType").FirstOrDefault()?.Value)
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

                    var iqr = resultNode.Descendants("StiffnessIQR").FirstOrDefault()?.Value;

                    if (iqr == null)
                    {
                        throw new Exception("Отсутствует параметр StiffnessIQR");
                    }

                    e.Iqr = double.Parse(iqr, CultureInfo.InvariantCulture);

                    var med = resultNode.Descendants("StiffnessMedian").FirstOrDefault()?.Value;
                    if (med == null)
                    {
                        throw new Exception("Отсутствует параметр StiffnessMedian");
                    }
                    e.Med = double.Parse(med, CultureInfo.InvariantCulture);

                    var duration = resultNode.Descendants("ExamDuration").FirstOrDefault()?.Value;

                    if (duration != null)
                    {
                        e.Duration = int.Parse(duration);
                    }

                    e.WhiskerPlot = ImageFileToByteArray(tempPath + slash + resultNode.Descendants("WhiskerPlotImageLink").FirstOrDefault()?.Value);
                    e.ExpertStatus = ExpertStatus.Pending;

                    e.Measures = new List<Measure>();

                    var measuresCorrect = true;
                    var measurements = examNode.Descendants("Measurements").FirstOrDefault();

                    if (measurements != null)
                    {
                        foreach (var measure in measurements.Descendants("Measure"))
                        {
                            var m = new Measure();
                            m.CreatedAt = DateTime.Parse(examNode.Descendants("Time").FirstOrDefault()?.Value);

                            var stiffness = measure.Descendants("Stiffness").FirstOrDefault()?.Value;
                            if (stiffness != null)
                            {
                                m.Stiffness = double.Parse(stiffness, CultureInfo.InvariantCulture);
                            }

                            var sourceFile = tempPath + slash + measure.Descendants("ImageLink").FirstOrDefault()?.Value;
                            var source = Image.FromFile(sourceFile);

                            var prod = new FibroscanImage(source);
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
                    }

                    e.Valid = e.Validate() && measuresCorrect;

                    if (SaveFibxToLocalStorage(fileName))
                    {
                        e.FibxSource = Path.GetFileName(fileName);
                    }

                    if (FibrosisRepository.Instance.AddExamine(e) == 0)
                    {
                        throw new Exception("Обследование не было добавлено в БД");
                    }

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

        private static bool SaveFibxToLocalStorage(string filePath)
        {
            var localPath = $"{ Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Esculabs Import";
            Directory.CreateDirectory(localPath);

            var newFilePath = $"{localPath}\\{Path.GetFileName(filePath)}";

            File.Copy(filePath, newFilePath, true);

            return File.Exists(newFilePath);
        }
    }
}
