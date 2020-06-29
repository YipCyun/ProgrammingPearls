using System;

namespace QuickSortPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tosort = new int[10];

            Random randon = new Random();

            Console.WriteLine("Original array elements:");
            for (int i = 0; i < 10; i++)
            {
                tosort[i] = randon.Next(0, 100);
                Console.Write(tosort[i] + " ");
            }
            Console.WriteLine();

            int lowIndex = 0;
            int highIndex = tosort.Length - 1;

            QuickSort(tosort, lowIndex, highIndex);

            Console.WriteLine("Sorted array elements:");
            for (int i = 0; i < tosort.Length; i++)
            {
                Console.Write(tosort[i] + " ");
            }
            Console.WriteLine();
        }

        private static void QuickSort(int [] array, int low, int high)
        {
            try
            {
                int pivotPosition;
                if (low < high)
                {
                    pivotPosition = GetPivotPosition(array, low, high);
                    QuickSort(array, low, pivotPosition - 1);
                    QuickSort(array, pivotPosition + 1, high);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static int GetPivotPosition(int[] array, int low, int high)
        {
            int leftIndex = low;
            int rightIndex = high;

            int pivot = array[low];
            int temp;

            while (leftIndex < rightIndex)
            {
                while (leftIndex < rightIndex && array[leftIndex] <= pivot)
                {
                    leftIndex++;
                }

                while (leftIndex < rightIndex && array[rightIndex] >= pivot)
                {
                    rightIndex--;
                }

                if (leftIndex < rightIndex)
                {
                    temp = array[leftIndex];
                    array[leftIndex] = array[rightIndex];
                    array[rightIndex] = temp;
                }
            }

            temp = pivot;
            if (temp < array[rightIndex])
            {
                array[low] = array[rightIndex - 1];
                array[rightIndex - 1] = temp;
                return rightIndex - 1;
            }
            else
            {
                array[low] = array[rightIndex];
                array[rightIndex] = temp;
                return rightIndex;
            }
        }
    }
}