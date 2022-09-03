using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculator.Classes.Model
{
    public class Transaction
    {
        [JsonProperty]
        private static int idCount = 0;

        public double Profit { get => profit; }
        public DateTime TransactionTime { get => transactionTime; }
        public int CategorieID { get => categorieID;  }
        public string Name { get => name; }
        public int ID { get => id; }
        public string Display { get => display; }

        private double profit;
        private DateTime transactionTime;
        private int categorieID;
        private string name;
        private int id;
        private string display;

        public Transaction(double profit, string name, DateTime dateTime, int categorieID)
        {
            this.id = idCount;
            this.name = name;
            this.profit = profit;
            this.categorieID = categorieID;
            this.transactionTime = dateTime;

            if (profit > 0)
                display = "+" + profit;
            else
                display = profit.ToString();

            idCount++;
        }
    }
}
