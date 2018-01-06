using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace goruntuIslemeEditoru1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
        
            InitializeComponent();
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e) // Open button
        {
            openFileDialog1.Filter = "Resim Dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Visible = true;
                pictureBox2.Image = null;
                pictureBox2.Visible = false;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e) // Reopen button
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                pictureBox2.Image = null;
                pictureBox1.Visible = true;
                pictureBox2.Visible = false;
                pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e) // Save Button
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                SaveFileDialog kaydet = new SaveFileDialog();
                kaydet.Filter = "Resim Dosyaları|" + "*.bmp;*.jpg;*.gif;*.wmf;*.tif;*.png";
                kaydet.Title = "kayit";
                kaydet.FileName = "tablo";
                DialogResult sonuc = kaydet.ShowDialog();
                if (sonuc == DialogResult.OK)
                {
                    pictureBox2.Image.Save(kaydet.FileName);
                }
            }
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e) // Negative Image button
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {

                int i, j;
                Color r;
                Bitmap bmp = new Bitmap(pictureBox2.Image);

                for (i = 0; i <= bmp.Width - 1; i++)
                {
                    for (j = 0; j <= bmp.Height - 1; j++)
                    {
                        r = bmp.GetPixel(i, j);
                        r = Color.FromArgb(r.A, 255-r.R, 255-r.G, 255-r.B);
                        bmp.SetPixel(i, j, r);

                    }
                }
                pictureBox2.Image = bmp;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e) // left mirroring
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                int width = bmp.Width;
                int height = bmp.Height;

                Bitmap mir = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int soldanSaga = 0, sagdanSola = width - 1; sagdanSola > 0; soldanSaga++, sagdanSola--)
                    {
                        Color p = bmp.GetPixel(soldanSaga, y);
                        mir.SetPixel(sagdanSola, y, p);
                    }
                }
                pictureBox2.Image = mir;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e) //right mirroring
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                int width = bmp.Width;
                int height = bmp.Height;

                Bitmap mir = new Bitmap(width, height);

                for (int y = 0; y < height; y++)
                {
                    for (int soldanSaga = 0, sagdanSola = width - 1; sagdanSola > 0; soldanSaga++, sagdanSola--)
                    {
                        Color p = bmp.GetPixel(soldanSaga, y);
                        mir.SetPixel(sagdanSola, y, p);
                    }
                }
                pictureBox2.Image = mir;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;

            }

        }

        private void toolStripButton4_Click_1(object sender, EventArgs e) // gray scaling buttton
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                Color renk;
                Bitmap bmp = new Bitmap(pictureBox2.Image);

                for (int i = 0; i < bmp.Height - 1; i++)
                {
                    for (int j = 0; j < bmp.Width - 1; j++)
                    {
                        int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3;
                        renk = Color.FromArgb(deger, deger, deger);
                        bmp.SetPixel(j, i, renk);
                    }
                }
                pictureBox2.Image = bmp;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
        }

    

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                textBox2.Visible = true;
                simpleButton1.Visible = true;
                textBox1.Text = null;
                textBox2.Text = null;
            }
        }
        public static Bitmap resimHistogram;
        private void toolStripButton5_Click(object sender, EventArgs e) // Histogram  button
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                resimHistogram = new Bitmap(pictureBox2.Image);
                Histogram goster = new Histogram();
                goster.Show();
            }
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e) // red 
        {
            {
                if (pictureBox1.Image == null && pictureBox2.Image == null)
                {
                    MessageBox.Show("Henüz Resim Seçilmedi!");
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBox2.Image);
                    int width = bmp.Width;
                    int height = bmp.Height;

                    Bitmap redbmp = new Bitmap(bmp);

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color p = bmp.GetPixel(x, y);

                            int a = p.A;
                            int r = p.R;

                            redbmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));
                        }

                    }
                    pictureBox2.Image = redbmp;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                }
            }
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e) // green
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox2.Image);
                int width = bmp.Width;
                int height = bmp.Height;

                Bitmap greenbmp = new Bitmap(bmp);

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Color p = bmp.GetPixel(x, y);

                        int a = p.A;
                        int g = p.G;
       
                        greenbmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));
                    }

                }
                pictureBox2.Image = greenbmp;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e) // blue
        {
            {
                if (pictureBox1.Image == null && pictureBox2.Image == null)
                {
                    MessageBox.Show("Henüz Resim Seçilmedi!");
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBox2.Image);
                    int width = bmp.Width;
                    int height = bmp.Height;

                    Bitmap bluebmp = new Bitmap(bmp);

                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            Color p = bmp.GetPixel(x, y);

                            int a = p.A;
                            int b = p.B;

                            bluebmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));
                        }

                    }
                    pictureBox2.Image = bluebmp;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = true;
                }
            }
        }

        private Bitmap soladondur(Bitmap bmp)
        {
            Bitmap yeni = new Bitmap(bmp.Height, bmp.Width);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    yeni.SetPixel(j, yeni.Height - 1 - i, bmp.GetPixel(i, j)); 

                }
            }
            return yeni;
        }
        private Bitmap sagadondur(Bitmap bmp)
        {
            Bitmap yeni = new Bitmap(bmp.Height, bmp.Width);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    yeni.SetPixel(yeni.Width - 1 - j, i, bmp.GetPixel(i, j));

                }
            }
            return yeni;
        }

        private void toolStripButton6_Click(object sender, EventArgs e) // turn left button
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox2.Image);

                Bitmap soladon = soladondur(bmp);

                pictureBox2.Image = soladon;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;

            }
        }

        private void toolStripButton7_Click(object sender, EventArgs e) // turn right button
        {
            if (pictureBox1.Image == null && pictureBox2.Image == null)
            {
                MessageBox.Show("Henüz Resim Seçilmedi!");
            }
            else
            {
                Bitmap bmp = new Bitmap(pictureBox2.Image);

                Bitmap sagadon = sagadondur(bmp);

                pictureBox2.Image = sagadon;
                pictureBox1.Visible = false;
                pictureBox2.Visible = true;
            }
        }

        private void simpleButton1_Click_1(object sender, EventArgs e) // boyutlandırma 
        {
            int en = (Convert.ToInt32(textBox1.Text));
            int boy = (Convert.ToInt32(textBox2.Text));
            Bitmap bmp = new Bitmap(pictureBox2.Image, en, boy);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.GetPixel(i, j);

                }
            }

            pictureBox2.Image = bmp;
            pictureBox1.Visible = false;
            pictureBox2.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            simpleButton1.Visible = false;
        }

    }
}

    