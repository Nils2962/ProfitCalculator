using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using ProfitCalculator.Classes.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProfitCalculator.Visual_Components
{
    /// <summary>
    /// Interaction logic for MaterialCards.xaml
    /// </summary>
    public partial class MaterialCards : UserControl
    {
        public string Title { get; set; }
        public double LineSmoothness { get; set; }
        public List<Transaction> Transactions { get => transactions; set { transactions = value; FillTransactions(); } }

        private SeriesCollection lineSeriesCollection;
        private List<Transaction> transactions;

        public MaterialCards()
        {
            InitializeComponent();

            lineSeriesCollection = new SeriesCollection()
            {
                new LineSeries()
                {
                    Title = Title,
                    LineSmoothness = this.LineSmoothness,
                    PointGeometry = DefaultGeometries.Circle,
                    PointForeground = Brushes.Blue,
                    Values = new ChartValues<double>(),
                    ScalesXAt = 0
                }
            };

            chart.Series = lineSeriesCollection;
        }

        public void AddChartValue(Transaction transaction)
        {
            this.transactions.Add(transaction);
            chart.Series[0].Values.Add(transaction.Profit);
        }

        private void FillTransactions()
        {
            chart.Series[0].Values.Clear();

            foreach (Transaction transaction in this.transactions)
            {
                chart.Series[0].Values.Add(transaction.Profit);
            }
        }
    }
}
