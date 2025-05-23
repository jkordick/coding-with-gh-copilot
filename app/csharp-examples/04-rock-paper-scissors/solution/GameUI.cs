// Create a GameUI class to handle user interface interactions
// Add methods to display the game menu, get player input, and show results
// Use different colors to enhance the user experience
// Display the game history and statistics

using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
    public class GameUI
    {
        private readonly GameLogic _gameLogic;

        public GameUI(GameLogic gameLogic)
        {
            _gameLogic = gameLogic;
        }

        public void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("====================================");
            Console.WriteLine("  WELCOME TO ROCK, PAPER, SCISSORS  ");
            Console.WriteLine("====================================");
            Console.ResetColor();
            Console.WriteLine();
        }

        public void DisplayGameRules()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=================");
            Console.WriteLine("  GAME RULES:    ");
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Rock crushes Scissors");
            Console.WriteLine("2. Scissors cuts Paper");
            Console.WriteLine("3. Paper covers Rock");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey(true);
        }

        public void DisplayMainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=================");
            Console.WriteLine("  MAIN MENU:     ");
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("1. Play a Round");
            Console.WriteLine("2. View Game Rules");
            Console.WriteLine("3. View Game History");
            Console.WriteLine("4. View Statistics");
            Console.WriteLine("5. Reset Game");
            Console.WriteLine("6. Exit Game");
            Console.WriteLine();
            Console.Write("Enter your choice (1-6): ");
        }

        public int GetMenuChoice(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out int choice) && choice >= min && choice <= max)
                {
                    return choice;
                }
                
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Invalid choice. Please enter a number between {min} and {max}: ");
                Console.ResetColor();
            }
        }

        public Move GetPlayerMove()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=================");
            Console.WriteLine("  SELECT YOUR MOVE:  ");
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"1. {_gameLogic.GetMoveDescription(Move.Rock)}");
            Console.WriteLine($"2. {_gameLogic.GetMoveDescription(Move.Paper)}");
            Console.WriteLine($"3. {_gameLogic.GetMoveDescription(Move.Scissors)}");
            Console.WriteLine();
            Console.Write("Enter your choice (1-3): ");
            
            int choice = GetMenuChoice(1, 3);
            return (Move)choice;
        }

        public void DisplayRoundResult(GameRound round)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=================");
            Console.WriteLine("  ROUND RESULT:  ");
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine();
            
            Console.Write("You chose: ");
            ConsoleColor playerColor = ConsoleColor.Blue;
            Console.ForegroundColor = playerColor;
            Console.WriteLine(_gameLogic.GetMoveDescription(round.PlayerMove));
            Console.ResetColor();
            
            Console.Write("Computer chose: ");
            ConsoleColor computerColor = ConsoleColor.Magenta;
            Console.ForegroundColor = computerColor;
            Console.WriteLine(_gameLogic.GetMoveDescription(round.ComputerMove));
            Console.ResetColor();
            
            Console.WriteLine();
            Console.ForegroundColor = GetResultColor(round.Result);
            Console.WriteLine(_gameLogic.GetResultDescription(round.Result, round.PlayerMove, round.ComputerMove));
            Console.ResetColor();
            
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        public void DisplayGameHistory(Game game)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=================");
            Console.WriteLine("  GAME HISTORY:  ");
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine();
            
            if (game.GameHistory.Count == 0)
            {
                Console.WriteLine("No rounds have been played yet.");
            }
            else
            {
                foreach (var round in game.GameHistory)
                {
                    Console.Write($"Round {round.RoundNumber}: ");
                    
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"You chose {round.PlayerMove}");
                    Console.ResetColor();
                    
                    Console.Write(", ");
                    
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"Computer chose {round.ComputerMove}");
                    Console.ResetColor();
                    
                    Console.Write(" - ");
                    
                    Console.ForegroundColor = GetResultColor(round.Result);
                    Console.WriteLine(round.Result);
                    Console.ResetColor();
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey(true);
        }

        public void DisplayGameStatistics(Game game)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=================");
            Console.WriteLine("  GAME STATISTICS:  ");
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine();
            
            if (game.TotalRounds == 0)
            {
                Console.WriteLine("No rounds have been played yet.");
            }
            else
            {
                Console.WriteLine($"Total Rounds Played: {game.TotalRounds}");
                Console.WriteLine();
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Player Wins: {game.PlayerScore} ({game.GetPlayerWinPercentage():F1}%)");
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Computer Wins: {game.ComputerScore} ({(double)game.ComputerScore / game.TotalRounds * 100:F1}%)");
                Console.ResetColor();
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Draws: {game.DrawCount} ({(double)game.DrawCount / game.TotalRounds * 100:F1}%)");
                Console.ResetColor();
                
                Console.WriteLine();
                Console.WriteLine("Player Move Distribution:");
                DisplayMoveDistribution(game.GetPlayerMoveStatistics(), game.TotalRounds);
                
                Console.WriteLine();
                Console.WriteLine("Computer Move Distribution:");
                DisplayMoveDistribution(game.GetComputerMoveStatistics(), game.TotalRounds);
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey(true);
        }

        public bool ConfirmReset()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("=================");
            Console.WriteLine("  RESET GAME:    ");
            Console.WriteLine("=================");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Are you sure you want to reset the game?");
            Console.WriteLine("All game history and statistics will be lost.");
            Console.WriteLine();
            Console.Write("Enter 'Y' to confirm or any other key to cancel: ");
            
            string input = Console.ReadLine().Trim().ToUpper();
            return input == "Y";
        }

        private ConsoleColor GetResultColor(GameResult result)
        {
            switch (result)
            {
                case GameResult.PlayerWin:
                    return ConsoleColor.Green;
                case GameResult.ComputerWin:
                    return ConsoleColor.Red;
                case GameResult.Draw:
                    return ConsoleColor.Yellow;
                default:
                    return ConsoleColor.White;
            }
        }

        private void DisplayMoveDistribution(Dictionary<Move, int> moveStats, int totalRounds)
        {
            foreach (var move in moveStats.Keys)
            {
                int count = moveStats[move];
                double percentage = (double)count / totalRounds * 100;
                
                Console.Write($"  {move}: {count} ({percentage:F1}%) ");
                
                // Display a simple bar graph
                int barLength = (int)(percentage / 5);
                Console.ForegroundColor = GetMoveColor(move);
                Console.WriteLine(new string('█', barLength));
                Console.ResetColor();
            }
        }

        private ConsoleColor GetMoveColor(Move move)
        {
            switch (move)
            {
                case Move.Rock:
                    return ConsoleColor.DarkGray;
                case Move.Paper:
                    return ConsoleColor.White;
                case Move.Scissors:
                    return ConsoleColor.Cyan;
                default:
                    return ConsoleColor.Gray;
            }
        }
    }
}