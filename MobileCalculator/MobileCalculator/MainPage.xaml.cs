/* Project: Mobile Calculator
   Author: Ryan Alcorn
   Date Updated: 7-21-2021 */

using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileCalculator
{
    public partial class MainPage : ContentPage
    {
        readonly HashSet<string> numbers = new HashSet<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "." };
        readonly HashSet<string> operations = new HashSet<string> { "+", "-", "×", "÷" };
        Problem currentProblem = new Problem();
        Memory currentMemory = new Memory();

        public MainPage()
        {
            InitializeComponent();

            List<Button> buttons = new List<Button>() { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero, Clear, Solve,
                                                        Addition, Subtraction, Division, Multiplication, Dot };

            foreach(Button b in buttons)
            {
                b.Clicked += (sender, e) => { DisplayClicks(b.Text); };
            }

            HistoryButton.Clicked += (sender, e) => CallHistory(buttons);
        }

        /// <summary>
        /// This function toggles the history label which will display the most recent problems solved on the calculator.
        /// </summary>
        private void CallHistory(List<Button> buttons)
        {
            HistoryTextArea.IsVisible = !HistoryTextArea.IsVisible;
            Display.IsVisible = !Display.IsVisible;

            if(HistoryTextArea.IsVisible)
            {
                HistoryTextArea.Text = currentMemory.DisplayProblems();
            }

            foreach(Button b in buttons)
            {
                b.IsVisible = !b.IsVisible;
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
                Display.Text = "";
                currentProblem.ResetProblem();
            }
            else if (character.Equals("Solve"))
            {
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
                currentMemory.AddToList(currentProblem.FirstNumber, currentProblem.Operation, currentProblem.SecondNumber, Display.Text);
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
            double outcome = 0.0;

            _ = double.TryParse(currentProblem.FirstNumber, out double num1);
            _ = double.TryParse(currentProblem.SecondNumber, out double num2);

            if (currentProblem.Operation.Equals("+"))
            {
                outcome = num1 + num2;
            }
            else if(currentProblem.Operation.Equals("-"))
            {
                outcome = num1 - num2;
            }
            else if (currentProblem.Operation.Equals("×"))
            {
                outcome = num1 * num2;
            }
            else if (currentProblem.Operation.Equals("÷") && num2 != 0)
            {
                outcome = num1 / num2;
            }

            return outcome.ToString();
        }
    }
}
