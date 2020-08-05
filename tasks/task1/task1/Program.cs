using System;
using System.IO;

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
                Console.WriteLine("Something wrong with path ");
        }

        public static void Second()
        {
            
        }

    public static void Main(string[] args)
        {
            //First();
            //File.Delete("backUp.txt");
        }
    }
}