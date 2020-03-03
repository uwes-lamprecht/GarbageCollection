using System;
using System.Text;

namespace CollectionCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Good Memory Usage (StringBuilder)");
            GoodMemoryUsage();

            Console.WriteLine(Environment.NewLine + "Bad Memory Usage (String)");
            BadMemoryUsage();

            Console.ReadLine();
        }

        private static void GoodMemoryUsage()
        {
            var tmp = new StringBuilder();
            // This loop does a lot of allocations!
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    tmp.Append(System.IO.Path.GetRandomFileName());
                    tmp.Append(System.IO.Path.GetRandomFileName());
                }
                System.Threading.Thread.Sleep(1);
            }

            // Display collection counts
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                int count = GC.CollectionCount(i);
                Console.WriteLine($"Collection count at generation {i}: {count}");
            }
            Console.WriteLine($"StringBuilder byte size: {tmp.Length}");
            Console.WriteLine($"StringBuilder.ToString() byte size: {tmp.ToString().Length}");
        }

        private static void BadMemoryUsage()
        {
            var tmp = System.IO.Path.GetRandomFileName();
            // This loop does a lot of allocations!
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 1000; j++)
                {
                    tmp += System.IO.Path.GetRandomFileName();
                    tmp += System.IO.Path.GetRandomFileName();
                }
                System.Threading.Thread.Sleep(1);
            }

            // Display collection counts
            for (int i = 0; i <= GC.MaxGeneration; i++)
            {
                int count = GC.CollectionCount(i);
                Console.WriteLine($"Collection count at generation {i}: {count}");
            }
            Console.WriteLine($"String byte size: {tmp.Length}");
        }
    }
}
