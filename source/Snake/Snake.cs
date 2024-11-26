using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


class Program

{

    static void Main()

    {

        Console.WindowHeight = 16;

        Console.WindowWidth = 32;

        int screenwidth = Console.WindowWidth;

        int screenheight = Console.WindowHeight;

        Random randomNumber = new Random();

        Pixel head = new Pixel();

        head.xPos = screenwidth / 2;

        head.yPos = screenheight / 2;

        head.screenColor = ConsoleColor.Red;

        string movement = "RIGHT";

        List<int> axis = new List<int>();

        int score = 0;

        List<int> positionsCount = new List<int>();



        positionsCount.Add(head.xPos);

        positionsCount.Add(head.yPos);



        DateTime tijd = DateTime.Now;

        string obstacle = "*";

        int obstacleXpos = randomNumber.Next(1, screenwidth);

        int obstacleYpos = randomNumber.Next(1, screenheight);

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

            for (int i = 0; i < screenwidth; i++)

            {

                Console.SetCursorPosition(i, 0);

                Console.Write("■");

            }

            for (int i = 0; i < screenwidth; i++)

            {

                Console.SetCursorPosition(i, screenheight - 1);

                Console.Write("■");

            }

            for (int i = 0; i < screenheight; i++)

            {

                Console.SetCursorPosition(0, i);

                Console.Write("■");

            }

            for (int i = 0; i < screenheight; i++)

            {

                Console.SetCursorPosition(screenwidth - 1, i);

                Console.Write("■");

            }

            Console.ForegroundColor =  ConsoleColor.Yellow;

            Console.WriteLine("Score: " + score);

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("H");

            for (int i = 0; i < axis.Count(); i++)

            {

                Console.SetCursorPosition(axis[i], axis[i + 1]);

                Console.Write("■");

            }

            //Draw Snake

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");

            Console.SetCursorPosition(head.xPos, head.yPos);

            Console.Write("■");



            ConsoleKeyInfo info = Console.ReadKey();

            //Game Logic

            switch (info.Key)

            {

                case ConsoleKey.UpArrow:

                    movement = "UP";

                    break;

                case ConsoleKey.DownArrow:

                    movement = "DOWN";

                    break;

                case ConsoleKey.LeftArrow:

                    movement = "LEFT";

                    break;

                case ConsoleKey.RightArrow:

                    movement = "RIGHT";

                    break;

            }

            if (movement == "UP")

                head.yPos--;

            if (movement == "DOWN")

                head.yPos++;

            if (movement == "LEFT")

                head.xPos--;

            if (movement == "RIGHT")

                head.xPos++;

            //Collision with obstacle

            if (head.xPos == obstacleXpos && head.yPos == obstacleYpos)

            {

                score++;

                obstacleXpos = randomNumber.Next(1, screenwidth);

                obstacleYpos = randomNumber.Next(1, screenheight);

            }

            positionsCount.Insert(0, head.xPos);

            positionsCount.Insert(1, head.yPos);

            positionsCount.RemoveAt(positionsCount.Count - 1);

            positionsCount.RemoveAt(positionsCount.Count - 1);

            //Collision with walls or with oneself

            if (head.xPos == 0 || head.xPos == screenwidth - 1 || head.yPos == 0 || head.yPos == screenheight - 1)

            {

                Console.Clear();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2);

                Console.WriteLine("Game Over");

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);

                Console.WriteLine("Your score is: " + score);

                Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);

                Environment.Exit(0);

            }

            for (int i = 0; i < axis.Count(); i += 2)

            {

                if (head.xPos == axis[i] && head.yPos == axis[i + 1])

                {

                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2);

                    Console.WriteLine("Game over");

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 1);

                    Console.WriteLine("Your score is: " + score);

                    Console.SetCursorPosition(screenwidth / 5, screenheight / 2 + 2);

                    Environment.Exit(0);

                }

            }

            Thread.Sleep(50);

        }

    }

}




