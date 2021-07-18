using System;
using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        public int[,] board = new int[Ct.BoardSize, Ct.BoardSize];
        int currentPlayer;
        string player1, player2;

        List<GameResult> gameResults = new List<GameResult>();

        public void Start(string p1, string p2)
        {
            player1 = p1;
            player2 = p2;
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

        internal string GetWinnerName()
        {
            return GetPlayerName(currentPlayer);
        }

        private string GetPlayerName(int currentPlayer)
        {
            if (currentPlayer == 1) return player1;
            if (currentPlayer == 2) return player2;
            return "No Winner";
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

