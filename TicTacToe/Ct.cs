using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    static class Ct
    {
        public static int BoardSize = 3;

        public static int FreeCell = 0;
        public static int FirstPlayer = 1;
        public static int SecondPlayer = 2;

        public static int NoWinner = FreeCell;

        public static int LeftMargin = Convert.ToInt32(Properties.Resources.LeftMargin);
        public static int TopMargin = Convert.ToInt32(Properties.Resources.TopMargin);
        public static int CellSize = 100;
        public static string FreeCellText = ".";
        public static int CellGap = 4;
        public static Color CellColor = Color.LightBlue;

        public static string FirstPlayerText = "X";
        public static string SecondPlayerText = "0";
    }
}
