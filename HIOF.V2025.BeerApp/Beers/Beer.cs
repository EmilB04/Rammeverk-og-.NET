namespace HIOF.V2025.BeerApp.Beers
{
    public class Beer
    {
        private string _name;
        private double _alcoholPercentage;

        public Beer(string name, double alcoholPercentage = 4.5)
        {
            _name = name;
            _alcoholPercentage = alcoholPercentage;

            var MyStruct = new MyStruct(5);
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double AlcoholPercentage
        {
            get { return _alcoholPercentage; }
            protected set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Alcohol percentage must be between 0 and 100");
                }
                _alcoholPercentage = value;
            }
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Name: {_name}, Alcohol percentage: {_alcoholPercentage}");
        }

        public static void Brew(int amountInLiters)
        {
            if (amountInLiters < 100 || amountInLiters > 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amountInLiters), "Amount must be between 100 and 1000");
            }
        }
    }
}