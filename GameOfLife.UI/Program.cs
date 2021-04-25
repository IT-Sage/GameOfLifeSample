using GameOfLife.Model;
using GameOfLife.Model.Enums;
using System;

namespace GameOfLife.UI
{
    class Program
    {
        private const int Size = 50;
        static void Main(string[] args)
        {
            Universe universe = Universe.Create(Size);
            for (int i = 0; i < 1000; i++)
            {
                DrawUniverse(universe.NextMoment());
            }
        }

        static void DrawUniverse(State[,] universeState)
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (universeState[i, j] == State.Live)
                    {
                        Console.Write("X|");
                    }
                    else
                    {
                        Console.Write(" |");
                    }
                }
                Console.WriteLine();
            }

            for (int i = 0; i < Size; i++)
            {
                Console.Write("__");
            }
            Console.WriteLine();
        }
    }
}
