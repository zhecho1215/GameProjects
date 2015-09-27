
using System;
using System.Collections.Generic;
using System.Threading;

class SpaceInvaders
{
    // here are all variables that we need to be used more often in both the Main and the additional methods.
    private const int MaxHeight = 30;
    private const int MaxWidth = 70;
    private const int FieldWidth = MaxWidth/2;

    private static int PlayerPositionX = FieldWidth / 2;
    private static int PlayerPositionY = MaxHeight - 2;
    static List<int[]> enemies = new List<int[]>(); // the enemies and shots are List because this list holds all the enemies and shots currently on the field so they can drawn. Each enemy and object consists of PositionX and PositionY that is why they are saved in List from int array.
    static List<int[]> shots = new List<int[]>();

    private static char playerSymbol = 'W'; // it looks the most as a spaceship to me
    private static char enemySymbol = '@'; // looks the angriest
    private static char shotSymbol = ':'; // just random shots

    static Random generator = new Random(); // this is the generator for the starting position of the enemies.

    static void Main()
    {
        // I set the size of the Console it can be changed easily from the constants above
        Console.BufferHeight = Console.WindowHeight = MaxHeight;
        Console.BufferWidth = Console.WindowWidth = MaxWidth;
        
        int lives = 3;

        while (lives > 0)
        {
            // Draw
            DrawField();
            DrawResultTable();

            // Logic
            while (Console.KeyAvailable)
            {
                var keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.RightArrow)
                {
                    if (PlayerPositionX < FieldWidth)
                    {
                        PlayerPositionX++;
                    }
                }
                if (keyPressed.Key == ConsoleKey.LeftArrow)
                {
                    if (PlayerPositionX > 1)
                    {
                        PlayerPositionX--;
                    }
                }
                if (keyPressed.Key == ConsoleKey.DownArrow)
                {
                    if (PlayerPositionY < MaxHeight - 2)
                    {
                        PlayerPositionY++;
                    }
                }
                if (keyPressed.Key == ConsoleKey.UpArrow)
                {
                    if (PlayerPositionY > 1)
                    {
                        PlayerPositionY--;
                    }
                }

               
                
            }
            
            Thread.Sleep(200); // decide how much do you want to slow the game.
            //Clear. If the console is not cleared the object will be drawn multiple times and it will looks like there is no movement.
            Console.Clear();
        }
    }

    private static void DrawResultTable()
    {
        FieldBarrier();
        // TODO all the information we are going to think of.
    }

    private static void FieldBarrier()
    {
        // TODO drawing a straight line so the user can see the size of his field.
    }

    private static void DrawField()
    {      
        DrawEnemies();
        DrawShots();
        DrawPlayer();
    }

    private static void DrawPlayer()
    {
       int[] playerPosition = {PlayerPositionX, PlayerPositionY};
       ConsoleColor playerColor = ConsoleColor.Black; // choose whatever you like;
       DrawAtCoordinates(playerPosition, playerColor, playerSymbol);
    } 

    private static void DrawShots()
    {
       // TODO. They start from the player position and going upwards so their PostitionY--; 
    }

    private static void DrawEnemies()
    {
        // TODO They start from the top position and going downwards so their PostitionY++; 
    }
    private static void DrawAtCoordinates(int[] objectPostion, ConsoleColor objectColor, char objectSymbol)
    {
        Console.SetCursorPosition(objectPostion[0], objectPostion[1]);
        Console.ForegroundColor = objectColor;
        Console.WriteLine(objectSymbol);
        Console.CursorVisible = false;
    }
}
