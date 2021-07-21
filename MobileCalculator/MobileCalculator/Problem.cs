/* Project: Mobile Calculator
   Author: Ryan Alcorn
   Date Updated: 7-21-2021 */

namespace MobileCalculator
{
    /// <summary>
    /// This class contains elements to create a problem that can be solved by the calculator.
    /// </summary>
    /// <remarks>
    /// These elements include two numbers and an operation to be performed along with flags associated with them.
    /// </remarks>
    public class Problem
    {
        public string FirstNumber { get; private set; }
        public string SecondNumber { get; private set; }
        public string Operation { get; private set; }
        public bool OperationFlag { get; private set; }
        public bool FirstNumberFlag { get; private set; }
        public bool SecondNumberFlag { get; private set; }

        /// <summary>
        /// This constructor calls the ResetProblem function to set the properties.
        /// </summary>
        public Problem()
        {
            ResetProblem();
        }

        /// <summary>
        /// This function sets the operation to the passed in symbol and changes the flag associated with the property.
        /// </summary>
        /// <remarks>
        /// <param name="symbol">symbol: represents one of the four operations that can be performed on the numbers in the problem.</param>
        /// </remarks>
        public void ChangeOperation(string symbol)
        {
            OperationFlag = true;
            Operation = symbol;
        }

        /// <summary>
        /// This function changes one of the two numbers based on the flags that have been set so far.
        /// </summary>
        /// <remarks>
        /// <param name="newNumber">newNumber: represents a number/dot that helps build one of the two numbers used in the problem.</param>
        /// </remarks>
        public void ChangeNumber(string newNumber)
        {
            if (!OperationFlag)
            {
                if(newNumber.Equals(".") && !FirstNumber.Contains("."))
                {
                    FirstNumber += ".";
                }
                else if(!newNumber.Equals("."))
                {
                    FirstNumber = FirstNumber.Equals("0") ? newNumber : (FirstNumber + newNumber);
                }
                FirstNumberFlag = true;
            }
            else
            {
                if (newNumber.Equals(".") && !SecondNumber.Contains("."))
                {
                    SecondNumber += ".";
                }
                else if (!newNumber.Equals("."))
                {
                    SecondNumber = SecondNumber.Equals("0") ? newNumber : (SecondNumber.ToString() + newNumber);
                }
                SecondNumberFlag = true;
            }
        }

        /// <summary>
        /// This function changes the text on the label named Display based on the flags that have been set so far.
        /// </summary>
        /// <returns>
        /// A string that represents the text to display.
        /// </returns>
        public string ChangeDisplayText()
        {
            if (!OperationFlag) return FirstNumber;
            if (OperationFlag && !SecondNumberFlag) return FirstNumber + " " + Operation;

            return FirstNumber + " " + Operation + " " + SecondNumber;
        }

        /// <summary>
        /// This function resets all the properties used by the Problem instance.
        /// </summary>
        public void ResetProblem()
        {
            FirstNumber = "0";
            SecondNumber = "0";
            Operation = "";
            OperationFlag = false;
            FirstNumberFlag = false;
            SecondNumberFlag = false;
        }
    }
}
