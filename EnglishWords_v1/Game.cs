using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace EnglishWords_v1
{
    internal class Game
    {
        string[] images = null; //массив строк для загаданых слов
        public string Variant1 { set; get; } = String.Empty;
        public string Variant2 { set; get; } = String.Empty;
        public string Variant3 { set; get; } = String.Empty;
        public string Gamer { set; get; } = String.Empty;
        public int RightAnswer { set; get; } = 0; //количество правильных ответов
        public int NotRightAnswer { set; get; } = 0; //количество неправильных ответов
        public int QuantityOfQuestions { get; } = 5; //количество вопросов в туре
        public string OverTime {  set; get; } = String.Empty; //потраченное время на игру
        public Game()
        {
            images = File.ReadAllLines("list.txt"); //читаем слова из файла
            
        }
        
        public void SetVariants() //выбор слова из массива images
        {
            Variant1 = images[new Random().Next(0, images.Length-1)];
            Variant2 = images[new Random().Next(0, images.Length-1)];
            while(Variant2 == Variant1)
            {
                Variant2 = images[new Random().Next(0, images.Length - 1)];
            }
            Variant3 = images[new Random().Next(0, images.Length-1)];
            while(Variant3 == Variant2 || Variant3 == Variant1)
            {
                Variant3 = images[new Random().Next(0, images.Length - 1)];
            }
        }
        public void WriteToFile()
        {
            //string str = String.Concat("Имя: ", Gamer, "\nКоличество правильных ответов: ", RightAnswer, "\nКоличество неправильных ответов: ", NotRightAnswer, "\nПотраченное время ", OverTime);
            string fileName = "info.txt";
            using(StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(String.Concat("Имя: ", Gamer));
                sw.WriteLine(String.Concat("Количество правильных ответов: ", RightAnswer));
                sw.WriteLine(String.Concat("Количество неправильных ответов: ", NotRightAnswer));
                sw.WriteLine(String.Concat("Потраченное время ", OverTime));
            }
        }
        public string SetImageFromVariants() //выбор картинки из выбранных вариантов
        {
            string[] variants = new string[3] { Variant1, Variant2, Variant3 };
            int i = new Random().Next(0, variants.Length-1);
            string image = variants[i];
            return image;
        }
    }
}
