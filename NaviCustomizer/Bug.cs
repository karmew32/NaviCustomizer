using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaviCustomizer
{
    class Bug
    {
        int type;
        public Piece pieceOne { get; private set; }
        public Piece pieceTwo { get; private set; }
        public string bugMessage { get; private set; }
        public Bug(int type, Piece one, Piece two)
        {
            this.type = type;
            pieceOne = one;
            pieceTwo = two;
            generateBugMessage();
        }

        private void generateBugMessage()
        {
            switch (type)
            {
                case 0:
                    bugMessage = pieceOne.name + " is touching same-colored piece " + pieceTwo.name + ".";
                    break;
                case 1:
                    bugMessage = pieceOne.name + " is textured and is on the line.";
                    break;
                case 2:
                    bugMessage = pieceOne.name + " is plain and is not on the line.";
                    break;
                case 3:
                    bugMessage = "Too many colors are on the grid. There can be a maximum of 4 unique colors on the grid.";
                    break;
                default:
                    bugMessage = "Foo";
                    break;
            }
        }
    }
}
