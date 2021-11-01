using System.Collections.Generic;

namespace Savanah
{
    public class GamePlay
    {
        public void Game(List<IAnimal>list,string[,]board, List<ValidPos> validPos)
        {
            AnimalActions animalActions = new AnimalActions();

            animalActions.AnimalMove(list,board,validPos);
            animalActions.AnimalHealth(list);
        }
    }
}
