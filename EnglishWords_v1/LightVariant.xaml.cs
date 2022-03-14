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
using System.IO;
using System.Diagnostics;
using System.Windows.Threading;


namespace EnglishWords_v1
{
    /// <summary>
    /// Логика взаимодействия для LightVariant.xaml
    /// </summary>
    public partial class LightVariant : Window
    {
        public DispatcherTimer timer;
        int timerInterval = 1;
        TimeSpan timeSpan = new TimeSpan(0, 0, 0);
        TimeSpan timeSpanSeconds = TimeSpan.FromSeconds(1);

        Game game = null;
        public BitmapImage Image = null;
        public string ImagePath { set; get; }
        public string RightVariant { set; get; }
        
        
        public void SetUserName(string n)
        {
            game.Gamer = n;
        }
        public string GetUserName()
        {
            return game.Gamer;
        }
        public LightVariant()
        {
            InitializeComponent();
            game = new Game();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(timerInterval);
            timer.Tick += Timer_Tick;
            SetNewTour();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeSpan += timeSpanSeconds;
            timerLable.Content = timeSpan.ToString();
        }

        public void SetNewTour()
        {
            game.SetVariants();
            RightVariant = game.SetImageFromVariants();
            SetVariants(game.Variant1, game.Variant2, game.Variant3);
            SetImage();
        }
        public void SetImage()
        {
            try
            {
                ImagePath = String.Concat("/Img/", RightVariant, ".jpg");
                Image = new BitmapImage();
                Image.BeginInit();
                Image.UriSource = new Uri(ImagePath, UriKind.RelativeOrAbsolute);
                Image.EndInit();
                imageBox.Source = Image;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SetVariants(string v1, string v2, string v3)
        {
            button_Variant1.Content = v1;
            button_Variant2.Content = v2;
            button_Variant3.Content = v3;
        }
        public bool IsAnswerOK(object sender)
        {
            Button btn = (Button)sender;
            if (btn.Content == RightVariant)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowMessage(bool b)
        {
            if (b)
            {
                MessageBox.Show("Правильно!", "Отлично!");
                game.RightAnswer++;
                lable_RightAnswer.Content = game.RightAnswer.ToString();
                SetNewTour();
            }
            else
            {
                MessageBox.Show("Неправильно! Попробуйте еще раз.", "Внимание!");
                game.NotRightAnswer++;
                lable_NotRightAnswer.Content = game.NotRightAnswer.ToString();
            }
        }
        public void ShowMessage()
        {
            timer.Stop();
            string str = game.Gamer + ", " + "вы набрали " + game.RightAnswer.ToString() + " очка." + 
                "\n" + "Потраченное время " + timeSpan.ToString();
            MessageBox.Show(str, "Тур пройден");
            game.OverTime = timeSpan.ToString();
            game.WriteToFile();
            this.Close();
        }
        private void button_Variant1_Click(object sender, RoutedEventArgs e)
        {
            if (game.RightAnswer + game.NotRightAnswer < game.QuantityOfQuestions)
            {
                ShowMessage(IsAnswerOK(sender));
            }
            if (game.RightAnswer + game.NotRightAnswer == game.QuantityOfQuestions)
            {
                ShowMessage();
            }
        }

    
    }
}
