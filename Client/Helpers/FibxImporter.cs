﻿using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Client.Context;
using Client.Helpers.Converters;
using Client.Repositories;
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
        private Patient Patient { get; set; }

        public FibxImporter(Patient patient)
        {
            Patient = patient;
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

            var base64Converter = new Base64ImageConverter();

            var examine = new Examine
            {
                Patient = Patient,
                PatientMetric = null,
                FibxSource = fileName,
                CreatedAt = reportObj.Exam.Date,
                Duration = reportObj.Exam.Result.ExamDuration,
                ExpertStatus = ExpertStatus.Pending,
                Iqr = reportObj.Exam.Result.StiffnessIQR,
                Med = reportObj.Exam.Result.StiffnessMedian,
                SensorType = reportObj.Exam.ExamType,
                WhiskerPlotImage = await ImageFileToBase64(await fibxFolder.GetFileAsync(reportObj.Exam.Result.WhiskerPlotImageLink)),
            };
            
            foreach (var m in reportObj.Exam.Measurements.Measures)
            {
                var imageFile = await fibxFolder.GetFileAsync(m.ImageLink);

                if (imageFile == null)
                {
                    continue;
                }

                var source = await ImageFileToBase64(imageFile);

                /*
                    
                    TODO: Обработка изображения

                */

                var measure = new Measure
                {
                    CreatedAt = m.Time,
                    Stiffness = m.Stiffness,
                    SourceImage = source,
                    ProcessedImage = source       // TODO: Заменить на обработанное изображение
                };

                examine.Measures.Add(measure);
            }
            
            Patient.Examines.Add(examine);
            PatientsRepository.Instance.SaveChanges();

            return true;
        }

        private async Task<string> ImageFileToBase64(StorageFile imageFile)
        {
            byte[] fileBytes = null;
            using (var stream = await imageFile.OpenReadAsync())
            {
                fileBytes = new byte[stream.Size];
                using (var reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                }
            }

            return fileBytes.Length > 0 ? Convert.ToBase64String(fileBytes) : null;
        }
    }
}
