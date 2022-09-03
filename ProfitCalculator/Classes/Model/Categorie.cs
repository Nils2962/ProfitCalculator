using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculator.Classes.Model
{
    public class Categorie
    {
        [JsonProperty]
        private static int idCount = 0;

        public int ID { get => id; }
        public string Name { get => name; }

        [JsonProperty]
        private int id;

        [JsonProperty]
        private string name;

        public Categorie(string name)
        {
            this.name = name;
            this.id = idCount;
            idCount++;
        }
    }
}
