using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Sharpness : MatrixFilter
    {
        public Sharpness()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel = new float[sizeX, sizeY];
            kernel[0, 0] = -1f;
            kernel[0, 1] = -1f;
            kernel[0, 2] = -1f;
            kernel[1, 0] = -1f;
            kernel[1, 1] = 9f;
            kernel[1, 2] = -1f;
            kernel[2, 0] = -1f;
            kernel[2, 1] = -1f;
            kernel[2, 2] = -1f;
        }
    }
}
