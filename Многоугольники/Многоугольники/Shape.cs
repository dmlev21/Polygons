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
    abstract class Shape : Form
    {
        protected int x;
        protected int y;
        protected int dx;
        protected int dy;
        protected static int R;
        bool isHeld;

        public Shape()
        {
            x = 0;
            y = 0;
            isHeld = false;
        }

        static Shape() { R = 20; }
        
        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
            isHeld = false;
        }

        static public int Radius
        {
            get { return R; }
            set { if (value >= 0) R = value; }
        }

        public int X
        {
            get { return x; }
            set {   if (value >= 0) x = value;  }
        }

        public int Y
        {
            get { return y; }
            set { if (value >= 0) y = value; }
        }

        public int Dx
        {
            get { return dx; }
            set { dx = value; }
        }

        public int Dy
        {
            get { return dy; }
            set { dy = value; }
        }

        public bool IsHeld
        {
            get { return isHeld; }
            set { isHeld = value; }
        }
        

        public abstract void Draw(Graphics g);
        public abstract bool IsInside(int xx, int yy);
    }


    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------


    class Circle : Shape
    {
        public Circle() : base() { }
        
        public Circle(int x, int y) : base(x, y) { }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Black), x - R, y - R, 2 * R, 2 * R);
        }

        public override bool IsInside(int xx, int yy)
        {
            return ((xx - x) * (xx - x) + (yy - y) * (yy - y) <= R * R);
        }
    }


    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------


    class Square : Shape
    {
        int a;

        public Square() : base()
        {
            a = (int)Math.Round(R * Math.Sqrt(2));
        }

        public Square(int x, int y) : base(x, y)
        {
            a = (int)Math.Round(R * Math.Sqrt(2));
        }


        public int A
        {
            get { return a; }
        }


        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), x - a / 2, y - a / 2, a, a);
        }

        public override bool IsInside(int xx, int yy)
        {
            return ((xx >= x - a / 2) && (xx <= x + a / 2) && (yy >= y - a / 2) && (yy <= y + a / 2));
        }
    }


    //-----------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------------


    class Triangle : Shape
    {
        int a;
        Point pt1, pt2, pt3;

        public Triangle() : base()
        {
            a = (int)Math.Round(R * Math.Sqrt(3));
        }

        public Triangle(int x, int y) : base(x, y)
        {
            a = (int) Math.Round(R * Math.Sqrt(3));
        }


        public int A
        {
            get { return a; }
        }


        public override void Draw(Graphics g)
        {
            pt1 = new Point(x, y - R);
            pt2 = new Point(x - a / 2, y + (int)Math.Sqrt(R * R - a * a / 4.0));
            pt3 = new Point(x + a / 2, y + (int)Math.Sqrt(R * R - a * a / 4.0));

            Point[] points = { pt1, pt2, pt3 };

            g.FillPolygon(new SolidBrush(Color.Black), points);
        }


        public override bool IsInside(int xx, int yy)
        {
            double sk1 = (pt1.X - xx) * (pt2.Y - pt1.Y) - (pt2.X - pt1.X) * (pt1.Y - yy);
            double sk2 = (pt2.X - xx) * (pt3.Y - pt2.Y) - (pt3.X - pt2.X) * (pt2.Y - yy);
            double sk3 = (pt3.X - xx) * (pt1.Y - pt3.Y) - (pt1.X - pt3.X) * (pt3.Y - yy);

            return ((sk1 >= 0 && sk2 >= 0 && sk3 >= 0) || (sk1 <= 0 && sk2 <= 0 && sk3 <= 0));
        }
    }
}