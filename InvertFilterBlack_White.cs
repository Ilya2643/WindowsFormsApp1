using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class InvertFilterBlack_White : Filters
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int i, int j)
        {
            int trachold = 150;
            Color sourseColor = sourceImage.GetPixel(i, j);
            int arithmetic_mean =(int)(sourseColor.R + sourseColor.G + sourseColor.B) / 3;
            Color resultColor = Color.FromArgb((trachold<arithmetic_mean ? 255 : 0), (trachold < arithmetic_mean ? 255 : 0), (trachold < arithmetic_mean ? 255 : 0));
            return resultColor;
        }
    }
}
