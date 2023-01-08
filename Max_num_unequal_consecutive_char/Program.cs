using System;

string userInput = "";

// Ask the user to type the string of characters .
Console.Write("Type a string of characters, and then press Enter: ");
userInput = Console.ReadLine();

int lengthOfUserString = userInput.Length;
int count = 0;
string temp = "";

for (int i = 0; i < lengthOfUserString; i++)
{
    int inside_count = 1;
    string inside_temp = "";
    //cur_temp += userInput[i];
    for (int j = i + 1; j < lengthOfUserString; j++)
    {
        //
        //cur_temp += userInput[i];
        if (inside_temp.Contains(userInput[j]) || userInput[i] == userInput[j])
        {
            break;
        }
        else
        {
            inside_count += 1;
            inside_temp += userInput[j];
        }
    }
    if (inside_count > count)
    {
        count = inside_count;
        temp = userInput[i] + inside_temp;
    }
}

Console.WriteLine($"The count is {count}. And the string is {temp}!");
Console.ReadKey();