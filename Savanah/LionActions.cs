using System.Collections.Generic;

namespace Savanah
{
    public class LionActions
    {
        public bool CheckForPrey(string [,] board, int y, int x)
        {
            bool CheckPrey = true;
            switch (y)
            {
                case 9:
                    y = 8;
                    break;
                case 0:
                    y = 1;
                    break;
            }
            switch (x)
            {
                case 9:
                    x = 8;
                    break;
                case 0:
                    x = 1;
                    break;
            }
            if (board[y - 1, x - 1] == Constants.Antelope) return CheckPrey;
            if (board[y - 1, x] == Constants.Antelope) return CheckPrey;
            if (board[y - 1, x + 1] == Constants.Antelope) return CheckPrey;
            if (board[y, x - 1] == Constants.Antelope) return CheckPrey;
            if (board[y, x + 1] == Constants.Antelope) return CheckPrey;
            if (board[y + 1, x - 1] == Constants.Antelope) return CheckPrey;
            if (board[y + 1, x] == Constants.Antelope) return CheckPrey;
            if (board[y + 1, x + 1] == Constants.Antelope) return CheckPrey;
            else
            {
                CheckPrey = false;
                return CheckPrey;
            }
        }
        public void GetPrey(string[,] board, int y, int x, IAnimal animal, List<IAnimal> list)
        {
            switch (y)
            {
                case 9:
                    y = 8;
                    break;
                case 0:
                    y = 1;
                    break;
            }
            switch (x)
            {
                case 9:
                    x = 8;
                    break;
                case 0:
                    x = 1;
                    break;
            }
            if (board[y - 1, x - 1] == Constants.Antelope) EatAntelope(animal,list, y - 1, x - 1);
            else if (board[y - 1, x] == Constants.Antelope) EatAntelope(animal, list, y - 1, x);
            else if (board[y - 1, x + 1] == Constants.Antelope) EatAntelope(animal, list, y - 1, x + 1);
            else if (board[y, x - 1] == Constants.Antelope) EatAntelope(animal, list,y, x - 1);
            else if (board[y, x + 1] == Constants.Antelope) EatAntelope(animal, list, y, x + 1);
            else if (board[y + 1, x - 1] == Constants.Antelope) EatAntelope(animal, list, y + 1, x - 1);
            else if (board[y + 1, x] == Constants.Antelope) EatAntelope(animal, list, y + 1, x);
            else if (board[y + 1, x + 1] == Constants.Antelope) EatAntelope(animal, list, y + 1, x + 1);
        }
        public void EatAntelope(IAnimal animal, List<IAnimal> list, int y, int x)
        {
            for (int i = 0; i < list.Count; i++)
            {
                    if (list[i].PosY == y && list[i].PosX == x)
                    {
                        list.Remove(list[i]);
                    }
            }
            animal.PosX = x;
            animal.PosY = y;
            animal.Health = 110;
        }
    }
}
