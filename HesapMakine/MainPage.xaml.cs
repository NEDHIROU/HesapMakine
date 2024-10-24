namespace HesapMakine
{
    public partial class MainPage : ContentPage
    {
        string currentEntry = "";
        string operatorUsed = "";
        double firstNumber, secondNumber;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Number_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string pressed = button.Text;

            if (currentEntry == "0")
                currentEntry = "";

            currentEntry += pressed;
            ResultLabel.Text = currentEntry;
        }
        private void Operator_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operatorUsed = button.Text;

            firstNumber = Convert.ToDouble(currentEntry);
            currentEntry = "";
        }
        private void Equal_Clicked(object sender, EventArgs e)
        {
            secondNumber = Convert.ToDouble(currentEntry);

            double result = 0;
            switch (operatorUsed)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
            }

            ResultLabel.Text = result.ToString();
            currentEntry = result.ToString();
        }
        private void Clear_Clicked(object sender, EventArgs e)
        {
            currentEntry = "0";
            ResultLabel.Text = "0";
            firstNumber = 0;
            secondNumber = 0;
        }
        private void Backspace_Clicked(object sender, EventArgs e)
        {
            if (currentEntry.Length > 0)
            {
                currentEntry = currentEntry.Substring(0, currentEntry.Length - 1);
                ResultLabel.Text = currentEntry;
            }
        }
        private void Decimal_Clicked(object sender, EventArgs e)
        {
            if (!currentEntry.Contains("."))
            {
                currentEntry += ".";
                ResultLabel.Text = currentEntry;
            }
        }
        private void Trig_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string function = button.Text;

            // Convert the currentEntry to a double
            if (!double.TryParse(currentEntry, out double number))
            {
                ResultLabel.Text = "Error";
                return;
            }

            // Convert the input number from degrees to radians
            double radians = number * (Math.PI / 180);
            double result = 0;

            // Perform the appropriate trigonometric function
            switch (function)
            {
                case "sin":
                    result = Math.Sin(radians);  // Convert to radians
                    break;
                case "cos":
                    result = Math.Cos(radians);
                    break;
                case "tan":
                    result = Math.Tan(radians);
                    break;
            }

            // Display the result and store it as the current entry
            ResultLabel.Text = result.ToString();
            currentEntry = result.ToString();
        }

        private void Log_Clicked(object sender, EventArgs e)
        {
            double number = Convert.ToDouble(currentEntry);

            if (number <= 0)
            {
                ResultLabel.Text = "Error";
                currentEntry = "0";
                return;
            }

            double result = Math.Log(number);
            ResultLabel.Text = result.ToString();
            currentEntry = result.ToString();
        }


    }

}
