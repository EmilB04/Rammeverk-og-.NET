using Workshop.Data;

namespace Workshop.CsvParseCLI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Oppgave 1
            var dataParser = new DataParser();
            
            var temp1 = dataParser.ParseCsv("C:\\Users\\andyi\\Dropbox\\IT_Skole\\hiof\\.Net\\workshop\\workshop3\\Workshop\\infile\\names.csv", true, ',');

            Console.WriteLine(String.Join(',', temp1[0]));


            //Oppgave 2
            var filePath = new FileInfo("C:\\Users\\andyi\\Dropbox\\IT_Skole\\hiof\\.Net\\workshop\\workshop3\\Workshop\\infile\\names.csv");

            var parser_options = new ParserOptions
            {
                HasHeader = true
            };

            var temp2 = dataParser.ParseCsv(filePath, parser_options);

            Console.WriteLine(String.Join(',', temp2[0]));
        }
    }
}
