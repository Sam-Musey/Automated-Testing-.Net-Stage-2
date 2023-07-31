namespace DesignPrinciples
{
    public class Receiver
    {
        public Receiver() { }

        // --- Task 1 - count types - the number of car brands --- //
        public void CountNumberOfUniqueBrands()
        {
            // Here I use LINQ to group all cars by brand
            // To create such group I use a List<string> carBrandsList that is created in a Car class

            var uniqueBrands = Car.carBrandsList
                .GroupBy(brand => brand)
                .Select(group => new { Brand = group.Key, Count = group.Count() });

            Console.WriteLine("--------------------------------------------------\n" +
                    "This is the information about: \n" +
                    "1) All the unique brands of all your cars \n" +
                    "2) How many different models of those brands there are:");

            foreach (var brand in uniqueBrands)
            {
                Console.WriteLine($"-> {brand.Brand} - {brand.Count}");
            }
        }

        // --- Task 2 - count all - the total number of cars --- //
        public void CountAllCarsCommand()
		{
			int numberOfCars = 0;
			foreach (Car car in Car.carList)
			{
				numberOfCars += car.CarQuantity;
			}
			Console.WriteLine("--------------------------------------------------\n" +
                $"The total number of all cars of all brands is {numberOfCars}!");
        }

        // --- Task 3 - average price - the average cost of the car --- //
        public void AveragePriceOfAllCars()
		{
			int averagePrice = 0;
            foreach (Car car in Car.carList)
            {
                averagePrice += car.CarPrice;
            }
            averagePrice /= Car.carList.Count;
            Console.WriteLine($"--------------------------------------------------\n" +
                $"The average price of your cars is {averagePrice}!");
        }

        // --- Task 4  - average price type - the average cost of cars for each brand (the brand is set by the user) --- //
        public void AveragePriceOfBrand()
        {
            Console.WriteLine("--------------------------------------------------\n" +
                "Please, enter the car brand the average price of which you want to find out: ");
            string userCarBrand = Console.ReadLine();
            //int averagePriceByBrand;
            List<Car> carsOfOneBrand = Car.carList
                .Where(brand => brand.CarBrand.ToLower() == userCarBrand.ToLower()).ToList();

            int totalPrice = 0;
            int totalQuantity = 0;
            foreach (Car car in carsOfOneBrand)
            {
                totalPrice += car.CarPrice * car.CarQuantity;
                totalQuantity += car.CarQuantity;
            }
            int averagePriceByBrand = totalPrice / totalQuantity;
            Console.WriteLine($"--------------------------------------------------\n" +
                $"The average price of a car by brand {userCarBrand} is {averagePriceByBrand}!");
        }
    }
}

