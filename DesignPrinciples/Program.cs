namespace DesignPrinciples;
class Program
{
    static void Main(string[] args)
    {
        // In our task we should have used Singleton pattern, so I decided to implement Invoker as a singleton class
        // So I instantiate Invoker class by GetInstance() method
        // Receiver is instantiated inside Invoker (singleton) class
        // I understand there is no actual need to use Singleton class in such a program, but we use it for the sake of learning and practising

        // Instantiation of a receiver and an invoker
        Invoker.GetInstance();

        // Manual creation of 10 cars
        Car car1 = new Car("Volvo", "v90", 2, 53000);
        Car car2 = new Car("Volvo", "v60", 3, 47000);
        Car car3 = new Car("BMW", "M5", 2, 110000);
        Car car4 = new Car("Jiguli", "06", 4, 5000);
        Car car5 = new Car("Audi", "Q7", 2, 51000);
        Car car6 = new Car("Tesla", "Model 3", 5, 42000);
        Car car7 = new Car("Tesla", "Model Y", 1, 44000);
        Car car8 = new Car("Volkswagen", "Polo", 4, 19200);
        Car car9 = new Car("Volkswagen", "Passat", 2, 47000);
        Car car10 = new Car("Mini", "Countryman", 3, 34000);

        // Welcome our user and invite him/her to create new cars

        Console.WriteLine("--- Welcome to our program! ---\n" +
            "We already have 10 cars in our park.\n\n" +
            "Do you want to make your own car? (Y/N)");

        // This code processes the input from user (only Y or N are valid as input)

        string userResponse = Console.ReadLine();
        bool createNewCarOrNot = true;
        if (userResponse.ToLower() == "n")
        {
            createNewCarOrNot = false;
        }

        while (userResponse.ToLower() != "y" && userResponse.ToLower() != "n")
        {
            Console.WriteLine("Please type either Y or N");
            userResponse = Console.ReadLine();

            if (userResponse.ToLower() == "y")
            {
                break;
            }
            if (userResponse.ToLower() == "n")
            {
                createNewCarOrNot = false;
                break;
            }
        }

        // This code asks user to input 4 parameters to create a new car(s)
       
        while (createNewCarOrNot)
        {
            Console.WriteLine("Great! You've decided to make your own car!\n");
            Console.WriteLine("-> Please enter the brand of your car: ");
            string userCarBrand = Console.ReadLine();
            Console.WriteLine("-> Please enter the model of your car: ");
            string userCarModel = Console.ReadLine();
            Console.WriteLine("-> Please enter the price of your car: ");
            int userCarPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("-> Please enter the quantity of your car: ");
            int userCarQuantity = int.Parse(Console.ReadLine());

            Car newCarByUser = new Car(userCarBrand, userCarModel, userCarQuantity, userCarPrice);
            Console.WriteLine($"Congratulations! You've just created a new car(s): brand - {newCarByUser.CarBrand}, model - {newCarByUser.CarModel}, quantity - {newCarByUser.CarQuantity}, price - {newCarByUser.CarPrice}!");
            Car.carList.Add(newCarByUser);

            Console.WriteLine("Do you want to make another car(s)?");

            userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "n")
            {
                createNewCarOrNot = false;
            }
        }

        // Testing all 4 commands
        Console.WriteLine($"\n--- Now it's time to test all commands! ---\n");

        while (true)
        {
            Console.WriteLine("> Type '1' to display the number of car brands\n" +
                              "> Type '2' to display the total number of all cars\n" +
                              "> Type '3' to display the average cost of the car\n" +
                              "> Type '4' to display the average cost of cars of a particular brand (you will specify the brand)\n");
            int userInputForCommand = int.Parse(Console.ReadLine());
            switch (userInputForCommand)
            {
                case 1:
                    Invoker.GetInstance().CountCarsBrands();
                    break;
                case 2:
                    Invoker.GetInstance().CountAllCars();
                    break;
                case 3:
                    Invoker.GetInstance().AveragePriceOfAllCars();
                    break;
                case 4:
                    Invoker.GetInstance().AveragePriceOfBrand();
                    break;
                default:
                    Console.WriteLine("There is no such option. Please choose again from 1 to 4");
                    break;
            }
            Console.WriteLine("--------------------------------------------------\n" +
                "Do you want to execute another command? (Y/N)");

            string userChoiceToContinue = Console.ReadLine();

            if (userChoiceToContinue.ToLower() != "y")
            {
                break;
            }
        }

        Console.WriteLine("\nPlease enter any key to exit the program...");
        Console.ReadKey();
    }
}

