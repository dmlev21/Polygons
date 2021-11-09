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
    public partial class Form1 : Form
    {
        List<Shape> vertexes;
        List<Shape> convex_hull;
        int checkedShape;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            vertexes = new List<Shape>();
            checkedShape = 1;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (vertexes.Count >= 3)
            {
                int size = convex_hull.Count;
                Point[] pts = new Point[size];

                for (int i = 0; i < size; ++i) pts[i] = new Point(convex_hull[i].X, convex_hull[i].Y);

                e.Graphics.DrawPolygon(new Pen(Color.Green, (int)Shape.Radius / 20), pts);
                e.Graphics.FillPolygon(new SolidBrush(Color.Green), pts);
            }

            foreach (Shape sh in vertexes)
            {
                sh.Draw(e.Graphics);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool isSomewhere = false;


            for (int i = vertexes.Count - 1; i >= 0; --i)
            {
                if (vertexes[i].IsInside(e.X, e.Y))
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        vertexes[i].IsHeld = true;
                        vertexes[i].Dx = e.X - vertexes[i].X;
                        vertexes[i].Dy = e.Y - vertexes[i].Y;
                    }
                    else
                    {
                        vertexes.Remove(vertexes[i]);
                        Refresh();
                        break;
                    }

                    isSomewhere = true;
                }
            }
            

            if (!isSomewhere && e.Button == MouseButtons.Left)
            {
                switch (checkedShape)
                {
                    case 1: vertexes.Add(new Circle(e.X, e.Y)); break;
                    case 2: vertexes.Add(new Square(e.X, e.Y)); break;
                    case 3: vertexes.Add(new Triangle(e.X, e.Y)); break;
                }
            }

            DeleteShapes();
            Refresh();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Shape sh in vertexes)
            {
                if (sh.IsHeld)
                {
                    sh.X = e.X - sh.Dx;
                    sh.Y = e.Y - sh.Dy;

                    Refresh();
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Shape sh in vertexes)
            {
                if (sh.IsHeld)
                {
                    sh.IsHeld = false;
                }
            }

            DeleteShapes();
            DeleteShapes();
            Refresh();
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedShape = 1;
        }

        private void squareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedShape = 2;
        }

        private void triangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedShape = 3;
        }




        //======================================convex_hull====================================
        static int Comp(Shape sh1, Shape sh2)
        {
            if (sh1.X < sh2.X || (sh1.X == sh2.X && sh1.Y < sh2.Y)) return 1;
            else return 0;
        }

        int CrossProduct(Shape a, Shape b, Shape c)
        {
            return (a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y));
        }

        int GetSign(int x)
        {
            if (x > 0) return 1;
            if (x < 0) return -1;
            return 0;
        }

        void BuildConvexHull()
        {
            int len = vertexes.Count;

            Shape[] vertexes_copy = new Shape[len];
            vertexes.CopyTo(vertexes_copy);

            if (len == 1) return;

            Array.Sort(vertexes_copy, Comp);


            List<Shape> up = new List<Shape>();
            List<Shape> down = new List<Shape>();

            Shape p1 = vertexes_copy[0], p2 = vertexes_copy[len - 1];
            up.Add(p1);
            down.Add(p1);

            for (int i = 1; i < len; ++i)
            {
                if ((i == vertexes_copy.Length - 1) || (GetSign(CrossProduct(p1, vertexes_copy[i], p2)) == -1))
                {
                    while ((up.Count >= 2) && !(GetSign(CrossProduct(up[up.Count - 2], up[up.Count - 1], vertexes_copy[i])) == -1))
                        up.RemoveAt(up.Count - 1);

                    up.Add(vertexes_copy[i]);
                }

                if ((i == vertexes_copy.Length - 1) || (GetSign(CrossProduct(p1, vertexes_copy[i], p2)) == 1))
                {
                    while ((down.Count >= 2) && !(GetSign(CrossProduct(down[down.Count - 2], down[down.Count - 1], vertexes_copy[i])) == 1))
                        down.RemoveAt(down.Count - 1);
                    
                    down.Add(vertexes_copy[i]);
                }
            }


            convex_hull = new List<Shape>();
            for (int i = 0; i < up.Count; ++i)
                convex_hull.Add(up[i]);


            for (int i = down.Count - 2; i > 0; --i)
                convex_hull.Add(down[i]);

        }

        void DeleteShapes()
        {
            if (vertexes.Count > 2)
            {
                BuildConvexHull();
                vertexes = convex_hull;
            }
        }
    }
}