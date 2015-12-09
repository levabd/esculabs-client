using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using EsculabsCommon;
using Fibrosis.Controls;

namespace Fibrosis.Views
{
    using Models;
    using System.IO;
    using FibroscanProcessor;
    using EsculabsCommon;

    /// <summary>
    /// Interaction logic for ExamineView.xaml
    /// </summary>
    public partial class ExamineView : BaseView, INotifyPropertyChanged
    {
        private ModuleProvider _moduleProvider;
        private Examine _examine;
        private IPatient _patient;

        public IPatient Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                OnPropertyChanged();
            }
        }

        public Examine Examine
        {
            get
            {
                return _examine;
            }
            set
            {
                _examine = value;
                OnPropertyChanged();
            }
        }

        public ModuleProvider ModuleProvider
        {
            get
            {
                return _moduleProvider;
            }
            set
            {
                _moduleProvider = value;
                OnPropertyChanged();
            }
        }

        public ExamineView()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            //VisualStyleElement.ToolTip.Close();
        }

        public void ReloadView()
        {
            nameLabel.Text = string.Format(_patient.FullNameString);
            dateLabel.Text = _examine.CreatedAt.ToString();
            iqrLabel.Text = _examine.Iqr.ToString();
            medLabel.Text = _examine.Med.ToString();

            UpdateSensorLabel(sensorLabel, _examine.SensorType);
            UpdateIqrMedLabel(iqrMedLabel, _examine.Iqr, _examine.Med);
            UpdateScansLabel(scansLabel, _examine.Measures);

            correctScansLabel.Text = _examine.Measures.Count(x => x.IsCorrect).ToString();

            measuresPanel.Children.Clear();

            foreach (var measure in _examine.Measures)
            {
                var preview = new MeasurePreview
                {
                    measure = measure,
                    image = {Source = ImageFromByteArray(measure.Source)}
                };

                UpdateMeasurePreviewStatus(preview, measure);

                preview.TouchDown += Preview_TouchDown;
                preview.MouseLeftButtonUp += Preview_MouseLeftButtonUp;

                measuresPanel.Children.Add(preview);
            }
        }

        // Touch event
        private void Preview_TouchDown(object sender, TouchEventArgs e)
        {
            throw new NotImplementedException();
        }

        // Mouse event
        private void Preview_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var preview = sender as MeasurePreview;

            ModuleProvider?.SetView(new ViewChangeArgs
            {
                ViewName = typeof(MeasureView).FullName,
                ViewInitDelegate = x =>
                {
                    ((MeasureView)x).SourceImage.Source = ImageFromByteArray(preview.measure.Source);
                    ((MeasureView)x).ProcessedImage.Source = ImageFromByteArray(preview.measure.ResultMerged);
                }
            });

            //ViewImageWindow window = new ViewImageWindow("Просмотр сканирования", ImageFromBase64(preview.measure.ResultMerged), 512, 384);
            //window.Owner = this;
            //window.ShowDialog();
        }

        private BitmapSource ImageFromByteArray(byte[] imageBytes)
        {
            MemoryStream m = new MemoryStream(imageBytes);

            var decoder = BitmapDecoder.Create(m, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            return decoder.Frames[0];
        }

        private void UpdateScansLabel(TextBlock label, ICollection<Measure> measures)
        {
            var scansCount = _examine.Measures.Count();
            scansLabel.Text = scansCount.ToString();

            if (scansCount < 10)
            {
                label.Text += " (некорректно)";
                label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2323"));
            }
            else
            {
                label.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void UpdateSensorLabel(TextBlock label, SensorType sensorType)
        {
            label.Text = sensorType.ToString();
            label.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void UpdateIqrMedLabel(TextBlock label, double iqr, double med)
        {
            if (med != 0 && iqr != 0)
            {
                var iqrMed = _examine.IqrMed;

                if (!iqrMed.HasValue)
                {
                    label.Text += "Нет данных";
                    label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2323"));
                }
                else
                {
                    label.Text = iqrMed.ToString() + "%";

                    if (iqrMed > 30)
                    {
                        label.Text += " (некорректно)";
                        label.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFF2323"));
                    }
                    else
                    {
                        label.Foreground = new SolidColorBrush(Colors.Black);
                    }
                }
            }
        }

        private void UpdateMeasurePreviewStatus(MeasurePreview measurePreview, Measure measure)
        {
            var statuses = new List<VerificationStatus> { measure.ValidationElasto, measure.ValidationModeM, measure.ValidationModeA };
            var status = statuses.Min();

            string statusText;
            Brush background;
            switch (status)
            {
                case (VerificationStatus.Correct):
                    statusText = "Корректно";
                    background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB3FFC9"));
                    break;
                case (VerificationStatus.Incorrect):
                    statusText = "Некорректно";
                    background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFB3B3"));
                    break;
                case (VerificationStatus.Uncertain):
                    statusText = "Неоднозначно";
                    background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFF4B3"));
                    break;
                case (VerificationStatus.NotCalculated):
                default:
                    statusText = "Не вычислено";
                    background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFB3B3"));
                    break;
            }

            measurePreview.status.Content = statusText;
            measurePreview.status.Background = background;
        }

        private void dispersionBtn_Click(object sender, RoutedEventArgs e)
        {
            ModuleProvider?.SetView(new ViewChangeArgs
            {
                ViewName = typeof(WhiskerPlotView).FullName,
                ViewInitDelegate = x =>
                {
                    ((WhiskerPlotView)x).WhiskerPlot.Source = ImageFromByteArray(Examine.WhiskerPlot);
                }
            });

            //ViewImageWindow window = new ViewImageWindow("Просмотр дисперсии", ImageFromBase64(examine.ElastoExam.WhiskerPlot), 832, 320);
            //window.Owner = this;
            //window.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
