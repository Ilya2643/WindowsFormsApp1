using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class MatrixFilter3 : Filters
    {
        protected float[,] kernel1 = null;
        protected float[,] kernel2 = null;
        
        protected MatrixFilter3() { }
        public MatrixFilter3(float[,] kernel1, float[,] kernel2)
        {

            this.kernel1 = kernel1;
            this.kernel2 = kernel2;
            
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            int radiusX = kernel1.GetLength(0) / 2;
            int radiusY = kernel1.GetLength(1) / 2;

            float resultR1 = 0;
            float resultG1 = 0;
            float resultB1 = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(i + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(j + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR1 += neighborColor.R * kernel1[k + radiusX, l + radiusY];
                    resultG1 += neighborColor.G * kernel1[k + radiusX, l + radiusY];
                    resultB1 += neighborColor.B * kernel1[k + radiusX, l + radiusY];
                }
            }
            int radiusX2 = kernel2.GetLength(0) / 2;
            int radiusY2 = kernel2.GetLength(1) / 2;

            float resultR2= 0;
            float resultG2 = 0;
            float resultB2 = 0;
            for (int l = -radiusY; l <= radiusY; l++)
            {
                for (int k = -radiusX; k <= radiusX; k++)
                {
                    int idX = Clamp(i + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(j + l, 0, sourceImage.Height - 1);
                    Color neighborColor = sourceImage.GetPixel(idX, idY);
                    resultR2 += neighborColor.R * kernel2[k + radiusX, l + radiusY];
                    resultG2 += neighborColor.G * kernel2[k + radiusX, l + radiusY];
                    resultB2 += neighborColor.B * kernel2[k + radiusX, l + radiusY];
                }
            }
            float resultR = resultR1+resultR2;
            float resultG = resultG1+resultG2;
            float resultB = resultB1+resultB2;
            return Color.FromArgb(Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255));
            

        }
    }
}
