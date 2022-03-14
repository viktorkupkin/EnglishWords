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
using System.Diagnostics;

namespace EnglishWords_v1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        
        public MainWindow()
        {
            InitializeComponent();
        }
        private string ReturnUserName()
        {
            InputUserName inputUserNameWindow = new InputUserName();
            inputUserNameWindow.Owner = this;
            inputUserNameWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            inputUserNameWindow.ResizeMode = ResizeMode.NoResize;
            if (inputUserNameWindow.ShowDialog() == true)
            {
                if (inputUserNameWindow.UserName != "")
                {
                    return inputUserNameWindow.UserName;
                }
                else
                {
                    throw new Exception("Введите имя");
                }
            }
            
            return "Игрок 1";
        }
        private void buttonLight_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LightVariant LightVariantWindow = new LightVariant();
                LightVariantWindow.SetUserName(ReturnUserName());
                LightVariantWindow.GamerName.Content = LightVariantWindow.GetUserName();
                LightVariantWindow.Owner = this;
                LightVariantWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                LightVariantWindow.ResizeMode = ResizeMode.NoResize;
                LightVariantWindow.timer.Start();
                LightVariantWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonHard_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HardVariant HardVariantWindow = new HardVariant();
                HardVariantWindow.SetUserName(ReturnUserName());
                HardVariantWindow.GamerName.Content = HardVariantWindow.GetUserName();
                HardVariantWindow.Owner = this;
                HardVariantWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                HardVariantWindow.ResizeMode = ResizeMode.NoResize;
                HardVariantWindow.timer.Start();
                HardVariantWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
