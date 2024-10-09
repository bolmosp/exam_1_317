namespace DeteccionBordes
{
    partial class Form1
    {
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.Button btnDetectarBordes;
        private System.Windows.Forms.Button btnSobel;

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.btnDetectarBordes = new System.Windows.Forms.Button();
            this.btnSobel = new System.Windows.Forms.Button();
            
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Size = new System.Drawing.Size(320, 240);
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            
            this.pictureBox2.Location = new System.Drawing.Point(350, 12);
            this.pictureBox2.Size = new System.Drawing.Size(320, 240);
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.btnCargarImagen.Location = new System.Drawing.Point(12, 270);
            this.btnCargarImagen.Size = new System.Drawing.Size(120, 30);
            this.btnCargarImagen.Text = "Cargar Imagen";
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);

            this.btnDetectarBordes.Location = new System.Drawing.Point(150, 270);
            this.btnDetectarBordes.Size = new System.Drawing.Size(120, 30);
            this.btnDetectarBordes.Text = "Detectar Bordes (Canny)";
            this.btnDetectarBordes.Click += new System.EventHandler(this.btnDetectarBordes_Click);

            this.btnSobel.Location = new System.Drawing.Point(290, 270);
            this.btnSobel.Size = new System.Drawing.Size(120, 30);
            this.btnSobel.Text = "Detectar Bordes (Sobel)";
            this.btnSobel.Click += new System.EventHandler(this.btnSobel_Click);

            this.ClientSize = new System.Drawing.Size(684, 311);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.btnDetectarBordes);
            this.Controls.Add(this.btnSobel);
            this.Text = "Detección de Bordes";
        }
    }
}
