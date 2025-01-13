namespace HIOF.V2025.BeerApp.Beers
{
    public class Ale : Beer
    {
        public Ale(string name, double alcoholPercentage) : base(name, alcoholPercentage)
        {
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Type: Ale");
        }
    }
}