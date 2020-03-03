using System;

namespace GarbageCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass testClassInstance = new TestClass();
            Console.WriteLine("TestClass object is now on generation " + GC.GetGeneration(testClassInstance));
            Console.WriteLine();
            Console.WriteLine("Garbage Collection occured in Generation 0: " + GC.CollectionCount(0));
            Console.WriteLine("Garbage Collection occured in Generation 1: " + GC.CollectionCount(1));
            Console.WriteLine("Garbage Collection occured in Generation 2: " + GC.CollectionCount(2));
            Console.WriteLine();

            Console.WriteLine("Calling GC.Collect(0)");
            GC.Collect(0);
            Console.WriteLine();

            Console.WriteLine("Garbage Collection occured in Generation 0: " + GC.CollectionCount(0));
            Console.WriteLine("Garbage Collection occured in Generation 1: " + GC.CollectionCount(1));
            Console.WriteLine("Garbage Collection occured in Generation 2: " + GC.CollectionCount(2));

            Console.ReadLine();
        }
    }

    class TestClass
    {
    }
}
