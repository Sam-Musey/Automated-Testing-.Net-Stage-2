using System.Text.RegularExpressions;

namespace Max_num_unequal_consecutive_char
{
	public class MaxNumberOfConsecutiveIdenticalDigits
	{
        public List<string> listOfFinalStrings = new List<string>();

        public MaxNumberOfConsecutiveIdenticalDigits() { }

        // This method prints the maximum number of consecutive identical digits
        public void GetMaxNumberOfConsecutiveIdenticalDigits(string userInput = null)
        {
            if (userInput is null)
            {
                Console.Write("Type a string of digits and then press Enter: ");
                userInput = Console.ReadLine();
            }

            // Here we use regular expression to check if a string from user input contains only digits
            string patternForDigitsOnly = "^[0-9]+$";
            while (Regex.IsMatch(userInput, patternForDigitsOnly) != true)
            {
                Console.Write("This method accepts only digits as an input!\n" +
                    "Please type a new string: --> ");
                userInput = Console.ReadLine();
            }

            int lengthOfUserString = userInput.Length;
            int count = 0;
            string temp;

            for (int i = 0; i < lengthOfUserString; i++)
            {
                int inside_count = 1;
                string inside_temp = "";

                for (int j = i + 1; j < lengthOfUserString; j++)
                {
                    if (userInput[i] == userInput[j])
                    {
                        inside_count++;
                        inside_temp += userInput[j];
                    }
                    else break;
                }

                if (inside_count >= count)
                {
                    count = inside_count;
                    temp = userInput[i] + inside_temp;
                    listOfFinalStrings.Add(temp);

                    // This is a little tweak that lets store all final strings if they are of the same size
                    // If a new longer string is found, the whole List<> is cleared and new string is stored
                    if (temp.Length > listOfFinalStrings[0].Length)
                    {
                        listOfFinalStrings.Clear();
                        listOfFinalStrings.Add(temp);
                    }
                }
            }

            // This if statement checks if the length of the final longest string is of size 1
            // If it is, then there is no repeating digits in a string
            if (listOfFinalStrings.Last().Length == 1)
            {
                Console.WriteLine("There is no repeating consecutive digits in your string!");
            }
            else
            {
                Console.WriteLine($"The maximum count of non-repeating digits in your string is {count}.\n" +
                    $"And the string (or strings if there are several of them with the same length) is (are):");
                foreach (string item in listOfFinalStrings)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

