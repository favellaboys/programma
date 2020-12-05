using System;

namespace Work7
{
    /// <summary>
    /// Класс, сожержащий информацию об Авторе.
    /// </summary>
    public static class Author
    {
        /// <summary>
        /// ФИО.
        /// </summary>
        public const string FIO = "Сергеев Антон Вячеславович";
        
        /// <summary>
        /// Номер группы.
        /// </summary>
        public const int Group  = 6101;

        /// <summary>
        /// Вывести данные на консоль.
        /// </summary>
        public static void Print()
        {
            Console.WriteLine($"ФИО   автора: {FIO}\n" +
                              $"Номер группы: {Group}");
        }
    }
}
