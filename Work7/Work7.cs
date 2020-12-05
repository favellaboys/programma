using System;

namespace Work7
{
    /// <summary>
    /// Лабараторная работа 7.
    /// </summary>
    class Work7
    {
        static void Main()
        {
            while (true)
            {
                PrintMenuActions();

                ChoiceItem(Input.GetDoubleValue("нужный пункт"));

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выбрать пункт меню.
        /// </summary>
        /// <param name="item"> Пункт Меню. </param>
        private static void ChoiceItem(double item)
        {
            switch (item)
            {
                case 1: GuessGame.Start();                         break;
                case 2: Author.Print();                            break;
                case 3: new MyArray().ComparisonOfSorts();         break;
                case 4: new CrossZeroGame().Start();               break;
                case 5: new MyString().PringCaseCount();           break;
                case 6: Exit.Confirmation();                       break;
                default: Console.WriteLine("Некорректный выбор!"); break;
            }
        }

        /// <summary>
        /// Вывести доступные пункты меню.
        /// </summary>
        private static void PrintMenuActions()
        {
            Console.WriteLine("Выберите нужный пункт:               \n" +
                              "1 - Отгадай ответ                    \n" +
                              "2 - Об авторе(Фамилия И. О., группа) \n" +
                              "3 - Сортировка                       \n" +
                              "4 - Крестики-Нолики                  \n" +
                              "5 - Строки                           \n" +
                              "6 - Выход                            \n");
        }
    }
}