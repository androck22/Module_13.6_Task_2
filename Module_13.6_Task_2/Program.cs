using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Module_13._6_Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();

            string path = @"C:\Users\Lenovo\source\repos\Module_13.6_Task_2\cdev_Text.txt";

            using (var sr = new StreamReader(path))
            {
                var text = sr.ReadToEnd().ToLower();

                string[] words = text.Split(new char[] { ' ', '-', '.', '?', '!', ')', '(', ',', ':', '<', '>', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                var result = words.GroupBy(x => x)
                                  .Where(x => x.Count() > 1)
                                  .Select(x => new { Word = x.Key, Frequency = x.Count() });

                foreach (var item in result)
                {
                    if (item.Frequency > 1)
                    {
                        dictionary.Add(item.Word, item.Frequency);
                    }
                }
            }

            var oderedWords = dictionary.OrderByDescending(s => s.Value);

            int count = 0;

            Console.WriteLine("10 самых встречаемых слов в тексте: ");
            Console.WriteLine();

            foreach (var word in oderedWords)
            {
                Console.WriteLine("Слово: {0}\tКоличество повторов: {1}", word.Key, word.Value);
                count++;
                if (count == 10)
                {
                    break;
                }
            }

            Console.ReadKey();
        }
    }
}
