namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Point = 0;
        private int player2Point = 0;

        private string player1Res = "";
        private string player2Res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (player1Point == player2Point && player1Point < 3)
            {
                if (player1Point == 0)
                    score = "Love";
                if (player1Point == 1)
                    score = "Fifteen";
                if (player1Point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (player1Point == player2Point && player1Point > 2)
                score = "Deuce";

            if (player1Point > 0 && player2Point == 0)
            {
                if (player1Point == 1)
                    player1Res = "Fifteen";
                if (player1Point == 2)
                    player1Res = "Thirty";
                if (player1Point == 3)
                    player1Res = "Forty";

                player2Res = "Love";
                score = player1Res + "-" + player2Res;
            }
            if (player2Point > 0 && player1Point == 0)
            {
                if (player2Point == 1)
                    player2Res = "Fifteen";
                if (player2Point == 2)
                    player2Res = "Thirty";
                if (player2Point == 3)
                    player2Res = "Forty";

                player1Res = "Love";
                score = player1Res + "-" + player2Res;
            }

            if (player1Point > player2Point && player1Point < 4)
            {
                if (player1Point == 2)
                    player1Res = "Thirty";
                if (player1Point == 3)
                    player1Res = "Forty";
                if (player2Point == 1)
                    player2Res = "Fifteen";
                if (player2Point == 2)
                    player2Res = "Thirty";
                score = player1Res + "-" + player2Res;
            }
            if (player2Point > player1Point && player2Point < 4)
            {
                if (player2Point == 2)
                    player2Res = "Thirty";
                if (player2Point == 3)
                    player2Res = "Forty";
                if (player1Point == 1)
                    player1Res = "Fifteen";
                if (player1Point == 2)
                    player1Res = "Thirty";
                score = player1Res + "-" + player2Res;
            }

            if (player1Point > player2Point && player2Point >= 3)
            {
                score = "Advantage player1";
            }

            if (player2Point > player1Point && player1Point >= 3)
            {
                score = "Advantage player2";
            }

            if (player1Point >= 4 && player2Point >= 0 && (player1Point - player2Point) >= 2)
            {
                score = "Win for player1";
            }
            if (player2Point >= 4 && player1Point >= 0 && (player2Point - player1Point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private void P1Score()
        {
            player1Point++;
        }

        private void P2Score()
        {
            player2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == player1Name)
                P1Score();
            else if (player == player2Name)
                P2Score();
        }
    }
}