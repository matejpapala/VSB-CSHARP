using System;
using System.Collections.Generic;
using System.Text;

namespace Tutorial10
{
    public class DictionaryStatistics
    {
        public static int WordFrequency(string text)
        {
            string[] words = text.Split([' ', ',', '.', '(', ')'], StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> dict = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (dict.ContainsKey(word))
                {
                    dict[word] += 1;
                } 
                else 
                {
                    dict[word] = 1;
                }
            }

            foreach(KeyValuePair<string, int> pair in dict) {
                Console.WriteLine(pair.Key + ": " + pair.Value);
            }
            return 0;
        }



    }
}
