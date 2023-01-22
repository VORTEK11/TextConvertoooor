using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class GavnoKod
    {
        public static List<Bibos> DataList = new List<Bibos>() {
            new Bibos("Пиво", 1000),
            new Bibos("Водка", 120),
            new Bibos("И вино", 250),
            new Bibos("Вот такое я гавно", 200)
        };

        static void Main(string[] args)
        {
            Console.WriteLine("├ Введите файл который хотите открыть (.txt, .json, .xml)");

            Console.Write($"\n{Pivo.url} > ");
            string input = Console.ReadLine();
            PathToFile(input);
        }

        public static void PathToFile(string readLine)
        {
            Pivo.dir = readLine;

            if (File.Exists(Pivo.url + "/" + Pivo.dir))
            {
                Console.Clear();
                Pivo.Open();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Файл: {Pivo.dir} - не найден!");

                if (Pivo.Create())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Создаю новый файл: {Pivo.url}/{Pivo.dir}");
                }
                else Console.WriteLine($"Файл: {Pivo.dir} - не удалось создать");

                Close();
            }
        }

        public static void Close()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nСпасибо за оценку! :3");
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
    }
}
