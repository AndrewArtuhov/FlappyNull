using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{
    class DynamicObject
    {
        const int gameField = 19;
        public static void Obstacles(ref int lengthTraversedPath, int lightObstaclesD,int lightObstaclesU, int startObstacles)
        {
            try {
                for (int j = gameField; j > 0; j--)
                {
                    Console.SetCursorPosition(startObstacles - lengthTraversedPath + 1, j);
                    Console.Write("\0");
                }
                for (int i = 1; i < lightObstaclesU + 1; i++)
                {
                    Console.SetCursorPosition(startObstacles - lengthTraversedPath, i);
                    Console.Write("*");
                }
                for (int i = gameField; i > gameField - lightObstaclesD; i--)
                {
                    Console.SetCursorPosition(startObstacles - lengthTraversedPath, i);
                    Console.Write("*");
                }
                lengthTraversedPath++;
            }
            catch
            {
                lengthTraversedPath = 0;
            }
        }
    }
}
