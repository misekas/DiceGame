using DiceGame.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class MenuController
    {
        private Frame frame;
        private List<Button> createButton;
        private List<TextBlock> createTextBlock;
        private ConsoleKeyInfo enterKey;
        private int x = 38;
        private int y = 17;
        private int playerCount;
        private int setDiceCount;
        private int setPlayerCount;
        GameController gameController;

        public MenuController()
        {
            frame = new Frame(0, 39, 0, 118, '.');
            createButton = new List<Button>();
            createButton.Add(new Button(38, 3, 17, 20, "2 payers"));
            createButton.Add(new Button(57, 3, 17, 20, "3 payers"));
            createButton.Add(new Button(38, 3, 21, 20, "4 payers"));
            createButton.Add(new Button(57, 3, 21, 20, "5 payers"));
            createButton.Add(new Button(38, 3, 25, 20, "6 payers"));
            createButton.Add(new Button(57, 3, 25, 20, "7 payers"));
            createButton.Add(new Button(29, 3, 25, 18, "Play"));
            createButton.Add(new Button(71, 3, 25, 18, "Quit"));
            createButton.Add(new Button(50, 3, 25, 18, "Replay"));
            createTextBlock = new List<TextBlock>();
            createTextBlock.Add(new TextBlock(53, 10, 15, new List<String> { "-=DICE GAME!=-" }));
            createTextBlock.Add(new TextBlock(31, 22, 15, new List<String> { "P - play game." }));
            createTextBlock.Add(new TextBlock(73, 22, 15, new List<String> { "Q - quit game." }));
            createTextBlock.Add(new TextBlock(36, 10, 15, new List<String> { "Select how many players will play the game:" }));
            createTextBlock.Add(new TextBlock(40, 10, 15, new List<String> { "Select the amount of dice. Max 3 dice." }));
            createTextBlock.Add(new TextBlock(42, 11, 15, new List<String> { "Dice can be changed with keys +/-." }));
            createTextBlock.Add(new TextBlock(51, 22, 15, new List<String> { "R - replay game." }));
            createTextBlock.Add(new TextBlock(53, 10, 15, new List<String> { "GAME OVER!" }));
            gameController = new GameController();
        }
        public void MainMenu()
        {
            frame.Render();
            createButton[6].Render();
            createButton[7].Render();
            createTextBlock[0].Render();
            createTextBlock[1].Render();
            createTextBlock[2].Render();
            MainMeniuButtonSelections();
        }
        public void MainMeniuButtonSelections()
        { 
            do
            {
                Console.SetCursorPosition(53, 33);
                enterKey = Console.ReadKey();
                if (enterKey.Key == ConsoleKey.P)
                {
                    SelectPlayersCount();
                    break;
                }
                else if (enterKey.Key == ConsoleKey.Q || enterKey.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (enterKey.Key == ConsoleKey.R)
                {
                    gameController.PlayerRoll(setPlayerCount, setDiceCount);
                    Console.ReadKey();
                    GameOver();
                }
                else
                {
                    Console.WriteLine(" Wrong key!");
                    Console.ReadKey();
                    MainMenu();
                }

            } while (enterKey.Key != ConsoleKey.Escape); 
        }

        public void SelectPlayersCount()
        {
            frame.Render();
            createTextBlock[3].Render();
            for (int i = 0; i < 6; i++)
            {
                createButton[i].Render();
            }
            do
            {
                Button selectPlayerCount = new Button(x, 3, y, 20, $" {x} {y} ");

                selectPlayerCount.SetActive();
                selectPlayerCount.Render();

                enterKey = Console.ReadKey();
                if (enterKey.Key == ConsoleKey.RightArrow)
                {
                    x = 57;
                }
                else if (enterKey.Key == ConsoleKey.LeftArrow)
                {
                    x = 38;
                }
                else if (enterKey.Key == ConsoleKey.UpArrow)
                {
                    if (y == 25)
                    {
                        y = 21;
                    }
                    else if (y == 21)
                    {
                        y = 17;
                    }
                    else if (y == 17)
                    {
                        y = 17;
                    }
                }
                else if (enterKey.Key == ConsoleKey.DownArrow)
                {
                    if (y == 17)
                    {
                        y = 21;
                    }
                    else if (y == 21)
                    {
                        y = 25;
                    }
                    else if (y == 25)
                    {
                        y = 25;
                    }
                }
                playerCount = x + y;
                createTextBlock[3].Render();
                for (int i = 0; i < 6; i++)
                {
                    createButton[i].Render();
                }

                selectPlayerCount.SetInActive();

            } while (enterKey.Key != ConsoleKey.Enter);

            switch (playerCount)
            {
                case 55:
                    setPlayerCount = 2;
                    break;
                case 74:
                    setPlayerCount = 3;
                    break;
                case 59:
                    setPlayerCount = 4;
                    break;
                case 78:
                    setPlayerCount = 5;
                    break;
                case 63:
                    setPlayerCount = 6;
                    break;
                case 82:
                    setPlayerCount = 7;
                    break;
            }
            SelectDiceCount();
        }

            public void SelectDiceCount()
        {
            Console.Clear();
            frame.Render();
            createTextBlock[4].Render();
            createTextBlock[5].Render();
            int diceCount = 1;

            do
            {
            Console.SetCursorPosition(53, 18);
            Console.WriteLine($"{diceCount} - dice.");
            enterKey = Console.ReadKey();

            if (enterKey.Key == ConsoleKey.Add)
            {
                    diceCount++;
             }
            else if (enterKey.Key == ConsoleKey.Subtract)
            {
                    diceCount--;
            }
            else if (enterKey.Key == ConsoleKey.Enter)
                {
                    break;
                }
            else
                {
                    Console.SetCursorPosition(51, 20);
                    Console.WriteLine("Wrong key!");
                    Console.ReadKey();
                }
                
                if (diceCount > 3)
                {
                    Console.SetCursorPosition(51, 20);
                    Console.WriteLine("Max dice - 3!");
                    diceCount = 3;
                }
                else if (diceCount < 1)
                {
                    Console.SetCursorPosition(51, 20);
                    Console.WriteLine("Min dice - 1!");
                    diceCount = 1;
                }

            } while (enterKey.Key != ConsoleKey.Enter);

            switch (diceCount)
            {
                case 1:
                    setDiceCount = 1;
                    break;
                case 2:
                    setDiceCount = 2;
                    break;
                case 3:
                    setDiceCount = 3;
                    break;
            }
            gameController.PlayerRoll(setPlayerCount, setDiceCount);
            Console.ReadKey();
            GameOver();
        }

        public void GameOver()
        {
            frame.Render();
            createButton[6].Render();
            createButton[7].Render();
            createButton[8].Render();
            createTextBlock[7].Render();
            createTextBlock[1].Render();
            createTextBlock[2].Render();
            createTextBlock[6].Render();
            MainMeniuButtonSelections();
        }
    }
}
