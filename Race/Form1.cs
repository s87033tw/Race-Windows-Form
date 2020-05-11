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
        Form2 along_race = new Form2();
        Form3 relay_race = new Form3();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            along_race.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            relay_race.Show();
        }
    }
}
