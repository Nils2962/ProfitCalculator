using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfitCalculator.Classes.Model
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Account
    {
        public IReadOnlyList<Transaction> Transactions { get => transactions; }
        public double TotalProfit { get => totalProfit; }
        public double PositivProfitPercent { get => positivProfitPercent; }
        public double MaxProfit { get => maxProfit; }
        public double MaxLoss { get => maxLoss; }
        public double ProfitAverage { get => profitAverage; }
        public double BankBalance { get => bankBalance; }
        public List<Categorie> Categories { get => categories; set => categories = value; }

        [JsonProperty]
        private List<Transaction> transactions = new List<Transaction>();
        [JsonProperty]
        List<Categorie> categories = new List<Categorie>();
        [JsonProperty]
        private double startCapital = 0;

        private double bankBalance = 0;
        private double totalProfit = 0;
        private double positivProfitPercent = 0;
        private double maxProfit = 0;
        private double maxLoss = 0;
        private double profitAverage = 0;

        public delegate void DelTransactionAdded(object sender, Transaction newTransaction);
        public event DelTransactionAdded TransactionAdded;

        public Account(double bankBalance)
        {
            this.startCapital = bankBalance;
            this.TransactionAdded += Account_TransactionAdded;
        }

        private void Account_TransactionAdded(object sender, Transaction newTransaction)
        {
            double profit = newTransaction.Profit;

            CalculateBankBalance(profit);
            CalculateTotalProfit(profit);
            CalculatePositivProfitPercent();
            CalculateMaxProfit(profit);
            CalculateMaxLoss(profit);
            CalculateProfitAverage();
        }

        public void AddTransaction(Transaction transaction)
        {
            this.transactions.Add(transaction);
            TransactionAdded?.Invoke(this, transaction);
        }

        public void Update()
        {
            Calculate();
        }

        private void Calculate()
        {
            //20071969
            this.bankBalance = this.startCapital;
            this.totalProfit = 0;
            this.maxLoss = 0;
            this.maxProfit = 0;

            double positivProfitsCount = 0;

            foreach (Transaction transaction in this.transactions)
            {
                this.bankBalance += transaction.Profit;
                this.totalProfit += transaction.Profit;

                if (transaction.Profit > 0)
                    positivProfitsCount++;

                if (transaction.Profit > this.maxProfit)
                    this.maxProfit = transaction.Profit;

                if (transaction.Profit < this.maxLoss)
                    this.maxLoss = transaction.Profit;
            }

            this.positivProfitPercent = positivProfitsCount / this.transactions.Count * 100;
            this.profitAverage = this.totalProfit / this.transactions.Count;
        }

        private void CalculateBankBalance(double profit)
        {
            this.bankBalance += profit;
        }

        private void CalculateTotalProfit(double profit)
        {
            this.totalProfit += profit;
        }

        private void CalculatePositivProfitPercent()
        {
            double positiv = 0;

            int transactionCount = this.transactions.Count;

            for (int t = 0; t < transactionCount; t++)
            {
                double transactionValue = this.transactions[t].Profit;

                if (transactionValue > 0)
                    positiv++;
            }

            this.positivProfitPercent = positiv * 100 / transactionCount;
        }

        private void CalculateMaxProfit(double profit)
        {
            if (this.maxProfit < profit)
                this.maxProfit = profit;
        }

        private void CalculateMaxLoss(double profit)
        {
            if (this.MaxLoss > profit)
                this.maxLoss = profit;
        }

        private void CalculateProfitAverage()
        {
            double average = 0;

            int transactionCount = this.transactions.Count;

            for (int i = 0; i < transactionCount; i++)
            {
                average += this.transactions[i].Profit;
            }

            average /= transactionCount;

            this.profitAverage = average;
        }
    }
}
