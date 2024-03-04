using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Filter_Brightness : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            int MaxColor = 255;
            int Brightness = 50;
            Color sourseColor = sourceImage.GetPixel(i, j);
            Color resultColor = Color.FromArgb((Brightness+sourseColor.R < MaxColor ? Brightness + sourseColor.R : sourseColor.R),
                (Brightness + sourseColor.G < MaxColor ? Brightness + sourseColor.G : sourseColor.G),
                (Brightness + sourseColor.B < MaxColor ? Brightness + sourseColor.B : sourseColor.B));
            return resultColor;
        }
    }
}
