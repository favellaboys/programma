using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work7
{
    /// <summary>
    /// Класс для Ввода.
    /// </summary>
    static class Input
    {
        /// <summary>
        /// Метод, для получения от пользователя значения.
        /// </summary>
        /// <param name="message"> 
        /// Запрос параметра пользователю:
        /// Введите {message}: 
        /// </param>
        /// <returns> Значение. </returns>
        public static double GetDoubleValue(string message)
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

        /// <summary>
        /// Метод, для получения от пользователя значения.
        /// </summary>
        /// <param name="message"> 
        /// Запрос параметра пользователю:
        /// Введите {message}: 
        /// </param>
        /// <returns> Значение. </returns>
        public static int GetIntValue(string message)
        {
            int value; 

            Console.Write($"Введите {message}: ");
            var input = Console.ReadLine();

            while (int.TryParse(input, out value) == false)
            {
                Console.Write($"\nВведите {message} ещё раз: ");
                input = Console.ReadLine();
            }

            return value;
        }

        /// <summary>
        /// Метод, для получения от координаты поля.
        /// </summary>
        /// <param name="message"> 
        /// Запрос координаты пользователю:
        /// Введите {message}: 
        /// </param>
        /// <param name="minValue"> Минимальное  значение координаты. </param>
        /// <param name="maxValue"> Максимальное значение координаты. </param>
        /// <returns> Значение. </returns>
        public static int GetCoord(string message, int minValue, int maxValue)
        {
            int value;

            Console.Write($"Введите {message}: ");
            var input = Console.ReadLine();

            while (int.TryParse(input, out value) == false || value < minValue || value > maxValue)
            {
                Console.Write($"\nВведите {message} ещё раз: ");
                input = Console.ReadLine();
            }

            return value - 1;
        }

        /// <summary>
        /// Метод, для получения (x, y) поля.
        /// </summary>
        /// <param name="board"> Поле. </param>
        /// <param name="minValue"> Минимальное  значение координаты. </param>
        /// <param name="maxValue"> Максимальное значение координаты. </param>
        /// <returns> (x, y). </returns>
        public static (int x, int y) GetCoords(Mark[,] board, int minValue, int maxValue)
        {
            var y = GetCoord("y", minValue, maxValue);
            var x = GetCoord("x", minValue, maxValue);

            while (board[y, x] != Mark.None)
            {
                Console.WriteLine("\nЭта ячейка уже занята. Введите координаты другой ячейки.\n");
                y = GetCoord("y", minValue, maxValue);
                x = GetCoord("x", minValue, maxValue);
            }

            return (x, y);
        }
    
        /// <summary>
        /// Получить действие (д/н).
        /// </summary>
        /// <returns> Действие. </returns>
        public static char GetAction()
        {
            char action;
            
            do
            {
                Console.Write("Введите д или н: ");
                action = (char)Console.Read();
            } while (action != 'д' && action != 'н');
            
            return action;
        }
    }
}
