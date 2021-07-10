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
        List<string> currentSequence = new List<string>();
        HashSet<char> numbers = new HashSet<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        //HashSet<char> operations = new HashSet<char> { '+', '-', '×', '÷' };

        public MainPage()
        {
            InitializeComponent();

            List<Button> buttons = new List<Button>() { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero, Clear, Addition, Subtraction, Division, Multiplication };

            foreach(Button b in buttons)
            {
                b.Clicked += (sender, e) => { displayClicks(b.Text); };
            }
        }

        private void displayClicks(string character)
        {
            if(numbers.Contains(character[0]))
            {
                Display.Text += character[0];
            }
            else if(character.Equals("Clear"))
            {
                Display.Text = "";
            }
            else if(character.Equals('='))
            {
                Debug.WriteLine("Equals clicked");
                Display.Text = runCalculation(Display.Text);
            }
            else if(!Display.Text.Equals(""))
            {
                Display.Text += " " + character + " ";
            }
        }

        private string runCalculation(string currentSequence)
        {
            string[] sequence = currentSequence.Split(' ');

            int outcome = 0;

            if(sequence[1].Equals('+'))
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
            else if (sequence[1].Equals("÷"))
            {
                outcome = Int32.Parse(sequence[0]) / Int32.Parse(sequence[2]);
            }

            return outcome.ToString();
        }
    }
}
