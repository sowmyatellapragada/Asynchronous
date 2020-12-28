using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Async_Await
{
    public class Demo1
    {
        private string urlContents;


        public  Task DoStuff()
        {
            var t = Task.Run(() =>
            {
                CountToFifty();
            });

            Console.WriteLine("Counting to 50 is completed");
            return t;
        }

        private void CountToFifty()
        {
            for (int count = 0; count < 10; count++)
            {
                Console.WriteLine("Background: " + count);
            }
        }

        public async Task<string> LoadUrlContants()
        {

            HttpClient client = new HttpClient();

            // Task<string> getStringTask = client.GetStringAsync("https://msdn.microsoft.com");
            // urlContents = await getStringTask;

            urlContents = await client.GetStringAsync("https://www.microsoft.com");
            if (urlContents == null)
            {
                urlContents = "No contants were collected";
            }
            else if (urlContents.Length == 0)
            {
                urlContents = "No contants were collected";
            }
            System.Threading.Thread.Sleep(1000);
            return urlContents;
        }
    }
}
