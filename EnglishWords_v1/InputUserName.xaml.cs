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

namespace EnglishWords_v1
{
    /// <summary>
    /// Логика взаимодействия для InputUserName.xaml
    /// </summary>
    public partial class InputUserName : Window
    {
        public InputUserName()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public string UserName
        {
            get { return nameBox.Text; }
        }
    }
}
