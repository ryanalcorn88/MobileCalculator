/* Project: Mobile Calculator
   Author: Ryan Alcorn
   Date Updated: 7-15-2021 */

namespace MobileCalculator
{
    /// <summary>
    /// This class contains elements to create a problem that can be solved by the calculator.
    /// These elements include two numbers and an operation to be performed.
    /// </summary>
    public class Problem
    {
        public int FirstNumber { get; private set; }
        public int SecondNumber { get; private set; }
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
        /// <param name="newNumber">newNumber: represents a number that helps build one of the two numbers used in the problem.</param>
        /// </remarks>
        public void ChangeNumber(string newNumber)
        {
            if (!OperationFlag)
            {
                FirstNumber = FirstNumber == 0 ? int.Parse(newNumber) : int.Parse(FirstNumber.ToString() + newNumber);
                FirstNumberFlag = true;
            }
            else
            {
                SecondNumber = SecondNumber == 0 ? int.Parse(newNumber) : int.Parse(SecondNumber.ToString() + newNumber);
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
            if (!OperationFlag) return FirstNumber.ToString();
            if (OperationFlag && !SecondNumberFlag) return FirstNumber.ToString() + " " + Operation;

            return FirstNumber.ToString() + " " + Operation + " " + SecondNumber.ToString();
        }

        /// <summary>
        /// This function resets all the properties used by the Problem instance.
        /// </summary>
        public void ResetProblem()
        {
            FirstNumber = 0;
            SecondNumber = 0;
            Operation = "";
            OperationFlag = false;
            FirstNumberFlag = false;
            SecondNumberFlag = false;
        }
    }
}
