using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Example
    {
        #region Test1

        public void Test1()
        {
            PagePaint();
        }
        void PagePaint()
        {
            Console.WriteLine("Paint Start");
            Paint();
            Console.WriteLine("Paint End");
        }

        async void Paint()
        {
            Rendering("Header");
            Rendering(await RequestBody());
            Rendering("Footer");
        }

        async Task<string> RequestBody()
        {
            return await Task.Run<string>(() =>
            {
                Thread.Sleep(1000);
                return "Body";
            });

        }

        void Rendering(string text)
        {
            Console.WriteLine(text);
        }

        #endregion


        #region Test2

        public async void Test2()
        {
            var s = ShowTodaysInfo();
            Console.WriteLine(await s);


        }
        private static async Task<string> ShowTodaysInfo()
        {
            var integer = GetLeisureHours();
            string ret = $"Today is {DateTime.Today:D}\n" +
                         "Today's hours of leisure: " +
                         $"{await integer}";
            return ret;
        }

        static async Task<int> GetLeisureHours()
        {
            var today = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());
            Console.WriteLine("\nSorry for the delay. . . .\n");
            return 10;
        }

        #endregion

        public void Test3()
        {
            DisplayCurrentInfo().Wait();
        }

        static async Task DisplayCurrentInfo()
        {
            await WaitAndApologize();
            Console.WriteLine($"Today is {DateTime.Now:D}");
            Console.WriteLine($"The current time is {DateTime.Now.TimeOfDay:t}");
            Console.WriteLine("The current temperature is 76 degrees.");

        }

        static async Task WaitAndApologize()
        {
            // Task.Delay is a placeholder for actual work.  
            await Task.Delay(2000);
            // Task.Delay delays the following line by two seconds.  
            Console.WriteLine("\nSorry for the delay. . . .\n");
        }


    }





}
