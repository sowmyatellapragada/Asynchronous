using System;

namespace Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            AsyncAwaitDemo demo = new AsyncAwaitDemo();
            //demo.DoStuff().GetAwaiter().GetResult();

            //for (int count = 0; count < 10; count++)
            //{
            //    Console.WriteLine("Main thread: " + count);
            //}
            string results = "Hi";
            results = demo.LoadUrlContants();
            Console.WriteLine(results);
            Console.WriteLine("Read Complete");
            Console.ReadKey();
        }


    }
