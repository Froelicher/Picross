/*
 * Author : JP. Froelicher
 * Date : 15.03.2015
 * Description : Generate image Picross 
 */ 
using System.Drawing;
using System.Drawing.Imaging;

namespace PicrossManager
{
    class GeneratorImage
    {
        private Bitmap _sourceImage;
        private Bitmap _grayImage;
        private Bitmap _picrossImage;

        public Bitmap PicrossImage
        {
            get { return _picrossImage; }
            set { _picrossImage = value; }
        }

        public Bitmap GrayImage
        {
            get { return _grayImage; }
            set { _grayImage = value; }
        }

        public Bitmap SourceImage
        {
            get { return _sourceImage; }
            set { _sourceImage = value; }
        }

        public GeneratorImage()
        {

        }

        /// <summary>
        /// Load image
        /// </summary>
        /// <param name="fileName">file name</param>
        public void LoadImage(string fileName)
        {
            SourceImage = new Bitmap(fileName);
        }

        /// <summary>
        /// Convert to gray image
        /// </summary>
        /// <param name="originalImg"></param>
        /// <returns></returns>
        public Bitmap MakeGrayScale(Bitmap originalImg)
        {
            Bitmap newImg = new Bitmap(originalImg.Width, originalImg.Height);

            Graphics g = Graphics.FromImage(newImg);

            ColorMatrix colorMatrix = new ColorMatrix(
                new float[][] 
                {
                    new float[] {.3f, .3f, .3f, 0, 0},
                    new float[] {.59f, .59f, .59f, 0, 0},
                    new float[] {.11f, .11f, .11f, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix);

            //Draw the original image ont the new image.
            //Using the grayscale color matrix.
            g.DrawImage(originalImg, new Rectangle(0, 0, originalImg.Width, originalImg.Height),
                0, 0, originalImg.Width, originalImg.Height, GraphicsUnit.Pixel, attributes);

            g.Dispose();

            this.GrayImage = newImg;
            return newImg;
        }

        /// <summary>
        /// Convert to picross image
        /// </summary>
        /// <param name="grayImg">gray image</param>
        /// <param name="seuille">seuille</param>
        /// <param name="p_width">width</param>
        /// <param name="p_height">height</param>
        /// <returns>image picross</returns>
        public Bitmap MakePicross(Bitmap grayImg, int seuille, int p_width, int p_height)
        {

            Bitmap imgTemp = new Bitmap(grayImg, new Size(p_width, p_height));
            int width = imgTemp.Width;
            int height = imgTemp.Height;
            Bitmap imgPixel = new Bitmap(imgTemp);

            Rectangle rcA = new Rectangle(0, 0, p_width, p_height);
            System.Drawing.Imaging.PixelFormat pfA = imgTemp.PixelFormat;
            System.Drawing.Imaging.BitmapData bmpdataA = imgTemp.LockBits(rcA, System.Drawing.Imaging.ImageLockMode.ReadWrite, pfA);
            int strideA = bmpdataA.Stride;
            System.IntPtr ScanA = bmpdataA.Scan0;

            //IMG PIXEL
            Rectangle rcB = new Rectangle(0, 0, p_width, p_height);
            System.Drawing.Imaging.PixelFormat pfB = imgPixel.PixelFormat;
            System.Drawing.Imaging.BitmapData bmpdataB = imgPixel.LockBits(rcB, System.Drawing.Imaging.ImageLockMode.ReadWrite, pfB);
            int strideB = bmpdataB.Stride;
            System.IntPtr ScanB = bmpdataB.Scan0;

            unsafe
            {
                byte* pA = (byte*)(void*)ScanA; // p pointe vers le début du bitmap
                byte* pB = (byte*)(void*)ScanB;
                int offsetA = strideA - width * 4;
                int offsetB = strideB - width * 4;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        //Si il est pas transparant
                        if (pA[0] >= seuille)
                        {
                            pB[0] = 255;
                            pB[1] = 255;
                            pB[2] = 255;
                        }
                        else
                        {
                            pB[0] = 0;
                            pB[1] = 0;
                            pB[2] = 0;
                        }

                        if(pA[3] > byte.MinValue)
                        {
                            pB[3] = 255;
                        }
                        else
                        {
                            pB[0] = 255;
                            pB[1] = 255;
                            pB[2] = 255;
                            pB[3] = 255;
                        }

                        pA += 4;
                        pB += 4;
                    }
                    pA += offsetA;
                    pB += offsetB;
                }
            } // Fin du unsafe

            imgTemp.UnlockBits(bmpdataA);
            imgPixel.UnlockBits(bmpdataB);

            this.PicrossImage = imgPixel;

            return imgPixel;
        }
    }
}
