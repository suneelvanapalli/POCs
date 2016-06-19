using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncAwaitSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main method before async call" + Thread.CurrentThread.ManagedThreadId);

            var accesswebtask =  AccessTheWebAsync();

            Console.WriteLine("Main method after aync call" + Thread.CurrentThread.ManagedThreadId);
            Console.ReadKey();
        }

        static async Task<int> AccessTheWebAsync()
        {
            var client = new HttpClient();
            var getStringTask = client.GetStringAsync("http://msdn.microsoft.com");
            DoIndependentWork();

            string urlContents = await getStringTask;

            return urlContents.Length;

        }
        static void DoIndependentWork()
        {
            Console.WriteLine("Doing independent work" + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
