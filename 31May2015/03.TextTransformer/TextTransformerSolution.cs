using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.TextTransformer
{
    class TextTransformerSolution
    {
        private static readonly Regex _importantInfo =
            new Regex(@"\$[^\$%&']+\$|%[^\$%&']+%|&[^\$%&']+&|'[^\$%&']+'");

        static void Main()
        {
            var encryptedInput = CreateInput();
            var matches = _importantInfo.Matches(encryptedInput);

            var decryptedOutput = new StringBuilder();
            foreach (Match match in matches)
            {
                var decryptedWord = DecryptWord(match.Value);
                decryptedOutput.AppendFormat($"{decryptedWord} ");
            }

            Console.WriteLine(decryptedOutput);
        }

        private static string CreateInput()
        {
            var inputBuilder = new StringBuilder();

            var nextInputLine = Console.ReadLine();
            while (nextInputLine != "burp")
            {
                inputBuilder.Append(nextInputLine);
                nextInputLine = Console.ReadLine();
            }
            var inputWithRedundantSpaces = inputBuilder.ToString();
            var inputWithoutRedundantSpaces =
                Regex.Replace(inputWithRedundantSpaces, @"\s+", " ");

            return inputWithoutRedundantSpaces;

        }

        private static string DecryptWord(string encryptedWord)
        {
            var coefficient = GetCoefficient(encryptedWord[0]);
            var content = encryptedWord.Substring(1, encryptedWord.Length - 2);

            var wordBuilder = new StringBuilder();
            for (var i = 0; i < content.Length; ++i)
            {
                char currentSymbol;
                if (i % 2 == 0)
                {
                    currentSymbol = (char)(content[i] + coefficient);
                }
                else
                {
                    currentSymbol = (char)(content[i] - coefficient);
                }
                wordBuilder.Append(currentSymbol);
            }

            return wordBuilder.ToString();
        }

        private static int GetCoefficient(char symbol)
        {
            switch (symbol)
            {
                case '$':
                    return 1;
                case '%':
                    return 2;
                case '&':
                    return 3;
                case '\'':
                    return 4;
                default:
                    return 0;
            }
        }
    }
}
