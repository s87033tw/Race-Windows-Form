using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race
{
    public partial class Form1 : Form
    {
        Form2 along_race;
        Form3 relay_race;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            along_race = new Form2();
            along_race.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            relay_race = new Form3();
            relay_race.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = "https://github.com/s87033tw/Race-Windows-Form";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start("https://github.com/s87033tw/Race-Windows-Form");
        }
    }
}
