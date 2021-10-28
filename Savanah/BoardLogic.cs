using System;
using System.Collections.Generic;

namespace Savanah
{
    public class BoardLogic
    {
        public void DrawBoard(string[,] board, List<IAnimal> list)
        {
            AnimalActions animalActions = new AnimalActions();

            Console.Clear();
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    Console.Write(board[y, x]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("\nPress L to add a Lion or Press A to add Antelope press the 'Esc' key to quit.");
            foreach (var animal in list)
            {
                if (animal.Name == Constants.Lion)
                {
                    Console.WriteLine();
                    Console.WriteLine("lion's health :" + animal.Health + " posy-" + animal.PosY + " posx-" + animal.PosX);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("antelope's health :" + animal.Health + " posy-" + animal.PosY + " posx-" + animal.PosX);
                }
            }
        }

        public void Add(string[,] board, ConsoleKeyInfo c, List<IAnimal> list)
        {
            string animalToAdd = c.Key.ToString();

            if (animalToAdd == Constants.Lion)
            {
                AddAnimal(new Lion(), list);
            }

            if (animalToAdd == Constants.Antelope)
            {
                AddAnimal(new Antelope(), list);
            }
        }

        public void ReSetBoard(string[,] board)
        {
            for (int y = 0; y < board.GetLength(0); y++)
            {
                for (int x = 0; x < board.GetLength(1); x++)
                {
                    board[y, x] = " ";
                }
            }
        }

        public void CheckForAnimals(string[,] board, List<IAnimal> list)
        {
            foreach (var animal in list)
            {
                    board[animal.PosY, animal.PosX] = animal.Name;
            }
        }

        public void AddAnimal(IAnimal newAnimal, List<IAnimal> animals)
        {
            AnimalActions animalAction = new AnimalActions();

            int PosY = animalAction.GenRandPos(0, 10);
            int PosX = animalAction.GenRandPos(0, 10);

            if (animalAction.PosFree(animals, PosY, PosX))
            {
                newAnimal.PosX = PosY;
                newAnimal.PosY = PosX;
                animals.Add(newAnimal);
            }
        }
    }
}
