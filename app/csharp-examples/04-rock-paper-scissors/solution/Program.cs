// Create a Program class with a Main method to run the Rock, Paper, Scissors game
// Initialize the game components and start the game loop
// Allow the player to play multiple rounds and see statistics
// Include options to view rules, game history, and exit the game

using System;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize game components
            Game game = new Game();
            GameLogic gameLogic = new GameLogic();
            GameUI gameUI = new GameUI(gameLogic);
            
            // Display welcome message
            gameUI.DisplayWelcomeMessage();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
            
            bool exitGame = false;
            
            // Main game loop
            while (!exitGame)
            {
                // Display main menu and get user choice
                gameUI.DisplayMainMenu();
                int choice = gameUI.GetMenuChoice(1, 6);
                
                // Process user choice
                switch (choice)
                {
                    case 1: // Play a round
                        PlayRound(game, gameLogic, gameUI);
                        break;
                    
                    case 2: // View game rules
                        gameUI.DisplayGameRules();
                        break;
                    
                    case 3: // View game history
                        gameUI.DisplayGameHistory(game);
                        break;
                    
                    case 4: // View statistics
                        gameUI.DisplayGameStatistics(game);
                        break;
                    
                    case 5: // Reset game
                        if (gameUI.ConfirmReset())
                        {
                            game.ResetGame();
                            Console.WriteLine("Game has been reset.");
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey(true);
                        }
                        break;
                    
                    case 6: // Exit game
                        exitGame = true;
                        break;
                }
            }
            
            // Display goodbye message
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you for playing Rock, Paper, Scissors!");
            Console.WriteLine("Goodbye!");
            Console.ResetColor();
        }
        
        static void PlayRound(Game game, GameLogic gameLogic, GameUI gameUI)
        {
            // Get player's move
            Move playerMove = gameUI.GetPlayerMove();
            
            // Get computer's move
            // For more challenge, use the smart computer move which adapts to player's patterns
            // Move computerMove = gameLogic.GetSmartComputerMove(game);
            Move computerMove = gameLogic.GetComputerMove();
            
            // Determine the winner
            GameResult result = gameLogic.DetermineWinner(playerMove, computerMove);
            
            // Record the round
            game.RecordRound(playerMove, computerMove, result);
            
            // Display round result
            GameRound round = game.GameHistory[game.GameHistory.Count - 1];
            gameUI.DisplayRoundResult(round);
        }
    }
}