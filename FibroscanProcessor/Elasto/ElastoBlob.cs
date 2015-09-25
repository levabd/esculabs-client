using Eklekto.Geometry;
using Eklekto.Imaging.Blobs;
using Eklekto.Imaging.Contours;
using Eklekto.Approximators;
using Blob = Eklekto.Imaging.Blobs.Blob;

namespace FibroscanProcessor.Elasto
{
    public class ElastoBlob : BlobEntity
    {
        private const int ContourRotationHeihgt = 30;
        private const byte ContourCromHeight = 3;

        private ReflectionedLine _leftApproximation;
        private ReflectionedLine _rightApproximation;
        private double _rSquareLeft;
        private double _rSquareRight;
        private double _relativeEstimationLeft;
        private double _relativeEstimationRight;

        public ReflectionedLine LeftApproximation => _leftApproximation;
        public ReflectionedLine RightApproximation => _rightApproximation;
        public double RSquareLeft => _rSquareLeft;
        public double RSquareRight => _rSquareRight;
        public double RelativeEstimationLeft => _relativeEstimationLeft;
        public double RelativeEstimationRight => _relativeEstimationRight;

        public Contour LeftContour { get; }

        public Contour RightContour { get; }

        public ElastoBlob(Blob blob, Contour contour) : base(blob, contour)
        {
            int leftContoursTopIndex;
            int rightContoursTopIndex;
            int leftContoursBottomIndex = LeftContoursBottomIndexes(contour, out leftContoursTopIndex);
            int rightContoursBottomIndex = RightContoursBottomIndexes(contour, out rightContoursTopIndex);
            LeftContour = new Contour(contour.Points.GetRange(leftContoursBottomIndex, leftContoursTopIndex - leftContoursBottomIndex));
            RightContour = new Contour(contour.Points.GetRange(rightContoursTopIndex, rightContoursBottomIndex - rightContoursTopIndex));
        }

        public ElastoBlob(BlobEntity blob) : base(blob.Blob, blob.Contour)
        {
            int leftContoursTopIndex;
            int rightContoursTopIndex;
            int leftContoursBottomIndex = LeftContoursBottomIndexes(blob.Contour, out leftContoursTopIndex);
            int rightContoursBottomIndex = RightContoursBottomIndexes(blob.Contour, out rightContoursTopIndex);
            LeftContour = new Contour(blob.Contour.Points.GetRange(leftContoursBottomIndex, leftContoursTopIndex - leftContoursBottomIndex));
            RightContour = new Contour(blob.Contour.Points.GetRange(rightContoursTopIndex, rightContoursBottomIndex - rightContoursTopIndex));
        }

        public void Approximate(double sampleShare, double outlierShare, int iterations)
        {
            Ransac linear = new Ransac(sampleShare, outlierShare, iterations);
            _leftApproximation = linear.Approximate(LeftContour.Points, LeftContour.Points.Count, out _rSquareLeft, out _relativeEstimationLeft);
            _rightApproximation = linear.Approximate(RightContour.Points, RightContour.Points.Count, out _rSquareRight, out _relativeEstimationRight);
        }

        private int LeftContoursBottomIndexes(Contour contour, out int leftContourTopIndex)
        {
            int rotationCountDown = ContourRotationHeihgt;
            leftContourTopIndex = 0;
            for (int i = contour.Points.Count - 1; i > 0; i--)
            {
                if (contour.Points[i].Y < Blob.Rectangle.Y + ContourCromHeight)
                    continue;

                if (leftContourTopIndex < 1)
                    leftContourTopIndex = i;

                if (contour.Points[i].Y > contour.Points[i - 1].Y)
                    rotationCountDown--;

                if (contour.Points[i].Y < contour.Points[i - 1].Y)
                    rotationCountDown = (rotationCountDown < ContourRotationHeihgt) ? rotationCountDown + 1 : ContourRotationHeihgt; //Dump conuter

                if (contour.Points[i].Y > Blob.Rectangle.Y + Blob.Rectangle.Height - ContourCromHeight)
                    return i + ContourRotationHeihgt - rotationCountDown;

                if (rotationCountDown == 0)
                    return i + ContourRotationHeihgt;
            }
            return 0;
        }

        private int RightContoursBottomIndexes(Contour contour, out int rightContourTopIndex)
        {
            int rotationCountDown = ContourRotationHeihgt;
            rightContourTopIndex = 0;
            int maxVerticalIndex = 0;
            int maxY = 0;

            for (int i = 1; i < contour.Points.Count; i++)
            {
                if (contour.Points[i].Y < Blob.Rectangle.Y + ContourCromHeight)
                    continue;

                //not found bottom exception handler
                if (contour.Points[i].Y > maxY)
                {
                    maxVerticalIndex = i;
                    maxY = contour.Points[i].Y;
                }


                if (rightContourTopIndex < 1)
                    rightContourTopIndex = i;

                if (contour.Points[i].Y < contour.Points[i - 1].Y)
                    rotationCountDown--;

                if (contour.Points[i].Y > contour.Points[i - 1].Y)
                    rotationCountDown = (rotationCountDown < ContourRotationHeihgt) ? rotationCountDown + 1 : ContourRotationHeihgt; //Dump conuter

                if (contour.Points[i].Y > Blob.Rectangle.Y + Blob.Rectangle.Height - ContourCromHeight)
                    return i - ContourRotationHeihgt + rotationCountDown;

                if (rotationCountDown == 0)
                    return i - ContourRotationHeihgt;
            }
            return maxVerticalIndex;

        }
    }
}
