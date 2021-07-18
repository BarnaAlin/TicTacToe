namespace TicTacToe
{
    public class GameResult
    {
        private string player1;
        private string player2;
        private int result;

        public string Player1 { get => player1; set => player1 = value; }
        public string Player2 { get => player2; set => player2 = value; }
        public int Result { get => result; set => result = value; }
    }
}