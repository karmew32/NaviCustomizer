using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviCustomizer
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
            

        }


        public static bool operator == (Point a, Point b)
        {
            return a.x == b.x && a.y == b.y;
        }

        public static bool operator !=(Point a, Point b)
        {
            return a.x != b.x || a.y != b.y;
        }

        public void swap()
        {
            int temp = x;
            x = y;
            y = temp;
            
        }


    }
}
