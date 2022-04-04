using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Многоугольники
{

    abstract class Operation
    {
        public abstract void Undo(ref List<Shape> vertexes);

        public abstract void Redo(ref List<Shape> vertexes);
    }


    class DragDropVertex : Operation
    {
        int dx, dy;
        int index;

        public DragDropVertex(int dx, int dy, int index)
        {
            this.dx = dx;
            this.dy = dy;
            this.index = index;
        }

        public override void Undo(ref List<Shape> vertexes)
        {
            vertexes[index].X -= dx;
            vertexes[index].Y -= dy;
        }

        public override void Redo(ref List<Shape> vertexes)
        {
            vertexes[index].X += dx;
            vertexes[index].Y += dy;
        }
    }

    class DragDropPolygon : Operation
    {
        int dx, dy;

        public DragDropPolygon(int dx, int dy)
        {
            this.dx = dx;
            this.dy = dy;
        }

        public override void Undo(ref List<Shape> vertexes)
        {
            foreach (Shape sh in vertexes)
            {
                sh.X -= dx;
                sh.Y -= dy;
            }
        }

        public override void Redo(ref List<Shape> vertexes)
        {
            foreach (Shape sh in vertexes)
            {
                sh.X += dx;
                sh.Y += dy;
            }
        }
    }

    class CreateVertex : Operation
    {
        int x, y;
        int index;
        string shape;

        public CreateVertex(int x, int y, int index, string shape)
        {
            this.x = x;
            this.y = y;
            this.index = index;
            this.shape = shape;
        }

        public override void Undo(ref List<Shape> vertexes)
        {
            vertexes.RemoveAt(index);
        }

        public override void Redo(ref List<Shape> vertexes)
        {
            if (shape == "circle") vertexes.Insert(index, new Circle(x, y));
            if (shape == "square") vertexes.Insert(index, new Square(x, y));
            vertexes.Insert(index, new Triangle(x, y));
        }
    }

    class DeleteVertex : Operation
    {
        int x, y;
        int index;
        string shape;

        public DeleteVertex(int x, int y, int index, string shape)
        {
            this.x = x;
            this.y = y;
            this.index = index;
            this.shape = shape;
        }

        public override void Undo(ref List<Shape> vertexes)
        {
            if (shape == "circle") vertexes.Insert(index, new Circle(x, y));
            if (shape == "square") vertexes.Insert(index, new Square(x, y));
            vertexes.Insert(index, new Triangle(x, y));
        }

        public override void Redo(ref List<Shape> vertexes)
        {
            vertexes.RemoveAt(index);
        }
    }

    class RadiusChange : Operation
    {
        int d_radius;

        public RadiusChange(int d_radius)
        {
            this.d_radius = d_radius;
        }

        public override void Undo(ref List<Shape> vertexes)
        {
            foreach (Shape sh in vertexes) Shape.Radius -= d_radius;
        }

        public override void Redo(ref List<Shape> vertexes)
        {
            foreach (Shape sh in vertexes) Shape.Radius += d_radius;
        }
    }

    class ColorFillChange : Operation
    {
        Color col_pr, col_new;

        public ColorFillChange(Color col_pr, Color col_new)
        {
            this.col_pr = col_pr;
            this.col_new = col_new;
        }

        public override void Undo(ref List<Shape> vertexes)
        {

        }

        public override void Redo(ref List<Shape> vertexes)
        {

        }

    }

}