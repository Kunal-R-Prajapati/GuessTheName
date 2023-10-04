using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        string nameToGuess = string.Empty;
        string guessedName = string.Empty;
        int guesses = 5;
        Button intermediate1;
        Button intermediate2;

        public GamePage(Button btn1, Button btn2)
        {
            InitializeComponent();
            intermediate1 = btn1;
            intermediate2 = btn2;
        }

        private void LoadGameName(object sender, RoutedEventArgs e)
        {
            string[] textFromFile = File.ReadAllLines("cities.txt");
            Random random = new Random();
            int randomIndex =  random.Next(textFromFile.Length);
            nameToGuess = textFromFile[randomIndex];
            guessedName = new string( '_' , nameToGuess.Length);
            guessedName = PurifyTheName(guessedName, nameToGuess);
            GuessedNameBox.Text = guessedName;
            GuessLeftBox.Text = guesses.ToString();
        }

        /*
         * This fuction is used to add blank space in place of _ in the guessedName Variable
         */
        private string PurifyTheName(string nameToPurify, string PurifyerName)
        {
            StringBuilder temp = new StringBuilder(nameToPurify);
            for (int i = 0; i < PurifyerName.Length; i++)
            {
                if (PurifyerName[i] == ' ')
                {
                    temp[i] = ' ';
                }
                else { continue; }
            }
            return temp.ToString();
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            checkTheGuessedChar();
        }

        private void checkTheGuessedChar()
        {

            int counter = 0;
            char guessedChar ;
            try {
                guessedChar = Convert.ToChar(GuessedCharBox.Text[0]);
            } catch (Exception) {
                MessageBox.Show("Enter a Valid Character");
                    return;
            }
            StringBuilder temp = new StringBuilder(guessedName);
            for (int i = 0; i < nameToGuess.Length; i++)
            {
                if(guessedChar == nameToGuess[i] || guessedChar -32 == nameToGuess[i])
                {
                    temp[i] = nameToGuess[i];
                    counter++;
                }
            }

            if (counter == 0)
            {
                guesses--;
                if (guesses  == 0)
                {
                    Frame1.Content = new GameWinLose(0,nameToGuess,intermediate1,intermediate2);
                    Frame1.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("Wrong Guess");
                }
                GuessLeftBox.Text = guesses.ToString();
                GuessedCharBox.Text = "";
                return;
            }
            GuessedCharBox.Text = "";
            guessedName = temp.ToString();
            GuessedNameBox.Text = guessedName;
            if (guessedName == nameToGuess)
            {
                Frame1.Content = new GameWinLose(1,nameToGuess,intermediate1,intermediate2);
                Frame1.Visibility = Visibility.Visible; 
            }
        }
        private void GuessedCharBox_KeyUp(object sender, KeyEventArgs e)
        {
            CheckKey(e);

        }

        private void CheckKey(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checkTheGuessedChar();
                return;
            }
            else
                return;
        }

        private void GuessedNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
