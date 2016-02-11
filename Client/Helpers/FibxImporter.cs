using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Client.Context;
using Microsoft.Data.Entity;

namespace Client.Helpers
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Threading.Tasks;
    using Windows.Storage.Pickers;
    using Windows.Storage;
    using Windows.UI.Popups;
    using System.Xml;
    using ViewModels;
    using Models;

    public sealed class FibxImporter
    {
        private PatientViewModel _patient;

        public FibxImporter(PatientViewModel patient)
        {
            _patient = patient;
        }

        public async Task<bool> OpenFile()
        {
            var picker = new FileOpenPicker
            {
                SuggestedStartLocation = PickerLocationId.ComputerFolder
            };

            picker.FileTypeFilter.Add(".fibx");

            var file = await picker.PickSingleFileAsync();

            if (file == null)
            {
                return false;
            }

            var storage = ApplicationData.Current.LocalFolder;
            var fibxStorage = await storage.CreateFolderAsync("FIBX Storage", CreationCollisionOption.OpenIfExists);
            var fibxFolder = await fibxStorage.CreateFolderAsync(Guid.NewGuid().ToString(), CreationCollisionOption.GenerateUniqueName);

            try
            {
                await Task.Run(() => ZipFile.ExtractToDirectory(file.Path, fibxFolder.Path));

            }
            catch (Exception)
            {
                var d = new MessageDialog("Не удалось распаковать FIBX. Приложение не может получить доступ к файлу, либо на локальном диске закончилось свободное пространство.", "Ошибка импорта");
                d.Commands.Add(new UICommand("Жаль"));

                await d.ShowAsync();

                return false;
            }

            var result = await Import(fibxFolder, file.Name);

            await fibxFolder.DeleteAsync(StorageDeleteOption.PermanentDelete);

            return result;
        }

        public async Task<bool> Import(StorageFolder fibxFolder, string fileName = null)
        {
            if (fibxFolder == null)
            {
                return false;
            }

            var report = await fibxFolder.GetFileAsync("ExamReport.xml");

            if (report == null)
            {
                return false;
            }

            var stream = await report.OpenStreamForReadAsync();

            if (stream == null)
            {
                return false;
            }

            var settings = new XmlReaderSettings { Async = true, ConformanceLevel = ConformanceLevel.Document};
            var reader = XmlReader.Create(stream, settings);
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(XmlReport));

            XmlReport reportObj;

            if (!serializer.CanDeserialize(reader))
            {
                var d = new MessageDialog("Отчёт в выбранном FIBX-файле не может быть десериализован", "Ошибка импорта");
                d.Commands.Add(new UICommand("Жаль"));

                await d.ShowAsync();

                return false;
            }

            try
            {
                reportObj = (XmlReport)serializer.Deserialize(reader);
            }
            catch (Exception e)
            {
                var d = new MessageDialog($"Ошибка импорта FIBX:\n\n{e.Message}", "Ошибка импорта");
                d.Commands.Add(new UICommand("Жаль"));

                await d.ShowAsync();

                return false;
            }

            var examine = new Examine
            {
                Patient = _patient.Patient,
                PatientMetric = null,
                FibxSource = fileName,
                CreatedAt = reportObj.Exam.Date,
                Duration = reportObj.Exam.Result.ExamDuration,
                ExpertStatus = ExpertStatus.Pending,
                Iqr = reportObj.Exam.Result.StiffnessIQR,
                Med = reportObj.Exam.Result.StiffnessMedian,
                SensorType = reportObj.Exam.ExamType,
                WhiskerPlot = await ConvertImagetoByte(await fibxFolder.GetFileAsync(reportObj.Exam.Result.WhiskerPlotImageLink)),
            };
            
            //foreach (var measure in reportObj.Exam.Measurements.Measures)
            //{
            //    var imageFile = await fibxFolder.GetFileAsync(measure.ImageLink);

            //    using (IRandomAccessStream fileStream = await imageFile.OpenAsync(Windows.Storage.FileAccessMode.Read))
            //    {
            //        var sourceImage = new BitmapImage();
            //        await sourceImage.SetSourceAsync(fileStream);

            //        // TODO: Обработка sourceImage
            //        //var prod = new FibroscanImage(sourceImage);
            //        //m.ResultMerged = ImageToByteArray(prod.Merged);

            //    }
            //}


 //           _patient.SaveChanges();

            //using (var db = new EsculabsContext())
            //{
            //    db.Entry(_patient).State = EntityState.Modified;
            //    _patient.Examines.Add(examine);
            //    db.SaveChanges();
            //}

            return true;
        }

        private async Task<byte[]> ConvertImagetoByte(StorageFile image)
        {
            IRandomAccessStream fileStream = await image.OpenAsync(FileAccessMode.Read);
            var reader = new Windows.Storage.Streams.DataReader(fileStream.GetInputStreamAt(0));
            await reader.LoadAsync((uint)fileStream.Size);

            byte[] pixels = new byte[fileStream.Size];

            reader.ReadBytes(pixels);

            return pixels;
        }
    }
}
