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
        public mainForm()
        {
            InitializeComponent();
            game = new TicTacToeGame();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            game.Start();
        }
    }
}
