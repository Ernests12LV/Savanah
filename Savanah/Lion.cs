namespace Savanah
{
    class Lion : IAnimal
    {
        public Lion()
        {
            Health = 100;
            Name = Constants.Lion;
        }
        public int Health { get; set; }
        public int PosY { get; set; }
        public int PosX { get; set; }
        public string Name { get; set; }
    }
}
