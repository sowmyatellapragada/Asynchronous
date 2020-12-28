using System;

namespace Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            Demo1 demo = new Demo1();
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
