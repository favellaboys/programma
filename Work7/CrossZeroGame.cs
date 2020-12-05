using System;

namespace Work7
{
    /// <summary>
    /// Игра Крестики-Нолики.
    /// </summary>
    class CrossZeroGame
    {
        /// <summary>
        /// Размер поля.
        /// </summary>
        public const int Size = 3;

        /// <summary>
        /// Поле.
        /// </summary>
        private readonly Mark[,] board;

        /// <summary>
        /// Начать.
        /// </summary>
        public void Start()
        {
            bool winX = false,
                 winO = false;

            var board = new Mark[Size, Size];

            Console.WriteLine($"Игра Крестики-нолики {Size}х{Size}");
            Print();

            for (var i = 0; i < Size * Size; i++)
            {
                var sign = i % 2 == 1 ? Mark.Cross : Mark.Zero;

                Console.WriteLine($"\nХодит игрок, ставящий {(sign == Mark.Cross ? "крестики" : "нолики")}.\n");

                var (x, y) = Input.GetCoords(board, 1, Size);

                board[y, x] = sign;

                Print();

                winX = MarkIsWin(Mark.Cross);
                winO = MarkIsWin(Mark.Zero);

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

        /// <summary>
        /// Напечатать поле.
        /// </summary>
        private void Print()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    var sign = board[i, j];

                    Console.Write(sign switch
                    {
                        Mark.None  => ".  ",
                        Mark.Cross => "X  ",
                        Mark.Zero  => "O  ",
                    });
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Проверить победу отметки.
        /// </summary>
        /// <param name="mark"> Отметка. </param>
        /// <returns> Выиграл ли? </returns>
        private bool MarkIsWin(Mark mark)
        {
            return CheckLines() || CheckMainDiagonal() || CheckSideDiagonal();

            /// <summary>
            /// Проверка выигрыша отметки на главной диагонали.
            /// </summary>
            /// <returns> Победил ли? </returns>
            bool CheckMainDiagonal()
            {
                return board[0, 0] == mark        &&
                       board[0, 0] == board[1, 1] &&
                       board[0, 0] == board[2, 2];
            }
            /// <summary>
            /// Проверка выигрыша отметки на побочной диагонали.
            /// </summary>
            /// <returns> Победил ли? </returns>
            bool CheckSideDiagonal()
            {
                return board[0, 2] == mark        &&
                       board[0, 2] == board[1, 1] &&
                       board[0, 2] == board[2, 0];
            }

            /// <summary>
            /// Проверка выигрыша отметки на Линиях.
            /// </summary>
            /// <returns> Победил ли? </returns>
            bool CheckLines()
            {
                for (var i = 0; i < Size; i++)
                {
                    if (CheckHorizontalLine(i)) return true;
                    if (CheckVerticalLine(i))   return true;
                }
                return false;

                /// <summary>
                /// Проверка выигрыша отметки на горизонатльной линии.
                /// </summary>
                /// <param name="y"> Проверяемая линия. </param>
                /// <returns> Победил ли? </returns>
                bool CheckHorizontalLine(int y)
                {
                    return board[y, 0] == mark       &&
                           board[y, 0] == board[y, 1] &&
                           board[y, 0] == board[y, 2];
                }
                /// <summary>
                /// Проверка выигрыша отметки на вертикальной линии.
                /// </summary>
                /// <param name="x"> Проверяемая линия. </param>
                /// <returns> Победил ли? </returns>
                bool CheckVerticalLine(int x)
                {
                    return board[0, x] == mark       &&
                           board[0, x] == board[1, x] &&
                           board[0, x] == board[2, x];
                }
            }
        }      
    }
}
