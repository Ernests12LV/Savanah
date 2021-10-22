using System;
using System.Collections.Generic;
using System.Threading;

namespace Savanah
{
    public class Program
    {
        static void Main()
        {
            List<IAnimal> list = new List<IAnimal>();
            BoardLogic logic = new BoardLogic();
            GamePlay gamePlay = new GamePlay();

            ConsoleKeyInfo c;

            string[,] board = new string[10, 10];

            do
            {
                logic.ReSetBoard(board);
                logic.CheckForAnimals(board, list);
                logic.DrawBoard(board, list);
                gamePlay.Game(list, board);
                Thread.Sleep(50);
                c = Console.ReadKey();

                logic.Add(board, c, list);
                Thread.Sleep(50);

            } while (c.Key != ConsoleKey.Escape);
        }
    }
}
