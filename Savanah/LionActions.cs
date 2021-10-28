using System.Collections.Generic;
using System.Linq;

namespace Savanah
{
    public class LionActions
    {
        public bool CheckForPrey(List<IAnimal> list,IAnimal animal)
        {
            bool CheckPrey = true;

            AnimalActions animalActions = new AnimalActions();

            foreach (var item in animalActions.AnimalsAround(list, animal.PosY, animal.PosX))
            {
                if (item.Name == Constants.Antelope)
                {
                    return CheckPrey;
                }
            }
                CheckPrey = false;
                return CheckPrey;
        }
        public void GetPrey(IAnimal animal, List<IAnimal> list)
        {
            AnimalActions animalActions = new AnimalActions();

            foreach (var item in animalActions.AnimalsAround(list, animal.PosY, animal.PosX))
            {
                if (item.Name == Constants.Antelope)
                {
                    EatAntelope(animal, list, item.PosY, item.PosX);
                    break;
                }
            }
        }
        public void EatAntelope(IAnimal animal, List<IAnimal> list, int y, int x)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].PosY == y && list[i].PosX == x)
                {
                    list[i].Health = 0;
                    
                }
            }
            animal.PosX = x;
            animal.PosY = y;
            animal.Health = 110;
        }
    }
}
