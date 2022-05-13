using System;

namespace Calculator
{
    /// <summary>
    /// Калькулятор, вычисляющий нахождение следа матрицы, транспонирование матрицы, сумму двух матриц,
    /// разность двух матриц, произведение двух матриц, умножение матрицы на число, нахождение определителя матрицы.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа программы. Здесь предлагается выбрать один из семи предлагаемых пунктов.
        /// После выполнения необходимой процедуры предлагается нажать любую клавишу для продолжения
        /// или Esc для завершения работы.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Добро пожаловать!");
            do
            {
                UserInputNumber(out int n);

                if (n == 1)
                {
                    Item1();
                }
                else if (n == 2)
                {
                    Item2();
                }
                else if (n == 3)
                {
                    Item3();
                }
                else if (n == 4)
                {
                    Item4();
                }
                else if (n == 5)
                {
                    Item5();
                }
                else if (n == 6)
                {
                    Item6();
                }
                else if (n == 7)
                {
                    Item7();
                }

                Console.WriteLine("\n\nНажмите любую клавишу для продолжения или Esc для завершения работы...\n");
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }

        /// <summary>
        /// 7. Нахождение определителя матрицы.
        /// </summary>
        static void Item7()
        {
            Console.WriteLine("\nСоздание матрицы:");
            UserInputMatrix(out int sizeR, out int sizeC, out double[,] matr);
            OutputMatrix(in sizeR, in sizeC, in matr, true);

            if (sizeR == sizeC)
            {
                Console.WriteLine($"\nОпределитель матрицы det = {MatrixDet(matr)}");
            }
            else
            {
                Console.WriteLine("\nОпределитель матрицы посчитать нельзя, поскольку матрица НЕ квадратная...");
            }
        }

        /// <summary>
        /// 6. Умножение матрицы на число.
        /// </summary>
        static void Item6()
        {
            Console.WriteLine("\nСоздание матрицы:");
            UserInputMatrix(out int sizeR, out int sizeC, out double[,] matr);
            OutputMatrix(in sizeR, in sizeC, in matr, true);

            bool correctСoefficient;
            double coefficient;

            do
            {
                Console.Write("\nВведите числовой множитель матрицы (целочисленный): ");

                correctСoefficient = double.TryParse(Console.ReadLine(), out coefficient);
                if (!correctСoefficient || coefficient > (int)coefficient)
                    Console.WriteLine("\nНекорректный ввод.Повторите попытку...");
            } while (!correctСoefficient || coefficient > (int)coefficient);

            double[,] total = new double[sizeR, sizeC];

            for (int i = 0; i < sizeR; i++)
            {
                for (int j = 0; j < sizeC; j++)
                {
                    total[i, j] = matr[i, j] * coefficient;
                }
            }

            OutputMatrix(in sizeR, in sizeC, in total, false);
        }

        /// <summary>
        /// 5. Произведение двух матриц.
        /// </summary>
        static void Item5()
        {
            Console.WriteLine("\nСоздание первой матрицы:");
            UserInputMatrix(out int sizeR, out int sizeC, out double[,] matr);
            OutputMatrix(in sizeR, in sizeC, in matr, true);

            Console.WriteLine("\nСоздание второй матрицы:");
            UserInputMatrix(out int sizeR2, out int sizeC2, out double[,] matr2);
            OutputMatrix(in sizeR2, in sizeC2, in matr2, true);

            double[,] total = new double[sizeR, sizeC2];

            if (sizeC == sizeR2)
            {
                for (int i = 0; i < sizeR; i++)
                {
                    for (int j = 0; j < sizeC2; j++)
                    {
                        for (int k = 0; k < sizeR2; k++)
                        {
                            total[i, j] += matr[i, k] * matr2[k, j];
                        }
                    }
                }

                OutputMatrix(in sizeR, in sizeC2, in total, false);
            }
            else
            {
                Console.WriteLine("\nПроизведение матриц посчитать нельзя, поскольку кол-во стобцов первой матрицы" +
                                  "не равно кол-ву строк второй матрицы...");
            }
        }

        /// <summary>
        /// 4. Разность двух матриц.
        /// </summary>
        static void Item4()
        {
            Console.WriteLine("\nСоздание первой матрицы:");
            UserInputMatrix(out int sizeR, out int sizeC, out double[,] matr);
            OutputMatrix(in sizeR, in sizeC, in matr, true);

            Console.WriteLine("\nСоздание второй матрицы:");
            UserInputMatrix(out int sizeR2, out int sizeC2, out double[,] matr2);
            OutputMatrix(in sizeR2, in sizeC2, in matr2, true);

            double[,] total = new double[sizeR, sizeC];

            if ((sizeR == sizeR2) && (sizeC == sizeC2))
            {
                for (int i = 0; i < sizeR; i++)
                {
                    for (int j = 0; j < sizeC; j++)
                    {
                        total[i, j] = matr[i, j] - matr2[i, j];
                    }
                }

                OutputMatrix(in sizeR, in sizeC, in total, false);
            }
            else
            {
                Console.WriteLine("\nРазность матриц посчитать нельзя, поскольку матрицы разных размеров...");
            }
        }

        /// <summary>
        /// 3. Сумма двух матриц.
        /// </summary>
        static void Item3()
        {
            Console.WriteLine("\nСоздание первой матрицы:");
            UserInputMatrix(out int sizeR, out int sizeC, out double[,] matr);
            OutputMatrix(in sizeR, in sizeC, in matr, true);

            Console.WriteLine("\nСоздание второй матрицы:");
            UserInputMatrix(out int sizeR2, out int sizeC2, out double[,] matr2);
            OutputMatrix(in sizeR2, in sizeC2, in matr2, true);

            double[,] total = new double[sizeR, sizeC];

            if ((sizeR == sizeR2) && (sizeC == sizeC2))
            {
                for (int i = 0; i < sizeR; i++)
                {
                    for (int j = 0; j < sizeC; j++)
                    {
                        total[i, j] = matr[i, j] + matr2[i, j];
                    }
                }

                OutputMatrix(in sizeR, in sizeC, in total, false);
            }
            else
            {
                Console.WriteLine("\nСумму матриц посчитать нельзя, поскольку матрицы разных размеров...");
            }
        }

        /// <summary>
        /// 2. Транспонирование матрицы.
        /// </summary>
        static void Item2()
        {
            Console.WriteLine("\nСоздание матрицы:");
            UserInputMatrix(out int sizeR, out int sizeC, out double[,] matr);
            OutputMatrix(in sizeR, in sizeC, in matr, true);

            double[,] transpose = new double[sizeC, sizeR];

            for (int i = 0; i < sizeC; i++)
            {
                for (int j = 0; j < sizeR; j++)
                {
                    transpose[i, j] = matr[j, i];
                }
            }

            OutputMatrix(in sizeC, in sizeR, in transpose, false);
        }

        /// <summary>
        /// 1. Нахождение следа матрицы.
        /// </summary>
        static void Item1()
        {
            Console.WriteLine("\nСоздание матрицы:");
            UserInputMatrix(out int sizeR, out int sizeC, out double[,] matr);
            OutputMatrix(in sizeR, in sizeC, in matr, true);
            if (sizeR == sizeC)
            {
                double track = 0;
                for (int i = 0; i < sizeR; i++)
                {
                    for (int j = 0; j < sizeC; j++)
                    {
                        if (i == j)
                        {
                            track += matr[i, j];
                        }
                    }
                    Console.WriteLine();
                }

                Console.Write($"След матрицы: {track}");
            }
            else
            {
                Console.WriteLine("След матрицы посчитать нельзя, поскольку заданная матрица прямоугольная...");
            }
        }

        /// <summary>
        /// Подсчёт и возврат результата подсчёта определителя матрицы.
        /// </summary>
        /// <param name="matrix"> Переданная матрица. </param>
        /// <returns> Значение определителя. </returns>
        static double MatrixDet(double[,] matrix)
        {
            double det = 0;
            // Минор из одного элемента.
            if (matrix.GetLength(0) == 1)
            {
                return matrix[0, 0];
            }

            // Начало – проход по столбцам первой строки.
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                // Минор.
                double[,] minor = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
                // Проход второй и следующих строк.
                for (int i = 1; i < matrix.GetLength(0); i++)
                {
                    // Перебор всех возможных столбцов, т. е. элементов текущей строки.
                    for (int k = 0; k < matrix.GetLength(0); k++)
                    {
                        //  Проверка на свопадение столбцов. Пропуск текущего столбца и переход к следующему.
                        if (k == j)
                            continue;

                        // Текущий выбранный столбец правее выбранного столбца первой строки.
                        // Запись текущего элемента исходной матрицы в минор.
                        else if (k > j)
                            minor[i - 1, k - 1] = matrix[i, k];

                        // Текущий выбранный столбец левее выбранного столбца первой строки.
                        // Запись текущего элемента исходной матрицы в минор.
                        else
                            minor[i - 1, k] = matrix[i, k];
                    }
                }
                // Прибавление текущего произведения к желанному определителю. Точка рекурсии (MatrixDet(minor)).
                det += (1 + (-2) * (j % 2)) * matrix[0, j] * MatrixDet(minor);
            }

            // Возврат суммы произведений для желанного определителя.
            return det;
        }

        /// <summary>
        /// Вывод двумерного массива матрицы на экран.
        /// </summary>
        /// <param name="sizeR"> Передача заданного параметра количества строк по ссылке. </param>
        /// <param name="sizeC"> Передача заданного параметра количества столбцов по ссылке. </param>
        /// <param name="matr"> Передача заданного двумерного массива матрицы по ссылке. </param>
        /// <param name="flag"> Логический указатель вывода строки ("Введённая/Новая матрица: ") </param>
        static void OutputMatrix(in int sizeR, in int sizeC, in double[,] matr, bool flag)
        {
            // Вывод "Введённая/Новая матрица: " в зависимости от логического указателя.
            // Значение true – в метод был передан первоначальный двумерный массив матрицы до операций с ним.
            // Значение false – в метод был передан итоговый двумерный массив матрицы после операций с ним.
            if (flag)
            {
                Console.WriteLine("\nВведённая матрица: ");
            }
            else
            {
                Console.WriteLine("\nНовая матрица: ");
            }

            // Вывод двумерного массива матрицы по ячейкам.
            for (int i = 0; i < sizeR; i++)
            {
                for (int j = 0; j < sizeC; j++)
                {
                    if (j == 0)
                        Console.Write($"| {matr[i, j]}");
                    else if (j == sizeC - 1)
                        Console.Write($"{matr[i, j]} |");

                    else
                        Console.Write($" {matr[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Ввод матрицы с размерами строк и столбцов от 2 до 10, ввод номера пункта с требуемым типом заполнения матрицы.
        /// Проверка на корректность ввода (при неправильном – повторный ввод).
        /// </summary>
        /// <param name="sizeRow"> Параметр ввода количества строк матрицы. </param>
        /// <param name="sizeColumn"> Параметр ввода количества столбцов матрицы. </param>
        /// <param name="matrix"> Двумерный массив матрицы заданных размеров. </param>
        static void UserInputMatrix(out int sizeRow, out int sizeColumn, out double[,] matrix)
        {
            bool correctRow, correctColumn;

            Console.WriteLine("\nВведите размер матрицы (строки и столбцы от 2 до 10):");
            do
            {
                Console.Write("Кол-во строк: ");
                correctRow = int.TryParse(Console.ReadLine(), out sizeRow);
                Console.Write("Кол-во столбцов: ");
                correctColumn = int.TryParse(Console.ReadLine(), out sizeColumn);

                if (!correctRow || !correctColumn || sizeRow < 2 || sizeRow > 10 || sizeColumn < 2 || sizeColumn > 10)
                    Console.WriteLine("Некорректный ввод. Повторите попытку...");
            } while (!correctRow || !correctColumn || sizeRow < 2 || sizeRow > 10 || sizeColumn < 2 || sizeColumn > 10);

            bool correctType;
            int numberType;

            Console.WriteLine("\nВведите номер требуемого типа заполнения матрицы:");
            Console.WriteLine("1. Рандомное;\n2. Пользовательское.");
            do
            {
                Console.Write("\nВыбранный номер: ");
                correctType = int.TryParse(Console.ReadLine(), out numberType);

                if (!correctType || numberType < 1 || numberType > 2)
                    Console.WriteLine("Некорректный ввод. Повторите попытку...");
            } while (!correctType || numberType < 1 || numberType > 2);

            matrix = new double[sizeRow, sizeColumn];

            // Переход к одному из методов заполнения матрицы в зависимости от выбранного пользователем типа заполнения.
            if (numberType == 1)
            {
                RandomNumberGenerator(ref matrix, in sizeRow, in sizeColumn);
            }
            else
            {
                UserNumberGenerator(ref matrix, in sizeRow, in sizeColumn);
            }
        }

        /// <summary>
        /// Пользовательский ввод целых чисел (в диапазоне от -50 до 50) в массив уже заданных размеров.
        /// Проверка на корректность ввода (при неправильном – повторный ввод).
        /// </summary>
        /// <param name="matrix"> Передача заданного двумерного массива матрицы по ссылке. </param>
        /// <param name="sizeRow"> Передача заданного параметра количества строк по ссылке. </param>
        /// <param name="sizeColumn"> Передача заданного параметра количества столбцов по ссылке. </param>
        static void UserNumberGenerator(ref double[,] matrix, in int sizeRow, in int sizeColumn)
        {
            bool correctX;

            // Вводимый пользователем элемент матрицы.
            double x;

            Console.WriteLine("Вводите элементы матриц (целочисленные от -50 до 50):");

            // Перебор индексов (позиций матрицы) для красивого отображения в консоли вида "x_'строка'_'столбец' = ".
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    do
                    {
                        Console.Write($"x{i + 1}_{j + 1} = ");
                        correctX = double.TryParse(Console.ReadLine(), out x);

                        if (!correctX || x < -50 || x > 50 || x > (int)x)
                            Console.WriteLine("Некорректный ввод. Повторите попытку...");
                    } while (!correctX || x < -50 || x > 50 || x > (int)x);

                    matrix[i, j] = x;
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Случайный ввод целых чисел (в диапазоне от -50 до 50) в массив уже заданных размеров.
        /// </summary>
        /// <param name="matrix"> Передача заданного двумерного массива матрицы по ссылке. </param>
        /// <param name="sizeRow"> Передача заданного параметра количества строк по ссылке. </param>
        /// <param name="sizeColumn"> Передача заданного параметра количества столбцов по ссылке. </param>
        static void RandomNumberGenerator(ref double[,] matrix, in int sizeRow, in int sizeColumn)
        {
            Random random = new Random();

            bool correctX, correctY;
            int x, y;

            Console.Write("\nВведите диапазон рандомного заполнения матрицы:\nНижний диапазон (от -50 до 49): ");
            do
            {
                correctX = int.TryParse(Console.ReadLine(), out x);

                if (!correctX || x < -50 || x > 49)
                    Console.WriteLine("Некорректный ввод. Повторите попытку...");
            } while (!correctX || x < -50 || x > 49);

            Console.Write("Верхний диапазон (больше нижнего диапазона и от -49 до 50): ");
            do
            {
                correctY = int.TryParse(Console.ReadLine(), out y);

                if (!correctY || y < -49 || y > 50 || y <= x)
                    Console.WriteLine("Некорректный ввод. Повторите попытку...");
            } while (!correctY || y < -49 || y > 50 || y <= x);

            // Случайный ввод чисел в указанном пользователе диапазоне от 'x' до 'y' с помощью random.
            for (int i = 0; i < sizeRow; i++)
            {
                for (int j = 0; j < sizeColumn; j++)
                {
                    matrix[i, j] = (double)random.Next(x, y + 1);
                }
            }
        }

        /// <summary>
        /// Просьба у пользователя ввести необходимый пункт из списка на выбор.
        /// Проверка на корректность ввода введённого числа.
        /// </summary>
        /// <param name="number"> Вводимый пользователем номер выбранного пункта. </param>
        static void UserInputNumber(out int number)
        {
            bool correctNumber;

            // Обращение к пользователю.
            Console.WriteLine("\nВведите номер требуемой операции:");
            Console.WriteLine("1. Нахождение следа матрицы;\n2. Транспонирование матрицы;\n3. Сумма двух матриц;");
            Console.WriteLine("4. Разность двух матриц;\n5. Произведение двух матриц;\n6. Умножение матрицы на число;");
            Console.WriteLine("7. Нахождение определителя матрицы.");

            // Ввод номера и проверка на корректность.
            do
            {
                Console.Write("\nВыбранный номер: ");
                correctNumber = int.TryParse(Console.ReadLine(), out number);

                if (!correctNumber || number < 1 || number > 7)
                    Console.WriteLine("Некорректный ввод. Повторите попытку...");
            } while (!correctNumber || number < 1 || number > 7);
        }
    }
}
