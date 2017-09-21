using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задание_12
{
    class Program
    {
        static int countTransfer = 0;
        static int countSravnenie = 0;

        static void BubbleSort(int[] arr, int size)// сортировка пузырьком
        {
            countSravnenie = 0;
            countTransfer = 0;           

            for (int i = 0; i < size; i++) // i - номер прохода
            {
                for (int j = 0; j < size - 1 - i; j++) 
                {
                    countSravnenie++;

                    if (arr[j] > arr[j+1])
                    {
                        countTransfer++;
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;

                        
                    }
                }
            }
        }

        //k - максим граница значения эл-та в массиве
        //Подсчитываем сколько раз в массиве встречается каждое значение и 
        //заполняем массив подсчитанными элементами в соответствующих количествах.
        static void CountingSort(int[] a, int[] c, int n, int k)//сортировка пересчетами
        {
            countSravnenie = 0;
            countTransfer = 0;

            int i = 0;

            for (i = 0; i < k; i++)//создаем вспомогательный массив, состоящий из нулей
            {
                c[i] = 0;
            }
            for (i = 0; i < n; i++)
            {
                c[a[i]] = c[a[i]] + 1;
            }

            i = 0;
            for (int j = 0; j < k; j++)
            {
               //_countSravnenie++;

                while (c[j] != 0)
                {
                    a[i] = j;
                    c[j]--;
                    i++;

                    countTransfer++;
                    //_countSravnenie++;
                }
            }
        }

        static int[] CreateAscOrderArray(int n)
        {
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = i;
            }

            return arr;
        }

        static int[] CreateDescOrderArray(int n)
        {
            int[] arr = new int[n];

            for (int i = n - 1, j = 0; j < n; i--, j++)
            {
                arr[j] = i;
            }

            return arr;
        }

        static int[] CreateDisorderArray(int n, int max)
        {
            int[] arr = new int[n];

            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(0, max);
            }

            return arr;
        }

        static int[] CopyArray(int[] arr, int n)
        {
            int[] copy = new int[n];

            for (int i = 0; i < n; i++)
            {
                copy[i] = arr[i];
            }

            return copy;
        }

        static void PrintRes()
        {
            Console.WriteLine("Кол-во перестановок = {0}, Кол-во сравнений = {1}", countTransfer, countSravnenie);
        }

        static void Main(string[] args)
        {
            int n = 1000;
            int max = 1000;

            int[] arr = CreateAscOrderArray(n);
            int[] arr_copy = CopyArray(arr, n);

            BubbleSort(arr, n);
            Console.WriteLine("Упорядоченный по возрастанию:");
            PrintRes();


            //max - максимальное значение элемента в массиве arr
            int[] c = new int[max];

            CountingSort(arr_copy, c, n, max);
            PrintRes();

            arr = CreateDescOrderArray(n);
            arr_copy = CopyArray(arr, n);

            BubbleSort(arr, n);
            Console.WriteLine("Упорядоченный по убыванию:");
            PrintRes();

            CountingSort(arr_copy, c, n, max);
            PrintRes();

            arr = CreateDisorderArray(n, max);
            arr_copy = CopyArray(arr, n);

            BubbleSort(arr, n);
            Console.WriteLine("Неупорядоченный массив:");
            PrintRes();

            CountingSort(arr_copy, c, n, max);
            PrintRes();

            Console.ReadLine();
        }
    }
}
