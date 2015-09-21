using System.Collections.Generic;
using AForge;
using Eklekto.Approximators;
using Eklekto.Geometry;
using Eklekto.Imaging;

namespace FibroscanProcessor.Ultrasound
{
    public class UltrasoundModA
    {
        public SimpleGrayImage Image;
        private double _rSquare = -1;
        private double _relativeEstimation = -1;
        private ReflectionedLine _approxLine = null;

        public UltrasoundModA(SimpleGrayImage image)
        {
            Image = image;
        }

        private List<IntPoint> GetGraphicPoints()
        {
            List<IntPoint> graphicPoints = new List<IntPoint>();
            for (int i=1;i<Image.Cols-1;i++)
                for (int j = 0; j < Image.Rows; j++)
                {
                    if (Image.Data[j, i]<50)
                        graphicPoints.Add(new IntPoint(i,j));
                }
            return graphicPoints;
        }

        private void Approximation()
        {
            LinearLeastSquares approx = new LinearLeastSquares(GetGraphicPoints());
            _rSquare = approx.RSquares;
            _approxLine = approx.Line;
            _relativeEstimation = approx.RelativeEstimation;
        }

        public double RSquare
        {
            get
            {
                if (_rSquare < 0)
                    Approximation();
                return _rSquare;
            }
        }

        public double RelativeEstimation
        {
            get
            {
                if (_relativeEstimation<0)
                    Approximation();
                return _relativeEstimation;
            }
        }

        public ReflectionedLine ApproxLine
        {
            get
            {
                if (_approxLine == null)
                    Approximation();
                return _approxLine;
            }
        }
    }
}
