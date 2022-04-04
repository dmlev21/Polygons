using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Многоугольники
{
    public partial class Form1 : Form
    {
        List<Shape> vertexes;
        List<Shape> convex_hull;
        int checkedShape;
        int checkedConvexHull;

        Graphics g;
        Color colorFill;
        Color colorBorder;
        Pen pen;
        Brush brush;
        Form2 MDForm;

        bool isHeld;
        string fileName;
        Stack<List<Operation>> undo;
        Stack<List<Operation>> redo;

        List<Shape> testVertexes;
        Random rnd;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            label1.Text = "";

            DoubleBuffered = true;

            undo = new Stack<List<Operation>>();
            redo = new Stack<List<Operation>>();
            vertexes = new List<Shape>();
            convex_hull = new List<Shape>();
            checkedShape = 1;
            checkedConvexHull = 2;

            isHeld = false;

            colorBorder = Color.Green;
            colorFill = Color.White;
            pen = new Pen(colorBorder, Shape.Radius / 3);
            brush = new SolidBrush(colorFill);

            toolStripButton_play.Enabled = true;
            toolStripButton_stop.Enabled = false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            int len = vertexes.Count;
            if (len >= 3)
            {
                if (checkedConvexHull == 1)
                {
                    BuildConvexHull_Defin(g);
                    FillPolygon(g);
                }
                else
                {
                    for (int i = 1; i < len; ++i)
                    {
                        e.Graphics.DrawLine(pen, new Point(vertexes[i].X, vertexes[i].Y), new Point(vertexes[i - 1].X, vertexes[i - 1].Y));
                    }
                    e.Graphics.DrawLine(pen, new Point(vertexes[len - 1].X, vertexes[len - 1].Y), new Point(vertexes[0].X, vertexes[0].Y));

                    Point[] pts = new Point[len];
                    for (int i = 0; i < len; ++i) pts[i] = new Point(vertexes[i].X, vertexes[i].Y);

                    e.Graphics.FillPolygon(brush, pts);

                }

            }

            foreach (Shape sh in vertexes)
            {
                sh.Draw(e.Graphics);
            }

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            bool isSomewhere = false;
            int len = vertexes.Count;


            for (int i = len - 1; i >= 0; --i)
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

                        if (checkedConvexHull == 2) BuildConvexHull_Andrew(ref vertexes);

                        Refresh();
                        break;
                    }

                    isSomewhere = true;
                }
            }


            if (e.Button == MouseButtons.Left)
            {
                if (!isSomewhere)
                {
                    if (IsInsideConvexHull(e.X, e.Y))
                    {
                        isHeld = true;

                        foreach (Shape sh in vertexes)
                        {
                            sh.Dx1 = e.X - sh.X;
                            sh.Dy1 = e.Y - sh.Y;
                        }

                        isSomewhere = true;
                    }
                }

                if (!isSomewhere)
                {
                    switch (checkedShape)
                    {
                        case 1: vertexes.Add(new Circle(e.X, e.Y)); break;
                        case 2: vertexes.Add(new Square(e.X, e.Y)); break;
                        case 3: vertexes.Add(new Triangle(e.X, e.Y)); break;
                    }
                }
            }

            if (checkedConvexHull == 2) BuildConvexHull_Andrew(ref vertexes);

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
                    return;
                }
            }

            if (isHeld)
            {
                foreach(Shape sh in vertexes)
                {
                    sh.X = e.X - sh.Dx1;
                    sh.Y = e.Y - sh.Dy1;
                }

                Refresh();
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


            if (checkedConvexHull == 1) DeleteShapes();
            if (checkedConvexHull == 2) BuildConvexHull_Andrew(ref vertexes);


            if (isHeld) isHeld = false;

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

        int CrossProduct(Shape o, Shape a, Shape b)
        {
            return (a.X - o.X) * (b.Y - o.Y) - (a.Y - o.Y) * (b.X - o.X);
        }

        void BuildConvexHull_Andrew(ref List<Shape> vertexes)
        {
            convex_hull.Clear();

            int len = vertexes.Count;
            if (len < 3) return;


            vertexes.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
            List<Shape> up = new List<Shape>();
            List<Shape> down = new List<Shape>();
            
            Shape p1 = vertexes[0], p2 = vertexes[len - 1];
            up.Add(p1);
            down.Add(p1);
            for (int i = 1; i < len; ++i)
            {
                if (i == len - 1 || CrossProduct(p1, vertexes[i], p2) < 0)
                { 
                    while (up.Count >= 2 && CrossProduct(up[up.Count - 2], up[up.Count - 1], vertexes[i]) >= 0)
                        up.RemoveAt(up.Count - 1);
                    
                    up.Add(vertexes[i]);
                }
                if (i == len - 1 || CrossProduct(p1, vertexes[i], p2) > 0)
                {
                    while (down.Count >= 2 && CrossProduct(down[down.Count - 2], down[down.Count - 1], vertexes[i]) <= 0)
                        down.RemoveAt(down.Count - 1);

                    down.Add(vertexes[i]);
                }
            }
            
            up.RemoveAt(up.Count - 1);
            down.RemoveAt(0);
            
            for (int i = 0; i < up.Count; ++i)    convex_hull.Add(up[i]);
            for (int i = down.Count - 1; i >= 0; --i)   convex_hull.Add(down[i]);

            vertexes.Clear();
            foreach (Shape sh in convex_hull) vertexes.Add(sh);  
        }


        void BuildConvexHull_Defin(Graphics g)
        {
            int len = vertexes.Count;
            if (len < 3) return;

            foreach (Shape sh in vertexes) sh.IsInConvex = false;

            for (int i = 0; i < len - 1; ++i)
            {
                for (int j = i + 1; j < len; ++j)
                {
                    int sign = 0;
                    bool add = true;

                    if (vertexes[i].X == vertexes[j].X)
                    {
                        for (int m = 0; m < len; ++m)
                        {
                            if (m != i && m != j)
                            {
                                int zn = 0;
                                if (vertexes[m].X > vertexes[i].X) zn = 1;
                                else zn = -1;

                                if (sign == 0) sign = zn;
                                else if (sign != zn)
                                {
                                    add = false;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        double k = (vertexes[j].Y - vertexes[i].Y) * 1.0 / (vertexes[j].X - vertexes[i].X);
                        double b = vertexes[i].Y - k * vertexes[i].X;

                        for (int m = 0; m < len; ++m)
                        {
                            if (m != i && m != j)
                            {
                                int zn = 0;
                                if (vertexes[m].Y > (k * vertexes[m].X + b)) zn = 1;
                                else zn = -1;
                                if (sign == 0) sign = zn;
                                else if (sign != zn)
                                {
                                    add = false;
                                    break;
                                }
                            }
                        }

                        
                    }


                    if (add)
                    {
                        vertexes[i].IsInConvex = true;
                        vertexes[j].IsInConvex = true;

                        g.DrawLine(pen, new Point(vertexes[i].X, vertexes[i].Y), new Point(vertexes[j].X, vertexes[j].Y));
                    }
                }
            }

            
        }

        void DeleteShapes()
        {
            int len = vertexes.Count;
            if (len < 3) return;

            for (int i = 0; i < len; ++i)
            {
                if (!vertexes[i].IsInConvex)
                {
                    vertexes.RemoveAt(i);
                    len--;
                    i--;
                }
            }
        }


        private void defenitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedConvexHull = 1;
        }

        private void andrewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkedConvexHull = 2;
        }



        class Vector
        {
            public int x, y;


            public Vector(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public Vector(int x1, int y1, int x2, int y2)
            {
                x = x2 - x1;
                y = y2 - y1;
            }


            public double GetLen()
            {
                return Math.Sqrt(x * x + y * y);
            }

            static public int DotProduct(Vector v1, Vector v2)
            {
                return v1.x * v2.x + v1.y * v2.y;
            }

            static public int CrossProduct(Vector v1, Vector v2)
            {
                return v1.x * v2.y - v2.x * v1.y;
            }
        }

        bool CheckPoint(Vector v1, Vector v2, Vector otr)
        {
            return (Math.Abs(otr.GetLen() - (v1.GetLen() + v2.GetLen())) <= 0.000001);
        }

        bool IsInsideConvexHull(int xx, int yy)
        {
            #region UseConvHull
            /*Shape checkShape = new Circle(xx, yy);
            int len = vertexes.Count;
            label1.Text = (len + 100).ToString();
            if (len < 3) return false;

            List<Shape> convex_hull1 = new List<Shape>();
            List<Shape> vertexes_copy = new List<Shape>();

            foreach (Shape sh in vertexes) vertexes_copy.Add(sh);

            vertexes_copy.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
            List<Shape> up = new List<Shape>();
            List<Shape> down = new List<Shape>();

            Shape p1 = vertexes_copy[0], p2 = vertexes_copy[len - 1];
            up.Add(p1);
            down.Add(p1);
            for (int i = 1; i < len; ++i)
            {
                if (i == len - 1 || CrossProduct(p1, vertexes_copy[i], p2) < 0)
                {
                    while (up.Count >= 2 && CrossProduct(up[up.Count - 2], up[up.Count - 1], vertexes_copy[i]) >= 0)
                        up.RemoveAt(up.Count - 1);

                    up.Add(vertexes_copy[i]);
                }
                if (i == len - 1 || CrossProduct(p1, vertexes_copy[i], p2) > 0)
                {
                    while (down.Count >= 2 && CrossProduct(down[down.Count - 2], down[down.Count - 1], vertexes_copy[i]) <= 0)
                        down.RemoveAt(down.Count - 1);

                    down.Add(vertexes_copy[i]);
                }
            }

            up.RemoveAt(up.Count - 1);
            down.RemoveAt(0);

            for (int i = 0; i < up.Count; ++i) convex_hull1.Add(up[i]);
            for (int i = down.Count - 1; i >= 0; --i) convex_hull1.Add(down[i]);

            if (convex_hull1.Contains(checkShape)) return true;
            return false;*/
            #endregion


            List<Shape> v = new List<Shape>();
            foreach (Shape sh in vertexes) v.Add(sh);

            int len = v.Count;
            if (len < 3) return false;

            BuildConvexHull_Andrew(ref v);


            //-------------------------------check----------------------------
            Vector otr = new Vector(v[v.Count - 1].X, v[v.Count - 1].Y, v[0].X, v[0].Y);
            Vector v_1 = new Vector(xx, yy, v[v.Count - 1].X, v[v.Count - 1].Y);
            Vector v_2 = new Vector( xx, yy, v[0].X, v[0].Y);

            if (CheckPoint(v_1, v_2, otr)) return true;

            for (int i = 1; i < v.Count - 1; ++i)
            {
                otr = new Vector(v[i - 1].X, v[i - 1].Y, v[i].X, v[i].Y);
                v_1 = new Vector(xx, yy, v[i - 1].X, v[i - 1].Y);
                v_2 = new Vector(xx, yy, v[i].X, v[i].Y);

                if (CheckPoint(v_1, v_2, otr)) return true;
            }
            //--------------------------------check---------------------------

            double sum = 0;

            Vector v1 = new Vector(xx, yy, v[v.Count - 1].X, v[v.Count - 1].Y);
            Vector v2 = new Vector( xx, yy, v[0].X, v[0].Y);

            sum += Math.Atan2(Vector.CrossProduct(v1, v2), Vector.DotProduct(v1, v2));

            for (int i = 1; i < v.Count - 1; ++i)
            {
                v1 = new Vector(xx, yy, v[i - 1].X, v[i - 1].Y);
                v2 = new Vector(xx, yy, v[i].X, v[i].Y);

                sum += Math.Atan2(Vector.CrossProduct(v1, v2), Vector.DotProduct(v1, v2));
            }


            if (Math.Abs(sum) < 3) return false;
            return true;



        }


        #region check_algorithms
        //--------------------------check_algorithms--------------------------------
        void GenVertexes(int len)
        {
            testVertexes = new List<Shape>();


            for (int i = 0; i < len; ++i)
            {
                Circle sh = new Circle(rnd.Next(0, 1000), rnd.Next(0, 1000));
                testVertexes.Add(sh);
            }
        }

        int checkDefin(int len)
        {
            GenVertexes(len);

            DateTime dateTime1 = DateTime.Now;

            foreach (Shape sh in testVertexes) sh.IsInConvex = false;

            for (int i = 0; i < len - 1; ++i)
            {
                for (int j = i + 1; j < len; ++j)
                {
                    int sign = 0;
                    bool add = true;

                    if (testVertexes[i].X == testVertexes[j].X)
                    {
                        for (int m = 0; m < len; ++m)
                        {
                            if (m != i && m != j)
                            {
                                int zn = 0;
                                if (testVertexes[m].X > testVertexes[i].X) zn = 1;
                                else zn = -1;

                                if (sign == 0) sign = zn;
                                else if (sign != zn)
                                {
                                    add = false;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        double k = (testVertexes[j].Y - testVertexes[i].Y) * 1.0 / (testVertexes[j].X - testVertexes[i].X);
                        double b = testVertexes[i].Y - k * testVertexes[i].X;

                        for (int m = 0; m < len; ++m)
                        {
                            if (m != i && m != j)
                            {
                                int zn = 0;
                                if (testVertexes[m].Y > (k * testVertexes[m].X + b)) zn = 1;
                                else zn = -1;
                                if (sign == 0) sign = zn;
                                else if (sign != zn)
                                {
                                    add = false;
                                    break;
                                }
                            }
                        }


                    }


                    if (add)
                    {
                        testVertexes[i].IsInConvex = true;
                        testVertexes[j].IsInConvex = true;
                    }
                }
            }


            for (int i = 0; i < len; ++i)
            {
                if (!testVertexes[i].IsInConvex)
                {
                    testVertexes.RemoveAt(i);
                    len--;
                    i--;
                }
            }


            DateTime dateTime2 = DateTime.Now;
            int delta = ((dateTime2 - dateTime1).Milliseconds + (dateTime2 - dateTime1).Seconds * 1000 + (dateTime2 - dateTime1).Minutes * 60000);
            return delta;
        }

        int checkAndrew(int len)
        {
            GenVertexes(len);

            DateTime dateTime1 = DateTime.Now;

            List<Shape> convex_hull1 = new List<Shape>();


            testVertexes.Sort((a, b) => a.X == b.X ? a.Y.CompareTo(b.Y) : a.X.CompareTo(b.X));
            List<Shape> up = new List<Shape>();
            List<Shape> down = new List<Shape>();

            Shape p1 = testVertexes[0], p2 = testVertexes[len - 1];
            up.Add(p1);
            down.Add(p1);
            for (int i = 1; i < len; ++i)
            {
                if (i == len - 1 || CrossProduct(p1, testVertexes[i], p2) < 0)
                {
                    while (up.Count >= 2 && CrossProduct(up[up.Count - 2], up[up.Count - 1], testVertexes[i]) >= 0)
                        up.RemoveAt(up.Count - 1);

                    up.Add(testVertexes[i]);
                }
                if (i == len - 1 || CrossProduct(p1, testVertexes[i], p2) > 0)
                {
                    while (down.Count >= 2 && CrossProduct(down[down.Count - 2], down[down.Count - 1], testVertexes[i]) <= 0)
                        down.RemoveAt(down.Count - 1);

                    down.Add(testVertexes[i]);
                }
            }

            up.RemoveAt(up.Count - 1);
            down.RemoveAt(0);

            for (int i = 0; i < up.Count; ++i) convex_hull1.Add(up[i]);
            for (int i = down.Count - 1; i >= 0; --i) convex_hull1.Add(down[i]);


            DateTime dateTime2 = DateTime.Now;
            int delta = ((dateTime2 - dateTime1).Milliseconds + (dateTime2 - dateTime1).Seconds * 1000 + (dateTime2 - dateTime1).Minutes * 60000);
            return delta;
        }
        //---------------------------------------------------------------------------
        #endregion

        private void FillPolygon(Graphics g)
        {
            List<Shape> v = new List<Shape>();
            foreach (Shape sh in vertexes) v.Add(sh);

            int len = v.Count;
            if (len < 3) return;

            BuildConvexHull_Andrew(ref v);


            len = v.Count;
            Point[] pts = new Point[len];
            for (int i = 0; i < len; ++i) pts[i] = new Point(v[i].X, v[i].Y);

            g.FillPolygon(brush, pts);
        }

        private void fillColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = colorFill;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                colorFill = dialog.Color;
                brush = new SolidBrush(colorFill);
            }

            Refresh();
        }

        private void borderColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = colorBorder;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                colorBorder = dialog.Color;
                pen = new Pen(colorBorder, Shape.Radius / 3);
            }

            Refresh();
        }


        private void OnRadiusChanged(object sender, RadiusEventArgs e)
        {
            Shape.Radius = e.Radius;
            Refresh();
        }

        private void radiusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MDForm == null || MDForm.IsDisposed) MDForm = new Form2();
            else if (MDForm.WindowState == FormWindowState.Minimized) MDForm.WindowState = FormWindowState.Normal;
            MDForm.Show();
            MDForm.BringToFront();
            MDForm.RadiusChanged += OnRadiusChanged;
        }



        private void toolStripButton_play_Click(object sender, EventArgs e)
        {
            timer1.Start();
            toolStripButton_play.Enabled = false;
            toolStripButton_stop.Enabled = true;
        }

        private void toolStripButton_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            toolStripButton_play.Enabled = true;
            toolStripButton_stop.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Shape sh in vertexes)
            {
                int dx = rnd.Next(-1, 2);
                int dy = rnd.Next(-1, 2);
                sh.X += dx;
                sh.Y += dy;
            }

            Refresh();

        }


        void SaveData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);

            bf.Serialize(fs, vertexes);
            fs.Close();
        }

        void LoadData()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            vertexes = (List<Shape>)bf.Deserialize(fs);

            fs.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (dialog.ShowDialog() == DialogResult.OK && dialog.FileName != "")
            {
                foreach (char el in dialog.FileName)
                {
                    if (el == '.') break;
                    fileName += el;
                }

                LoadData();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (dialog.ShowDialog() == DialogResult.OK && dialog.FileName != "")
            {
                foreach (char el in dialog.FileName)
                {
                    if (el == '.') break;
                    fileName += el;
                }

                SaveData();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (dialog.ShowDialog() == DialogResult.OK && dialog.FileName != "")
            {
                foreach (char el in dialog.FileName)
                {
                    if (el == '.') break;
                    fileName += el;
                }

                SaveData();
            }
        }
    }
}