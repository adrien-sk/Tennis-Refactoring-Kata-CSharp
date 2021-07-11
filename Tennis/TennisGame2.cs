using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private Dictionary<int, string> scoreLabels = new Dictionary<int, string>{
            { 0, "Love" },
            { 1, "Fifteen" },
            { 2, "Thirty" },
            { 3, "Forty" }
        };

        private int player1Point = 0;
        private int player2Point = 0;
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

            if (IsScoreDeuce())
                score = "Deuce";

            if (IsScoreAll())
            {
                score = scoreLabels.GetValueOrDefault(player1Point) + "-All";
            }

            if (DoesPlayerHasAdvantage(player1Point, player2Point))
            {
                score = "Advantage player1";
            }

            if (DoesPlayerHasAdvantage(player2Point, player1Point))
            {
                score = "Advantage player2";
            }

            if (DoesPlayerWins(player1Point, player2Point))
            {
                score = "Win for player1";
            }

            if (DoesPlayerWins(player2Point, player1Point))
            {
                score = "Win for player2";
            }

            if (string.IsNullOrEmpty(score))
            {
                score = scoreLabels.GetValueOrDefault(player1Point) + "-" + scoreLabels.GetValueOrDefault(player2Point);
            }

            return score;
        }

        private bool IsScoreDeuce()
        {
            return player1Point == player2Point && player1Point > 2;
        }

        private bool IsScoreAll()
        {
            return player1Point == player2Point && player1Point < 3;
        }

        //Does 1st parameter player, has advantage over 2nd parameter player ?
        private bool DoesPlayerHasAdvantage(int firstPlayerPoint, int secondPlayerPoint)
        {
            return firstPlayerPoint > secondPlayerPoint && secondPlayerPoint >= 3;
        }

        //Does 1st parameter player Wins over 2nd parameter player ?
        private bool DoesPlayerWins(int firstPlayerPoint, int secondPlayerPoint)
        {
            return firstPlayerPoint >= 4 && (firstPlayerPoint - secondPlayerPoint) >= 2;
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