// Create an enum for Move (Rock, Paper, Scissors)
// Create a class to represent a game round with player move, computer move, and result
// Create an enum for result (PlayerWin, ComputerWin, Draw)
// Create a Game class to track score and game history

using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    public enum Move
    {
        Rock = 1,
        Paper = 2,
        Scissors = 3
    }

    public enum GameResult
    {
        PlayerWin,
        ComputerWin,
        Draw
    }

    public class GameRound
    {
        public int RoundNumber { get; set; }
        public Move PlayerMove { get; set; }
        public Move ComputerMove { get; set; }
        public GameResult Result { get; set; }
        public DateTime Timestamp { get; set; }

        public GameRound(int roundNumber, Move playerMove, Move computerMove, GameResult result)
        {
            RoundNumber = roundNumber;
            PlayerMove = playerMove;
            ComputerMove = computerMove;
            Result = result;
            Timestamp = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Round {RoundNumber}: Player chose {PlayerMove}, Computer chose {ComputerMove}, Result: {Result}";
        }
    }

    public class Game
    {
        public int PlayerScore { get; private set; }
        public int ComputerScore { get; private set; }
        public int DrawCount { get; private set; }
        public int TotalRounds => PlayerScore + ComputerScore + DrawCount;
        public List<GameRound> GameHistory { get; private set; }

        public Game()
        {
            PlayerScore = 0;
            ComputerScore = 0;
            DrawCount = 0;
            GameHistory = new List<GameRound>();
        }

        public void RecordRound(Move playerMove, Move computerMove, GameResult result)
        {
            // Update scores
            switch (result)
            {
                case GameResult.PlayerWin:
                    PlayerScore++;
                    break;
                case GameResult.ComputerWin:
                    ComputerScore++;
                    break;
                case GameResult.Draw:
                    DrawCount++;
                    break;
            }

            // Record the round in history
            GameRound round = new GameRound(TotalRounds, playerMove, computerMove, result);
            GameHistory.Add(round);
        }

        public void ResetGame()
        {
            PlayerScore = 0;
            ComputerScore = 0;
            DrawCount = 0;
            GameHistory.Clear();
        }

        public double GetPlayerWinPercentage()
        {
            if (TotalRounds == 0)
                return 0;
            
            return (double)PlayerScore / TotalRounds * 100;
        }

        public Dictionary<Move, int> GetPlayerMoveStatistics()
        {
            Dictionary<Move, int> moveStats = new Dictionary<Move, int>
            {
                { Move.Rock, 0 },
                { Move.Paper, 0 },
                { Move.Scissors, 0 }
            };

            foreach (var round in GameHistory)
            {
                moveStats[round.PlayerMove]++;
            }

            return moveStats;
        }

        public Dictionary<Move, int> GetComputerMoveStatistics()
        {
            Dictionary<Move, int> moveStats = new Dictionary<Move, int>
            {
                { Move.Rock, 0 },
                { Move.Paper, 0 },
                { Move.Scissors, 0 }
            };

            foreach (var round in GameHistory)
            {
                moveStats[round.ComputerMove]++;
            }

            return moveStats;
        }

        public Move GetMostUsedPlayerMove()
        {
            var stats = GetPlayerMoveStatistics();
            
            Move mostUsedMove = Move.Rock;
            int highestCount = 0;

            foreach (var move in stats.Keys)
            {
                if (stats[move] > highestCount)
                {
                    highestCount = stats[move];
                    mostUsedMove = move;
                }
            }

            return mostUsedMove;
        }
    }
}