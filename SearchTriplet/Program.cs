using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SearchTriplet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Введите путь к файлу");
            string path = Console.ReadLine();
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string text = new FileSearch(path).FileReader();

            TripletSearch tripletSearch = new TripletSearch(text);

            Task<Dictionary<string, int>> tripletSearchTack = Task.Factory.StartNew(tripletSearch.ResultTripletSearch);

            var resultTripletSeacrh = tripletSearchTack.Result;

            foreach (var item in resultTripletSeacrh.OrderByDescending(x => x.Value).Take(10))
            {
                Console.WriteLine($"{item.Key} ------ {item.Value}");
            }

            stopwatch.Stop();
            Console.WriteLine($" Time - {stopwatch.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }
    }
}
