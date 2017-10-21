using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Everlight.Puzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PuzzleSystem.Initialize();
                int anticipatedIndex;
                do
                {
                    Console.WriteLine($"Anticipate the empty container by entering a positive integer (between 1 and {PuzzleSystem.SystemContainers.Count}) representing the anticipated container index followed by <Enter> or 0 to exit");
                    var userInput = Console.ReadLine();
                    bool parseresult = int.TryParse(userInput, out anticipatedIndex);
                    if (!parseresult || anticipatedIndex > PuzzleSystem.SystemContainers.Count)
                    {
                        Console.WriteLine($"Invalid input!! Please enter a positive integer (between 1 and {PuzzleSystem.SystemContainers.Count}) representing the anticipated container index followed by <Enter> or 0 to exit");
                    }
                    else if (anticipatedIndex > 0)
                    {
                        PuzzleSystem.Run();
                        if (PuzzleSystem.SystemContainers[anticipatedIndex - 1].Lenght == 0)
                        {
                            Console.WriteLine("Well Done! you anticipated it!!!");
                        }
                        else
                        {
                            var firstOrDefault = PuzzleSystem.SystemContainers.FirstOrDefault(sc => sc.Lenght == 0);
                            if (firstOrDefault != null)
                                Console.WriteLine(
                                    $"Keep trying... the actual empty index is {firstOrDefault.ContainerIndex}");
                        }
                    }
                } while (anticipatedIndex != 0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();

            }
         
        }
    }
}
