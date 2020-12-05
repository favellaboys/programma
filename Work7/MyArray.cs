using System;
using System.Diagnostics;

namespace Work7
{
    /// <summary>
    /// Класс для работы с массивом.
    /// </summary>
    class MyArray
    {
        #region Fields

        /// <summary>
        /// Рандомайзер.
        /// </summary>
        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// Элементы массива.
        /// </summary>
        public int[] Elements { get; private set; }

        /// <summary>
        /// Длинна массива.
        /// </summary>
        public int Count => Elements.Length;

        #endregion

        #region Ctors

        /// <summary>
        /// Создание массива на 10 элементов.
        /// </summary>
        public MyArray() => Elements = new int[10];

        /// <summary>
        /// Создание массива на N элементов.
        /// </summary>
        /// <param name="n"> Количество элементов </param>
        public MyArray(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("Вы ввели некоректные данные!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            Elements = new int[n];
        }

        #endregion

        /// <summary>
        /// Метод, для сравнения времени двух методов Соритровки.
        /// </summary>
        public void ComparisonOfSorts()
        {
            TestSortAlgorithm(1);
            TestSortAlgorithm(2);
        }

        /// <summary>
        /// Метод, который тестирует способ Соритровки.
        /// </summary>
        /// <param name="sortAlg"> 
        /// Номер сортировки. 
        /// 1 - Шелл, 2 - Выбор. 
        /// </param>
        private void TestSortAlgorithm(int sortAlg)
        {
            FillRandomNumbers();
            Print();

            var timer = new Stopwatch();
            timer.Start();

            if (sortAlg == 1) ShellSort();
            if (sortAlg == 2) SelectionSort();

            timer.Stop();
            var sortTime = timer.ElapsedTicks / 1000.0;

            Console.Write($"Массив после Сортировки {(sortAlg == 1 ? "Шелла" : "Выбором")}: ");
            Print();

            Console.WriteLine($"Время сортировки: {sortTime} ms.\n");
        }

        /// <summary>
        /// Метод, который заполняет массив случайными числами.
        /// </summary>
        public void FillRandomNumbers()
        {
            for (int i = 0; i < Elements.Length; i++)
            {
                Elements[i] = random.Next(0, 100);
            }
        }
        
        /// <summary>
        /// Метод, который выводит элементы массива.
        /// </summary>
        public void Print()
        {
            Console.WriteLine($"\nЭлементы массива: {string.Join(" ", Elements)}");
        }

        #region Sorts

        /// <summary>
        /// Метод, меняющий значения int-переменных местами.
        /// </summary>
        /// <param name="a"> Переменная 1. </param>
        /// <param name="b"> Переменная 2. </param>
        private static void Swap(ref int a, ref int b)
        {
            if (a == b) return;

            var temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Сортировка Шелла.
        /// </summary>
        public void ShellSort()
        {
            int j, step = Elements.Length / 2;

            while (step > 0)
            {
                for (var i = 0; i < (Elements.Length - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (Elements[j] > Elements[j + step]))
                    {
                        Swap(ref Elements[j], ref Elements[j + step]);
                        j -= step;
                    }
                }
                step /= 2;
            }
        }
       
        /// <summary>
        /// Сортировка Выбором.
        /// </summary>
        public void SelectionSort()
        {
            for (int i = 0; i < Elements.Length - 1; i++)
            {
                var min = i;

                for (int j = i + 1; j < Elements.Length; j++)
                {
                    if (Elements[j] < Elements[min]) min = j;
                }

                if (min != i) Swap(ref Elements[i], ref Elements[min]);
            }
        }

        #endregion
    }
}
