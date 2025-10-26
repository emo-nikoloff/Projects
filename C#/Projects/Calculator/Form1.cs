using System.Numerics;
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
                    if (!Result.ToString().Contains('='))
                    {
                        Result.Append('=');
                        calculate();
                    }
                    break;
                default:
                    Result.Append(button.Text);
                    break;
            }
            Label1.Text = Result.ToString();
        }
    }

    private void calculate()
    {
        char[] operators = { '+', '-', '*', '/' };

        string mathExpression = Result.ToString().Split('=')[0];
        string[] expressionDigits = mathExpression.Split(operators);
        char[] expressionOperators = mathExpression.Where(op => operators.Contains(op)).ToArray();

        BigInteger sum = BigInteger.Parse(expressionDigits[0]);

        for (int i = 1; i < expressionDigits.Length; i++)
        {
            BigInteger digit = BigInteger.Parse(expressionDigits[i]);

            //int digit = int.Parse(expressionDigits[i]);
            char operation = expressionOperators[i - 1];

            switch (operation)
            {
                case '+':
                    sum += digit;
                    break;
                case '-':
                    sum -= digit;
                    break;
            }
        }

        Result.Clear();
        Result.Append(sum);
        //Result.Append("Hello, world!");
    }
}
