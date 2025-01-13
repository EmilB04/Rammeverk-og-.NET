using HIOF.V2025.BeerApp.Beers;

namespace HIOF.V2025.BeerApp.BeerCLI;

class Program
{
    static void Main(string[] args)
    {
        Beer beer = new Beer("Heineken", 4.7);
        Beer lager = new Lager("Aas", 4.5);
        Beer ale = new Ale("Brooklyn", 4.3);


        beer.PrintInfo();
        Console.WriteLine($"Beer: {beer.Name}");

        List<Beer> beers = new List<Beer> {
            beer,
            lager,
            ale
        };
        Console.WriteLine("Beers:");
        foreach (var b in beers) {
            b.PrintInfo();
        }

        Dictionary<string, Beer> beerDictionary = new Dictionary<string, Beer>();
        beerDictionary.Add(beer.Name, beer);

        Console.WriteLine("Beers in dictionary: ");
        foreach (var b in beerDictionary) {
            b.Value.PrintInfo();
        }
    }
}
