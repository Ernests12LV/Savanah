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
                    i--;
                }
            }
        }
        public void AnimalMove(List<IAnimal> list, string[,] board, List<ValidPos> validPos)
        {
            AntelopeActions antelopeActions = new AntelopeActions();
            LionActions lionActions = new LionActions();

            for (int i = 0; i < list.Count; i++)
            {
                validPos.Clear();
                PossiblePositions(list, list[i], validPos);
                RandMovePos(list, list[i], validPos);
                if (list[i].Name == Constants.Antelope)
                {
                    while (!antelopeActions.IsPosSafe(list, MovePosY, MovePosX))
                    {
                        RandMovePos(list, list[i], validPos);
                        if (Stuck(list, list[i], validPos))
                        {
                            MovePosY = list[i].PosY;
                            MovePosX = list[i].PosX;
                            break;
                        }
                    }
                    Move(list[i], MovePosY, MovePosX);
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
        public bool Stuck(List<IAnimal> list, IAnimal animal, List<ValidPos> validPos)
        {
            bool stuck = false; ;
            if (PossiblePositions(list, animal, validPos).Count == 0)
            {
                stuck = true;
            }
            return stuck;
        }
        public int GenRandPos(int from, int to)
        {
            Random random = new Random();

            int roll;
            roll = random.Next(from, to);
            return roll;
        }
        public void RandMovePos(List<IAnimal> list, IAnimal animal, List<ValidPos> validPos)
        {
            int PosIndex = GenRandPos(0, (validPos.Count));
            if (PossiblePositions(list, animal, validPos).Count == 0)
            {
                MovePosY = animal.PosY;
                MovePosX = animal.PosX;
            }
            else
            {
                MovePosY = PossiblePositions(list, animal, validPos)[PosIndex].ValidPosY;
                MovePosX = PossiblePositions(list, animal, validPos)[PosIndex].ValidPosX;
            }
        }
        public void Move(IAnimal animal, int MoveToPosY, int MoveToPosX)
        {
            animal.PosY = MoveToPosY;
            animal.PosX = MoveToPosX;
        }
        public bool PosFree(List<IAnimal> list, int PosY, int PosX)
        {
            bool PosFree = true;
            if (OutOfBounds(PosY, PosX))
            {
                PosFree = false;
            }
            foreach (var animal in list)
            {
                if (animal.PosY == PosY && animal.PosX == PosX)
                {
                    PosFree = false;
                }
            }
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
        public bool ValidPositions(IAnimal animal, List<IAnimal> list, int PosY, int PosX)
        {
            AntelopeActions antelopeActions = new AntelopeActions();
            bool validPos = true;
            foreach (var item in list)
            {
                if (PosY == item.PosY && PosX == item.PosX)
                {
                    validPos = false;
                }
            }
            if (OutOfBounds(PosY, PosX))
            {
                validPos = false;
            }
            if (animal.Name == Constants.Antelope && !antelopeActions.IsPosSafe(list, PosY, PosX))
            {
                validPos = false;
            }
            if (!PosFree(list, PosY, PosX))
            {
                validPos = false;
            }
            return validPos;
        }
        public List<ValidPos> PossiblePositions(List<IAnimal> list, IAnimal animal, List<ValidPos> validPos)
        {
            ValidPos newValidPos;
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (ValidPositions(animal, list, (animal.PosY + y), (animal.PosX + x)))
                    {
                        newValidPos = new ValidPos();
                        newValidPos.ValidPosY = animal.PosY + y;
                        newValidPos.ValidPosX = animal.PosX + x;

                        validPos.Add(newValidPos);
                    }
                }
            }

            return validPos;
        }
        private bool Itself(IAnimal animal, int PosY, int PosX)
        {
            bool itSelf = animal.PosY == PosY && animal.PosX == PosX;

            return itSelf;
        }
    }
}

