namespace Max_num_unequal_consecutive_char
{
    class Program
    {
        static void Main(string[] args)
        {
            MaxNumberOfConsecutiveChars maxNumberOfConsecutiveChars = new MaxNumberOfConsecutiveChars();
            MaxNumberOfConsecutiveIdenticalDigits maxNumberOfConsecutiveIdenticalDigits = new MaxNumberOfConsecutiveIdenticalDigits();
            MaxNumberOfConsecutiveIdenticalLatinLetters maxNumberOfConsecutiveIdenticalLatinLetters = new MaxNumberOfConsecutiveIdenticalLatinLetters();

            // --- Uncomment this piece of code to try --- Maximum number of consecutive chars --- //
            maxNumberOfConsecutiveChars.GetMaxNumberOfConsecutiveChars("iknowsomething");
            //maxNumberOfConsecutiveChars.GetMaxNumberOfConsecutiveChars();

            // --- Uncomment this piece of code to try --- Maximum number of consecutive identical digits --- //
            //maxNumberOfConsecutiveIdenticalDigits.GetMaxNumberOfConsecutiveIdenticalDigits("3216554");
            //maxNumberOfConsecutiveIdenticalDigits.GetMaxNumberOfConsecutiveIdenticalDigits();

            // --- Uncomment this piece of code to try --- Maximum number of consecutive identical latin letters --- //
            //maxNumberOfConsecutiveIdenticalLatinLetters.GetMaxNumberOfConsecutiveIdenticalLatinLetters("twollines");
            //maxNumberOfConsecutiveIdenticalLatinLetters.GetMaxNumberOfConsecutiveIdenticalLatinLetters();

            //try
            //{
            //    maxNumberOfConsecutiveIdenticalLatinLetters.GetMaxNumberOfConsecutiveIdenticalLatinLetters("эксидэнтл эррор");
            //}
            //catch (ArgumentException ex)
            //{
            //    Console.WriteLine($"Looks like you typed an invalid string! Error message is following:\n{ex.Message}");
            //}

            Console.ReadKey();
        }
    }
}