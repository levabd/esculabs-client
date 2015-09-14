using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Drawing;

namespace Client
{
    using Model;
    using MongoRepository;
    using System.Globalization;
    using System.Windows;
    using System.Xml.Linq;

    class FIBXParser
    {
        private static volatile FIBXParser instance;
        private static object syncRoot = new Object();

        public static FIBXParser Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new FIBXParser();
                    }
                }

                return instance;
            }
        }

        public Examine Import(string fileName, int patientId)
        {
            if (string.IsNullOrEmpty(fileName) || patientId <= 0)
            {
                return null;
            }
            
            var tempPath = Path.GetTempPath();
            var slash = Path.DirectorySeparatorChar;

            if (string.IsNullOrEmpty(tempPath))
            {
                return null;
            }

            Examine examine = null;

            tempPath += slash + "Balder";
            Directory.CreateDirectory(tempPath);

            tempPath += slash + Guid.NewGuid().ToString();
            Directory.CreateDirectory(tempPath);

            ZipFile.ExtractToDirectory(fileName, tempPath);

            var examReportFile = tempPath + slash + "ExamReport.xml";
            if (File.Exists(examReportFile))
            {
                var xml = XDocument.Load(examReportFile);

                if (xml != null)
                {
                    try {
                        examine = new Examine();

                        var exam = xml.Descendants("Exam").FirstOrDefault();
                        examine.CreatedAt = DateTime.Parse(exam.Descendants("Date").FirstOrDefault().Value);
                        examine.PhysicianId = 1;
                        examine.PatientId = patientId;

                        var result = exam.Descendants("Result").FirstOrDefault();
                        var sensorType = SensorType.Small;
                        switch (exam.Descendants("ExamType").FirstOrDefault().Value)
                        {
                            case ("Small"):
                                sensorType = SensorType.Small;
                                break;
                            case ("Medium"):
                                sensorType = SensorType.Medium;
                                break;
                            case ("XL"):
                                sensorType = SensorType.XL;
                                break;
                        }

                        examine.ElastoExam = new ElastoExam();
                        examine.ElastoExam.SensorType = sensorType;
                        examine.ElastoExam.IQR = double.Parse(result.Descendants("StiffnessIQR").FirstOrDefault().Value, CultureInfo.InvariantCulture);
                        examine.ElastoExam.MED = double.Parse(result.Descendants("StiffnessMedian").FirstOrDefault().Value, CultureInfo.InvariantCulture);
                        examine.ElastoExam.Duration = int.Parse(result.Descendants("ExamDuration").FirstOrDefault().Value);
                        examine.ElastoExam.WhiskerPlot = ImageToBase64(tempPath + slash + result.Descendants("WhiskerPlotImageLink").FirstOrDefault().Value);
                        examine.ElastoExam.ExpertStatus = ExpertStatus.Pending;
                        examine.ElastoExam.Valid = true;

                        examine.ElastoExam.Measures = new List<Measure>();
                        foreach (var measure in exam.Descendants("Measurements").FirstOrDefault().Descendants("Measure"))
                        {
                            Measure m = new Measure();
                            m.Stiffness = double.Parse(measure.Descendants("Stiffness").FirstOrDefault().Value, CultureInfo.InvariantCulture);
                            m.Source = ImageToBase64(tempPath + slash + measure.Descendants("ImageLink").FirstOrDefault().Value);

                            examine.ElastoExam.Measures.Add(m);
                        }

                        MongoRepository<Examine> examines = new MongoRepository<Examine>();
                        examines.Add(examine);                        
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Не удалось распознать FIBX-файл");
                        examine = null;
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось открыть ExamReport.xml. Файл повреждён или имеет неизвестный формат.");
                }
            }
            else
            {
                MessageBox.Show("ExamReport.xml не найден в файле\n\n" + fileName + "\n\nОперация прервана.");
            }

            Directory.Delete(tempPath, true);

            return examine;
        }

        private string ImageToBase64(string fileName)
        {
            using (Image image = Image.FromFile(fileName))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
