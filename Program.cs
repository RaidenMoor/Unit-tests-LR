using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchElementArray
{
    public class Program
    {
        static void Main(string[] args)
        {
            double[] array;
            try
            {
                int n = GetArraySize();
                array = GetOrderedArray(n);             
                Console.WriteLine("Ваш массив:");
                ArrayWrite(array);
                double element = GetSearchElement();
                double index = BinarySearch(array, element);
                
                ShowResult(index);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static void ArrayWrite(double[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
        public static int GetArraySize()
        {
            string input;
            int n;
            bool flag;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nВведите размер массива:");
                    input = Console.ReadLine();
                    ConvertToInt32(input, out n, out flag);
                    if (flag)
                        if (n > 1) return n;
                        else throw new Exception("Размерность массива не может быть меньше единицы! Повторите ввод");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
        }

        public static double[] GetOrderedArray(int n)
        {
            double[] array = new double[n];
            bool flag;

            Console.WriteLine("Введите элементы массива:");
            for (int i = 0; i < n; i++)
            {
                while (true)
                {
                    try
                    {
                        ConvertToDouble(Console.ReadLine(), out array[i], out flag);
                        if (flag)
                        {
                           
                                // Проверка на меньшее значение, чем у всех предыдущих элементов
                                bool isLessThanAllPrevious = true;

                                for (int j = 0; j < i; j++)
                                {
                                    if (array[i] < array[j])
                                    {
                                        isLessThanAllPrevious = false;
                                        break;
                                    }
                                }

                                if (!isLessThanAllPrevious)
                                {
                                    throw new Exception("Вы ввели элемент меньше предыдущих. Массив должен быть упорядочен по возрастанию.");
                                }

                                break;                          
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\n" + e.Message);
                        Console.WriteLine("\nПовторите ввод. Текущий индекс элемента:" + (i));
                    }
                }
            }
            return array;
        }

        public static double GetSearchElement()
        {
            string input;
            double element;
            bool flag;

            while (true)
            {
                try
                {
                    Console.WriteLine("\nВведите искомый элемент:");
                    ConvertToDouble(Console.ReadLine(), out element, out flag);
                    if (flag) return element;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message.ToString());
                }
            }
        }

        public static void ShowResult(double index)
        {
            if (index == -1)
                Console.WriteLine("Элемент не найден");
            else Console.WriteLine("Элемент найден. Его порядковый номер: " + (index + 1));
        }

        public static void ConvertToInt32(string input, out int num, out bool flag)
        {
            flag = false;
            num = 0;
            if (Int32.TryParse(input, out num))
            {
                flag = true;
            }
            else throw new Exception("Введено некорректное значение. Ожидается целое число.");
        }

        public static void ConvertToDouble(string input, out double num, out bool flag)
        {
            flag = false;
            num = 0;
            if (Double.TryParse(input, out num))
            {
                flag = true;
            }
            else throw new Exception("Введено некорректное значение. Ожидается число.");
        }

        public static double BinarySearch(double[] array, double element)
        {
            // Реализация бинарного поиска
            int left = 0, right = array.Length - 1;
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] == element) return mid;
                if (array[mid] < element) left = mid + 1;
                else right = mid - 1;
            }
            return -1; // элемент не найден
        }
    }
}
