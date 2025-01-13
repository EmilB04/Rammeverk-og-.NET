namespace HIOF.V2025.BeerApp.Beers
{
    public class Lager(string name, double alcoholPercentage) : Beer(name, alcoholPercentage)
    {
        public override void PrintInfo() {
            base.PrintInfo();
            Console.WriteLine("Type: Lager");
            Name = "Aas";
        }
    }
}