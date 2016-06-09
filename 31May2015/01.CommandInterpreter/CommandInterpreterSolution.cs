using System;
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

                    if (startIndex < 0 || startIndex >= initialCollection.Length ||
                        count < 0 || count >= initialCollection.Length)
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

                    if (startIndex < 0 || startIndex >= initialCollection.Length ||
                        count < 0 || count >= initialCollection.Length)
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
                    if (count < 0 || count >= initialCollection.Length)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        for (var iteration = 0; iteration < count; ++iteration)
                        {
                            var newCollection = new List<long>();

                            for (var i = 1; i < initialCollection.Length; ++i)
                            {
                                newCollection.Add(initialCollection[i]);
                            }
                            newCollection.Add(initialCollection[0]);

                            initialCollection = newCollection.ToArray();
                        }
                    }

                }
                else if (currentCommandParts[0] == "rollRight")
                {
                    var count = int.Parse(currentCommandParts[1]);
                    if (count < 0 || count >= initialCollection.Length)
                    {
                        Console.WriteLine("Invalid input parameters.");
                    }
                    else
                    {
                        for (var iteration = 0; iteration < count; ++iteration)
                        {
                            var newCollection = new List<long>();

                            newCollection.Add(initialCollection[initialCollection.Length - 1]);
                            for (var i = 0; i < initialCollection.Length - 1; ++i)
                            {
                                newCollection.Add(initialCollection[i]);
                            }

                            initialCollection = newCollection.ToArray();
                        }
                    }
                }

                currentCommand = Console.ReadLine();
            }

            PrintCollection(initialCollection);

        }

        private static long[] CreateInitialCollection()
        {
            return Console.ReadLine()
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(long.Parse)
                .ToArray();
        }

        private static void PrintCollection(IEnumerable<long> collection)
        {
            Console.Write("[");
            Console.Write(string.Join(", ", collection));
            Console.WriteLine("]");
        }
    }
}
