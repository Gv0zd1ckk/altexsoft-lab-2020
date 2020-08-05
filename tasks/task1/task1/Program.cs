using System;
using System.IO;
using System.Linq;

namespace task1
{
    internal class Program
    {
        private static void First()
        {
            var path = Console.ReadLine();
            const string backUp = "backup.txt";
            if (path != null)
            {
                File.Copy(path, backUp);
                var fileIn = new StreamReader(path);
                var fileText = fileIn.ReadToEnd();
                var word = Console.ReadLine();
                if (word != null && fileText.Contains(word))
                {
                    var substring = fileText.Replace(word, "");
                    Console.WriteLine(substring);
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
            if (path != null)
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
            if (path != null)
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

    public static void Main(string[] args)
        {
            //First();
            //File.Delete("backUp.txt");
            //Second();
            Third();
        }
    }
}