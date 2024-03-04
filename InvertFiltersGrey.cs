using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class InvertFiltersGrey : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            Color sourseColor = sourceImage.GetPixel(i, j);
            int arithmetic_mean = (int)(0.299 * sourseColor.R + 0.587 * sourseColor.G + 0.114 * sourseColor.B);
            Color resultColor = Color.FromArgb(arithmetic_mean,arithmetic_mean,arithmetic_mean);
            return resultColor;
        }
    }
}
