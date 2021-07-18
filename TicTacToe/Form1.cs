using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class mainForm : Form
    {
        TicTacToeGame game;
        Label[,] board = new Label[Ct.BoardSize, Ct.BoardSize];
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            game = new TicTacToeGame();
            game.Start(player1TextBox.Text, player2TextBox.Text);
            InitBoard(gamePanel);
            ResizeBoard(gamePanel);
        }

        private void InitBoard(ScrollableControl gameZone)
        {
            Ct.CellSize = (gameZone.Height - 2 * Ct.TopMargin - 2 * Ct.CellGap) / 3;
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    board[i, j] = new Label();
                    SetCellProperties(i, j);
                    board[i, j].MouseClick += ClickOnCell;

                    gameZone.Controls.Add(board[i, j]);

                }
            }
        }

        private void SetCellProperties(int i, int j)
        {
            board[i, j].Left = Ct.LeftMargin + j * (Ct.CellSize + Ct.CellGap);
            board[i, j].Top = Ct.TopMargin + i * (Ct.CellSize + Ct.CellGap);
            board[i, j].Height = Ct.CellSize;
            board[i, j].Width = Ct.CellSize;

            board[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", (Ct.CellSize - 10) / 2,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            board[i, j].TextAlign = ContentAlignment.MiddleCenter;
            board[i, j].BackColor = Ct.CellColor;
            board[i, j].Text = Ct.FreeCellText;
        }

        private void ClickOnCell(object sender, MouseEventArgs e)
        {
            (int x, int y) positionInBoard = GetPosition((Label)sender);
            game.Play(positionInBoard.x, positionInBoard.y);

            ChangeCell(positionInBoard.x, positionInBoard.y);

            if (!game.WeHaveAWinner(positionInBoard.x, positionInBoard.y) && !game.FullBoard()) return;

            if (game.WeHaveAWinner(positionInBoard.x, positionInBoard.y))
            {
                MessageBox.Show("We have a winner:" + game.GetWinnerName());
                game.SaveGame();
            }
            else if (game.FullBoard())
            {
                MessageBox.Show("Draw!");
                game.SaveDrawGame();

            }
            resultsDataGridView.DataSource = null;
            resultsDataGridView.DataSource = game.gameResults;
            game.Start(player1TextBox.Text, player2TextBox.Text);
            ResetBoard();
        }

        private void ResetBoard()
        {
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    ChangeCell(i, j);
                }
            }
        }

        private void ChangeCell(int x, int y)
        {
            board[x, y].Text = game.GetPlayerText(game.board[x, y]);
        }

        private (int x, int y) GetPosition(Label currentCell)
        {
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    if (board[i, j] == currentCell)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1);
        }

        private void resetGameButton_Click(object sender, EventArgs e)
        {
            game.SaveDrawGame();
            resultsDataGridView.DataSource = null;
            resultsDataGridView.DataSource = game.gameResults;
            game.Start(player1TextBox.Text, player2TextBox.Text);
            ResetBoard();
        }

        private void gamePanel_SizeChanged(object sender, EventArgs e)
        {

        }

        private void mainForm_ResizeEnd(object sender, EventArgs e)
        {
            gamePanel.Refresh();
        }

        private void gameOptionsSplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            int minSize = Math.Min(gameOptionsSplitContainer.Panel2.Height, gameOptionsSplitContainer.Panel2.Width);

            gamePanel.Left = 10;
            gamePanel.Top = 10;

            gamePanel.Height = minSize - 2 * Ct.TopMargin;
            gamePanel.Width = minSize - 2 * Ct.LeftMargin;
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            ResizeBoard(gamePanel);
        }

        private void ResizeBoard(Panel gameZone)
        {
            Ct.CellSize = (gameZone.Height - 2 * Ct.TopMargin - 2 * Ct.CellGap) / 3;
            for (int i = 0; i < Ct.BoardSize; i++)
            {
                for (int j = 0; j < Ct.BoardSize; j++)
                {
                    board[i, j].Left = Ct.LeftMargin + j * (Ct.CellSize + Ct.CellGap);
                    board[i, j].Top = Ct.TopMargin + i * (Ct.CellSize + Ct.CellGap);
                    board[i, j].Height = Ct.CellSize;
                    board[i, j].Width = Ct.CellSize;
                    board[i, j].Font = new System.Drawing.Font("Microsoft Sans Serif", (Ct.CellSize) / 2,
               System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void resetGameButton_MouseEnter(object sender, EventArgs e)
        {
            resetGameButton.BackColor = Color.Yellow;
        }

        private void resetGameButton_MouseLeave(object sender, EventArgs e)
        {
            resetGameButton.BackColor = Color.LightGray;
        }
    }
}
