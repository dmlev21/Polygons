using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Многоугольники
{
    public partial class Form2 : Form
    {
        public event RadiusEventHandler RadiusChanged;
        int radius_pr, radius_new;

        public Form2()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (RadiusChanged != null)  RadiusChanged(this, new RadiusEventArgs(trackBar1.Value));
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            trackBar1.Value = Shape.Radius;
        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            radius_pr = trackBar1.Value;
        }

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            radius_new = trackBar1.Value;
        }
    }
}
