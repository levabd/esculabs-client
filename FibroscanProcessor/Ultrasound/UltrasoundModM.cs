using System;
using System.Collections.Generic;
using Eklekto.Imaging;

namespace FibroscanProcessor.Ultrasound
{
    class UltrasoundModM
    {
        public SimpleGrayImage Image;

        private readonly double[] _deviations;
        private readonly double[] _expectations;

        public UltrasoundModM(SimpleGrayImage image)
        {
            Image = image;
            _deviations = new double[image.Rows];
            _expectations = new double[image.Rows];
            SetExpectations();
            SetDeviations();
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
        /// <summary>
        /// Find deviation
        /// </summary>
        /// <param name="deviationThreshold">Max normal deviation</param>
        /// <param name="deviationStreakSize">Size of streak bad lines</param>
        /// <returns></returns>
        public List<int> FindDeviationStreakLines(double deviationThreshold, int deviationStreakSize)
        {
            List<int> deviationStreaks = new List<int>();
            int streakCounter = 0;
            for (int i = 0; i < Image.Rows; i++)
            {
                if (_deviations[i] >= deviationThreshold)
                    streakCounter++;
                else if (streakCounter >= deviationStreakSize)
                {
                    for (int j = i - streakCounter; j < i; j++)
                        deviationStreaks.Add(j);
                    streakCounter = 0;
                }
                else
                    streakCounter = 0;
            }
            return deviationStreaks;
        } 
    }
}
