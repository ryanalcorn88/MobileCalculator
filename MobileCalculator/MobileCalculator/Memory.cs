using System.Collections.Generic;

namespace MobileCalculator
{
    public class Memory
    {
        List<string> problems = new List<string>();

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

        public string DisplayProblems()
        {
            string returnString = "Recent Problems" + System.Environment.NewLine + System.Environment.NewLine;

            foreach(string p in problems)
            {
                returnString += p + System.Environment.NewLine;
            }
            return returnString;
        }
    }
}
