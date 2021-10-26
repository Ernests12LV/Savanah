using System.Collections.Generic;

namespace Savanah
{
    public class AntelopeActions
    {
        public bool IsPosSafe(List<IAnimal> list, IAnimal animal)
        {
            bool PosSafe;
            AnimalActions animalActions = new AnimalActions();

            foreach (var item in animalActions.AnimalsAround(list, animal))
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
