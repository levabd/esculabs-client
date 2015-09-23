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
    public partial class FibroscanImage
    {
        #region Debug Properties

        public Elastogram WorkingElasto
        {
            get
            {
                if (!_debugMode)
                    throw new AccessViolationException("Can`t use this method in production mode");

                return _workingElasto;
            }
        }

        public ElastoBlob WorkingBlob
        {
            get
            {
                if (!_debugMode)
                    throw new AccessViolationException("Can`t use this method in production mode");

                return _workingBlob;
            }
        }

        public UltrasoundModM WorkingUltrasoundModM
        {
            get
            {
                if (!_debugMode)
                    throw new AccessViolationException("Can`t use this method in production mode");

                return _workingUltrasoundModM;
            }
        }

        public UltrasoundModA WorkingUltrasoundModA
        {
            get
            {
                if (!_debugMode)
                    throw new AccessViolationException("Can`t use this method in production mode");

                return _workingUltrasoundModA;
            }
        }

        public Segment Fibroline
        {
            get
            {
                if (!_debugMode)
                    throw new AccessViolationException("Can`t use this method in production mode");

                return _fibroline;
            }
        }

        #endregion

        #region DebugElastogram

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

        public Image Step4SimpleMorphologyBinarization(ref long timer, int morphologyKernel = 8, byte morphologyThreshold = 65)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _workingElasto.Image.Bitmap.MorphologySimpleBinarization(morphologyKernel, morphologyThreshold);
            _workingElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
        }

        public Image Step4MorphologyNiblackBinarization(ref long timer, double k = 0.2, int localRadius = 20,
            int globalRadius = 8, byte globalThreshold = 65)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            Bitmap result = _workingElasto.Image.Bitmap.MorphologyNiblackBinarization(k, localRadius, globalRadius, globalThreshold);
            _workingElasto = new Elastogram(new SimpleGrayImage(result));

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return result;
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

            return _workingElasto.Image.Bitmap.Invert();
        }

        public Image Step8ChooseOneObject(ref long timer, double areaProportion, double heightProportion)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingElasto.ChooseContour(0.55, AreaMinLimit, 0.65);
            _workingBlob = _workingElasto.TargetObject;
            if (_workingBlob == null)
                _elastoStatus = VerificationStatus.NotCalculated;

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap.Invert();
        }

        public Image Step9Approximation(ref long timer, double sampleShare = SampleShare, double outliersShare = OutliersShare, int iterations = RansacIterations)
        {
            if (!_debugMode)
                throw new AccessViolationException("Can`t use this method in production mode");

            Stopwatch watch = Stopwatch.StartNew();

            _workingBlob.Approximate(SampleShare, OutliersShare, RansacIterations);

            IntPoint p1 = new IntPoint(_workingBlob.LeftApproximation.GetX(0), 0);
            IntPoint p2 = new IntPoint(_workingBlob.LeftApproximation.GetX(_workingElasto.Image.Cols - 1), _workingElasto.Image.Cols - 1);
            _workingElasto.Image.DrawGrayLine(p1, p2, 128);

            p1 = new IntPoint(_workingBlob.RightApproximation.GetX(0), 0);
            p2 = new IntPoint(_workingBlob.RightApproximation.GetX(_workingElasto.Image.Cols - 1), _workingElasto.Image.Cols - 1);
            _workingElasto.Image.DrawGrayLine(p1, p2, 128);

            watch.Stop();
            timer = watch.ElapsedMilliseconds;

            return _workingElasto.Image.Bitmap.Invert();
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
    }
}
