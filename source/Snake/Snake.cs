using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


class Program
{
    static void Main()
    {
        if (OperatingSystem.IsWindows())
        {
            Console.WindowHeight = 16;
            Console.WindowWidth = 32;
        }

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        Random randomNumber = new Random();

        Pixel head = new Pixel
        {
            xPos = screenWidth / 2,
            yPos = screenHeight / 2,
            screenColor = ConsoleColor.Red
        };

        List<int> axis = new List<int>(); // Initially empty, no body
        int score = 0;

        string obstacle = "*";
        int obstacleXpos = randomNumber.Next(1, screenWidth - 1);
        int obstacleYpos = randomNumber.Next(1, screenHeight - 1);

        while (true)
        {
            Console.Clear();

            // Draw Obstacle
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(obstacleXpos, obstacleYpos);
            Console.Write(obstacle);

            // Draw Snake Head
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(head.xPos, head.yPos);
            Console.Write("■");

            // Draw Snake Body
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < axis.Count; i += 2)
            {
                Console.SetCursorPosition(axis[i], axis[i + 1]);
                Console.Write("■");
            }

            // Draw Walls
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < screenWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("■");
                Console.SetCursorPosition(i, screenHeight - 1);
                Console.Write("■");
            }
            for (int i = 0; i < screenHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("■");
                Console.SetCursorPosition(screenWidth - 1, i);
                Console.Write("■");
            }

            // Display Score
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(1, screenHeight - 2);
            Console.WriteLine("Score: " + score);
            Console.ForegroundColor = ConsoleColor.White;

            // Move Snake
            ConsoleKeyInfo info = Console.ReadKey(true);
            int prevX = head.xPos;
            int prevY = head.yPos;

            switch (info.Key)
            {
                case ConsoleKey.UpArrow: head.yPos--; break;
                case ConsoleKey.DownArrow: head.yPos++; break;
                case ConsoleKey.LeftArrow: head.xPos--; break;
                case ConsoleKey.RightArrow: head.xPos++; break;
            }

            // Update Snake Body
            List<int> newBody = new List<int>();
            if (axis.Count > 0) // Only update if the snake has a body
            {
                newBody.Add(prevX);
                newBody.Add(prevY); // First segment follows the head
                for (int i = 0; i < axis.Count - 2; i += 2)
                {
                    newBody.Add(axis[i]);
                    newBody.Add(axis[i + 1]);
                }
            }
            axis = newBody;

            // Collision with Obstacle
            if (head.xPos == obstacleXpos && head.yPos == obstacleYpos)
            {
                score++;
                // Add a new segment at the current tail position
                if (axis.Count >= 2)
                {
                    axis.Add(axis[axis.Count - 2]);
                    axis.Add(axis[axis.Count - 1]);
                }
                else
                {
                    axis.Add(prevX);
                    axis.Add(prevY);
                }

                obstacleXpos = randomNumber.Next(1, screenWidth - 1);
                obstacleYpos = randomNumber.Next(1, screenHeight - 1);
            }

            // Collision with Walls
            if (head.xPos == 0 || head.xPos == screenWidth - 1 || head.yPos == 0 || head.yPos == screenHeight - 1)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                Console.WriteLine("Game Over");
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                Console.WriteLine("Your score is: " + score);
                Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);
                Environment.Exit(0);
            }

            // Collision with Self
            for (int i = 0; i < axis.Count; i += 2)
            {
                if (head.xPos == axis[i] && head.yPos == axis[i + 1])
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);
                    Console.WriteLine("Game Over");
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);
                    Console.WriteLine("Your score is: " + score);
                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);
                    Environment.Exit(0);
                }
            }

            Thread.Sleep(100); // Adjust speed of the snake
        }
    }
}