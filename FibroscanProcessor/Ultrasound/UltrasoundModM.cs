using System;
using System.Collections.Generic;
using Eklekto.Imaging;

namespace FibroscanProcessor.Ultrasound
{
    public class UltrasoundModM
    {
        public SimpleGrayImage Image;

        private readonly double[] _deviations;
        private readonly double[] _expectations;
        private readonly double _deviationThreshold;
        private readonly int _deviationStreakSize;
        private readonly List<int> _deviationStreakLines;

        public UltrasoundModM(double deviationThreshold, int deviationStreakSize, SimpleGrayImage image)
        {
            Image = image;
            _deviationStreakLines = new List<int>();
            _deviations = new double[image.Rows];
            _expectations = new double[image.Rows];
            _deviationStreakSize = deviationStreakSize;
            _deviationThreshold = deviationThreshold;
            SetExpectations();
            SetDeviations();
        }

        public List<int> DeviationStreakLines
        {
            get
            {
                if (_deviationStreakLines.Count == 0)
                    CalculateDeviationStreakLines();

                return _deviationStreakLines;
            }
        }

        private void SetExpectations()
        {
            for (int j = 0; j < Image.Rows; j++)
            {
                int sum = 0;
                for (int i = 0; i < Image.Cols; i++)
                    sum += Image.Data[j, i];
                _expectations[j] = (double)sum / Image.Cols;
            }
        }

        private void SetDeviations()
        {
            for (int j = 0; j < Image.Rows; j++)
            {
                double dev = 0;
                double expect = _expectations[j];
                for (int i = 0; i < Image.Cols; i++)
                    dev += Math.Pow(Image.Data[j, i] - expect, 2);
                _deviations[j] = Math.Sqrt(dev / Image.Cols);
            }
        }

        public void CalculateDeviationStreakLines()
        {
            int streakCounter = 0;
            for (int i = 0; i < Image.Rows; i++)
            {
                if (_deviations[i] >= _deviationThreshold)
                    streakCounter++;
                else if (streakCounter >= _deviationStreakSize)
                {
                    for (int j = i - streakCounter; j < i; j++)
                        _deviationStreakLines.Add(j);
                    streakCounter = 0;
                }
                else
                    streakCounter = 0;
            }
        } 
    }
}
