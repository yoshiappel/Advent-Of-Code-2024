using System;
using System.Collections;
using System.Collections.Generic; 

namespace YA
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> leftNumbers = new List<int>();
            List<int> rightNumbers = new List<int>();

            Console.WriteLine("Enter the numbers");

            while (true)
            {
                string line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                    break;

                string[] parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int left) &&
                    int.TryParse(parts[1], out int right))
                {
                    leftNumbers.Add(left);
                    rightNumbers.Add(right);
                }
                else
                {
                    Console.WriteLine($"Invalid input line: {line}");
                }
            }
             
            leftNumbers.Sort();
            rightNumbers.Sort();

            if (leftNumbers.Count == rightNumbers.Count)
            {
                int total = 0;
                int similarity = 0;
                int similarityNumber = 0;
                int similarityTotal = 0;

                // for testing
                //Console.WriteLine("Left Numbers:");
                //Console.WriteLine(string.Join(", ", leftNumbers));

                //Console.WriteLine("Right Numbers:");
                //Console.WriteLine(string.Join(", ", rightNumbers));

                //Console.WriteLine(leftNumbers.Count);
                Console.WriteLine("The difference is");

                for (int i = 0; i < leftNumbers.Count; i++)
                {
                    int finalNumbers = Math.Abs(leftNumbers[i] - rightNumbers[i]);

                    total += finalNumbers;
                }

                for (int T = 0; T < leftNumbers.Count; T++)
                {
                    for (int z = 0; z < leftNumbers.Count; z++)
                    {
                        if (leftNumbers[T] == rightNumbers[z])
                        {
                            similarity++;
                            similarityNumber += leftNumbers[T] * similarity;
                            similarity = 0;
                        }

                    }


                }
                Console.WriteLine(similarityNumber);
                Console.WriteLine(total);

            } else {
                Console.WriteLine("invalid");
            }



        }
    }
}
