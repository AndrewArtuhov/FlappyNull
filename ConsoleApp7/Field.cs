using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7
{
    class Field
    {
        static int upperLimit = 0;
        static int lowerLimit = 20;

        public static void paintField()
        {
            for (int iField=upperLimit; iField < 30; iField++) {
                Console.SetCursorPosition(iField, upperLimit);
                Console.Write('\u2501');
                Console.SetCursorPosition(iField, lowerLimit);
                Console.Write('\u2501');
            }
        }
    }
}
