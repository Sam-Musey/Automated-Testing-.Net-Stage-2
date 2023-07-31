namespace Max_num_unequal_consecutive_char
{
    public class MaxNumberOfConsecutiveChars
    {
        public List<string> listOfFinalStrings = new List<string>();

        public MaxNumberOfConsecutiveChars() { }

        //This method prints the maximum number of unequal consecutive characters per line to the console.
        public void GetMaxNumberOfConsecutiveChars(string userInput = null)
        {
            if (userInput is null)
            {
                Console.Write("Type a string of characters, and then press Enter: ");
                userInput = Console.ReadLine();
            }

            int lengthOfUserString = userInput.Length;
            int count = 0;
            string temp = "";

            for (int i = 0; i < lengthOfUserString; i++)
            {
                int inside_count = 1;
                string inside_temp = "";

                for (int j = i + 1; j < lengthOfUserString; j++)
                {
                    if (inside_temp.Contains(userInput[j]) || userInput[i] == userInput[j])
                    {
                        break;
                    }
                    else
                    {
                        inside_count++;
                        inside_temp += userInput[j];
                    }
                }

                if (inside_count >= count)
                {
                    count = inside_count;
                    temp = userInput[i] + inside_temp;
                    listOfFinalStrings.Add(temp);

                    // This is a little tweak that lets store all final strings if they are of the same size
                    // If a new longer string is found, the whole list is cleared and new string is stored
                    if (temp.Length > listOfFinalStrings[0].Length)
                    {
                        listOfFinalStrings.Clear();
                        listOfFinalStrings.Add(temp);
                    }
                }

                // This if statement checks if the remaining number of characters to check is less than the current longest string of unique characters
                // If there is no point in continuing the for loop, then it just stops

                if (lengthOfUserString - (i + 1) < temp.Length)
                {
                    break;
                }
            }

            // This if statement checks if the length of the final longest string is of size 1
            // If it is, then all the characters of the string are repeating
            if (listOfFinalStrings.Last().Length == 1)
            {
                Console.WriteLine("All the characters from your string are identical!\n" +
                    $"And the repeating character is '{listOfFinalStrings.Last()}'.");
            }
            else
            {
                Console.WriteLine($"The maximum count of non repeating characters in your string is {count}.\n" +
                    $"And the string (or strings if there are several of them with the same length) is (are):");
                foreach (string item in listOfFinalStrings)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

