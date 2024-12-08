using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the numbers");

        // make the input list
        List<string> inputs = new List<string>();
        string input;

        // make a variable for setting the safenumber
        int safeNumber = 0;

        // while you dont press enter twice (copy paste will ignore this)
        while ((input = Console.ReadLine()) != "")
        {
            inputs.Add(input);
        }

        // check if the safenumber can be increased
        foreach (var row in inputs)
        {
            // the row in IsRowSafe or is the row in FixedSafe safe? then increase the safeNumber
            if (IsRowSafe(row) || FixedSafe(row))
            {
                safeNumber++;
            }
        }

        Console.WriteLine($"Number of safe rows: {safeNumber}");
    }

    // a function for checking if the row is safe
    static bool IsRowSafe(string row)
    {
        string[] parts = row.Split(' ');

        int[] numbers = Array.ConvertAll(parts, int.Parse);

        bool isAscending = false;
        bool isDescending = false;

        // a for loop for going through the entire list
        for (int i = 1; i < numbers.Length; i++)
        {
            int difference = numbers[i] - numbers[i - 1];

            // check if it doesnt have bigger gaps then 1 - 3
            if (Math.Abs(difference) < 1 || Math.Abs(difference) > 3)
            {
                return false;
            }

            // check if it doesnt icrease and decrease in the same row
            if (difference > 0)
            {
                if (isDescending) return false; 
                isAscending = true;
            }
            else if (difference < 0)
            {
                if (isAscending) return false; 
                isDescending = true;
            }
        }

        return true;
    }

    // a function for changing the row and then checking if it is safe
    static bool FixedSafe(string row)
    {
        string[] parts = row.Split(' ');
        int[] numbers = Array.ConvertAll(parts, int.Parse);

        for (int i = 0; i < numbers.Length; i++)
        {
            List<int> modifiedRow = new List<int>(numbers);
            modifiedRow.RemoveAt(i);

            // check if the row is safe using the IsRowSafe function with de modifiedRow
            if (IsRowSafe(string.Join(" ", modifiedRow)))
            {
                return true;
            }
        }

        return false;
    }
}
