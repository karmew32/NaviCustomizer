using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviCustomizer
{
    class Matrix : List<List<int>>
    {
        public int offsetX {get; private set;}
        public int offsetY {get; private set;}

        public Matrix()
        {
            offsetX = 0;
            offsetY = 0;
        }
        public void RemoveRow(int i)
        {
            RemoveAt(i);
        }
        public void RemoveColumn(int i)
        {
            foreach (List<int> row in this)
            {
                row.RemoveAt(i);
            }
        }
        public int this[int i, int j]
        {
            get { return this[i][j]; }
            set { this[i][j] = value; }
        }
        //is row all zeroes
        public bool isZeroRow(int n)
        {
            foreach (int i in this[n])
            {
                if (i != 0)
                {
                    return false;
                }
            }
            return true;
        }
        //is column all zeroes
        public bool isZeroColumn(int n)
        {
            foreach (List<int> l in this)
            {
                if (l[n] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public void trim(int desiredSize)
        {
            //trim down columns
            for (int i = 0; i < 5 - desiredSize; i++)
            {
                //if leftmost column is all 0s
                if (isZeroColumn(0))
                {
                    RemoveColumn(0);
                    offsetX++;
                }
                else
                {
                    //remove rightmost column instead
                    RemoveColumn(this[0].Count - 1);
                }
            }
            //trim down rows
            for (int i = 0; i < 5 - desiredSize; i++)
            {
                //if top row is all 0s
                if (isZeroRow(0))
                {
                    RemoveRow(0);
                    offsetY++;
                }
                else
                {
                    //remove bottom row instead
                    RemoveRow(Count - 1);
                }
            }
        }
        public void turnLeft()
        {
            int N = Count;
            for (int x = 0; x < N / 2; x++)
            {
                // Consider elements 
                // in group of 4 in 
                // current square
                for (int y = x; y < N - x - 1; y++)
                {
                    // store current cell 
                    // in temp variable
                    int temp = this[x, y];

                    // move values from 
                    // right to top
                    this[x, y] = this[y, N - 1 - x];

                    // move values from
                    // bottom to right
                    this[y, N - 1 - x] = this[N - 1 - x,
                                            N - 1 - y];

                    // move values from
                    // left to bottom
                    this[N - 1 - x,
                        N - 1 - y] = this[N - 1 - y, x];

                    // assign temp to left
                    this[N - 1 - y, x] = temp;
                }

            }
        }
        public void turnRight()
        {
            int N = Count;
            for (int x = 0; x < N / 2; x++)
            {
                // Consider elements 
                // in group of 4 in 
                // current square
                for (int y = x; y < N - x - 1; y++)
                {
                    // store current cell 
                    // in temp variable
                    int temp = this[x, y];

                    // move values from 
                    // left to top
                    this[x, y] = this[N - 1 - y, x];

                    // move values from
                    // bottom to left
                    this[N - 1 - y, x] = this[N - 1 - x,
                                            N - 1 - y];

                    // move values from
                    // right to bottom
                    this[N - 1 - x,
                        N - 1 - y] = this[y, N - 1 - x];

                    // assign temp to right
                    this[y, N - 1 - x] = temp;
                }

            }
        }
    }
}
