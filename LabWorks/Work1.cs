using System;
using static System.Math;

namespace LabWorks
{
    /// <summary>
    /// Лабараторная работа 1.
    /// </summary>
    class Work1
    {
        public static void Main()
        {
            var a = GetParameter("a");
            var b = GetParameter("b");

            Console.WriteLine("Чему равно значение фунуции: f(a, b) = sqrt( (sin^2(a) + cos^3(b)) / (sin^3(a) - cos^2(b)) )?");

            var userAnswer = Console.ReadLine();

            // Делимое.
            var dividend = Pow(Sin(a), 2) + Pow(Cos(b), 3);
           
            // Делитель.
            var divider = Pow(Sin(a), 3) - Pow(Cos(b), 2);

            #region Check

            if ((divider == 0) || (dividend / divider < 0))
            {
                Console.WriteLine("Вы ввели некорретные данные!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            #endregion

            var answer = Sqrt(dividend / divider);
            Console.WriteLine($"Правильный ответ: {answer}.");
        }

        private static double GetParameter(string parameter)
        {
            Console.Write($"Введите значение {parameter}: ");

            var input = Console.ReadLine();
            var value = double.Parse(input);

            return value;
        }
    }
}