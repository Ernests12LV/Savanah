using System;
using System.Collections.Generic;
using System.Linq;

namespace Savanah
{
    public class AnimalActions
    {
        public int MovePosY;
        public int MovePosX;
        public void AnimalHealth(List<IAnimal> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i].Health -= 10;
                if (list[i].Health <= 0)
                {
                    list.Remove(list[i]);
                }
            }
        }
        public void AnimalMove(List<IAnimal> list, string[,] board)
        {
            AntelopeActions antelopeActions = new AntelopeActions();
            LionActions lionActions = new LionActions();

            for (int i = 0; i < list.Count; i++)
            {
                MovePosY = list[i].PosY + GenRandPos(-1, 2);
                MovePosX = list[i].PosX + GenRandPos(-1, 2);
                if (list[i].Name == Constants.Antelope)
                {
                    if (PosFree(board, MovePosY, MovePosX) && antelopeActions.IsPosSafe(list, list[i]))
                    {
                        MoveRand(board, list[i], MovePosY, MovePosX);
                    }
                    else if (!PosFree(board, MovePosY, MovePosX) || !antelopeActions.IsPosSafe(list, list[i]))
                    {
                        int PrevPosY = MovePosY;
                        int PrevPosX = MovePosX;
                        do
                        {
                            MovePosY = list[i].PosY + GenRandPos(-1, 2);
                            MovePosX = list[i].PosX + GenRandPos(-1, 2);
                        }
                        while (MovePosY == PrevPosY && MovePosX == PrevPosX);
                        MoveRand(board, list[i], MovePosY, MovePosX);
                    }
                    else if (!PosFree(board, MovePosY, MovePosX) && !antelopeActions.IsPosSafe(list, list[i]))
                    {
                        board[MovePosY, MovePosX] = list[i].Name;
                    }
                }
                if (list[i].Name == Constants.Lion)
                {
                    if (lionActions.CheckForPrey(list,list[i],board, list[i].PosY, list[i].PosX))
                    {
                        lionActions.GetPrey(board, list[i].PosY, list[i].PosX, list[i], list);
                    }
                    else if (PosFree(board, MovePosY, MovePosX))
                    {
                        MoveRand(board, list[i], MovePosY, MovePosX);
                    }
                }
            }
            
        }
        public int GenRandPos(int from, int to)
        {
            Random random = new Random();

            int roll;
            roll = random.Next(from, to);
            return roll;
        }
        public void MoveRand(string[,] board, IAnimal animal, int MoveToPosY, int MoveToPosX)
        {
            //int currentPosY = animal.PosY;
            switch (MoveToPosY)
            {
                case 10:
                    MoveToPosY = 9;
                    break;
                case -1:
                    MoveToPosY = 0;
                    break;
            }
            //int currentPosX = animal.PosX;
            switch (MoveToPosX)
            {
                case 10:
                    MoveToPosX = 9;
                    break;
                case -1:
                    MoveToPosX = 0;
                    break;
            }

            animal.PosY = MoveToPosY;
            animal.PosX = MoveToPosX;
            //board[currentPosY, currentPosX] = " ";
            //board[MoveToPosY, MoveToPosX] = animal.Name;
        }
        public bool PosFree(string[,] board, int PosY, int PosX)
        {
            //outside the bounds
            bool PosFree;
            switch (PosY)
            {
                case 10:
                    PosY = 9;
                    break;
                case -1:
                    PosY = 0;
                    break;
            }
            switch (PosX)
            {
                case 10:
                    PosX = 9;
                    break;
                case -1:
                    PosX = 0;
                    break;
            }

            if (board[PosY, PosX] == " ")
            {
                PosFree = true;
                return PosFree;
            }
            else PosFree = false;
            return PosFree;
        }
        public bool OutOfBounds(int Pos)
        {
            bool outOfBounds = false;

            if (Pos > 9 || Pos < 0)
            {
                outOfBounds = true;
                return outOfBounds;
            }
            return outOfBounds;
        }
        public IEnumerable<IAnimal> AnimalsAround(List<IAnimal> animals, IAnimal currentAnimal)
        {
            IEnumerable<IAnimal> animalsAround =
            from animal in animals
            where animal.PosX >= currentAnimal.PosX - 1 && animal.PosX <= currentAnimal.PosX + 1 &&
                  animal.PosY >= currentAnimal.PosY - 1 && animal.PosY <= currentAnimal.PosY + 1 &&
                  !Itself(animal, currentAnimal)
            select animal;

            return animalsAround;
        }
        private bool Itself(IAnimal animal, IAnimal currentAnimal)
        {
            bool itSelf = animal.PosY == currentAnimal.PosY && animal.PosX == currentAnimal.PosX;

            return itSelf;
        }
    }
}

