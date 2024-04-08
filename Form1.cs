using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Windows;
using System.Reflection.Emit;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Bitmap image;
        private object progressBar1;
        public int Y;
        public int I;
        public int Q;
        public bool flag = false;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseMove += pictureBox1_MouseMove_1;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
            }
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = image;
            pictureBox1.Refresh();
        }

       

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            InvertFilter filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage =((Filters)e.Argument).processImage(image, backgroundWorker1);
            if(backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                flag = false;
            }
            progressBar2.Value = 0;
            flag = false;
        }

        private void оттенкиСерогоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            InvertFiltersGrey filter = new InvertFiltersGrey();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            InvertFilterBlack_White filter = new InvertFilterBlack_White();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void увеличениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            Filter_Brightness filter = new Filter_Brightness();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            BlurFilter filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            InvertSepia filter = new InvertSepia();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void теснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            Crowding filter = new Crowding();    
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гаусФильтрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            GaussianFilter filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) //если в pictureBox есть изображение
            {
                //создание диалогового окна "Сохранить как..", для сохранения изображения
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Title = "Сохранить картинку как...";
                //отображать ли предупреждение, если пользователь указывает имя уже существующего файла
                savedialog.OverwritePrompt = true;
                //отображать ли предупреждение, если пользователь указывает несуществующий путь
                savedialog.CheckPathExists = true;
                //список форматов файла, отображаемый в поле "Тип файла"
                savedialog.Filter = "Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
                //отображается ли кнопка "Справка" в диалоговом окне
                savedialog.ShowHelp = true;
                if (savedialog.ShowDialog() == DialogResult.OK) //если в диалоговом окне нажата кнопка "ОК"
                {
                    try
                    {
                        image.Save(savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch
                    {
                        MessageBox.Show("Невозможно сохранить изображение", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void фильтрСобеляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            Sobel filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
            Sharpness filter = new Sharpness();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        private void ConvertPixelToYIQ(Color pixelColor)
        {
            // Вычисляем значения модели YIQ
            int y = Clamp((int)((0.299 * pixelColor.R) + (0.587 * pixelColor.G) + (0.114 * pixelColor.B)),0,255);
            int i = Clamp((int)((0.596 * pixelColor.R) - (0.275 * pixelColor.G) - (0.321 * pixelColor.B)),0,255);
            int q = Clamp((int)((0.212 * pixelColor.R) - (0.523 * pixelColor.G) + (0.311 * pixelColor.B)),0,255);

            // Выводим значения каждого параметра на форму
            label1.Text = $"Y: {y}";
            label2.Text = $"I: {i}";
            label3.Text = $"Q: {q}";
        }

        

        private void pictureBox1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null && flag != true)
            {
                Point point = e.Location;
                if (point.X < pictureBox1.Image.Width && point.Y < pictureBox1.Image.Height)
                {
                    Bitmap bmp = (Bitmap)pictureBox1.Image;
                    Color pixelColor = bmp.GetPixel(point.X, point.Y);
                    ConvertPixelToYIQ(pixelColor);
                }
            }            
            
        }
        public int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }
}
