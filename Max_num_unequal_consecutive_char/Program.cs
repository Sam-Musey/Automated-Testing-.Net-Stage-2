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
    int cur_count = 1;
    string cur_temp = "";
    //cur_temp += userInput[i];
    for (int j = i + 1; j < lengthOfUserString; j++)
    {
        //
        //cur_temp += userInput[i];
        if (cur_temp.Contains(userInput[j]) || userInput[i] == userInput[j])
        {
            break;
        }
        else
        {
            cur_count += 1;
            cur_temp += userInput[j];
        }
    }
    if (cur_count > count)
    {
        count = cur_count;
        temp = userInput[i] + cur_temp;
    }
}

Console.WriteLine($"The count is {count}. And the string is {temp}!");
Console.ReadKey();