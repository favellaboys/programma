using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    public class MyString
    {
        /// <summary>
        /// Текст.
        /// </summary>
        public string Text { get; private set; }

        /// <summary>
        /// Строка по умолчанию.
        /// </summary>
        private const string DefaultText =
@"Варкалось. Хливкие шорьки
Пырялись по наве,
И хрюкотали зелюки,
Как мюмзики в мове.
О бойся Бармаглота, сын!
Он так свиреп и дик,
А в глуше рымит исполин -
Злопастный Брандашмыг.";

        /// <summary>
        /// Создание Строки по умолчанию.
        /// </summary>
        public MyString() => Text = DefaultText;

        /// <summary>
        /// Создание Строки.
        /// </summary>
        /// <param name="text"> Текст. </param>
        public MyString(string text) => Text = text;

        /// <summary>
        /// Напечатать количество строчных и прописных букв в строке.
        /// </summary>
        public void PringCaseCount()
        {
            var (lowerCount, upperCount) = CalculateCase();

            Console.WriteLine($"\nКоличество строчных  букв: {lowerCount}\n" +
                                $"Количество прописных букв: {upperCount}");
        }

        /// <summary>
        /// Посчитать количество строчных и прописных букв в строке.
        /// </summary>
        /// <returns> Количество строчных и прописных букв в строке. </returns>
        private (int lowerCount, int upperCount) CalculateCase()
        {
            var lowerCount = 0;
            var upperCount = 0;

            foreach (var letter in Text)
            {
                if (char.IsUpper(letter)) upperCount++;
                if (char.IsLower(letter)) lowerCount++;
            }

            return (lowerCount, upperCount);
        }
    }
}
