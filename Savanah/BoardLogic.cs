using System;
using System.Collections.Generic;

namespace Savanah
{
    public class BoardLogic
    {
        public void DrawBoard(string[,] board,List<IAnimal> list)
        {
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
                    Console.WriteLine("Lion's Health :");
                    Console.WriteLine(animal.Health);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Antelope's Health :");
                    Console.WriteLine(animal.Health);
                }
            }
        }

        public void Add(string[,]board, ConsoleKeyInfo c, List<IAnimal> list)
        {
            string animalToAdd = c.Key.ToString();

            if (animalToAdd == Constants.Lion)
            {
                AddAnimal(board,new Lion(), list);
            }

            if (animalToAdd == Constants.Antelope)
            {
                AddAnimal(board,new Antelope(), list);
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
                if (animal.Name == Constants.Lion || animal.Name == Constants.Antelope)
                {
                    board[animal.PosY, animal.PosX] = animal.Name;
                }
            }
        }

        public void AddAnimal(string[,]board ,IAnimal newAnimal, List<IAnimal> animals)
        {
            AnimalActions animalAction = new AnimalActions();

            int PosY = animalAction.GenRandPos(0, 10);
            int PosX = animalAction.GenRandPos(0, 10);

            if (animalAction.PosFree(board,PosY,PosX))
            {
                newAnimal.PosX = PosY;
                newAnimal.PosY = PosX;
                animals.Add(newAnimal);
            }
        }

    }
}
