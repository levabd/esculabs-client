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
        #region Private variables

        private readonly Image _source;

        private Bitmap _ultrasoundModeM;
        private Bitmap _ultrasoundModeA;
        private Bitmap _resultElasto;

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

        public Image MergedResult
        {
            get
            {
                if ((_ultrasoundModeA == null) ||
                    (_ultrasoundModeM == null) ||
                    (_resultElasto == null))
                {
                    Proceed();
                }
                
                Bitmap merged = new Bitmap(_source);

                using (Graphics g = Graphics.FromImage(merged))
                {
                    g.DrawImage(_resultElasto, new Rectangle(241, 33, _resultElasto.Width, _resultElasto.Height),
                        new Rectangle(0, 0, _resultElasto.Width, _resultElasto.Height), GraphicsUnit.Pixel);

                    g.DrawImage(_ultrasoundModeM, new Rectangle(50, 33, _ultrasoundModeM.Width, _ultrasoundModeM.Height),
                        new Rectangle(0, 0, _ultrasoundModeM.Width, _ultrasoundModeM.Height), GraphicsUnit.Pixel);

                    g.DrawImage(_ultrasoundModeA, new Rectangle(160, 33, _ultrasoundModeA.Width, _ultrasoundModeA.Height),
                        new Rectangle(0, 0, _ultrasoundModeA.Width, _ultrasoundModeA.Height), GraphicsUnit.Pixel);
                }
                // merge source ultrasoundModeA ultrasoundModeM and elasto here
                //TODO: Implement merging
                return merged;
            }
        }

        public Image ResultUltrasoundModeM
        {
            get
            {
                if (_ultrasoundModeM == null)
                    Proceed();
                return _ultrasoundModeM;
            }
        }

        public Image ResultUltrasoundModeA
        {
            get
            {
                if (_ultrasoundModeA == null)
                    Proceed();
                return _ultrasoundModeA;
            }
        }

        public Image ResultElasto
        {
            get
            {
                if (_resultElasto == null)
                    Proceed();
                return _resultElasto;
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

        private ElastoBlob _debugElastoBlob;
        private Elastogram _debugElasto;
        private Segment _fibroline;

        public Image Step1LoadElastogram(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            _debugElasto = LoadGrayElstogram();

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }

        public Image Step2ElastoWithoutLine(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            _debugElasto.GetFibroLine();
            _fibroline = _debugElasto.Fibroline;
            _debugElasto.PaintOverFibroline();
            
            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }

        public Image Step3KuwaharaElasto(ref long timer, int kernel)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _debugElasto.Image.Bitmap.GrayscaleKuwahara(kernel);
            _debugElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
        }

        public Image Step4SimpleBinarization(ref long timer, byte thresholdBin=105 )
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _debugElasto.Image.ApplyBinarization(thresholdBin);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }
        
        public Image Step4NiblackBinarization(ref long timer, double k=0.2, int radius = 20)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _debugElasto.Image.Bitmap.NiblackBinarization(k, radius);
            _debugElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
        }

        public Image Step4SauvolaBinarization(ref long timer, double k = 0.01, int radius = 20)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _debugElasto.Image.Bitmap.SauvolaBinarization(k, radius);
            _debugElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
        }

        public Image Step4WolfJoulionBinarization(ref long timer, double k = 0.2, int radius = 20)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");


            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _debugElasto.Image.Bitmap.WolfJoulionBinarization(k, radius);
            _debugElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }

        public Image Step4LgbtBinarization(ref long timer, double k = 0.2, int localRadius = 20, int globalRadius = 2, byte globalThreshold = 65)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _debugElasto.Image.ApplyLgbtBinarization(k, localRadius, globalRadius, globalThreshold);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }

       
        public Image Step5EdgeRemoving(ref long timer, int leftDist1, int leftCentralDist1, int leftDist2, int leftCentralDist2, int rightDist, int rightCentralDist)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _debugElasto.RemoveEdgeObjects(leftDist1, leftCentralDist1, leftDist2, leftCentralDist2, rightDist, rightCentralDist);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }
        public Image Step6Morphology(ref long timer, int morphologyTimes = 4)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _debugElasto.Image.Bitmap.MorphologyOpening(morphologyTimes);
            _debugElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }
        public Image Step7CropObjects(ref long timer, int step=24, int distance=16)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _debugElasto.CropObjects(step, distance);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }

        public Image Step8ChooseOneObject(ref long timer, double areaProportion, double heightProportion)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _debugElasto.ChooseContour(0.6, 0.65);
            _debugElastoBlob = _debugElasto.TargetObject;
            if (_debugElastoBlob == null)
                _elastoStatus = VerificationStatus.NotCalculated;

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }

        public Image Step9Approximation(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _debugElastoBlob.Approximate(0.3, 0.35, 5000);

            IntPoint p1 = new IntPoint(_debugElastoBlob.LeftApproximation.GetX(0), 0);
            IntPoint p2 = new IntPoint(_debugElastoBlob.LeftApproximation.GetX(_debugElasto.Image.Cols - 1), _debugElasto.Image.Cols - 1);
            _debugElasto.Image.DrawGrayLine(p1, p2, 128);

            p1 = new IntPoint(_debugElastoBlob.RightApproximation.GetX(0), 0);
            p2 = new IntPoint(_debugElastoBlob.RightApproximation.GetX(_debugElasto.Image.Cols - 1), _debugElasto.Image.Cols - 1);
            _debugElasto.Image.DrawGrayLine(p1, p2, 128);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugElasto.Image.Bitmap;
        }

        public VerificationStatus Step10Classify()
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            ElastogramClassification rElasto = new ElastogramClassification();

            _elastoStatus = rElasto.Classiffy(_debugElastoBlob, _fibroline);

            return _elastoStatus;
        }

        public long DebugProceed()
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Elastogram workingElasto = LoadGrayElstogram();
            workingElasto.GetFibroLine();
            workingElasto.PaintOverFibroline();

            watch.Stop();
            return watch.ElapsedMilliseconds;
        }

        #endregion

        #region DebugUltrasoundM
        private UltrasoundModM _debugUsm;
        private UltrasoundModA _debugUsa;

        public Image Step11LoadUltrasoundM(ref long timer)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            _debugUsm = LoadGrayUltrasoundModM();

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugUsm.Image.Bitmap;
        }

        public Image Step12DrawBadLines(ref long timer, ref VerificationStatus result)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();
            List<int> badLines = _debugUsm.FindDeviationStreakLines(30,3);
            SimpleGrayImage rez = new SimpleGrayImage(_debugUsm.Image.Data);
            badLines.ForEach(line => rez.DrawHorisontalGrayLine(0, _debugUsm.Image.Cols - 1, line, 0));

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

            _debugUsa = LoadGrayUltrasoundModA();
            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _debugUsa.Image.Bitmap;
        }

        public Image Step14DrawUltraSoundApproximation(ref long timer, ref VerificationStatus result)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");
            Stopwatch watch = Stopwatch.StartNew();

            ReflectionedLine drawingLine = _debugUsa.ApproxLine;
            SimpleGrayImage approxImage = new SimpleGrayImage(_debugUsa.Image.Data);

            IntPoint startPoint = new IntPoint(drawingLine.GetX(0), 0);
            IntPoint endPoint = new IntPoint(drawingLine.GetX(_debugUsa.Image.Rows), _debugUsa.Image.Rows);
            approxImage.DrawGrayLine(startPoint, endPoint, 128);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            _ultrasoundModeAStatus = _debugUsa.RelativeEstimation > 90 ? VerificationStatus.Correct : VerificationStatus.Incorrect;
            result = _ultrasoundModeAStatus;

            return approxImage.Bitmap;
        }
        #endregion

        #region Entry Point

        private void Proceed()
        {
            Elastogram workingElasto = LoadGrayElstogram();
            _resultElasto = LoadRGBElstogram();
            _ultrasoundModeM = LoadRGBUltrasoundModM();
            _ultrasoundModeA = LoadRGBUltrasoundModA();
            ElastoBlob workingBlob;
            _elastoStatus = VerifyElasto(ref workingElasto, out workingBlob);

            DrawElasto(workingBlob, workingElasto);

            UltrasoundModM workingUltrasoundModM = LoadGrayUltrasoundModM();
            List<int> badLines = new List<int>();
            _ultrasoundModeMStatus = VerifyUltrasoundModM(workingUltrasoundModM, ref badLines);

            using (Graphics g = Graphics.FromImage(_ultrasoundModeM))
            {
                badLines.ForEach(point => g.DrawLine(new Pen(Color.Blue), new Point(0, point), new Point(_ultrasoundModeM.Width, point)));
            }

            UltrasoundModA workingUltrasoundModA = LoadGrayUltrasoundModA();
            _ultrasoundModeAStatus = workingUltrasoundModA.RelativeEstimation > 90 ? VerificationStatus.Correct : VerificationStatus.Incorrect;

            using (Graphics g = Graphics.FromImage(_ultrasoundModeA))
            {
                g.DrawLine(new Pen(Color.Blue), new Point(workingUltrasoundModA.ApproxLine.GetX(0), 0), 
                    new Point(workingUltrasoundModA.ApproxLine.GetX(_ultrasoundModeA.Height), _ultrasoundModeA.Height));
            }

            //throw new ArithmeticException("stifness not calculated"); //TODO example of exception
            //return;
        }

        private void DrawElasto(ElastoBlob workingBlob, Elastogram workingElasto)
        {
            Point p1 = new Point(workingBlob.LeftApproximation.GetX(0), 0);
            Point p2 = new Point(workingBlob.LeftApproximation.GetX(workingElasto.Image.Cols - 1), workingElasto.Image.Cols - 1);
            Point p3 = new Point(workingBlob.RightApproximation.GetX(0), 0);
            Point p4 = new Point(workingBlob.RightApproximation.GetX(workingElasto.Image.Cols - 1), workingElasto.Image.Cols - 1);

            Point[] pContour = new Point[workingBlob.Contour.Points.Count];
            for (int i = 0; i < workingBlob.Contour.Points.Count; i++)
                pContour[i] = new Point(workingBlob.Contour.Points[i].X, workingBlob.Contour.Points[i].Y);

            using (Graphics g = Graphics.FromImage(_resultElasto))
            {
                g.DrawPolygon(new Pen(Color.GreenYellow), pContour);
                g.DrawLine(new Pen(Color.White), _fibroline.Top, _fibroline.Bottom);
                g.DrawLine(new Pen(Color.Red), p1, p2);
                g.DrawLine(new Pen(Color.Blue), p3, p4);
            }
        }

        private VerificationStatus VerifyUltrasoundModM(UltrasoundModM workingUltrasoundModM, ref List<int> badLines)
        {
            if (badLines == null) throw new ArgumentNullException(nameof(badLines));
            badLines = workingUltrasoundModM.FindDeviationStreakLines(30, 3);
            return badLines.Count < 15 ? VerificationStatus.Correct : VerificationStatus.Incorrect;
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
            workingElasto.ChooseContour(0.6, 0.65);
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
            Bitmap target = new Bitmap(254, 254 - 60);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                 new Rectangle(241, 33, target.Width, target.Height), GraphicsUnit.Pixel);
            }

            return new Elastogram(new SimpleGrayImage(Grayscale.CommonAlgorithms.RMY.Apply(target)));
        }

        private Bitmap LoadRGBElstogram()
        {
            Bitmap target = new Bitmap(254, 254 - 60);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                 new Rectangle(241, 33, target.Width, target.Height), GraphicsUnit.Pixel);
            }

            return target;
        }

        private UltrasoundModM LoadGrayUltrasoundModM()
        {
            Bitmap target = new Bitmap(92, 254);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                 new Rectangle(50, 33, target.Width, target.Height), GraphicsUnit.Pixel);
            }

            return new UltrasoundModM(new SimpleGrayImage(Grayscale.CommonAlgorithms.RMY.Apply(target)));
        }

        private Bitmap LoadRGBUltrasoundModM()
        {
            Bitmap target = new Bitmap(92, 254);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                 new Rectangle(50, 33, target.Width, target.Height), GraphicsUnit.Pixel);
            }

            return target;
        }

        private UltrasoundModA LoadGrayUltrasoundModA()
        {
            Bitmap target = new Bitmap(60, 254);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                 new Rectangle(160, 33, target.Width, target.Height), GraphicsUnit.Pixel);
            }

            return new UltrasoundModA(new SimpleGrayImage(Grayscale.CommonAlgorithms.RMY.Apply(target)));
        }

        private Bitmap LoadRGBUltrasoundModA()
        {
            Bitmap target = new Bitmap(60, 254);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(_source, new Rectangle(0, 0, target.Width, target.Height),
                                 new Rectangle(160, 33, target.Width, target.Height), GraphicsUnit.Pixel);
            }

            return target;
        }

        #endregion
    }
}
