using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp7
{
    class Logic
    {

        const int FreeSpace = 1;
        static int lightObstaclesD;
        static int lightObstaclesU;
        const int x = 10;
        static int y = 10;
        static int passedObstacles = 0;

        public static void ValueBorder()
        {
            Random rnd = new Random();
            if (passedObstacles <= 5) {
                lightObstaclesD = rnd.Next(5, 8);
                lightObstaclesU = rnd.Next(5, 8);
            }
            else if (passedObstacles <= 15)
            {
                lightObstaclesD = rnd.Next(6, 9);
                lightObstaclesU = rnd.Next(6, 9);
            }
            else
            {
                lightObstaclesD = rnd.Next(7, 11);
                lightObstaclesU = rnd.Next(7, 10);
            }
            
            if (lightObstaclesD + lightObstaclesU >= 18)
            {
                lightObstaclesU = lightObstaclesU - FreeSpace;
                lightObstaclesD = lightObstaclesD - FreeSpace;
            }

            if (lightObstaclesD == lightObstaclesU && lightObstaclesD + lightObstaclesU < 14)
            {
                lightObstaclesD = 14;
                lightObstaclesU = 2;
            }
            else if(lightObstaclesD == lightObstaclesU && lightObstaclesD + lightObstaclesU > 14)
            {
                lightObstaclesD = 2;
                lightObstaclesU = 14 ;
            }
        }

        public static bool Bird(ref int lengthTraversedPath, int startObstacles)
        {
            bool dead = false;
            DynamicObject.Obstacles(ref lengthTraversedPath, lightObstaclesD, lightObstaclesU, startObstacles);
            if (lengthTraversedPath == 0)
            {
                ValueBorder();
            }
            Console.SetCursorPosition(x, y);
            Console.Write("0");
            Thread.Sleep(170);
            Console.SetCursorPosition(x, y);
            Console.Write("\0");
            ConsoleKey key = ConsoleKey.Enter;
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true).Key;
            }
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    y--;
                    break;
                case ConsoleKey.Escape:
                    return true;
                default:
                    if (x % 2 == 0)
                        y++;
                    break;
            }
            if (startObstacles - lengthTraversedPath == x)
            {
                dead = CheckCollision(y, lightObstaclesD, lightObstaclesU);
            }
            else if (y == 0 || y == 20)
                dead = true;
            return dead;            
        }

        static bool CheckCollision(int y,int lightObstaclesD,int lightObstaclesU)
        {
            if( y <= lightObstaclesU || y >= 19 - lightObstaclesD )
            {
                return true;
            }
            passedObstacles++;
            return false;
        }
    }
}
