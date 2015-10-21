using System;
using System.Collections.Generic;
using Eklekto.Geometry;

namespace FibroscanProcessor.Elasto
{
    public class ElastogramSignatura
    {
        public static int Size = 8;

        public readonly double Area;
        public readonly double FibroAngle;
        public readonly double LeftAngle;
        public readonly double RightAngle;
        public readonly double RSquareLeft;
        public readonly double RSquareRight;
        public readonly double RelativeEstimationLeft;
        public readonly double RelativeEstimationRight;

        public VerificationStatus Answer;

        #region Constants
        private const double AreaNormalizator = 1/21000;
        private const double AngleNormalizator = 1/Math.PI;
        private const double EstimationNormalizator = 1;
        private const double AreaNormalizationShift = 0;
        private const double AngleNormalizationShift = 0.5;
        private const double EstimationNormalizationShift = 0;
        #endregion

        private static List<double> _normalizationVector = new List<double>
        {
            AreaNormalizator,
            AngleNormalizator,
            AngleNormalizator,
            AngleNormalizator,
            EstimationNormalizator,
            EstimationNormalizator,
            EstimationNormalizator,
            EstimationNormalizator
        };

        private static List<double> _shiftNormalizationVector = new List<double>
        {
            AreaNormalizationShift,
            AngleNormalizationShift,AngleNormalizationShift,AngleNormalizationShift,
            EstimationNormalizationShift,EstimationNormalizationShift,EstimationNormalizationShift,EstimationNormalizationShift
        };

        #region Property
        public List<double> Data => new List<double>
        {
            Area,
            FibroAngle,
            LeftAngle,
            RightAngle,
            RSquareLeft,
            RSquareRight,
            RelativeEstimationLeft,
            RelativeEstimationRight
        };

        public List<double> NormalizedSignatura
        {
            get
            {
                List<double> tempVector = new List<double>();
                for (int i = 0; i < Size; i++)
                {
                    tempVector.Add(Data[i] * _normalizationVector[i] + _shiftNormalizationVector[i]);
                }
                return tempVector;
            }
        }
        #endregion
        
        #region Constructors
        public ElastogramSignatura(List<double> inputSignature, VerificationStatus answer = VerificationStatus.NotCalculated)
        {
            if (inputSignature.Count != Size)
                throw new ArgumentException();
            Area = inputSignature[0];
            FibroAngle = inputSignature[1];
            LeftAngle = inputSignature[2];
            RightAngle = inputSignature[3];
            RSquareLeft = inputSignature[4];
            RSquareRight = inputSignature[5];
            RelativeEstimationLeft = inputSignature[6];
            RelativeEstimationRight = inputSignature[7];

            Answer = answer;
        }

        public ElastogramSignatura(double area, double fibroAngle,
            double leftAngle, double rightAngle,
            double rSquareLeft, double rSquareRight,
            double relativeEstimationLeft, double relativeEstimationRight,
            VerificationStatus answer = VerificationStatus.NotCalculated)
        {
            Area = area;
            FibroAngle = fibroAngle;
            LeftAngle = leftAngle;
            RightAngle = rightAngle;
            RSquareLeft = rSquareLeft;
            RSquareRight = rSquareRight;
            RelativeEstimationLeft = relativeEstimationLeft;
            RelativeEstimationRight = relativeEstimationRight;

            Answer = answer;
        }

        public ElastogramSignatura(ElastoBlob inputBlob, Segment inputFibroLine, VerificationStatus answer = VerificationStatus.NotCalculated)
        {
            Area = inputBlob.Blob.Area;
            FibroAngle = inputFibroLine.Equation.Angle;
            LeftAngle = inputBlob.LeftApproximation.Angle;
            RightAngle = inputBlob.RightApproximation.Angle;
            RSquareLeft = inputBlob.RSquareLeft;
            RSquareRight = inputBlob.RSquareRight;
            RelativeEstimationLeft = inputBlob.RelativeEstimationLeft;
            RelativeEstimationRight = inputBlob.RelativeEstimationRight;

            Answer = answer;
        }
        #endregion


    }
}
