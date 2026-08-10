using System.Text;

namespace Calculator;

public partial class Form1 : Form
{
    private StringBuilder Result;
    public Form1()
    {
        InitializeComponent();
        Result = new StringBuilder();
    }

    private void button_Click(object sender, System.EventArgs e)
    {
        Button button = sender as Button;
        if (button != null)
        {
            switch (button.Name)
            {
                case "ButtonClear":
                    Result.Clear();
                    break;
                case "ButtonRemove":
                    if (Result.Length != 0)
                    {
                        Result.Remove(Result.Length - 1, 1);
                    }
                    break;
                case "ButtonPercent":
                    if (!Result.ToString().Contains('%'))
                    {
                        Result.Append('%');
                    }
                    break;
                case "ButtonEquals":
                    if (!Result.ToString().Contains('=') && Result.Length != 0)
                    {
                        calculate();
                    }
                    break;
                default:
                    if ("+-x÷".Contains(button.Text) && Result.Length == 0)
                    {
                        return;
                    }
                    else if (Label1.Text == "Undenified" && button.Name != "ButtonClear")
                    {
                        return;
                    }
                    Result.Append(button.Text);
                    break;
            }
            Label1.Text = Result.ToString();
        }
    }

    private void calculate()
    {
        char[] operators = { '+', '-', 'x', '÷', '%' };

        string[] expressionDigits = Result.ToString().Split(operators);
        char[] expressionOperators = Result.ToString().Where(op => operators.Contains(op)).ToArray();

        double sum = double.Parse(expressionDigits[0]);

        for (int i = 1; i < expressionDigits.Length; i++)
        {
            char operation = expressionOperators[i - 1];

            if (operation == '%')
            {
                sum /= 100;
                break;
            }

            double digit = double.Parse(expressionDigits[i]);

            switch (operation)
            {
                case '+':
                    sum += digit;
                    break;
                case '-':
                    sum -= digit;
                    break;
                case 'x':
                    sum *= digit;
                    break;
                case '÷':
                    if (digit != 0)
                    {
                        sum /= digit;
                    }
                    else
                    {
                        Result.Clear();
                        Result.Append("Undenified");
                        return;
                    }
                    break;
            }
        }

        Result.Clear();
        Result.Append(sum);
    }
}
