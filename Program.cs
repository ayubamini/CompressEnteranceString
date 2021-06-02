using System;
using System.Collections.Generic;

namespace StringRepetitionCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, Enter a string: ");
            var input = Console.ReadLine();

            Console.WriteLine("Compress of string: ");
            Console.WriteLine(Compress(input));


            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static string Compress(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return "Input is not valid";

            var dictionary
                = new List<KeyValuePair<char, int>>();

            for (int i = 0; i < input.Length; i++)
            {
                dictionary.Add(new KeyValuePair<char, int>(input[i], 
                    CountOfCharactersContainInputString(input[i], input)));
            }

            return PrintResult(dictionary);
        }

        private static int CountOfCharactersContainInputString(char character, string input)
        {
            var count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == character)
                    count++;
            }

            return count;
        }

        private static string PrintResult(List<KeyValuePair<char, int>> dictionary)
        {
            var output = string.Empty;

            foreach (var item in dictionary)
            {
                if (output.Contains(item.Key + item.Value.ToString()))
                    continue;

                if (item.Value > 1)
                    output += item.Key + item.Value.ToString();
                else
                    output += item.Key;
            }

            return output;
        }
    }
}
