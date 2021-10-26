using System.Collections.Generic;
using System.Linq;

namespace Savanah
{
    public class LionActions
    {
        public bool CheckForPrey(List<IAnimal> list,IAnimal animal,string[,] board, int y, int x)
        {
            bool CheckPrey = true;
            //switch (y)
            //{
            //    case 9:
            //        y = 8;
            //        break;
            //    case 0:
            //        y = 1;
            //        break;
            //}
            //switch (x)
            //{
            //    case 9:
            //        x = 8;
            //        break;
            //    case 0:
            //        x = 1;
            //        break;
            //}

            //if (board[y - 1, x - 1] == Constants.Antelope) return CheckPrey;
            //if (board[y - 1, x] == Constants.Antelope) return CheckPrey;
            //if (board[y - 1, x + 1] == Constants.Antelope) return CheckPrey;
            //if (board[y, x - 1] == Constants.Antelope) return CheckPrey;
            //if (board[y, x + 1] == Constants.Antelope) return CheckPrey;
            //if (board[y + 1, x - 1] == Constants.Antelope) return CheckPrey;
            //if (board[y + 1, x] == Constants.Antelope) return CheckPrey;
            //if (board[y + 1, x + 1] == Constants.Antelope) return CheckPrey;
            //else
            //{
            //    CheckPrey = false;
            //    return CheckPrey;
            //}

            AnimalActions animalActions = new AnimalActions();

            foreach (var item in animalActions.AnimalsAround(list, animal))
            {
                if (item.Name == Constants.Antelope)
                {
                    return CheckPrey;
                }
            }
                CheckPrey = false;
                return CheckPrey;
        }
        public void GetPrey(string[,] board, int y, int x, IAnimal animal, List<IAnimal> list)
        {
            AnimalActions animalActions = new AnimalActions();

            foreach (var item in animalActions.AnimalsAround(list,animal))
            {
                if (item.Name == Constants.Antelope)
                {
                    EatAntelope(animal, list, item.PosY, item.PosX);
                }
            }
        }

        public void EatAntelope(IAnimal animal, List<IAnimal> list, int y, int x)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].PosY == y && list[i].PosX == x)
                {
                    //list.Remove(list[i]);
                    list[i].Health = 0;
                }
            }
            animal.PosX = x;
            animal.PosY = y;
            animal.Health = 110;
        }
    }
}
