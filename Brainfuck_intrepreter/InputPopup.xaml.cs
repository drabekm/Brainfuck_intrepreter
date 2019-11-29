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
using System.Windows.Shapes;

namespace Brainfuck_intrepreter
{
    /// <summary>
    /// Interakční logika pro InputPopup.xaml
    /// </summary>
    public partial class InputPopup : Window
    {
        public InputPopup()
        {
            InitializeComponent();
        }

        public string InputText { get { return textValue.Text; } set { textValue.Text = value; }  }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
