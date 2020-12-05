using System;
using static System.Math;

namespace Work3
{
    /// <summary>
    /// Лабараторная работа 3.
    /// </summary>
    class Work3
    {
        private static double GetDoubleValue(string message)
        {
            double value;

            Console.Write($"Введите {message}: ");
            var input = Console.ReadLine();

            while (double.TryParse(input, out value) == false)
            {
                Console.Write($"\nВведите {message} ещё раз: ");
                input = Console.ReadLine();
            }

            return value;
        }

        private static void GuessGame()
        {
            Console.WriteLine("Введите значения переменных A и B для нахождения ответа функции:\n " +
                            "f(a, b) = sqrt( (sin^2(a) + cos^3(b)) / (sin^3(a) - cos^2(b)) ).");
            var a = GetDoubleValue("значение a");
            var b = GetDoubleValue("значение b");

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
            answer = Round(answer, 1);

            var isWin = false;
            var remainingAttempts = 3;

            do
            {
                Console.WriteLine($"Осталось попыток: {remainingAttempts}\n");

                var userAnswer = Round(GetDoubleValue("ответ"), 1);

                if (answer == userAnswer)
                {
                    isWin = true;
                }
                else
                {
                    remainingAttempts--;
                    Console.WriteLine(remainingAttempts == 0 
                                    ? "У вас закончились попытки.    \n"
                                    : "Неправильно, попробуй еще раз.\n");
                }
            } while (!isWin && remainingAttempts > 0);

            Console.WriteLine($"Ответ {(isWin ? "верный" : "неверный")}.");
        }

        private static void WriteAutorData()
        {
            Console.WriteLine("ФИО   автора: Сергеев Антон Вячеславович\n" +
                              "Номер группы: 6101");
        }

        private static void ConfirmationExit()
        {
            Console.WriteLine("Выйти из программы?\n" +
                              "Выход - \'д\', остаться - \'н\'.");
            char action;
            do
            {
                Console.Write("Введите д или н: ");
                action = (char)Console.Read();
            } while (action != 'д' && action != 'н');

            if (action == 'д') Environment.Exit(0);

            if (action == 'н') Main();
        }

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите нужный пункт:               \n" +
                                  "1 - Отгадай ответ                    \n" +
                                  "2 - Об авторе(Фамилия И. О., группа) \n" +
                                  "3 - Выход                            \n");

                var item = GetDoubleValue("нужный пункт");

                switch (item)
                {
                    case 1: GuessGame();        break;
                    case 2: WriteAutorData();   break;
                    case 3: ConfirmationExit(); break;
                    default: Console.WriteLine("Некорректный выбор!"); break;
                }

                Console.WriteLine();
            }
        }
    }
}
