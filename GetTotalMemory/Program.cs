using System;

namespace GetTotalMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get memory in bytes
            long bytes1 = GC.GetTotalMemory(false);

            // 10 million bytes
            byte[] memory = new byte[1000 * 1000 * 10];
            // Set memory (prevent allocation from being optimized out)
            memory[0] = 1;

            // Get memory
            long bytes2 = GC.GetTotalMemory(false);
            long bytes3 = GC.GetTotalMemory(true);

            Console.WriteLine($"{bytes1.ToString().PadRight(15, ' ')} Program started with these bytes.");
            Console.WriteLine($"{bytes2.ToString().PadRight(15, ' ')} After ten million bytes allocated.");
            Console.WriteLine($"{(bytes2 - bytes1).ToString().PadRight(15, ' ')} Difference in memory.");
            Console.WriteLine($"{bytes3.ToString().PadRight(15, ' ')} After garbage colleciton.");
            Console.WriteLine($"{(bytes3 - bytes2).ToString().PadRight(15, ' ')} Difference in memory.");

            Console.ReadLine();
        }
    }
}
