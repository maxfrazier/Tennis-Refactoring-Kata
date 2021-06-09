using System.Collections.Generic;
using System.Linq;

namespace Tennis
{
    class TennisPlayers
    {
        public string player1Name;
        public string player2Name;
        public int player1Score;
        public int player2Score;
   
        /// <summary>
        /// Constructor for the TennisPlayers object.
        /// </summary>
        /// <param name="tp1Name">Name of tennis player 1.</param>
        /// <param name="tp2Name">Name of tennis player 2.</param>
        public TennisPlayers(string tp1Name, string tp2Name)
        {
            player1Name = tp1Name;
            player2Name = tp2Name;
        }
    }

    class TennisGame : ITennisGame
    {
        private TennisPlayers players;

        /// <summary>
        /// Begins a game of tennis by instantiating the TennisPlayers object.
        /// </summary>
        /// <param name="player1Name">Name of player 1.</param>
        /// <param name="player2Name">Name of player 2.</param>
        public TennisGame(string player1Name, string player2Name)
        {
            players = new TennisPlayers(player1Name, player2Name);
        }

        /// <summary>
        /// Updates the score using the name of the player who scored.
        /// </summary>
        /// <param name="playerName">Name of scoring player.</param>
        public void WonPoint(string playerName)
        {
            if(playerName == players.player1Name)
            {
                players.player1Score += 1;
            } 
            else
            {
                players.player2Score += 1;
            }
        }

        /// <summary>
        /// Gets the score of the Tennis Game.
        /// </summary>
        /// <returns>The current score of the tennis game.</returns>
        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (players.player1Score == players.player2Score)
            {
                switch (players.player1Score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (players.player1Score >= 4 || players.player2Score >= 4)
            {
                var difference = players.player1Score - players.player2Score;
                if (difference == 1) score = "Advantage player1";
                else if (difference == -1) score = "Advantage player2";
                else if (difference >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = players.player1Score;
                    else { score += "-"; tempScore = players.player2Score; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

