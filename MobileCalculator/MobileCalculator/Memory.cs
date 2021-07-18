using System.Collections.Generic;

namespace MobileCalculator
{
    /// <summary>
    /// This class provides functions that will help display the most recent problems on a label.
    /// </summary>
    public class Memory
    {
        List<string> problems = new List<string>();

        /// <summary>
        /// This function adds a string version of a completed problem to the problems list.
        /// </summary>
        /// <remarks>
        /// The list will only contain ten problems and remove the earliest problem if that limit is reached.
        /// </remarks>
        public void AddToList(int firstNumber, string operation, int secondNumber, string currentSolution)
        {
            string solution = currentSolution.Split(' ')[0];
            string newProblem = firstNumber.ToString() + " " + operation + " " + secondNumber.ToString() + " = " + solution;

            if(problems.Count < 10)
            {
                problems.Add(newProblem);
            }
            else
            {
                problems.RemoveAt(0);
                problems.Add(newProblem);
            }
        }

        /// <summary>
        /// This function display the ten most recent problems inputted into the calculator.
        /// </summary>
        /// <returns>
        /// A string that represents the text to display on the label.
        /// </returns>
        public string DisplayProblems()
        {
            string returnString = "Recent Problems" + System.Environment.NewLine + System.Environment.NewLine;

            if (problems.Count == 0) return returnString + "No problems solved yet.";

            foreach (string p in problems)
            {
                returnString += p + System.Environment.NewLine;
            }
            return returnString;
        }
    }
}
