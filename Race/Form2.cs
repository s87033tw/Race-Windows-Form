using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race
{
    public partial class Form2 : Form
    {
        bool racePoint = false;
        Thread[] t = new Thread[3];
        Run[] run = new Run[3];
        PictureBox[] p = new PictureBox[3];
        Random rad = new Random();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            p[0] = pictureBox1;
            p[1] = pictureBox2;
            p[2] = pictureBox3;

            for (int i = 0, j = 0; i < 3; i++, j += 100)
            {
                p[i].Location = new Point(0, j);
                run[i] = new Run(p[i], this, rad, i);
            }

            for (int i = 0; i < 3; i++)
                t[i] = new Thread(new ThreadStart(run[i].runner));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                t[i].Start();
            }

            new Thread(new ThreadStart(listenerThread)).Start();
        }

        private void listenerThread()
        {
            bool a = true;
            int i = 0;

            while (a)
            {
                if (t[i].IsAlive.Equals(false))
                {
                    a = false;
                    break;
                }
                Thread.Sleep(1);

                if (i == 2)
                    i = 0;
                else
                    i++;
            }
            if (MessageBox.Show((i + 1).ToString() + " win", "", MessageBoxButtons.OK).Equals(DialogResult.OK))
                Environment.Exit(Environment.ExitCode);
        }
    }

    public class Run
    {
        PictureBox pb;
        Form2 f2;
        Random rad;
        int name;

        public Run(PictureBox pictureBox, Form2 form2, Random rad, int name)
        {
            pb = pictureBox;
            f2 = form2;
            this.rad = rad;
            this.name = name + 1;
        }

        private delegate void UpdataUI(Point point);

        public void runner()
        {
            while (pb.Location.X < 500)
            {
                if (f2.InvokeRequired)
                {
                    UpdataUI up = new UpdataUI(changeLocation);
                    f2.Invoke(up, pb.Location);
                    Thread.Sleep(100);
                }
                Console.WriteLine(pb.Location);
            }
        }

        public void changeLocation(Point point)
        {
            int x = 0;

            int r = rad.Next(1, 10);
            x = point.X + r;


            pb.Location = new Point(x, point.Y);
        }
    }
}
