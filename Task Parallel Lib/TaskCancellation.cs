using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellationLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            CancellationToken ct = cts.Token;

            var task = Task.Factory.StartNew(() =>
            {
               
                ct.ThrowIfCancellationRequested();

                if (ct.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation requested before string task.");
                    throw new OperationCanceledException();
                }
                else
                {
                    Console.WriteLine("Starting task...");
                }               

                bool moreToDo = true;
                while (moreToDo)
                {
            
                    if (ct.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancellation requested during task execution.");
                        throw new OperationCanceledException();
                    }
                }
            }, cts.Token); 

            task.Wait(1000);
            cts.Cancel();
            try
            {
                task.Wait();
            }
            catch (AggregateException e)
            {
                foreach (var v in e.InnerExceptions)
                    Console.WriteLine(e.Message + " " + v.Message);
            }
            finally
            {
                cts.Dispose();
            }

            Console.Write("Hit a key to terminate...");
            Console.ReadKey();
        }
    }
}
