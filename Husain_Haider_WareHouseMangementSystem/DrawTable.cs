using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseMangementSystem
{
    internal class DrawTable
    {
        public static void Draw(int rows, int cols, int cellWidth)
        {
            string horizontalLine = "┌" + string.Join("┬", new string[cols].Select(_ => new string('─', cellWidth))) + "┐";
            string middleLine = "├" + string.Join("┼", new string[cols].Select(_ => new string('─', cellWidth))) + "┤";
            string bottomLine = "└" + string.Join("┴", new string[cols].Select(_ => new string('─', cellWidth))) + "┘";

            Console.WriteLine(horizontalLine);

            for (int r = 0; r < rows; r++)
            {
                Console.Write("│");
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(new string(' ', cellWidth) + "│");
                }
                Console.WriteLine();

                if (r < rows - 1)
                    Console.WriteLine(middleLine);
            }

            Console.WriteLine(bottomLine);
        }

    }
}
