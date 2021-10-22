namespace Savanah
{
    public class Antelope : IAnimal
    {
        public Antelope()
        {
            Health = 150;
            Name = Constants.Antelope;
        }
        public int Health { get; set; }
        public int PosY { get; set; }
        public int PosX { get; set; }
        public string Name { get; set; }
    }
}
