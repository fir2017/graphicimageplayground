using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace graphicimageplayground
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int contor = 1;
        public Image img;
        public Graphics g;
        public Bitmap bmp;
        public Pen pen0;
        public Brush brush0;
        public Font font0;
        public int top = 0;
        public int left = 0;
        public float zoomx = 1.0f;
        public float zoomy = 1.0f;
        public string currentfile = " ";
        public bool ismd = false;
        public double currx = 0;
        public double curry = 0;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            font0 = this.Font;
            pen0 = new Pen(Color.Black, 1);
            brush0 = new SolidBrush(Color.Black);
            g = pictureBox1.CreateGraphics();
            bmp = new Bitmap("bitmap.bmp");
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
           
        }
        public void drawpicture()
        {
            g.DrawImage(bmp, 0, 0, bmp.Width, bmp.Height);

            img = (Image)bmp;
            bmp = (Bitmap)img;
            //g.Dispose();
            //g = Graphics.FromImage(bmp);
            //g = Graphics.FromImage(img);

            

        }

        public void drawimage()
        {
            g.Clear(Color.White);
            img = (Image)bmp;
            bmp = (Bitmap)img;
            g.DrawImage(img, 0, 0, bmp.Width, bmp.Height);
            //g.Dispose();
            //g = Graphics.FromImage(bmp);
            //g = Graphics.FromImage(img);
        }
        public void drawimageXY(int X, int Y)
        {
            g.Clear(Color.White);
            img = (Image)bmp;
            bmp = (Bitmap)img;
            g.DrawImage(img, Y, X, bmp.Width, bmp.Height);
            //g.Dispose();
            //g = Graphics.FromImage(bmp);
            //g = Graphics.FromImage(img);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            drawpicture();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            contor++;
            Text = contor.ToString();
           
        }

       

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {


          //drawimage();
        }
        public double distanta(double a, double b)
        {
            return (a*a)-(b*b);
        }
        public double absdistanta(double a, double b)
        {
            return Math.Abs((a * a) - (b * b));
        }
        public void movetheimage(double x, double y)
        {
            left += (int)x/10000;
            top  += (int)y/10000;
            drawimageXY(top, left);
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            contor += 1;
            //drawimage();
            if (ismd == true)
            {
                movetheimage(distanta((double)e.X,currx),distanta((double)e.Y, curry));
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            top-=5;
            drawimageXY(top, left);
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            g.RotateTransform(-5);
            drawimage();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            top+=5;
            drawimageXY(top, left);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            left+=5;
            drawimageXY(top, left);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            left-=5;
            drawimageXY(top, left);
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            g.RotateTransform(2);
            drawimage();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            zoomx += 0.1f;
            zoomy += 0.1f;
            g.ScaleTransform(zoomx,zoomy);
            drawimage();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            zoomx -= 0.1f;
            zoomy -= 0.1f;
            g.ScaleTransform(zoomx, zoomy);
            drawimage();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            zoomx = 1.0f;
            zoomy = 1.0f;
           
            openFileDialog1.ShowDialog();
            try
            {
                bmp = new Bitmap(openFileDialog1.FileName);
            }
            catch { }
            drawimage();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ismd = true;
            currx = e.X;
            curry = e.Y;
           
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ismd = false;
        }
    }
}
