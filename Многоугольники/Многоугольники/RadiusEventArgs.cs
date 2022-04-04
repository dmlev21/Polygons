using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многоугольники
{
    public class RadiusEventArgs : EventArgs
    {
        int radius;

        public RadiusEventArgs()
        {
            radius = 20;
        }

        public RadiusEventArgs(int radius)
        {
            this.radius = radius;
        }

        public int Radius
        {
            get { return radius; }
            set { if (value > 0)    radius = value; }
        }
    }


    public delegate void RadiusEventHandler(object sender, RadiusEventArgs e);

}
