using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileCalculator
{
    public partial class MainPage : ContentPage
    {
        HashSet<string> numbers = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        HashSet<string> operations = new HashSet<string> { "+", "-", "×", "÷" };

        bool operationFlag = false;

        public MainPage()
        {
            InitializeComponent();

            List<Button> buttons = new List<Button>() { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero, Clear, Equals, Addition, Subtraction, Division, Multiplication };

            foreach(Button b in buttons)
            {
                b.Clicked += (sender, e) => { displayClicks(b.Text); };
            }
        }

        private void displayClicks(string character)
        {
            if(numbers.Contains(character))
            {
                Debug.WriteLine("Number clicked");
                Display.Text += character[0];
            }
            else if(character.Equals("Clear"))
            {
                Debug.WriteLine("Clear clicked");
                Display.Text = "";
                operationFlag = false;
            }
            else if(character.Equals("Solve"))
            {
                Debug.WriteLine("Equals clicked");

                if (canSolveProblem(Display.Text))
                {
                    Display.Text = runCalculation(Display.Text);
                    operationFlag = false;
                }
            }
            else if(!Display.Text.Equals("") && operations.Contains(character) && operationFlag == false)
            {
                Debug.WriteLine("First operation clicked");
                Display.Text += " " + character + " ";
                operationFlag = true;
            }
            else if (!Display.Text.Equals("") && operations.Contains(character) && operationFlag)
            {
                Debug.WriteLine("Multiple operations clicked");

                if(canSolveProblem(Display.Text))
                {
                    Display.Text = runCalculation(Display.Text) + " " + character + " ";
                }
            }
        }

        private bool canSolveProblem(string displayText)
        {
            string newDisplay = runCalculation(displayText);

            if (!newDisplay.Equals(Display.Text))
            {
                return true;
            }

            return false;
        }

        private string runCalculation(string displayText)
        {
            string[] sequence = displayText.Split(' ');

            if (sequence.Length != 3 || operations.Contains(sequence[2]) || sequence[2].Equals("")) return displayText;

            int outcome = 0;

            if(sequence[1].Equals("+"))
            {
                outcome = Int32.Parse(sequence[0]) + Int32.Parse(sequence[2]);
            }
            else if(sequence[1].Equals("-"))
            {
                outcome = Int32.Parse(sequence[0]) - Int32.Parse(sequence[2]);
            }
            else if (sequence[1].Equals("×"))
            {
                outcome = Int32.Parse(sequence[0]) * Int32.Parse(sequence[2]);
            }
            else if (sequence[1].Equals("÷") && !sequence[2].Equals("0"))
            {
                outcome = Int32.Parse(sequence[0]) / Int32.Parse(sequence[2]);
            }

            return outcome.ToString();
        }
    }
}
