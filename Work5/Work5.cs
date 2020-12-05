using System;
using System.Diagnostics;
using static System.Math;

namespace Work5
{
    /// <summary>
    /// Лабараторная работа 5.
    /// </summary>
    static class Work5
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

        private static int GetIntValue(string message)
        {
            int value; string input;

            Console.Write($"Введите {message}: ");
            input = Console.ReadLine();

            while (int.TryParse(input, out value) == false)
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
                    Console.WriteLine("Неправильно, попробуй еще раз.\n");
                    remainingAttempts--;
                }
            } while (!isWin && remainingAttempts > 0);

            Console.WriteLine($"Ответ {(isWin ? "верный" : "неверный")}.");
        }

        private static void WriteAutorData()
        {
            Console.WriteLine("ФИО   автора: Сергеев Антон Вячеславович\n" +
                              "Номер группы: 6101");
        }

        #region Arrays

        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        private static void ComparisonOfSorts()
        {
            var n = GetIntValue("количество элементов массива");

            TestSortAlgorithm(1);
            TestSortAlgorithm(2);

            void TestSortAlgorithm(int sortAlg)
            {
                var array = new int[n];

                array.FillRandomNumbers();
                array.Print();

                var timer = new Stopwatch();
                timer.Start();

                if (sortAlg == 1)
                {
                    ShellSort(array);
                }

                if (sortAlg == 2)
                {
                    SelectionSort(array);
                }

                timer.Stop();
                var sortTime = timer.ElapsedTicks / 1000.0;

                Console.Write($"Массив после Сортировки {(sortAlg == 1 ? "Шелла" : "Выбором")}: ");
                array.Print();

                Console.WriteLine($"Время сортировки: {sortTime} ms.\n");
            }
        }

        private static void FillRandomNumbers(this int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }
        }
        private static void Print(this int[] array)
        {
            Console.WriteLine($"\nЭлементы массива: {string.Join(" ", array)}");
        }

        private static void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        private static void ShellSort(int[] array)
        {
            int j, step = array.Length / 2;

            while (step > 0)
            {
                for (var i = 0; i < (array.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j] > array[j + step]))
                    {
                        Swap(ref array[j], ref array[j + step]);
                        j -= step;
                    }
                }
                step /= 2;
            }
        }
        private static void SelectionSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                var min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min]) min = j;
                }

                if (min != i) Swap(ref array[i], ref array[min]);
            }
        }

        #endregion

        #region Cross-Zero Game

        enum Sign
        {
            None = 0,

            /// <summary>
            /// X
            /// </summary>
            Cross = 1,

            /// <summary>
            /// O
            /// </summary>
            Zero  = 2
        }

        private static void CrossZeroGame()
        {
            bool winX = false, 
                 winO = false;

            var board = new Sign[3, 3];

            Console.WriteLine("Игра Крестики-нолики 3х3");
            board.Print();

            for (var i = 0; i < 9; i++)
            {
                var sign = i % 2 == 1 ? Sign.Cross : Sign.Zero;

                Console.WriteLine($"\nХодит игрок, ставящий {(sign == Sign.Cross ? "крестики" : "нолики")}.\n");

                var y = TryGetCoord("строки");
                var x = TryGetCoord("столбца");

                while (board[y, x] != Sign.None)
                {
                    Console.WriteLine("\nЭта ячейка уже занята. Введите координаты другой ячейки.\n");
                    y = TryGetCoord("строки");
                    x = TryGetCoord("столбца");
                }

                board[y, x] = sign;

                board.Print();

                winX = CheckSignWin(board, Sign.Cross);
                winO = CheckSignWin(board, Sign.Zero);

                if (winX || winO) break;
            }

            if (winX || winO)
            {
                Console.WriteLine($"Выиграл игрок, ставящий {(winX ? "крестики" : "нолики")}!");
            }
            else
            {
                Console.WriteLine("Партия закончилась ничьей!");
            }
        }

        private static void Print(this Sign[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var sign = board[i, j];

                    Console.Write(sign switch
                    {
                        Sign.None  => ".  ",
                        Sign.Cross => "X  ",
                        Sign.Zero  => "O  ",
                    });
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static int TryGetCoord(string message)
        {
            int value;

            Console.Write($"Введите номер {message}: ");
            var input = Console.ReadLine();

            while (int.TryParse(input, out value) == false || value < 1 || value > 3)
            {
                Console.Write($"\nВведите номер {message} ещё раз: ");
                input = Console.ReadLine();
            }

            return value - 1;
        }

        private static bool CheckSignWin(this Sign[,] board, Sign sign)
        {
            #region Check Lines

            for (var i = 0; i < 3; i++)
            {
                if (board[i, 0] == sign        && 
                    board[i, 0] == board[i, 1] && 
                    board[i, 0] == board[i, 2]) return true;

                if (board[0, i] == sign        && 
                    board[0, i] == board[1, i] && 
                    board[0, i] == board[2, i]) return true;
            }

            #endregion

            #region Check Diagonals

            if (board[0, 0] == sign        &&
                board[0, 0] == board[1, 1] &&
                board[0, 0] == board[2, 2]) return true;

            if (board[0, 2] == sign        &&
                board[0, 2] == board[1, 1] &&
                board[0, 2] == board[2, 0]) return true;

            #endregion

            return false;
        }

        #endregion

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
                                  "3 - Сортировка                       \n" +
                                  "4 - Крестики-Нолики                  \n" +
                                  "5 - Выход                            \n");

                var item = GetDoubleValue("нужный пункт");

                switch (item)
                {
                    case 1: GuessGame();         break;
                    case 2: WriteAutorData();    break;
                    case 3: ComparisonOfSorts(); break;
                    case 4: CrossZeroGame();     break;
                    case 5: ConfirmationExit();  break;
                    default: Console.WriteLine("Некорректный выбор!"); break;
                }

                Console.WriteLine();
            }
        }
    }
}