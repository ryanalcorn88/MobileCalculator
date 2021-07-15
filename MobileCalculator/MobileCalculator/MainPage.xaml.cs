/* Project: Mobile Calculator
   Author: Ryan Alcorn
   Date Updated: 7-15-2021 */

using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace MobileCalculator
{
    public partial class MainPage : ContentPage
    {
        readonly HashSet<string> numbers = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        readonly HashSet<string> operations = new HashSet<string> { "+", "-", "×", "÷" };
        Problem currentProblem = new Problem();

        public MainPage()
        {
            InitializeComponent();

            List<Button> buttons = new List<Button>() { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero, Clear, Solve, Addition, Subtraction, Division, Multiplication };

            foreach(Button b in buttons)
            {
                b.Clicked += (sender, e) => { DisplayClicks(b.Text); };
            }
        }

        /// <summary>
        /// This function is called when a button is clicked. It calls different functions based on which button is clicked.
        /// </summary>
        private void DisplayClicks(string character)
        {
            if(numbers.Contains(character))
            {
                currentProblem.ChangeNumber(character);
                Display.Text = currentProblem.ChangeDisplayText();
            }
            else if(operations.Contains(character))
            {
                if(currentProblem.SecondNumberFlag)
                {
                    SolveProblem();
                }

                if(currentProblem.FirstNumberFlag)
                {
                    currentProblem.ChangeOperation(character);
                    Display.Text = currentProblem.ChangeDisplayText();
                }
            }
            else if (character.Equals("Clear"))
            {
                Debug.WriteLine("Clear clicked");
                Display.Text = "";
                currentProblem.ResetProblem();
            }
            else if (character.Equals("Solve"))
            {
                Debug.WriteLine("Equals clicked");
                SolveProblem();
            }
        }

        /// <summary>
        /// This function checks if the correct properties have been set. If so, the RunCalculation function is called to display the result of the problem.
        /// The problems properties are then reset and the display is updated with the result.
        /// </summary>
        public void SolveProblem()
        {
            if (currentProblem.OperationFlag && currentProblem.SecondNumberFlag)
            {
                Display.Text = RunCalculation();
                currentProblem.ResetProblem();
                currentProblem.ChangeNumber(Display.Text);
            }
        }

        /// <summary>
        /// This function performs calculations based on what the operation symbol was set as.
        /// </summary>
        /// <returns>returns a string representation of the solution of the problem</returns>
        private string RunCalculation()
        {
            int outcome = 0;

            if(currentProblem.Operation.Equals("+"))
            {
                outcome = currentProblem.FirstNumber + currentProblem.SecondNumber;
            }
            else if(currentProblem.Operation.Equals("-"))
            {
                outcome = currentProblem.FirstNumber - currentProblem.SecondNumber;
            }
            else if (currentProblem.Operation.Equals("×"))
            {
                outcome = currentProblem.FirstNumber * currentProblem.SecondNumber;
            }
            else if (currentProblem.Operation.Equals("÷") && currentProblem.SecondNumber != 0)
            {
                outcome = currentProblem.FirstNumber / currentProblem.SecondNumber;
            }

            return outcome.ToString();
        }
    }
}
