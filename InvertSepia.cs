using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class InvertSepia : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            float k = 5.0f;
            double resultR = 0;
            double resultG = 0;
            double resultB = 0;
            Color sourseColor = sourceImage.GetPixel(i, j);
            double intensity = 0.299 * sourseColor.R + 0.587 * sourseColor.G + 0.114 * sourseColor.B;
            resultR = (intensity + (2 * k));
            resultB = (intensity + (0.5 * k));  
            resultG = (intensity - (1 * k));
            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
                );
        }
    }
}
