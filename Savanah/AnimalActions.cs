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
                RandMovePos(list, list[i]);
                if (list[i].Name == Constants.Antelope)
                {
                    if (antelopeActions.IsPosSafe(list, MovePosY, MovePosX))
                    {
                        Move(list[i], MovePosY, MovePosX);
                    }
                    else if (!antelopeActions.IsPosSafe(list, MovePosY, MovePosX))
                    {
                        RandMovePos(list, list[i]);
                        while (!antelopeActions.IsPosSafe(list, MovePosY, MovePosX))
                        {
                            RandMovePos(list, list[i]);
                            if (Stuck(list))
                            {
                                MovePosY = list[i].PosY;
                                MovePosX = list[i].PosX;
                                break;
                            }
                        }
                        Move(list[i], MovePosY, MovePosX);
                    }
                }
                if (list[i].Name == Constants.Lion)
                {
                    if (lionActions.CheckForPrey(list, list[i]))
                    {
                        lionActions.GetPrey(list[i], list);
                    }
                    else
                    {
                        Move(list[i], MovePosY, MovePosX);
                    }
                }
            }
        }
        public bool Stuck(List<IAnimal> list)
        {
            AntelopeActions antelopeActions = new AntelopeActions();

            bool stuck;
            for (int y = -1; y <= 1; y++)
            {
                for (int x = -1; x <= 1; x++)
                {
                    if (OutOfBounds(MovePosY + y, MovePosX + x) || !PosFree(list, MovePosY + y, MovePosX + x) || !antelopeActions.IsPosSafe(list, MovePosY + y, MovePosX + x))
                    {
                        stuck = true;
                        return stuck;
                    }
                }
            }
            stuck = false;
            return stuck;
        }
        public int GenRandPos(int from, int to)
        {
            Random random = new Random();

            int roll;
            roll = random.Next(from, to);
            return roll;
        }
        public void RandMovePos(List<IAnimal> list, IAnimal animal)
        {
            do
            {
                MovePosY = animal.PosY + GenRandPos(-1, 2);
                MovePosX = animal.PosX + GenRandPos(-1, 2);
                
            } while (!PosFree(list, MovePosY, MovePosX) || OutOfBounds(MovePosY, MovePosX));
        }
        public void Move(IAnimal animal, int MoveToPosY, int MoveToPosX)
        {
            animal.PosY = MoveToPosY;
            animal.PosX = MoveToPosX;
        }
        public bool PosFree(List<IAnimal> list, int PosY, int PosX)
        {
            bool PosFree;
            if (OutOfBounds(PosY, PosX))
            {
                PosFree = false;
                return PosFree;
            }
            foreach (var animal in list)
            {
                if (animal.PosY == PosY && animal.PosX == PosX)
                {
                    PosFree = false;
                    return PosFree;
                }
            }
            PosFree = true;
            return PosFree;
        }
        public bool OutOfBounds(int PosY, int PosX)
        {
            bool outOfBounds = false;

            if (PosY > 9 || PosY < 0)
            {
                outOfBounds = true;
                return outOfBounds;
            }
            if (PosX > 9 || PosX < 0)
            {
                outOfBounds = true;
                return outOfBounds;
            }
            return outOfBounds;
        }
        public IEnumerable<IAnimal> AnimalsAround(List<IAnimal> animals, int PosY, int PosX)
        {
            IEnumerable<IAnimal> animalsAround =
            from animal in animals
            where animal.PosX >= PosX - 1 && animal.PosX <= PosX + 1 &&
                  animal.PosY >= PosY - 1 && animal.PosY <= PosY + 1 &&
                  !Itself(animal, PosY, PosX)
            select animal;

            return animalsAround;
        }
        private bool Itself(IAnimal animal, int PosY, int PosX)
        {
            bool itSelf = animal.PosY == PosY && animal.PosX == PosX;

            return itSelf;
        }
    }
}

