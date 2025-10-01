using System;

namespace Lab_2_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Тест Task1");
            double[] arr = { 3.5, -2.1, 4.7, 0.5, -7.3, 6.2, 1.1 };
            double a = -1, b = 2;
            Task1(arr, a, b);

            Console.WriteLine("\nТест Task2");
            int[][] matrix =
            {
                new int[] { 5, 0, -2, -4 },
                new int[] { -6, 3, 1, 8 },
                new int[] { 7, -8, 0, -2 },
                new int[] { 9, 4, -10, 11 }
            };
            Task2(matrix);

            Console.WriteLine("\nТест Task3");
            Console.WriteLine("Введіть рядок для Task3 (наприклад: \"Hello WORLD this IS test рядок\"):");
            Task3();

            LombardApp.RunLombard();
        }

        static void Task1(double[] array, double a, double b)
        {
            int n = array.Length;

            double minAbs = Math.Abs(array[0]);
            double minAbsValue = array[0];
            for (int i = 1; i < n; i++)
            {
                if (Math.Abs(array[i]) < minAbs)
                {
                    minAbs = Math.Abs(array[i]);
                    minAbsValue = array[i];
                }
            }
            Console.WriteLine($"Мінімальний за модулем елемент: {minAbsValue}");

            double sumAfterNegative = 0;
            int firstNegIndex = -1;
            for (int i = 0; i < n; i++)
            {
                if (array[i] < 0)
                {
                    firstNegIndex = i;
                    break;
                }
            }

            if (firstNegIndex != -1)
            {
                for (int i = firstNegIndex + 1; i < n; i++)
                {
                    sumAfterNegative += Math.Abs(array[i]);
                }
            }
            Console.WriteLine($"Сума модулів після першого від’ємного: {sumAfterNegative}");

            int newLength = 0;
            for (int i = 0; i < n; i++)
            {
                if (!(array[i] >= a && array[i] <= b))
                {
                    array[newLength++] = array[i];
                }
            }

            for (int i = newLength; i < n; i++)
            {
                array[i] = 0;
            }

            ArraySegment<double> compressed = new ArraySegment<double>(array, 0, newLength);

            Console.WriteLine("Стиснутий масив:");
            foreach (var x in compressed)
                Console.Write(x + " ");
            Console.WriteLine();

            Console.WriteLine("Повний масив із нулями:");
            foreach (var x in array)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        static void Task2(int[][] matrix)
        {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int firstZeroCol = -1;
            for (int j = 0; j < cols; j++)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (matrix[i][j] == 0)
                    {
                        firstZeroCol = j;
                        break;
                    }
                }
                if (firstZeroCol != -1) break;
            }
            Console.WriteLine($"Перший стовпець із нулем: {firstZeroCol}");

            int[] characteristics = new int[rows];
            for (int i = 0; i < rows; i++)
            {
                int sum = 0;
                foreach (var val in matrix[i])
                {
                    if (val < 0 && val % 2 == 0)
                        sum += val;
                }
                characteristics[i] = sum;
            }

            Console.WriteLine("Характеристики рядків:");
            for (int i = 0; i < rows; i++)
                Console.WriteLine($"Рядок {i}: {characteristics[i]}");

            int[] indices = new int[rows];
            for (int i = 0; i < rows; i++) indices[i] = i;

            Array.Sort(characteristics, indices);
            Array.Reverse(characteristics);
            Array.Reverse(indices);

            int[][] sortedMatrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                sortedMatrix[i] = matrix[indices[i]];
            }

            Console.WriteLine("Матриця після перестановки рядків:");
            foreach (var row in sortedMatrix)
            {
                foreach (var val in row)
                    Console.Write(val + "\t");
                Console.WriteLine();
            }
        }

        static void Task3()
        {
            string text = Console.ReadLine();

            string lower = text.ToLower();
            Console.WriteLine("Рядок у малих літерах:");
            Console.WriteLine(lower);

            char[] separators = { ' ', '\t', ',', '.', '!', '?', ';', ':', '-', '(', ')', '[', ']', '"' };
            string[] words = lower.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string longest = "";
            foreach (string w in words)
            {
                if (w.Length > longest.Length)
                    longest = w;
            }
            Console.WriteLine($"Найдовше слово: {longest}");

            string vowels = "aeiouаеєиіїоуюя";
            string result = "";

            foreach (string w in words)
            {
                int consonants = 0;
                foreach (char c in w)
                {
                    if (char.IsLetter(c) && !vowels.Contains(c.ToString()))
                        consonants++;
                }

                if (consonants % 2 == 0)
                {
                    if (result.Length > 0) result += " ";
                    result += w;
                }
            }

            Console.WriteLine("Рядок без слів із непарною кількістю приголосних:");
            Console.WriteLine(result);
        }
    }
}
