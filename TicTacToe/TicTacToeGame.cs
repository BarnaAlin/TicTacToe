using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public int[,] board = new int[Ct.BoardSize, Ct.BoardSize];
        int currentPlayer;

        public void Start()
        {
            InitBoard();
            currentPlayer = Ct.FirstPlayer;
        }

        public string GetPlayerText(int player)
        {
            if (player == Ct.FirstPlayer) return Ct.FirstPlayerText;
            if (player == Ct.SecondPlayer) return Ct.SecondPlayerText;
            return Ct.FreeCellText;
        }


        public int Play(int x, int y)
        {
            Move(x, y);
            //           ConsoleShow();
            return GetWinner(x, y);
        }

        public bool WeHaveAWinner(int x, int y)
        {

            if (board[x, 0] == board[x, 1] && board[x, 1] == board[x, 2]) return true;
            if (board[0, y] == board[1, y] && board[1, y] == board[2, y]) return true;

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != Ct.FreeCell)
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0] && board[0, 2] != Ct.FreeCell)
                return true;

            return false;
        }
        private int GetWinner(int x, int y)
        {
            if (WeHaveAWinner(x, y))
            {
                return currentPlayer;
            }
            return Ct.NoWinner;
        }

        private void ConsoleShow()
        {
            Console.WriteLine("-------------------");
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                string t = "";
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    t += board[i, j].ToString();
                }
                Console.WriteLine(t);
            }
        }
        public void Move(int x, int y)
        {
            if (board[x, y] == Ct.FreeCell)
            {
                board[x, y] = currentPlayer;
                if (!WeHaveAWinner(x, y))
                {
                    TogglePlayer();
                }

            }
        }

        private void TogglePlayer()
        {
            currentPlayer = (currentPlayer == Ct.FirstPlayer) ? Ct.SecondPlayer : Ct.FirstPlayer;
        }

        private void InitBoard()
        {
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    board[i, j] = Ct.FreeCell;
                }
            }
        }

        internal void Reset()
        {
            throw new NotImplementedException();
        }
    }
}

