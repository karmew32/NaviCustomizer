using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviCustomizer
{
    class Tile : Point
    {
        //private Point correspondingPoint;
        public List<Point> borderingPoints { get; private set; }
        public char tileChar { get; set; }
        public char baseTileChar { get; private set; }
        public Piece parentPiece { get; set; }
        public Piece dummyPiece { get; private set; }
        public Tile(int x, int y) : base(x, y)
        {
            this.x = x;
            this.y = y;
            dummyPiece = new Piece("dummy", "Empty", false, new List<Point>());
            parentPiece = dummyPiece;
            borderingPoints = new List<Point>();
            if (!isTopBound())
            {
                borderingPoints.Add(new Point(x, y - 1));
            }
            if (!isBottomBound())
            {
                borderingPoints.Add(new Point(x, y + 1));
            }
            if (!isLeftBound())
            {
                borderingPoints.Add(new Point(x - 1, y));
            }
            if (!isRightBound())
            {
                borderingPoints.Add(new Point(x + 1, y));
            }
            tileChar = (isPartOfLine()) ? '=' : ' ';
            baseTileChar = (isPartOfLine()) ? '=' : ' ';
            //this.correspondingPoint = p;
        }


        public bool isTopBound()
        {
            return y == 0;
        }

        public bool isBottomBound()
        {
            return y == 4;
        }

        public bool isLeftBound()
        {
            return x == 0;
        }

        public bool isRightBound()
        {
            return x == 4;
        }

        public bool isPartOfLine()
        {
            return y == 2;
        }


        /*public Point getCorrespondingPoint()
        {
            return correspondingPoint;
        }*/
    }
}
