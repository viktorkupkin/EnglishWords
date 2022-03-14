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
using System.Windows.Threading;


namespace EnglishWords_v1
{
    /// <summary>
    /// Логика взаимодействия для HardVariant.xaml
    /// </summary>
    public partial class HardVariant : Window
    {
        public DispatcherTimer timer;
        int timerInterval = 1; //интервал для таймера
        TimeSpan timeSpan = new TimeSpan(0, 0, 0); //для отображения таймера на форме
        TimeSpan timeSpanSeconds = TimeSpan.FromSeconds(1); //для прибавки секунд на форме

        Game game = null;
        public BitmapImage Image = null;
        public string ImagePath { set; get; }
        public string RightVariant { set; get; } //загаданный вариант
        
        public void SetUserName(string n)
        {
            game.Gamer = n;
        }
        public string GetUserName()
        {
            return game.Gamer;
        }
        public HardVariant()
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
        public void SetNewTour() //инициализация нового тура
        {
            game.SetVariants();
            RightVariant = game.SetImageFromVariants();
            SetImage();
            textBox_Answer.Text = String.Empty;
        }
        public void SetImage() //смена картинки на форме
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
        public bool IsAnswerOK(object sender) //проверка введенного ответа
        {
            if (String.Compare(textBox_Answer.Text, RightVariant, true) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ShowMessage(bool b) //показ сообщения после ответа
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
        public void ShowMessage() //показ сообщения после окончания тура
        {
            timer.Stop();
            string str = game.Gamer + ", " + "вы набрали " + game.RightAnswer.ToString() + " очка." +
                "\n" + "Потраченное время " + timeSpan.ToString();
            MessageBox.Show(str, "Тур пройден");
            game.OverTime = timeSpan.ToString();
            game.WriteToFile();
            this.Close();
        }
        private void button_ChekVariant_Click(object sender, RoutedEventArgs e)
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

        private void button_ShowAnswer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(RightVariant, "Правильный ответ:");

        }
    }
}
