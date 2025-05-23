// Create a GameLogic class that implements the rules of Rock, Paper, Scissors
// Add a method for the computer to select a random move
// Add a method to determine the winner based on player and computer moves
// The rules are: Rock beats Scissors, Scissors beats Paper, Paper beats Rock

using System;

namespace RockPaperScissors
{
    public class GameLogic
    {
        private readonly Random _random;

        public GameLogic()
        {
            _random = new Random();
        }

        public Move GetComputerMove()
        {
            // Generate a random number between 1 and 3 (inclusive)
            int randomNumber = _random.Next(1, 4);
            
            // Convert the random number to a Move enum value
            return (Move)randomNumber;
        }

        public GameResult DetermineWinner(Move playerMove, Move computerMove)
        {
            // If both players choose the same move, it's a draw
            if (playerMove == computerMove)
                return GameResult.Draw;

            // Apply the rules of Rock, Paper, Scissors
            switch (playerMove)
            {
                case Move.Rock:
                    return computerMove == Move.Scissors ? GameResult.PlayerWin : GameResult.ComputerWin;
                
                case Move.Paper:
                    return computerMove == Move.Rock ? GameResult.PlayerWin : GameResult.ComputerWin;
                
                case Move.Scissors:
                    return computerMove == Move.Paper ? GameResult.PlayerWin : GameResult.ComputerWin;
                
                default:
                    throw new ArgumentException("Invalid move");
            }
        }

        public string GetMoveDescription(Move move)
        {
            switch (move)
            {
                case Move.Rock:
                    return "Rock (crushes Scissors)";
                case Move.Paper:
                    return "Paper (covers Rock)";
                case Move.Scissors:
                    return "Scissors (cuts Paper)";
                default:
                    return move.ToString();
            }
        }

        public string GetResultDescription(GameResult result, Move playerMove, Move computerMove)
        {
            switch (result)
            {
                case GameResult.PlayerWin:
                    return $"You win! {GetWinReason(playerMove, computerMove)}";
                case GameResult.ComputerWin:
                    return $"Computer wins! {GetWinReason(computerMove, playerMove)}";
                case GameResult.Draw:
                    return "It's a draw!";
                default:
                    return result.ToString();
            }
        }

        private string GetWinReason(Move winningMove, Move losingMove)
        {
            switch (winningMove)
            {
                case Move.Rock when losingMove == Move.Scissors:
                    return "Rock crushes Scissors.";
                case Move.Paper when losingMove == Move.Rock:
                    return "Paper covers Rock.";
                case Move.Scissors when losingMove == Move.Paper:
                    return "Scissors cuts Paper.";
                default:
                    return string.Empty;
            }
        }

        // Advanced: Smart computer move based on player history
        public Move GetSmartComputerMove(Game game)
        {
            // If less than 3 rounds have been played, use random move
            if (game.TotalRounds < 3)
                return GetComputerMove();
            
            // Get the player's most used move
            Move mostUsedPlayerMove = game.GetMostUsedPlayerMove();
            
            // Choose the move that beats the player's most frequent move
            switch (mostUsedPlayerMove)
            {
                case Move.Rock:
                    return Move.Paper;  // Paper beats Rock
                case Move.Paper:
                    return Move.Scissors;  // Scissors beats Paper
                case Move.Scissors:
                    return Move.Rock;  // Rock beats Scissors
                default:
                    return GetComputerMove();
            }
        }
    }
}