using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using AForge;
using AForge.Imaging;
using Eklekto.Imaging.Contours;

namespace Eklekto.Imaging.Blobs
{
    public class BlobCounter: AForge.Imaging.BlobCounter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobCounter"/> class.
        /// </summary>
        /// 
        /// <remarks>Creates new instance of the <see cref="BlobCounter"/> class with
        /// an empty objects map. Before using methods, which provide information about blobs
        /// or extract them, the <see cref="BlobCounterBase.ProcessImage(Bitmap)"/>,
        /// <see cref="BlobCounterBase.ProcessImage(BitmapData)"/> or <see cref="BlobCounterBase.ProcessImage(UnmanagedImage)"/>
        /// method should be called to collect objects map.</remarks>
        /// 
        public BlobCounter() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobCounter"/> class.
        /// </summary>
        /// 
        /// <param name="image">Image to look for objects in.</param>
        /// 
        public BlobCounter(Bitmap image) : base(image) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobCounter"/> class.
        /// </summary>
        /// 
        /// <param name="imageData">Image data to look for objects in.</param>
        /// 
        public BlobCounter(BitmapData imageData) : base(imageData) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobCounter"/> class.
        /// </summary>
        /// 
        /// <param name="image">Unmanaged image to look for objects in.</param>
        /// 
        public BlobCounter(UnmanagedImage image) : base(image) { }

        #endregion

        /// <summary>
        /// Return contours point one by one for the blob
        /// </summary>
        public List<IntPoint> GetBlobsContourPoints<TTracerMethod>(Blob blob) where TTracerMethod : IContourTracer, new()
        {
            // check if objects map was collected
            if (objectLabels == null)
                throw new InvalidOperationException("Image should be processed before to collect objects map.");

            int xmin = blob.Rectangle.Left;
            int xmax = xmin + blob.Rectangle.Width - 1;
            int ymin = blob.Rectangle.Top;

            int label = blob.ID;

            int startPointCounter = 0;

            IntPoint startPoint = new IntPoint();

            IntPoint lastStartPoint = new IntPoint();
            //find start point on top line (last but one)

            int ap = ymin * imageWidth + xmin;
            for (int x = xmin; x <= xmax; x++, ap++)
            {
                if (objectLabels[ap] == label)
                {
                    startPoint = lastStartPoint;
                    lastStartPoint = new IntPoint(x, ymin);
                    startPointCounter++;

                }
            }
            if (startPointCounter < 2)
                startPoint = lastStartPoint;

            TTracerMethod contourTracer = new TTracerMethod
            {
                Blob = blob, 
                ObjectLabels = ObjectLabels,
                ImageSize = new Size(imageWidth, imageHeight)
            };
            return contourTracer.SelectContour(startPoint);
        }

        public Blob[] GetBlobs(Bitmap image, bool extractInOriginalSize)
        {
            AForge.Imaging.Blob[] blobsResult = GetObjects(image, extractInOriginalSize);
            Blob[] newBlobResult = new Blob[blobsResult.Length];

            for (int blobCounter = 0; blobCounter < blobsResult.Length; blobCounter++)
            {
                newBlobResult[blobCounter] = new Blob(blobsResult[blobCounter]);
                newBlobResult[blobCounter].SetupObject(blobsResult[blobCounter].Rectangle, 
                    objectLabels, blobsResult[blobCounter].ID, imageWidth);
            }

            return newBlobResult;
        }
    }
}
