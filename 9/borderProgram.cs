using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DeteccionBordes
{
    public partial class Form1 : Form
    {
        Image<Bgr, Byte> imagenOriginal;
        Image<Gray, Byte> imagenGris;
        Image<Gray, Byte> imagenBordes;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagenOriginal = new Image<Bgr, byte>(openFileDialog.FileName);
                imagenGris = imagenOriginal.Convert<Gray, byte>();
                pictureBox1.Image = imagenOriginal.ToBitmap();
            }
        }

        private void btnDetectarBordes_Click(object sender, EventArgs e)
        {
            if (imagenGris == null) return;

            imagenBordes = imagenGris.Canny(100, 200);

            pictureBox2.Image = imagenBordes.ToBitmap();
        }

        private void btnSobel_Click(object sender, EventArgs e)
        {
            if (imagenGris == null) return;

            var sobelX = imagenGris.Sobel(1, 0, 3);
            var sobelY = imagenGris.Sobel(0, 1, 3);
            var sobel = sobelX.AbsDiff(new Gray(0)).Add(sobelY.AbsDiff(new Gray(0)));

            pictureBox2.Image = sobel.ToBitmap();
        }
    }
}
