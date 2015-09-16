﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using Accord.Imaging.Filters;
using AForge.Imaging.Filters;

namespace Eklekto.Imaging.Binarization
{
    public static class BinarizationHelper
    {
        #region Aforge Global Binarizations
        /// <summary>
        /// Binarize image with threshold filter
        /// </summary>
        /// <param name="image"></param>
        /// <param name="threshold">threshold for binarization</param>
        public static Bitmap Threshold(this Bitmap image, byte threshold)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Filter can be applied to binary 8bpp images only");

            Threshold thresholdFilter = new Threshold(threshold);
            return thresholdFilter.Apply(image);
        }

        /// <summary>
        /// Binarize image with SIS threshold filter
        /// </summary>
        /// <param name="image"></param>
        public static Image SisThreshold(this Bitmap image)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Filter can be applied to binary 8bpp images only");

            SISThreshold thresholdFilter = new SISThreshold();
            return thresholdFilter.Apply(image);
        }

        /// <summary>
        /// Binarize image with Otsu threshold filter
        /// </summary>
        /// <param name="image"></param>
        public static Image OtsuThreshold(this Bitmap image)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Filter can be applied to binary 8bpp images only");

            OtsuThreshold thresholdFilter = new OtsuThreshold();
            return thresholdFilter.Apply(image);
        }

        /// <summary>
        /// Binarize image with iterative threshold filter
        /// </summary>
        /// <param name="image"></param>
        /// <param name="threshold">threshold for binarization</param>
        public static Image IterativeThreshold(this Bitmap image, byte threshold)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Filter can be applied to binary 8bpp images only");

            IterativeThreshold thresholdFilter = new IterativeThreshold(2, threshold);
            return thresholdFilter.Apply(image);
        }
        #endregion

        #region Aforge Local Binarizations
        /// <summary>
        /// Binarize image with Niblack filter
        /// </summary>
        /// <param name="image"></param>
        /// <param name="k"></param>
        /// <param name="radius">radius of local area of pixel </param>
        /// <returns></returns>
        public static Bitmap NiblackBinarization(this Bitmap image, double k, int radius)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Filter can be applied to binary 8bpp images only");
            var threshold = new NiblackThreshold() { K = k, Radius = radius };
            return threshold.Apply(image);
        }

        /// <summary>
        /// Binarize image with Sauvola filter
        /// </summary>
        /// <param name="image"></param>
        /// <param name="k"></param>
        /// <param name="radius">radius of local area of pixel </param>
        /// <returns></returns>
        public static Bitmap SauvolaBinarization(this Bitmap image, double k, int radius)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Filter can be applied to binary 8bpp images only");
            var threshold = new SauvolaThreshold() { K = k, Radius = radius };
            return threshold.Apply(image);
        }

        /// <summary>
        /// Binarize image with WolfJoulion filter
        /// </summary>
        /// <param name="image"></param>
        /// <param name="k"></param>
        /// <param name="radius">radius of local area of pixel </param>
        /// <returns></returns>
        public static Bitmap WolfJoulionBinarization(this Bitmap image, double k, int radius)
        {
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new NotSupportedException("Filter can be applied to binary 8bpp images only");
            var threshold = new WolfJolionThreshold { K = k, Radius = radius };
            return threshold.Apply(image);
        }
        #endregion
    }
}
