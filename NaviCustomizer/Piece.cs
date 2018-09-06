using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviCustomizer
{
    class Piece
    {
        public string id { get; set; }
        public string name { get; set; }
        public string color { get; set; }
        public List<Point> points { get; private set; }
        public bool textured { get; set; }
        Matrix rotationalBound = new Matrix();
        public Piece(string name, string color, bool textured, List<Point> points)
        {
            id = generateId();
            this.name = name;
            this.color = color;
            this.textured = textured;
            this.points = points;
        }

        public void shift(int x, int y)
        {
            foreach (Point p in points)
            {
                p.x += x;
                p.y += y;
            }
        }

        /*public List<Point> getPoints()
        {
            return points;
        }*/

        public string generateId()
        {
            Random rnd = new Random();
            string pool = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string s = "";
            for (int i = 0; i < 10; i++)
            {
                s += pool[rnd.Next(62)];
            }
            return s;
        }

        public int getLeftBound()
        {
            int lb = 15;
            foreach (Point p in points)
            {
                if (p.x < lb)
                {
                    lb = p.x;
                }
            }
            return lb;
        }

        public int getRightBound()
        {
            int rb = 0;
            foreach (Point p in points)
            {
                if (p.x > rb)
                {
                    rb = p.x;
                }
            }
            return rb;
        }

        public int getTopBound()
        {
            int tb = 15;
            foreach (Point p in points)
            {
                if (p.y < tb)
                {
                    tb = p.y;
                }
            }
            return tb;
        }

        public int getBottomBound()
        {
            int bb = 0;
            foreach (Point p in points)
            {
                if (p.y > bb)
                {
                    bb = p.y;
                }
            }
            return bb;
        }

        public int getWidth()
        {
            return getRightBound() - getLeftBound() + 1;
        }

        public int getHeight()
        {
            return getBottomBound() - getTopBound() + 1;
        }

        /*private void transpose()
        {
            foreach (Point p in points)
            {
                p.swap();
            }
        }

        //flips the piece horizontally
        private void flip()
        {
            foreach (Point p in points)
            {
                p.x += getWidth() - 1 - (2 * p.x);
            }
        }*/

        private Matrix generateProjSquare()
        {
            int desiredSize = (getHeight() > getWidth()) ? getHeight() : getWidth();
            Matrix square = new Matrix();
            for (int i = 0; i < 5; i++)
            {
                List<int> s = new List<int>();
                for (int j = 0; j < 5; j++)
                {
                    s.Add(0);
                }
                square.Add(s);
            }
            foreach (Point p in points)
            {
                square[p.y][p.x] = 1;
            }
            square.trim(desiredSize);
            return square;
        }

        public void rotateLeft()
        {
            Matrix m = rotationalBound;
            m.turnLeft();
            List<Point> newPointList = new List<Point>();
            for (int i = 0; i < m.Count; i++)
            {
                for (int j = 0; j < m.Count; j++)
                {
                    if (m[i][j] == 1)
                    {
                        newPointList.Add(new Point(j + m.offsetX, i + m.offsetY));
                    }
                }
            }
            points = newPointList;
        }

        public void rotateRight()
        {
            Matrix m = rotationalBound;
            m.turnRight();
            List<Point> newPointList = new List<Point>();
            for (int i = 0; i < m.Count; i++)
            {
                for (int j = 0; j < m.Count; j++)
                {
                    if (m[i][j] == 1)
                    {
                        newPointList.Add(new Point(j + m.offsetX, i + m.offsetY));
                    }
                }
            }
            points = newPointList;
        }

        public void setRotationalBound()
        {
            int desiredSize = (getHeight() > getWidth()) ? getHeight() : getWidth();
            Matrix square = new Matrix();
            for (int i = 0; i < 5; i++)
            {
                List<int> s = new List<int>();
                for (int j = 0; j < 5; j++)
                {
                    s.Add(0);
                }
                square.Add(s);
            }
            foreach (Point p in points)
            {
                square[p.y][p.x] = 1;
            }
            square.trim(desiredSize);
            rotationalBound = square;
        }
    }
}
