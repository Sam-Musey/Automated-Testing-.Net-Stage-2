using System.Text.RegularExpressions;

namespace Max_num_unequal_consecutive_char
{
    public class MaxNumberOfConsecutiveIdenticalLatinLetters
    {
        public List<string> listOfFinalStrings = new List<string>();
        public int count = 0;

        public MaxNumberOfConsecutiveIdenticalLatinLetters() { }

        // This method prints the maximum number of consecutive identical letters of the Latin alphabet
        public void GetMaxNumberOfConsecutiveIdenticalLatinLetters(string userInput = null)
        {
            if (userInput is null)
            {
                Console.Write("Type a string of characters (only Latin letters are allowed), and then press Enter: ");
                userInput = Console.ReadLine();
            }

            // Here we use regular expression to check if a string from user input contains only Latin letters
            string patternForLatinOnly = "^[a-zA-Z]+$";

            // For the sake of creating a new test method
            // this piece of code throws an Exception if the input string contains characters other than Latin letters
            if (Regex.IsMatch(userInput, patternForLatinOnly) is false)
            {
                throw new ArgumentException();
            }

            //while (Regex.IsMatch(userInput, patternForLatinOnly) != true)
            //{
            //    Console.Write("This method accepts only Latin letters as an input!\n" +
            //        "Please type a new string: --> ");
            //    userInput = Console.ReadLine();
            //}

            int lengthOfUserString = userInput.Length;
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
            // If it is, then there is no repeating letters in a string
            if (listOfFinalStrings.Last().Length == 1)
            {
                Console.WriteLine("There is no repeating consecutive letters in your string!");
            }
            else
            {
                Console.WriteLine($"The maximum count of non-repeating characters in your string is {count}.\n" +
                    $"And the string (or strings if there are several of them with the same length) is (are):");
                foreach (string item in listOfFinalStrings)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

