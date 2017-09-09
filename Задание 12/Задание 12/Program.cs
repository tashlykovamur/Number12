using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Задание_12
{
    class Program
    {
        static int _countTransfer = 0;
        static int _countSravnenie = 0;

        static void BubbleSort(int[] arr, int size)
        {
            _countSravnenie = 0;
            _countTransfer = 0;

            int tmp;

            for (int i = 0; i < size - 1; ++i) // i - номер прохода
            {
                for (int j = 0; j < size - 1; ++j) // внутренний цикл прохода
                {
                    _countSravnenie++;

                    if (arr[j + 1] < arr[j])
                    {
                        tmp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = tmp;

                        _countTransfer += 3;
                    }
                }
            }
        }

        //k - максим граница значения эл-та в массиве
        static void CountingSort(int[] a, int[] c, int n, int k)
        {
            _countSravnenie = 0;
            _countTransfer = 0;

            int i = 0;

            for (i = 0; i < k; i++)
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
                _countSravnenie++;

                while (c[j] != 0)
                {
                    a[i] = j;
                    c[j]--;
                    i++;

                    _countTransfer++;
                    _countSravnenie++;
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
            Console.WriteLine("Кол-во перестановок = {0}, Кол-во сравнений = {1}", _countTransfer, _countSravnenie);
        }

        static void Main(string[] args)
        {
            int n = 10;
            int max = 50;

            int[] arr = CreateAscOrderArray(n);
            int[] arr_copy = CopyArray(arr, n);

            BubbleSort(arr, n);
            PrintRes();

            //max - максимальное значение элемента в массиве arr
            int[] c = new int[max];

            CountingSort(arr_copy, c, n, max);
            PrintRes();

            arr = CreateDescOrderArray(n);
            arr_copy = CopyArray(arr, n);

            BubbleSort(arr, n);
            PrintRes();

            CountingSort(arr_copy, c, n, max);
            PrintRes();

            arr = CreateDisorderArray(n, max);
            arr_copy = CopyArray(arr, n);

            BubbleSort(arr, n);
            PrintRes();

            CountingSort(arr_copy, c, n, max);
            PrintRes();

            Console.ReadLine();
        }
    }
}
