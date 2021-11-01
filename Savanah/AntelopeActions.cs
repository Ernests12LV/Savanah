using System.Collections.Generic;

namespace Savanah
{
    public class AntelopeActions
    {
        public bool IsPosSafe(List<IAnimal> list, int PosY, int PosX)
        {
            bool PosSafe;
            AnimalActions animalActions = new AnimalActions();

            foreach (var item in animalActions.AnimalsAround(list, PosY, PosX))
            {
                if (item.Name == Constants.Lion)
                {
                    PosSafe = false;
                    return PosSafe;
                }
            }
            PosSafe = true;
            return PosSafe;
        }
    }
}
