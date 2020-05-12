using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Race
{
    public partial class Form3 : Form
    {
        Thread[] t = new Thread[3];
        Run[] run = new Run[3];
        PictureBox[] p = new PictureBox[3];
        Random rad = new Random();

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            p[0] = pictureBox1;
            p[1] = pictureBox2;
            p[2] = pictureBox3;

            for (int i = 0, j = 0; i < 3; i++, j += 150)
            {
                p[i].Location = new Point(j, 0);
                run[i] = new Run(p[i], this, i);
                t[i] = new Thread(run[i].relay);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t[0].Start(t);
        }
    }
}
