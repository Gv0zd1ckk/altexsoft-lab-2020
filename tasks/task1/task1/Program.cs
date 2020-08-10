using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace task1
{
    internal class Program
    {
        private static void First()
        {
            var path = Console.ReadLine();
            const string backUp = "backup.txt";
            if (path != null && File.Exists(path))
            {
                File.Copy(path, backUp);
                var fileIn = new StreamReader(path);
                var fileText = fileIn.ReadToEnd();
                var word = Console.ReadLine();
                if (word != null && fileText.Contains(word))
                {
                    var substring = fileText.Replace(word, "");
                    fileIn.Close();
                    using (var sw = new StreamWriter(path, false))
                    {
                        sw.WriteLine(substring);
                    }
                }
                else
                    Console.WriteLine("There is no word like {0}", word);
            }
            else
                Console.WriteLine("Something wrong with the path");
        }

        private static void Second()
        {
            var path = Console.ReadLine();
            if (path != null && File.Exists(path))
            {
                var fileIn = new StreamReader(path);
                var pattern = new[] {',', '-', '.', '"', ':', '\t', '!', '?', ' ', '(', ')'};
                var text = fileIn.ReadToEnd().Split(pattern, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine(text.Length);
                var comma = new string[text.Length / 10 + 1];
                for (var i = 0; i < text.Length; i+=10)
                {
                    comma[i/10] = text[i];
                }
                Console.WriteLine(string.Join(",", comma));
            }
            else
                Console.WriteLine("Something wrong with the path");
        }

        private static string ReverseWord(string word)
        {
            var myArr = word.ToCharArray();
            Array.Reverse(myArr);
            return new string(myArr);
        }
        private static void Third()
        {
            var path = Console.ReadLine();
            if (path != null && File.Exists(path))
            {
                var fileIn = new StreamReader(path);
                var text = fileIn.ReadToEnd().Split('.');
                var subtext = text[2].Split(' ');
                foreach (var word in subtext)
                {
                    Console.Write(ReverseWord(word) + " ");
                }
            }
            else
                Console.WriteLine("Something wrong with the path");
        }

        private static void Fourth()
        {
            var path = Console.ReadLine();
            while (true)
            {
                var catalog = new ArrayList();
                if (path != null && Directory.Exists(path))
                {
                    var directories = Directory.GetDirectories(path);
                    var files = Directory.GetFiles(path);

                    foreach (var d in directories) catalog.Add(d);
                    foreach (var f in files) catalog.Add(f);
                }

                catalog.Sort();
                for (var i = 0; i < catalog.Count; i++)
                {
                    if (Directory.Exists(catalog[i].ToString())) Console.Write(i + " - ");
                    Console.WriteLine("\t" + catalog[i]);
                }

                string pointer;
                do
                {
                    Console.WriteLine("Enter index of the next directories or 'exit' to quit program:");
                    pointer = Console.ReadLine();
                    try
                    {
                        var flag = !Directory.Exists(catalog[Convert.ToInt32(pointer)].ToString());
                    }
                    catch
                    {
                        Console.WriteLine("U choose wrong index");
                    }
                    if (pointer == "exit") return;
                } while (Convert.ToInt32(pointer) > catalog.Count || Convert.ToInt32(pointer) < 0);
                path = catalog[Convert.ToInt32(pointer)].ToString();
                Console.Clear();
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("To run first method which delete one word from file enter 1\nTo run second method that will show u count of a word in file and also show u every 10th word enter 2\nTo run third method which will show u third sentence and reverse all character in word reverse enter 3\nTo run Fourth method which open u catalog by address that u type enter \n");
            var flag = Console.ReadLine();
            switch (flag)
            {
                case "1": First();
                    File.Delete("backup.txt");
                    break;
                case "2": Second();
                    break;
                case "3": Third();
                    break;
                case "4": Fourth();
                    break;
                default:
                    Console.WriteLine("U write wrong number of function");
                    break;
            }
        }
    }
}