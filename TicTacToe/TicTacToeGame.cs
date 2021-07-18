using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        int[,] board = new int[Ct.BoardSize, Ct.BoardSize];
        int currentPlayer;
        int winner;
        public void Start()
        {
            InitBoard();
            currentPlayer = Ct.FirstPlayer;
        }
        public void Move(int x, int y)
        {
            if (board[x, y] == Ct.FreeCell)
            {
                board[x, y] = currentPlayer;
                if (WeHaveAWinner(x, y))
                {
                    winner = currentPlayer;
                }
                else
                {
                    TogglePlayer();
                }
            }
        }
        private bool WeHaveAWinner(int x, int y)
        {
            if (board[x, 0] == board[x, 1] && board[x, 1] == board[x, 2]) return true;
            if (board[0, y] == board[1, y] && board[1, y] == board[2, y]) return true;

            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0]) return true;

            return false;
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
    }
}