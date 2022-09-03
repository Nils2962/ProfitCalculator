using ProfitCalculator.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProfitCalculator.Visual_Components
{
    /// <summary>
    /// Interaktionslogik für ValueControl.xaml
    /// </summary>
    public partial class ValueControl : UserControl
    {
        //21082002
        public Brush PositivValueBrush { get => positivValueBrush; set => positivValueBrush = value; }
        public Brush NegativValueBrush { get => negativValueBrush; set => negativValueBrush = value; }
        public Brush NeutralValueBrush { get => neutralValueBrush; set => neutralValueBrush = value; }
        public Brush BackgroundBrush { get => backgroundBrush; set { this.backgroundBrush = value; this.rectangle.Fill = value; } }
        public string ControlOverride { get => controlOverride; set { controlOverride = value; this.labelOverride.Content = value; } }
        public double Value { get => value; set { this.value = value; SetValue(); } }
        public ImageSource Icon { get => icon; set { icon = value; this.image.Source = value; } }
        public bool UseColorValue { get => useColorValue; set => useColorValue = value; }
        public ValueTyp ValueTyp { get => valueTyp; set => valueTyp = value; }

        private Brush backgroundBrush;
        private Brush positivValueBrush = new SolidColorBrush(Color.FromRgb(0, 255, 0));
        private Brush negativValueBrush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        private Brush neutralValueBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        private string controlOverride;
        private double value;
        private ImageSource icon;
        private bool useColorValue = false;
        private ValueTyp valueTyp = ValueTyp.None;
        private Storyboard newValueStoryboard;

        public ValueControl()
        {
            InitializeComponent();

            this.newValueStoryboard = (Storyboard)(this.FindResource("NewValue"));
        }

        private void SetValue()
        {
            this.value = Math.Round(this.value, 2);

            if (this.valueTyp != ValueTyp.Percent)
            {
                newValueStoryboard.Begin();

                Thread thread = new Thread(new ThreadStart(() => 
                {
                    Thread.Sleep(150);

                    this.Dispatcher.Invoke(new Action(() =>
                    {
                        if (this.valueTyp == ValueTyp.Money)
                            this.labelValue.Content = this.value.ToString("C");
                        else
                            this.labelValue.Content = this.value;

                        if (useColorValue)
                        {
                            if (this.value > 0)
                            {
                                this.labelValue.Foreground = this.positivValueBrush;
                            }
                            else if (this.value < 0)
                            {
                                this.labelValue.Foreground = this.negativValueBrush;
                            }
                            else
                            {
                                this.labelValue.Foreground = this.neutralValueBrush;
                            }
                        }
                    }));
                }));

                thread.Start();
            }
            else
            {
                chart.Opacity = 100;
                labelValue.Opacity = 0;

                chart.Value = this.value;
            }
        }
    }
}
