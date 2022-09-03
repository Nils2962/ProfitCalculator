using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProfitCalculator.Visual_Components
{
    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            PreviewTextInput += NumericTextBox_PreviewTextInput;
        }

        private void NumericTextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regexAll = new Regex("[^0-9|,-]+");
            Regex regexNumbers = new Regex("[^0-9]+");

            string text = this.Text;
            int textLength = text.Length;

            bool result = true;

            if (!regexAll.IsMatch(text))
            {
                char newChar = e.Text[0];

                if (newChar == '-' && textLength == 0)
                {
                    result = false;
                }
                else if (newChar == ',')
                {
                    if (textLength > 1 && int.TryParse(text[textLength - 1].ToString(), out int number))
                    {
                        if (text.Where(c => c == ',').Count() == 0)
                            result = false;
                    }
                }
                else if(!regexNumbers.IsMatch(newChar.ToString()))
                {
                    result = false;
                }
            }

            e.Handled = result;
        }
    }
}
