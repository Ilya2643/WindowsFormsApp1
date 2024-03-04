using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Sobel : MatrixFilter3
    {
        public Sobel()
        {
            int sizeX = 3;
            int sizeY = 3;
            kernel1 = new float[sizeX, sizeY];
            kernel1[0, 0] = -1f;
            kernel1[0, 1] = -2f;
            kernel1[0, 2] = -1f;
            kernel1[1, 0] = 0f;
            kernel1[1, 1] = 0f;
            kernel1[1, 2] = 0f;
            kernel1[2, 0] = 1f;
            kernel1[2, 1] = 2f;
            kernel1[2, 2] = 1f;
            kernel2 = new float[sizeX, sizeY];
            kernel2[0, 0] = -1f;
            kernel2[0, 1] = 0f;
            kernel2[0, 2] = 1f;
            kernel2[1, 0] = -2f;
            kernel2[1, 1] = 0f;
            kernel2[1, 2] = 2f;
            kernel2[2, 0] = -1f;
            kernel2[2, 1] = 0f;
            kernel2[2, 2] = 1f;
        }
    }
}
