using System.Collections.Generic;

namespace Savanah
{
    public class GamePlay
    {
        public void Game(List<IAnimal>list,string[,]board)
        {
            AnimalActions animalActions = new AnimalActions();

            animalActions.AnimalMove(list,board);
            animalActions.AnimalHealth(list);
        }
    }
}
