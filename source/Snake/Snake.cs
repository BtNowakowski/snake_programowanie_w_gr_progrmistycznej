using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


class Program

{

    static void Main()

    {


        if (OperatingSystem.IsWindows()){
        Console.WindowHeight = 16;

        Console.WindowWidth = 32;
        }

        int screenWidth = Console.WindowWidth;
        int screenHeight = Console.WindowHeight;

        Random randomNumber = new Random();

        Pixel head = new Pixel();

        head.xPos = screenWidth / 2;

        head.yPos = screenHeight / 2;

        head.screenColor = ConsoleColor.Red;


        List<int> axis = new List<int>();

        int score = 0;

        List<int> positionsCount = new List<int>();



        positionsCount.Add(head.xPos);

        positionsCount.Add(head.yPos);



        DateTime tijd = DateTime.Now;

        string obstacle = "*";

        
        int obstacleXpos = randomNumber.Next(1, Math.Max(2, screenWidth - 1));
        int obstacleYpos = randomNumber.Next(1, Math.Max(2, screenHeight - 1));

        while (true)

        {

            Console.Clear();

            //Draw Obstacle

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.SetCursorPosition(obstacleXpos, obstacleYpos);

            Console.Write(obstacle);



            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");



            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < screenWidth; i++)

            {

                Console.SetCursorPosition(i, 0);

                Console.Write("■");

            }

            for (int i = 0; i < screenWidth; i++)

            {

                Console.SetCursorPosition(i, screenHeight - 1);

                Console.Write("■");

            }

            for (int i = 0; i < screenHeight; i++)

            {

                Console.SetCursorPosition(0, i);

                Console.Write("■");

            }

            for (int i = 0; i < screenHeight; i++)

            {

                Console.SetCursorPosition(screenWidth - 1, i);

                Console.Write("■");

            }

            Console.ForegroundColor =  ConsoleColor.Yellow;

            Console.WriteLine("Score: " + score);

            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < axis.Count(); i++)

            {

                Console.SetCursorPosition(axis[i], axis[i + 1]);

                Console.Write("■");

            }


            ConsoleKeyInfo info = Console.ReadKey();

            //Game Logic

            switch (info.Key)
            {
                case ConsoleKey.UpArrow:
                    head.yPos--;
                    break;

                case ConsoleKey.DownArrow:
                    head.yPos++;
                    break;

                case ConsoleKey.LeftArrow:
                    head.xPos--;
                    break;

                case ConsoleKey.RightArrow:
                    head.xPos++;
                    break;

            }

            //Collision with obstacle

            if (head.xPos == obstacleXpos && head.yPos == obstacleYpos)

            {

                score++;

                obstacleXpos = randomNumber.Next(1, screenWidth);

                obstacleYpos = randomNumber.Next(1, screenHeight);


            }

            
          

            //Collision with walls or with oneself

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

            for (int i = 0; i < axis.Count(); i += 2)
            {

                if (head.xPos == axis[i] && head.yPos == axis[i + 1])

                {

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2);

                    Console.WriteLine("Game over");

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 1);

                    Console.WriteLine("Your score is: " + score);

                    Console.SetCursorPosition(screenWidth / 5, screenHeight / 2 + 2);

                    Environment.Exit(0);

                }

            }

            Thread.Sleep(50);

        }

    }

}




