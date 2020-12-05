using System;
using static System.Math;

namespace Work7
{
    /// <summary>
    /// Игра по отгадыванию ответа значения функции.
    /// </summary>
    public static class GuessGame
    {
        /// <summary>
        /// Начать игру.
        /// </summary>
        public static void Start()
        {
            Console.WriteLine("Введите значения переменных A и B для нахождения ответа функции:\n " +
                                  "f(a, b) = sqrt( (sin^2(a) + cos^3(b)) / (sin^3(a) - cos^2(b)) ).");
            var a = Input.GetDoubleValue("значение a");
            var b = Input.GetDoubleValue("значение b");

            var answer = Calculate(a, b);

            var isWin = false;
            var remainingAttempts = 3;

            do
            {
                Console.WriteLine($"Осталось попыток: {remainingAttempts}\n");

                var userAnswer = Round(Input.GetDoubleValue("ответ"), 1);

                if (answer == userAnswer)
                {
                    isWin = true;
                }
                else
                {
                    Console.WriteLine("Неправильно, попробуй еще раз.\n");
                    remainingAttempts--;
                }
            } while (!isWin && remainingAttempts > 0);

            Console.WriteLine($"Ответ {(isWin ? "верный" : "неверный")}.");
        }

        /// <summary>
        /// Вычислить значение f(a, b) = sqrt( (sin^2(a) + cos^3(b)) / (sin^3(a) - cos^2(b)) ).
        /// </summary>
        /// <param name="a"> Альфа. </param>
        /// <param name="b"> Бета. </param>
        /// <returns> Значение функции. </returns>
        private static double Calculate(double a, double b)
        {
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

            return Round(Sqrt(dividend / divider), 1);
        }
    }
}
