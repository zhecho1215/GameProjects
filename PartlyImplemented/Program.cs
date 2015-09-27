using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSpaceInvaders
{
    class Program
    {

        const int CountLevels = 4;//read only if the player can customize   
        const string SpaceShip = "_||*-W-||*_";
        static char[][,] levels = new char[CountLevels][,];
        static int rowOfEnemies = 1;

        static char[] enemies =
            {
                '@',
                '#',
                '+',
                '*',
            };
        private const int MaxHeight = 30;
        private const int MaxWidth = 70;
        private const int FieldWidth = MaxWidth / 2;

        private static int PlayerPositionX = FieldWidth / 2;
        private static int PlayerPositionY = MaxHeight - 2;

        private static int EnemiesPositionX = 0;
        private static int EnemiesPositionY = 0;

        static int currentLevel = 1;
        static int lives = 3;

        static void Main(string[] args)
        {
            Console.BufferHeight = Console.WindowHeight = MaxHeight;
            Console.BufferWidth = Console.WindowWidth = MaxWidth;
            Console.CursorVisible = false;
            Console.SetCursorPosition(PlayerPositionX, PlayerPositionY);
            Console.Write(SpaceShip);


            while (true)
            {

                char[,] currentLevelEnemies = new char[rowOfEnemies, FieldWidth];
                bool startLevel = new bool();

                if (EnemiesPositionX == 0 && EnemiesPositionY == 0)
                {
                    startLevel = true;
                }


                if (startLevel)
                {
                    CreatingLevel(levels, 1, enemies);
                    currentLevelEnemies = levels[currentLevel];
                }
                else
                {
                    currentLevelEnemies = CheckForDestroyedEnemies(currentLevelEnemies);
                }

                DrawingEnemies(currentLevelEnemies, EnemiesPositionX, EnemiesPositionY);


                var action = Console.ReadKey();
                if (action.Key == ConsoleKey.LeftArrow)
                {
                    PlayerPositionX--;
                    if (PlayerPositionX < 0)
                    {
                        PlayerPositionX = 0;
                    }
                }
                if (action.Key == ConsoleKey.RightArrow)
                {
                    PlayerPositionX++;
                    if (PlayerPositionX > FieldWidth)
                    {
                        PlayerPositionX = FieldWidth;
                    }
                }
                Console.Clear();
                Console.SetCursorPosition(PlayerPositionX, PlayerPositionY);
                Console.Write(SpaceShip);

            }


        }

        private static char[,] CheckForDestroyedEnemies(char[,] currentLevelEnemies)
        {
            throw new NotImplementedException();
        }

        private static void DrawingEnemies(char[,] currentLevelEnemies, int EnemiesPositionX, int EnemiesPositionY)
        {
            Console.SetCursorPosition(EnemiesPositionX, EnemiesPositionY);

            for (int r = 0; r < currentLevelEnemies.GetLength(0); r++)
            {
                for (int c = 0; c < currentLevelEnemies.GetLength(1); c++)
                {
                    Console.Write(currentLevelEnemies[r, c].ToString());
                }
                Console.WriteLine();
            }
        }

        private static void CreatingLevel(char[][,] levels, int currentLevel, char[] enemies)
        {
            //To Do Creation of Levels

            if (currentLevel < 2)
            {
                levels[currentLevel] = new char[rowOfEnemies, FieldWidth];
                for (int r = 0; r < rowOfEnemies; r++)
                {
                    for (int c = 0; c < FieldWidth; c++)
                    {
                        //for example
                        levels[currentLevel][r, c] = enemies[0];
                    }
                }
            }
        }
    }
}
