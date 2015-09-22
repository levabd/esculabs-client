using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using AForge;
using AForge.Imaging.Filters;
using Eklekto.Geometry;
using Eklekto.Imaging;
using Eklekto.Imaging.Binarization;
using Eklekto.Imaging.Filters;
using Eklekto.Imaging.Morfology;
using FibroscanProcessor.Elasto;
using FibroscanProcessor.Ultrasound;
using Point = System.Drawing.Point;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace FibroscanProcessor
{
    public enum VerificationStatus
    {
        NotCalculated,
        Incorrect,
        Uncertain,
        Correct
    }

    public class FibroscanImage
    {
        #region Const

        // ReSharper disable InconsistentNaming
        // Const
        private Rectangle ElastogramRect = new Rectangle(242, 33, 253, 194);
        private Rectangle UltrasoundModMRect = new Rectangle(50, 33, 92, 254);
        private Rectangle UltrasoundModARect = new Rectangle(160, 33, 60, 254);

        private const int MinUltrasoundModARelativeEstimation = 90;
        // ReSharper restore InconsistentNaming

        #endregion

        #region Private variables

        private Elastogram _workingElasto;
        private ElastoBlob _workingBlob;
        private UltrasoundModM _workingUltrasoundModM;
        private UltrasoundModA _workingUltrasoundModA;

        private readonly Image _source;

        // Lock object to prevent threads use a source image at the same time
        private object sourceLock = new object();

        private VerificationStatus _elastoStatus = VerificationStatus.NotCalculated;
        private VerificationStatus _ultrasoundModeMStatus = VerificationStatus.NotCalculated;
        private VerificationStatus _ultrasoundModeAStatus = VerificationStatus.NotCalculated;
        private double _stiffness = 0; //

        private readonly bool _debugMode;

        #endregion

        #region Constructor

        public FibroscanImage(Image source, bool debugMode = false)
        {
            _debugMode = debugMode;
            _source = source;
        }

        #endregion

        #region Properties

        public Image Merged
        {
            get
            {
                if ((_workingElasto == null) ||
                    (_workingBlob == null) ||
                    (_workingUltrasoundModM == null) ||
                    (_workingUltrasoundModA == null))
                {
                    Proceed();
                }

                // Already checked by null
                // ReSharper disable PossibleNullReferenceException
                Point p1 = new Point(_workingBlob.LeftApproximation.GetX(0) + ElastogramRect.X, 0 + ElastogramRect.Y);
                Point p2 = new Point(_workingBlob.LeftApproximation.GetX(_workingElasto.Image.Cols - 1) + ElastogramRect.X, _workingElasto.Image.Cols - 1 + ElastogramRect.Y);
                Point p3 = new Point(_workingBlob.RightApproximation.GetX(0) + ElastogramRect.X, 0 + ElastogramRect.Y);
                Point p4 = new Point(_workingBlob.RightApproximation.GetX(_workingElasto.Image.Cols - 1) + ElastogramRect.X, _workingElasto.Image.Cols - 1 + ElastogramRect.Y);

                Point[] pContour = new Point[_workingBlob.Contour.Points.Count];
                for (int i = 0; i < _workingBlob.Contour.Points.Count; i++)
                    pContour[i] = new Point(_workingBlob.Contour.Points[i].X + ElastogramRect.X, _workingBlob.Contour.Points[i].Y + ElastogramRect.Y);

                using (Graphics g = Graphics.FromImage(_source))
                {
                    g.DrawPolygon(new Pen(Color.GreenYellow), pContour);
                    g.DrawLine(new Pen(Color.Red), p1, p2);
                    g.DrawLine(new Pen(Color.Blue), p3, p4);
                    _workingUltrasoundModM.DeviationStreakLines.ForEach(point => g.DrawLine(new Pen(Color.Blue), 
                        new Point(0 + UltrasoundModMRect.X, point + UltrasoundModMRect.Y), 
                        new Point(UltrasoundModMRect.Width + UltrasoundModMRect.X, point + UltrasoundModMRect.Y)));
                    g.DrawLine(new Pen(Color.Blue), new Point(_workingUltrasoundModA.ApproxLine.GetX(0) + UltrasoundModARect.X, 0 + UltrasoundModARect.Y),
                        new Point(_workingUltrasoundModA.ApproxLine.GetX(UltrasoundModARect.Height) + UltrasoundModARect.X, UltrasoundModARect.Height + UltrasoundModARect.Y));
                }
                // ReSharper restore PossibleNullReferenceException
                
                return _source;
            }
        }

        public VerificationStatus UltrasoundModeMStatus
        {
            get
            {
                if (_ultrasoundModeMStatus == VerificationStatus.NotCalculated)
                    Proceed();
                return _ultrasoundModeMStatus;
            }
        }

        public VerificationStatus UltrasoundModeAStatus
        {
            get
            {
                if (_ultrasoundModeAStatus == VerificationStatus.NotCalculated)
                    Proceed();
                return _ultrasoundModeAStatus;
            }
        }

        public VerificationStatus ElastoStatus
        {
            get
            {
                if (_elastoStatus == VerificationStatus.NotCalculated)
                    Proceed();
                return _elastoStatus;
            }
        }

        public double Stiffness
        {
            get
            {
                if (_stiffness < Double.Epsilon)
                    Proceed();
                return _stiffness;
            }
        }

        #endregion

        #region DebugElastogram

        private Segment _fibroline;

        public Image Step1LoadElastogram(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto = LoadGrayElstogram();

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step2ElastoWithoutLine(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto.GetFibroLine();
            _fibroline = _workingElasto.Fibroline;
            _workingElasto.PaintOverFibroline();
            
            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step3KuwaharaElasto(ref long timer, int kernel)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _workingElasto.Image.Bitmap.GrayscaleKuwahara(kernel);
            _workingElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
        }

        public Image Step4SimpleBinarization(ref long timer, byte thresholdBin)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto.Image.ApplyBinarization(thresholdBin);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }
        
        public Image Step4NiblackBinarization(ref long timer, double k=0.2, int radius = 20)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _workingElasto.Image.Bitmap.NiblackBinarization(k, radius);
            _workingElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
        }

        public Image Step4SauvolaBinarization(ref long timer, double k = 0.01, int radius = 20)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _workingElasto.Image.Bitmap.SauvolaBinarization(k, radius);
            _workingElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
        }

        public Image Step4WolfJoulionBinarization(ref long timer, double k = 0.2, int radius = 20)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");


            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _workingElasto.Image.Bitmap.WolfJoulionBinarization(k, radius);
            _workingElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step4LgbtBinarization(ref long timer, double k, int localRadius, int globalRadius, byte globalThreshold)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto.Image.ApplyLgbtBinarization(k, localRadius, globalRadius, globalThreshold);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step5EdgeRemoving(ref long timer, int leftDist1, int leftCentralDist1, int leftDist2, int leftCentralDist2, int rightDist, int rightCentralDist)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto.RemoveEdgeObjects(leftDist1, leftCentralDist1, leftDist2, leftCentralDist2, rightDist, rightCentralDist);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step6Morphology(ref long timer, int morphologyTimes)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _workingElasto.Image.Bitmap.MorphologyOpening(morphologyTimes);
            _workingElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step7CropObjects(ref long timer, int step, int distance)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto.CropObjects(step, distance);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step8ChooseOneObject(ref long timer, double areaProportion, double heightProportion)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto.ChooseContour(0.6, 0.65);
            _workingBlob = _workingElasto.TargetObject;
            if (_workingBlob == null)
                _elastoStatus = VerificationStatus.NotCalculated;

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public Image Step9Approximation(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingBlob.Approximate(0.3, 0.35, 5000);

            IntPoint p1 = new IntPoint(_workingBlob.LeftApproximation.GetX(0), 0);
            IntPoint p2 = new IntPoint(_workingBlob.LeftApproximation.GetX(_workingElasto.Image.Cols - 1), _workingElasto.Image.Cols - 1);
            _workingElasto.Image.DrawGrayLine(p1, p2, 128);

            p1 = new IntPoint(_workingBlob.RightApproximation.GetX(0), 0);
            p2 = new IntPoint(_workingBlob.RightApproximation.GetX(_workingElasto.Image.Cols - 1), _workingElasto.Image.Cols - 1);
            _workingElasto.Image.DrawGrayLine(p1, p2, 128);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap;
        }

        public VerificationStatus Step10Classify()
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            ElastogramClassification rElasto = new ElastogramClassification();

            _elastoStatus = rElasto.Classiffy(_workingBlob, _fibroline);

            return _elastoStatus;
        }

        #endregion

        #region DebugUltrasoundM

        public Image Step11LoadUltrasoundM(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            _workingUltrasoundModM = LoadGrayUltrasoundModM();

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingUltrasoundModM.Image.Bitmap;
        }

        public Image Step12DrawBadLines(ref long timer, ref VerificationStatus result)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();
            List<int> badLines = _workingUltrasoundModM.DeviationStreakLines;
            SimpleGrayImage rez = new SimpleGrayImage(_workingUltrasoundModM.Image.Data);
            badLines.ForEach(line => rez.DrawHorisontalGrayLine(0, _workingUltrasoundModM.Image.Cols - 1, line, 0));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            _ultrasoundModeMStatus = badLines.Count < 15 ? VerificationStatus.Correct : VerificationStatus.Incorrect;
            result = _ultrasoundModeMStatus;

            return rez.Bitmap;
        }

        public Image Step13LoadUltrasoundA(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            _workingUltrasoundModA = LoadGrayUltrasoundModA();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingUltrasoundModA.Image.Bitmap;
        }

        public Image Step14DrawUltraSoundApproximation(ref long timer, ref VerificationStatus result)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            ReflectionedLine drawingLine = _workingUltrasoundModA.ApproxLine;
            SimpleGrayImage approxImage = new SimpleGrayImage(_workingUltrasoundModA.Image.Data);

            IntPoint startPoint = new IntPoint(drawingLine.GetX(0), 0);
            IntPoint endPoint = new IntPoint(drawingLine.GetX(_workingUltrasoundModA.Image.Rows), _workingUltrasoundModA.Image.Rows);
            approxImage.DrawGrayLine(startPoint, endPoint, 128);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            _ultrasoundModeAStatus = _workingUltrasoundModA.RelativeEstimation > MinUltrasoundModARelativeEstimation ? VerificationStatus.Correct : VerificationStatus.Incorrect;
            result = _ultrasoundModeAStatus;

            return approxImage.Bitmap;
        }
        #endregion

        #region Entry Point

        private void Proceed()
        {
            var elastoTask = Task.Factory.StartNew(() => 
            {
                _workingElasto = LoadGrayElstogram();
                _elastoStatus = VerifyElasto(ref _workingElasto, out _workingBlob);
            });

            var modeMTask = Task.Factory.StartNew(() => 
            {
                _workingUltrasoundModM = LoadGrayUltrasoundModM();
                _ultrasoundModeMStatus = _workingUltrasoundModM.DeviationStreakLines.Count < 15 ? VerificationStatus.Correct : VerificationStatus.Incorrect;
            });

            var modeATask = Task.Factory.StartNew(() =>
            {
                _workingUltrasoundModA = LoadGrayUltrasoundModA();
                _ultrasoundModeAStatus = _workingUltrasoundModA.RelativeEstimation > MinUltrasoundModARelativeEstimation ? VerificationStatus.Correct : VerificationStatus.Incorrect;

            }
                );

            Task.WaitAll(elastoTask, modeMTask, modeATask);           
        }

        private VerificationStatus VerifyElasto(ref Elastogram workingElasto, out ElastoBlob workingBlob)
        {
            workingElasto.GetFibroLine();
            _fibroline = workingElasto.Fibroline;
            workingElasto.PaintOverFibroline();
            workingElasto = new Elastogram(new SimpleGrayImage(workingElasto.Image.Bitmap.GrayscaleKuwahara(29)));
            workingElasto.Image.ApplyBinarization(65);
            workingElasto.RemoveEdgeObjects(25, 85, 100, 100, 50, 80);
            workingElasto = new Elastogram(new SimpleGrayImage(workingElasto.Image.Bitmap.MorphologyOpening(4)));
            workingElasto.CropObjects(24, 10);
            workingElasto.ChooseContour(0.55, 0.65);
            workingBlob = workingElasto.TargetObject;
            if (workingBlob == null)
                return VerificationStatus.NotCalculated;
            workingBlob.Approximate(0.3, 0.35, 5000);
                return (new ElastogramClassification()).Classiffy(workingBlob, _fibroline);
        }

        #endregion

        #region Private

        private Elastogram LoadGrayElstogram()
        {
            Bitmap target = new Bitmap(ElastogramRect.Width, ElastogramRect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                lock (sourceLock)
                {
                    g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                    ElastogramRect, GraphicsUnit.Pixel);
                }
            }

            return new Elastogram(new SimpleGrayImage(Grayscale.CommonAlgorithms.RMY.Apply(target)));
        }

        private UltrasoundModM LoadGrayUltrasoundModM()
        {
            Bitmap target = new Bitmap(UltrasoundModMRect.Width, UltrasoundModMRect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                lock (sourceLock)
                {
                    g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                    UltrasoundModMRect, GraphicsUnit.Pixel);
                }
            }

            return new UltrasoundModM(30, 3, new SimpleGrayImage(Grayscale.CommonAlgorithms.RMY.Apply(target)));
        }

        private UltrasoundModA LoadGrayUltrasoundModA()
        {
            Bitmap target = new Bitmap(UltrasoundModARect.Width, UltrasoundModARect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                lock (sourceLock)
                {
                    g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                    UltrasoundModARect, GraphicsUnit.Pixel);
                }
            }

            return new UltrasoundModA(new SimpleGrayImage(Grayscale.CommonAlgorithms.RMY.Apply(target)));
        }

        #endregion
    }
}
