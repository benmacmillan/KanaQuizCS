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

namespace Kanaquizcs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public string Submited_Answer = "null";
        public string Chosen_Answer = "a";
        public int Correct = 0;
        public int Incorrect = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Exit_Mousedown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
        private void Menu_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        private void CheckAnswer()
        {
            if (Submited_Answer == Chosen_Answer)
            {
                Answer_Response.Text = "Correct!";
                Answer_Response.Foreground = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                Question_FG.Foreground = new SolidColorBrush(Color.FromRgb(46, 204, 113));
                Correct = +1;
                Score.Text = ("R: " + Correct + " W: " + Incorrect);
            }
            else
            {
                Answer_Response.Text = "Incorrect!";
                Answer_Response.Foreground = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Question_FG.Foreground = new SolidColorBrush(Color.FromRgb(231, 76, 60));
                Incorrect = +1;
                Score.Text = ("R: " + Correct + " W: " + Incorrect); 
            }
        }
        private void answer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                    Submited_Answer = answer.Text;
                    CheckAnswer();
                    answer.Clear();
            }
        }
    }
}
