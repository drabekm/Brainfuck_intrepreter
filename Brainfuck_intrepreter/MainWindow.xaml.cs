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

namespace Brainfuck_intrepreter
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Interpreter interpreter; 

        public MainWindow()
        {
            InitializeComponent();
            interpreter = new Interpreter(textOutput, labelHelp, labelIsBreak, labelIsDebug);
        }



        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {            
            interpreter.Start(textInput.Text, false);
        }

        private void ButtonDebug_Click(object sender, RoutedEventArgs e)
        {
            interpreter.Start(textInput.Text, true);
        }

        private void ButtonContinue_Click(object sender, RoutedEventArgs e)
        {
            interpreter.Continue();
        }

        private void ButtonStep_Click(object sender, RoutedEventArgs e)
        {
            interpreter.DoStep();
        }

        private void ButtonAbout_Click(object sender, RoutedEventArgs e)
        {
            About aboutPopup = new About();
            aboutPopup.Show();
        }
    }
}
