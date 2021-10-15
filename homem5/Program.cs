using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homem5
{
    class Program
    {
        enum Months { January = 1, February, March, April, May, June, July, August, September, October, November, December }
        static double[,] Print(double[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.WriteLine(a[i, j]);
                }
            }
            return a;
        }
        static double[,] Multiplication(double[,] a, double[,] b)
        {
            double[,] result = new double[a.GetLength(0), b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {
                        result[i, j] += a[i, k] * b[k, j];
                    }
                }
            }
            return result;
        }
        static void PrintVowelsConsonants(string str)
        {
            char[] symbol = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                symbol[i] = str[i];
            }
            string vowels = "аеёиоуыэюя";
            string consonants = "бвгджзйклмнпрстфхцчшщ";
            int countVowels = 0;
            int countConsonants = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(symbol[i]))
                {
                    countVowels++;
                }
                else if (consonants.Contains(symbol[i]))
                {
                    countConsonants++;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("homemet1");
            string vowels = "аеёиоуыэюя";
            string consonants = "бвгджзйклмнпрстфхцчшщ";
            string str = File.ReadAllText("Text.txt");
            char[] symbols = new char[str.Length];
            PrintVowelsConsonants(str);

            Console.WriteLine("homemet2");
            Console.WriteLine("Введите размерность первой матрицы: ");
            double[,] matricaOne = new double[2, 2];
            for (int i = 0; i < matricaOne.GetLength(0); i++)
            {
                for (int j = 0; j < matricaOne.GetLength(1); j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    matricaOne[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine("Введите размерность второй матрицы: ");
            double[,] matricaTwo = new double[2, 2];
            for (int i = 0; i < matricaTwo.GetLength(0); i++)
            {
                for (int j = 0; j < matricaTwo.GetLength(1); j++)
                {
                    Console.Write("A[{0},{1}] = ", i, j);
                    matricaOne[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
            Print(matricaOne);
            Print(matricaTwo);
            double[,] result = Multiplication(matricaOne, matricaTwo);
            Print(result);

            Console.WriteLine("homemet3");
            int countMonths = 12;
            int countDaysInMonths = 30;
            double summ = 0;
            Random value = new Random();
            double[,] temperature = new double[countMonths, countDaysInMonths];
            var avgTempInMonth = new double[countMonths];
            for (int i = 0; i < countMonths; i++)
            {
                summ = 0;
                for (int j = 0; j < countDaysInMonths; j++)
                {
                    temperature[i, j] = value.Next(-45, 45);
                    summ += temperature[i, j];

                }
                avgTempInMonth[i] = summ / countDaysInMonths;
            }
            summ = 0;
            byte temp = 1;
            foreach (var item in avgTempInMonth)
            {
                Console.WriteLine($"Средние температуры за месяц {(Months)temp} составила : {item}");
                summ += item;
                temp++;
            }
            Console.WriteLine($"Средняя температура за весь год = {summ / countMonths}");

            Console.WriteLine("homemet4");
            vowels = "аеёиоуыэюя";
            consonants = "бвгджзйклмнпрстфхцчшщ";
            str = File.ReadAllText("Text.txt");
            var list = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                symbols[i] = str[i];
            }
            Console.WriteLine(str);
            int countVowels = 0;
            int countConsonants = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (vowels.Contains(list[i]))
                {
                    countVowels++;
                }
                else if (consonants.Contains(list[i]))
                {
                    countConsonants++;
                }
            }
            Console.WriteLine("Кол-во гласных в файле = " + countVowels);
            Console.WriteLine("Кол-во согласных в файле = " + countConsonants);         
        }
    }
}
