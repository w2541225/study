using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    public static class Tester
    {
        public async static void TestAsync()
        {
            Console.WriteLine(" 我是线程" + Thread.CurrentThread.ManagedThreadId);
            Task<int> t = await GetCostTime();

        }

        public async static Task<int> GetCostTime()
        {
            Task<int> t = Task.Factory.StartNew(() =>
             {
                 Thread.Sleep(10000);
                 return 10000;
             });
            return t.Result;


        }
    }
}
