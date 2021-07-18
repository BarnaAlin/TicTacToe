using System;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        int[,] board = new int[Ct.BoardSize, Ct.BoardSize];
        int currentPlayer;
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
                TogglePlayer(ref currentPlayer);
            }
        }

        private void TogglePlayer(ref int currentPlayer)
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