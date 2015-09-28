using System;
using System.Collections.Generic;
using System.Threading;

class SpaceInvaders
{
    // here are all variables that we need to be used more often in both the Main and the additional methods.
    private const int MaxHeight = 30;
    private const int MaxWidth = 70;
    private const int FieldWidth = MaxWidth / 3; // I made the field smaller because otherwise you cannot catch all the enemies.

    private static int PlayerPositionX = FieldWidth / 2;
    private static int PlayerPositionY = MaxHeight - 2;
    static List<int[]> enemies = new List<int[]>(); // the enemies and shots are List because this list holds all the enemies and shots currently on the field so they can drawn. Each enemy and object consists of PositionX and PositionY that is why they are saved in List from int array.
    static List<int[]> shots = new List<int[]>();

    private static char playerSymbol = 'W'; // it looks the most as a spaceship to me
    private static char enemySymbol = '@'; // looks the angriest
    private static char shotSymbol = ':'; // just random shots

    static int pause = 0; // here I am adjusting the enemies being spawn because there were too many.
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
            SpawnEnemies();    // I moved the spawning of the enemies outside the keyavailable loop because otherwise not a single enemy is spawn if you don't click a button.
            FieldBarrier();

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
                if (keyPressed.Key == ConsoleKey.Spacebar)
                {
                    shots.Add(new int[] { PlayerPositionX, PlayerPositionY });
                }
            }

            Thread.Sleep(50); // decide how much do you want to slow the game. // 200 was too slow for me
            //Clear. If the console is not cleared the object will be drawn multiple times and it will looks like there is no movement. We need to think of an way to clear withour clearing the barrier because right now if we slow the game a little bit more and the barrier will start to flicker.
            Console.Clear();
        }
    }


    private static void DrawResultTable()
    {

        // TODO all the information we are going to think of.
    }

    private static void FieldBarrier()
    {
        // TODO we need to think of an a way to draw the barrier outside the while and after that we need make a clear method which doesn't remove it
        for (int i = 0; i < MaxHeight; i++)
        {
            DrawAtCoordinates(new int[] { FieldWidth + 1, i }, ConsoleColor.Black, '|');
        }
    }

    private static void DrawField()
    {
        DrawEnemies();
        DrawShots();
        DrawPlayer();
    }

    private static void DrawPlayer()
    {
        int[] playerPosition = { PlayerPositionX, PlayerPositionY };
        ConsoleColor playerColor = ConsoleColor.Green; // choose whatever you like; // changed to Green so it's more visible
        DrawAtCoordinates(playerPosition, playerColor, playerSymbol);
    }

    private static void DrawShots()
    {
        // TODO. When it gets outside the field we need to remove it from the list not just made it hidden, because the list will become enormously big. 
        foreach (var shot in shots)
        {
            DrawAtCoordinates(new[] { shot[0], shot[1] }, ConsoleColor.DarkBlue, shotSymbol);
            shot[1]--;
        }
    }

    private static void DrawEnemies()
    {
        // TODO They start from the top position and going downwards so their PostitionY++; 
        foreach (var enemy in enemies)
        {
            // I changed the drewing of the enemies to remove the flickering. There is a drawAtCoordinates method which is handling all the drawing. So use it don't repeat the code everywhere.
            if (enemy[1] != MaxHeight - 1)
            {
                DrawAtCoordinates(new[] { enemy[0], enemy[1] }, ConsoleColor.DarkRed, enemySymbol);
                enemy[1]++;
            }
        }
    }
    private static void DrawAtCoordinates(int[] objectPostion, ConsoleColor objectColor, char objectSymbol)
    {
        Console.SetCursorPosition(objectPostion[0], objectPostion[1]);
        Console.ForegroundColor = objectColor;
        Console.WriteLine(objectSymbol);
        Console.CursorVisible = false;
    }
    private static void SpawnEnemies()
    {
        // I made the enemies less because there were just too man to handle and also made them spawn from the higher because some of the enemies spawned at the center
        if (pause % 4 == 0)
        {
            int spawningWidth = generator.Next(0, FieldWidth);
            int spawningHeight = generator.Next(0, MaxHeight / 6);
            enemies.Add(new int[] { spawningWidth, spawningHeight });
            pause = 0;
        }
        pause++;
    }
}
