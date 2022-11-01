using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchTriplet
{
    internal class TripletSearch
    {
        private string text { get; set; }
        public TripletSearch(string Text)
        {
            this.text = Text;
        }

        private Dictionary<string, int> Search1()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            char[] chars = text.ToCharArray();

            for (int i = 1; i < chars.Length / 2; i++)
            {
                if (Char.IsLetter(chars[i - 1]) && Char.IsLetter(chars[i]) && Char.IsLetter(chars[i + 1]))
                {
                    string str = Char.ToString(chars[i - 1]) + Char.ToString(chars[i]) + Char.ToString(chars[i + 1]);

                    if (result.ContainsKey(str))
                    {
                        result[str] += 1;
                    }
                    else
                    {
                        result.Add(str, 1);
                    }
                }
            }
            return result;
        }

        private Dictionary<string, int> Search2()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            char[] chars = text.ToCharArray();

            for (int i = (chars.Length / 2); i < chars.Length - 1; i++)
            {
                if (Char.IsLetter(chars[i - 1]) && Char.IsLetter(chars[i]) && Char.IsLetter(chars[i + 1]))
                {
                    string str = Char.ToString(chars[i - 1]) + Char.ToString(chars[i]) + Char.ToString(chars[i + 1]);

                    if (result.ContainsKey(str))
                    {
                        result[str] += 1;
                    }
                    else
                    {
                        result.Add(str, 1);
                    }
                }
            }
            return result;
        }

        public Dictionary<string, int> ResultTripletSearch()
        {
            Task<Dictionary<string, int>> task1 = Task.Factory.StartNew(Search1);
            Task<Dictionary<string, int>> task2 = Task.Factory.StartNew(Search2);

            Task.WaitAll(task1, task2);

            var dictionary1 = task1.Result;
            var dictionary2 = task2.Result;

            foreach (var item in dictionary2)
            {
                if (dictionary1.ContainsKey(item.Key))
                {
                    dictionary1[item.Key] += item.Value;
                }
                else
                    dictionary1.Add(item.Key, item.Value);
            }
            return dictionary1;
        }
    }
}
