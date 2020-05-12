using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race
{
    class Run
    {
        PictureBox pb;
        Form f;
        Random rad;
        int name;
        Thread[] t;

        public Run(PictureBox pictureBox, Form form, Random rad, int name)//Form2使用的建構子
        {
            pb = pictureBox;
            f = form;
            this.rad = rad;
            this.name = name + 1;
        }
        public Run(PictureBox pictureBox, Form form, int name)//Form3使用的建構子
        {
            pb = pictureBox;
            f = form;
            this.name = name;
        }
        public void alone()
        {
            invoke(true);
        }

        public void relay(object t)
        {
            this.t = (Thread[])t;
            rad = new Random();
            invoke(false);
            if (name != 2)
                this.t[name + 1].Start(t);
            else
            {
                MessageBox.Show("結束");
                MethodInvoker methodInvoker = new MethodInvoker(f.Close);//執行緒內Close視窗必須同步前景
                f.Invoke(methodInvoker);
            }       
        }
        private void invoke(bool XY)//與前景執行緒同步
        {
            if (XY)
                while (pb.Location.X < 500)
                {
                    if (f.InvokeRequired)
                    {
                        UpdataUI up = new UpdataUI(changeLocation);
                        f.Invoke(up, pb.Location);
                        Thread.Sleep(100);//給執行緒反應切換的時間
                    }
                    Console.WriteLine(pb.Location);
                }
            else
            {
                int temp = pb.Location.X;
                while (pb.Location.X - temp != 150)
                {
                    if (f.InvokeRequired)
                    {
                        UpdataUI2 up = new UpdataUI2(changeLocation);
                        f.Invoke(up, pb.Location, temp);
                        Thread.Sleep(100);
                    }
                    Console.WriteLine(pb.Location);
                }
            }

        }
        private delegate void UpdataUI(Point point);
        private delegate void UpdataUI2(Point point, int temp);
        
        private void changeLocation(Point point)
        {
            int x;
            int r = rad.Next(1, 10);

            x = point.X + r;
            pb.Location = new Point(x, point.Y);
        }
        public void changeLocation(Point point, int temp)
        {
            int x = point.X;
            x += rad.Next(1, 10);
            if (x - temp > 150)
                pb.Location = new Point(temp + 150, point.Y);
            else
                pb.Location = new Point(x, point.Y);
        }
    }
}
