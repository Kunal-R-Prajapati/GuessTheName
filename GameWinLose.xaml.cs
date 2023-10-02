using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for GameWinLose.xaml
    /// </summary>
    public partial class GameWinLose : Page
    {
        public GameWinLose(int res, string name,Button btnPlayAgain, Button btnExit)
        {
            InitializeComponent();
            btnPlayAgain.Visibility = Visibility.Visible;
            btnExit.Visibility = Visibility.Visible;
           if (res == 0)
            {
                ResultTextBox.Foreground = Brushes.Red;
                ResultTextBox.Text = "You Lose!";
            }
           else
            {
                ResultTextBox.Foreground = Brushes.Green;
                ResultTextBox.Text = "You Won 😊";
            }
            AnswerBox.Text = "Name To Guess is :" + name;
        }
    }
}
