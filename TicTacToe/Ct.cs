using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToe
{
    static class Ct
    {
        public static int BoardSize = 3;

        public static int FreeCell = 0;
        public static int FirstPlayer = 1;
        public static int SecondPlayer = 2;
        public static int NoWinner = FreeCell;

        public static int LeftMargin = 20;
        public static int TopMargin = 20;
        public static int CellSize = 50;
        public static string FreeCellText = ".";
        public static int CellGap = 4;
        public static Color CellColor = Color.LightBlue;
        public static string FirstPlayerText = "X";
        public static string SecondPlayerText = "0";
    }
}