using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DelegatesHomeWork
{
    [Serializable]
    public class StarWarsCharacters
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Height")]
        public int? Height { get; set; }

        [JsonProperty("Mass")]
        public int? Mass { get; set; }

        [JsonProperty("Hair_Color")]
        public string HairColor { get; set; }

        [JsonProperty("Skin_Color")]
        public string SkinColor { get; set; }

        [JsonProperty("Eye_Color")]
        public string EyeColor { get; set; }

        [JsonProperty("Birth_Year")]
        public string BirthYear { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("Homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("Films")]
        public List<string> Films { get; set; }

        [JsonProperty("Species")]
        public List<string> Species { get; set; }

        [JsonProperty("Vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonProperty("Starships")]
        public List<string> Starships { get; set; }

        [JsonProperty("Created")]
        public DateTime? Created { get; set; }

        [JsonProperty("Edited")]
        public DateTime? Edited { get; set; }

        [JsonProperty("Url")]
        public string Url { get; set; }

        public void ShowCharacters()
        {
            Console.Clear();
            Console.WriteLine($"Name - {Name}");
            Console.WriteLine($"Height - {Height}");
            Console.WriteLine($"Mass - {Mass}");
            Console.WriteLine($"Hair color - {HairColor}");
            Console.WriteLine($"Skin color - {SkinColor}");
            Console.WriteLine($"Eye color - {EyeColor}");
            Console.WriteLine($"Birth year - {BirthYear}");
            Console.WriteLine($"Gender - {Gender}");
            Console.WriteLine($"Home world - {Homeworld}");

            Console.WriteLine("Films - ");
            foreach (var films in Films)
            {
                Console.WriteLine(films);
            }

            Console.WriteLine("Species -");
            foreach (var species in Species)
            {
                Console.WriteLine(species);
            }

            Console.WriteLine("Vehicles -");
            foreach (var vehicles in Vehicles)
            {
                Console.WriteLine(vehicles);
            }

            Console.WriteLine("Starships -");
            foreach (var starships in Starships)
            {
                Console.WriteLine(starships);
            }

            Console.WriteLine($"Created - {Created}");
            Console.WriteLine($"Edited - {Edited}");
            Console.WriteLine($"Url - {Url}");
        }
    }
}
