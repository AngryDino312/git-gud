using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Relógio_analogico
{
    public partial class Form1 : Form
    {
        int Comp = 300, Alt = 300;

        int hor = 0;
        int min = 0;
        int seg = 0;

        int cx, cy;

        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(Comp + 1, Alt + 1);

            cx = Comp / 2 - 1;
            cy = Alt / 2 - 1;
        }

        //Coordenadas polares - seg e min
        private int[] coordSeg(int CPont, int segVal) {
            int[] coords = new int[2];
            int ang = segVal * 6;

            coords[0] = cx + (int) (CPont * Math.Sin(Math.PI * ang / 180));
            coords[1] = cy - (int) (CPont * Math.Cos(Math.PI * ang / 180));
             
            return coords;
        }

        //Coordenadas polares - hora
        private int[] coordHor(int CPont, int horVal, int minVal)
        {
            int[] coords = new int[2];
            int ang = horVal * 30 + minVal / 2;

            coords[0] = cx + (int)(CPont * Math.Sin(Math.PI * ang / 180));
            coords[1] = cy - (int)(CPont * Math.Cos(Math.PI * ang / 180));

            return coords;
        }

        private void timer1_Tick(object sender, EventArgs e) {
            seg++;

            g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            g.DrawImage(Relógio_analogico.Properties.Resources.relogio, 0, 0, 300, 300);

            int[] coordPonto = new int[2];

            if (seg == 60) {
                seg = 0;
                min++;
            }

            if (min == 60) {
                min = 0;
                hor++;
            }

            if (hor == 12) {
                hor = 0;
            }

            //Ponteiro Segundos
            coordPonto = coordSeg(130, seg);
            g.DrawLine(new Pen(Color.Red, 1f), cx, cy, coordPonto[0], coordPonto[1]);

            //Ponteiro Minutos
            coordPonto = coordSeg(100, min);
            g.DrawLine(new Pen(Color.Blue, 2f), cx, cy, coordPonto[0], coordPonto[1]);

            //Ponteiro Horas
            coordPonto = coordHor(80, hor, min);
            g.DrawLine(new Pen(Color.Black, 3f), cx, cy, coordPonto[0], coordPonto[1]);

            this.Text = "Relógio Analógico:  " + hor + ":" + min + ":" + seg;

            pictureBox1.Image = bmp;

            g.Dispose();
        }
    }
}
