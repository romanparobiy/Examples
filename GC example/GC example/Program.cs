using System;

namespace GCExample
{
    class MyGCCollectClass
    {
        private const long maxGarbage = 1000000;

        static void Main()
        {
            MyGCCollectClass myGCCol = new MyGCCollectClass();

            myGCCol.MakeSomeGarbage();

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation of my class: {0}", GC.GetGeneration(myGCCol));

            // Determine the best available approximation of the number 
            // of bytes currently allocated in managed memory.
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            // Perform a collection of generation 0 only.
            GC.Collect(0);

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation of my class: {0}", GC.GetGeneration(myGCCol));

            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));

            // Perform a collection of all generations up to and including 2.
            GC.Collect(2);
            //GC.Collect();

            // Determine which generation myGCCol object is stored in.
            Console.WriteLine("Generation of my class: {0}", GC.GetGeneration(myGCCol));
            Console.WriteLine("Total Memory: {0}", GC.GetTotalMemory(false));
            Console.WriteLine("GC worked for 0 generation: {0} times", GC.CollectionCount(0));
            Console.WriteLine("GC worked for 1 generation: {0} times", GC.CollectionCount(1));
            Console.WriteLine("GC worked for 2 generation: {0} times", GC.CollectionCount(2));
            Console.Read();
        }

        void MakeSomeGarbage()
        {
            Version vt;

            for (int i = 0; i < maxGarbage; i++)
            {
                // Create objects and release them to fill up memory
                // with unused objects.
                vt = new Version();
            }
        }
    }
}