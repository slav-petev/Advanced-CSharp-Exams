using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CommandInterpreter
{
    public class CommandInterpreterSolution
    {
        public static void Main()
        {
            var initialCollection = CreateInitialCollection();

            var currentCommand = Console.ReadLine();
            while (currentCommand != "end")
            {
                var currentCommandParts = currentCommand.Split();
                if (currentCommandParts[0] == "reverse")
                {
                    var startIndex = int.Parse(currentCommandParts[2]);
                    var count = int.Parse(currentCommandParts[4]);

                    if (startIndex < 0 || startIndex > initialCollection.Length - 1 ||
                        count < 0 || count > initialCollection.Length ||
                        count > initialCollection.Length - startIndex)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        Array.Reverse(initialCollection, startIndex, count);
                    }
                }
                else if (currentCommandParts[0] == "sort")
                {
                    var startIndex = int.Parse(currentCommandParts[2]);
                    var count = int.Parse(currentCommandParts[4]);

                    if (startIndex < 0 || startIndex > initialCollection.Length - 1 ||
                        count < 0 || count > initialCollection.Length ||
                        count > initialCollection.Length - startIndex)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        Array.Sort(initialCollection, startIndex, count);
                    }
                }
                else if (currentCommandParts[0] == "rollLeft")
                {
                    var count = int.Parse(currentCommandParts[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        var reversesCount = count % initialCollection.Length;
                        for (var iteration = 0; iteration < reversesCount; ++iteration)
                        {
                            Swap(ref initialCollection[0],
                                ref initialCollection[initialCollection.Length - 1]);

                            for (var i = 0; i < initialCollection.Length - 2; ++i)
                            {
                                Swap(ref initialCollection[i], ref initialCollection[i + 1]);
                            }
                        }
                    }
                }
                else if (currentCommandParts[0] == "rollRight")
                {
                    var count = int.Parse(currentCommandParts[1]);
                    if (count < 0)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        var reversesCount = count % initialCollection.Length;
                        for (var iteration = 0; iteration < reversesCount; ++iteration)
                        {
                            Swap(ref initialCollection[0],
                                ref initialCollection[initialCollection.Length - 1]);

                            for (var i = initialCollection.Length - 1; i > 1; --i)
                            {
                                Swap(ref initialCollection[i - 1], ref initialCollection[i]);
                            }
                        }
                    }
                }

                currentCommand = Console.ReadLine();
            }

            PrintCollection(initialCollection);
        }
        
        private static string[] CreateInitialCollection()
        {
            return Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
        }

        private static void PrintCollection(IEnumerable<string> collection)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", collection));
            Console.WriteLine("]");
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            var temp = first;
            first = second;
            second = temp;
        }
    }
}
