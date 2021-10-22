using System;
using System.Collections.Generic;

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
                    //position is free and safe
                    if (PosFree(board, MovePosY, MovePosX) && antelopeActions.IsPosSafe(board, MovePosY, MovePosX))
                    {
                        MoveRand(board, list[i], MovePosY, MovePosX);
                    }
                    //position is not safe or not free
                    else if (!PosFree(board, MovePosY, MovePosX) || !antelopeActions.IsPosSafe(board, MovePosY, MovePosX))
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
                    //position is not safe and not free
                    else if (!PosFree(board, MovePosY, MovePosX) && !antelopeActions.IsPosSafe(board, MovePosY, MovePosX))
                    {
                        board[MovePosY, MovePosX] = list[i].Name;
                    }
                }
                if (list[i].Name == Constants.Lion)
                {
                    if (lionActions.CheckForPrey(board, list[i].PosY, list[i].PosX))
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
            int currentPosY = animal.PosY;
            switch (MoveToPosY)
            {
                case 10:
                    MoveToPosY = 9;
                    break;
                case -1:
                    MoveToPosY = 0;
                    break;
            }
            int currentPosX = animal.PosX;
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
            board[currentPosY, currentPosX] = " ";
            board[MoveToPosY, MoveToPosX] = animal.Name;
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
    }
}

