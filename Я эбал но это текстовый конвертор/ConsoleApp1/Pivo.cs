using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
     public class Pivo
     {
        public static string url = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static string dir = "";

        public static bool Create()
        {
            string extension = Path.GetExtension(url + "/" + dir);
            if (extension == ".txt")
            {
                using StreamWriter sw = File.CreateText(url + "/" + dir);
                for (int i = 0; i < GavnoKod.DataList.Count; i++)
                {
                    sw.WriteLine(GavnoKod.DataList[i].Name);
                    sw.WriteLine(GavnoKod.DataList[i].Price.ToString());
                }
            }
            else if (extension == ".json")
            {
                using StreamWriter sw = File.CreateText(url + "/" + dir);
                sw.WriteLine(JsonConvert.SerializeObject(GavnoKod.DataList));
            }
            else if (extension == ".xml")
            {
                XmlSerializer xml = new XmlSerializer(GavnoKod.DataList.GetType());
                using FileStream fs = new FileStream(url + "/" + dir, FileMode.OpenOrCreate);
                xml.Serialize(fs, GavnoKod.DataList);
            }
            else return false;
            return true;
        }
        public static void Open()
        {
            Console.WriteLine("F1 - Сохранить файл в одном из трёх фрагментов (txt, json, xml)");
            Console.WriteLine("Escape - Закрыть программу\n");

            string extension = Path.GetExtension(url + "/" + dir);
            if (extension == ".txt")
            {
                string[] list = File.ReadAllLines(url + "/" + dir);
                foreach (var item in list) Console.WriteLine(item);
            }
            else if (extension == ".json")
            {
                List<Bibos> list = JsonConvert.DeserializeObject<List<Bibos>>(File.ReadAllText(url + "/" + dir));
                foreach (Bibos item in list)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Price.ToString());
                }
            }
            else if (extension == ".xml")
            {
                XmlSerializer xml = new XmlSerializer(GavnoKod.DataList.GetType());
                using (FileStream fs = new FileStream(url + "/" + dir, FileMode.Open))
                {
                    List<Bibos> list = (List<Bibos>)xml.Deserialize(fs);
                    foreach (Bibos item in list)
                    {
                        Console.WriteLine(item.Name);
                        Console.WriteLine(item.Price.ToString());
                    }
                }
            }

            Amogus.Load();
        }

        public static void Save()
        {
            Console.Clear();
            Console.WriteLine("├ Введите имя и тип файла чтобы его сохранить");

            Console.Write($"\n{Pivo.url} > ");
            string readLine = Console.ReadLine();
            Pivo.dir = readLine;

            if (Pivo.Create())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Файл: {Pivo.url}/{Pivo.dir} - сохранён");
            }
            else Console.WriteLine($"Файл: {Pivo.dir} - не удалось сохранить");

            GavnoKod.Close();
        }
     }
}
