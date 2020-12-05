using System;

namespace Work7
{
    /// <summary>
    /// Класс, для выхода из приложения.
    /// </summary>
    public static class Exit
    {
        /// <summary>
        /// Подтверждение выхода.
        /// </summary>
        public static void Confirmation()
        {
            Console.WriteLine("Выйти из программы?\n" +
                              "Выход - \'д\', остаться - \'н\'.");

            if (Input.GetAction() == 'д') Environment.Exit(0);
        }
    }
}
