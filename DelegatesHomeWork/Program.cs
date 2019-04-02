using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml.Serialization;

namespace DelegatesHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.Write("Введите идентификатор персонажа: ");
                string identifierCharacter = Console.ReadLine();
                string url = $"https://swapi.co/api/people/{identifierCharacter}/";

                List<StarWarsCharacters> characters = new List<StarWarsCharacters>();

                XmlSerializer formatter = new XmlSerializer(typeof(List<StarWarsCharacters>));
                bool check = false;

                try
                {
                    using (FileStream fileStream = new FileStream("StarWarsCharacters.xml", FileMode.OpenOrCreate))
                    {
                        characters = (List<StarWarsCharacters>)formatter.Deserialize(fileStream);

                        foreach (var character in characters)
                        {
                            if (character.Url == url)
                            {
                                character.ShowCharacters();
                                check = true;
                                Console.WriteLine("Нажмите любую клавишу для продолжения");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                    Console.WriteLine("Персонаж с таким идентификатором отсутствует в файле!");
                    Console.WriteLine("Запрос отправлен на https://swapi.co/ для получения этого персонажа");
                }
                catch (Exception)
                {
                    Console.WriteLine("Персонаж с таким идентификатором отсутствует в файле!");
                    Console.WriteLine("Запрос отправлен на https://swapi.co/ для получения этого персонажа");
                }

                if (!check)
                {
                    try
                    {
                        string json;
                        using (WebClient client = new WebClient())
                        {
                            json = client.DownloadString(url);
                        }

                        var character = JsonConvert.DeserializeObject<StarWarsCharacters>(json);
                        character.ShowCharacters();
                        characters.Add(character);

                        using (FileStream fileStream = new FileStream("StarWarsCharacters.xml", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fileStream, characters);
                        }
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Персонаж с таким идентификатором отсутствует!!!");
                        Console.WriteLine("Нажмите любую клавишу для продолжения");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
