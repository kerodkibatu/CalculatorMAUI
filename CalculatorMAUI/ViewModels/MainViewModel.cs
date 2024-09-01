// We are using the NCalc library to evaluate the expression
using NCalc;
namespace CalculatorMAUI.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    // The display property is bound to the display label and holds the current expression displayed on the calculator
    [ObservableProperty]
    string display = "0";

    // This Command is called when a digit is pressed
    [RelayCommand]
    void OnDigitPress(string digit)
    {
        Console.WriteLine(digit);
        // If the display is 0, replace it with the digit
        if (Display == "0")
        {
            Display = digit;
        }
        else
        {
            // Otherwise, append the digit to the display
            Display += digit;
        }
        if (Display.Contains("Error")) {
            Display = digit;
        }
        Console.WriteLine("asasasasa",Display);
    }
    // This Command is called when the Clear button is pressed
    // It resets the display to 0, Effectively clearing the current expression
    [RelayCommand]
    void Clear() { Display = "0"; }
    // The Negate Command is called when the +/- button is pressed
    // It negates the last digit in the display
    // If the last digit is already negative, it makes it positive
    [RelayCommand]
    void Negate()
    {
        if (!string.IsNullOrEmpty(Display))
        {
            int lastIndex = Display.Length - 1;
            if (char.IsDigit(Display[lastIndex]))
            {
                int number = int.Parse(Display[lastIndex].ToString());
                number = -number;
                Display = Display.Remove(lastIndex, 1).Insert(lastIndex, number.ToString());
            }
        }
    }

    // This Command is called when an operator is pressed
    [RelayCommand]
    void OnOperatorPress(string op)
    {
        // if the pressed operator is =, evaluate the expression
        if (op == "=")
        {
            // Try to evaluate the expression
            try
            {
                // Use NCalc to evaluate the expression
                Expression e = new(Display);
                // Set the display to the result
                Display = e.Evaluate().ToString();
                return;
            }
            // If an exception is thrown, set the display to "Error"
            catch (Exception)
            {
                Display = "Error";
                return;
            }
        }
        // If the operator is not =, append it to the display
        // This allows the user to chain operators eg. 2 + -1
        // And allows for the  parenthesis to be usedl, eg. 2 * (3 + 4)
        Display += op;
    }
}
