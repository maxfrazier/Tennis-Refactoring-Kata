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
            switch (players.player1Score)
            {
                case 0:
                    switch (players.player2Score)
                    {
                        case 0:
                            return "Love-All";                                         //Player 1: 0 Player 2: 0
                        case 1:
                            return "Love-Fifteen";                                     //Player 1: 0 Player 2: 1
                        case 2: 
                            return "Love-Thirty";                                      //Player 1: 0 Player 2: 2
                        case 3:
                            return "Love-Forty";                                       //Player 1: 0 Player 2: 3
                        default:
                            return "Win for " + players.player2Name;                   //Player 1: 0 Player 2: >3                                                
                    }                    
                case 1:
                    switch (players.player2Score)
                    {
                        case 0:
                            return "Fifteen-Love";                                     //Player 1: 1 Player 2: 0
                        case 1:
                            return "Fifteen-All";                                      //Player 1: 1 Player 2: 1
                        case 2:
                            return "Fifteen-Thirty";                                   //Player 1: 1 Player 2: 2
                        case 3:
                            return "Fifteen-Forty";                                    //Player 1: 1 Player 2: 3
                        default:
                            return "Win for " + players.player2Name;                   //Player 1: 1 Player 2: >3                        
                    }                    
                case 2:
                    switch (players.player2Score)
                    {
                        case 0:
                            return "Thirty-Love";                                      //Player 1: 2 Player 2: 0
                        case 1:
                            return "Thirty-Fifteen";                                   //Player 1: 2 Player 2: 1
                        case 2:
                            return "Thirty-All";                                       //Player 1: 2 Player 2: 2
                        case 3:
                            return "Thirty-Forty";                                     //Player 1: 2 Player 2: 3
                        default:                        
                            return "Win for " + players.player2Name;                   //Player 1: 2 Player 2: >3                        
                    }                    
                case 3:
                    switch (players.player2Score)
                    {
                        case 0:
                            return "Forty-Love";                                       //Player 1: 3 Player 2: 0
                        case 1:
                            return "Forty-Fifteen";                                    //Player 1: 3 Player 2: 1
                        case 2:
                            return "Forty-Thirty";                                     //Player 1: 3 Player 2: 2
                        case 3:
                            return "Deuce";                                            //Player 1: 3 Player 2: 3
                        case 4:
                            return "Advantage " + players.player2Name;                 //Player 1: 3 Player 2: 4
                        default:
                            return "Win for " + players.player2Name;                   //Player 1: 3 Player 2: >4
                    }                    
                case 4:
                    switch (players.player2Score)
                    {                        
                        case 0: case 1: case 2:
                            return "Win for " + players.player1Name;                   //Player 1: 4 Player 2: 0/1/2
                        case 3:
                            return "Advantage " + players.player1Name;                 //Player 1: 4 Player 2: 3                        
                        case 4:
                            return "Deuce";                                            //Player 1: 4 Player 2: 4
                        case 5:
                            return "Advantage " + players.player2Name;                 //Player 1: 4 Player 2: 5
                        default:
                            return "Win for " + players.player2Name;                   //Player 1: 4 Player 2: >5
                    }                                      
                default:
                    int difference = players.player1Score - players.player2Score;
                    if(difference > 1) 
                    {
                        return "Win for " + players.player1Name;                       //Player 1 has at least 2 more points than player 2 and Player 1's score is higher than 4
                    }                                                                  
                    else if (difference < -1)
                    {
                        return "Win for " + players.player2Name;                       //Player 1 has scored 5 or more points but Player 2 has scored at least 2 more
                    }
                    else if (difference == 1)
                    {
                        return "Advantage " + players.player1Name;                     //Player 1 has scored 5 or more points and Player 2 has scored 1 less than that
                    }
                    else if (difference == -1)
                    {
                        return "Advantage " + players.player2Name;                     //Player 1 has scored 5 or more points and Player 2 has scored 1 more than that
                    }
                    break;                    
            }
            return "error";
        }
    }
}

