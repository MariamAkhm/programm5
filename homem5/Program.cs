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
        static double[] TemperatureValue(Dictionary<string, double[]> array)
        {
            string[] mounth = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            double[] result = new double[array.Keys.Count];
            for (int i = 0; i < array.Keys.Count; i++)
            {
                double sum = 0;
                for (int j = 0; j < array.Values.Count; j++)
                {
                    sum += array[mounth[i]][j];
                }
                result[i] = sum / array.Keys.Count;
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

            Console.WriteLine("homemet5");


            Console.WriteLine("homemet6");
            Dictionary<string, double[]> temperature1 = new Dictionary<string, double[]>();
            int count = 12;
            int maxTemp = 30;
            int minTemp = -30;
            for (int i = 0; i < count; i++)
            {
                double[] temperatureOfDay = new double[30];
                for (int j = 0; j < temperatureOfDay.Length; j++)
                {
                    temperatureOfDay[j] = value.NextDouble() * (maxTemp - minTemp) + minTemp;
                }
                switch (i)
                {
                    case 0:
                        temperature1.Add("Январь", temperatureOfDay);
                        break;
                    case 1:
                        temperature1.Add("Февраль", temperatureOfDay);
                        break;
                    case 2:
                        temperature1.Add("Март", temperatureOfDay);
                        break;
                    case 3:
                        temperature1.Add("Апрель", temperatureOfDay);
                        break;
                    case 4:
                        temperature1.Add("Май", temperatureOfDay);
                        break;
                    case 5:
                        temperature1.Add("Июнь", temperatureOfDay);
                        break;
                    case 6:
                        temperature1.Add("Июль", temperatureOfDay);
                        break;
                    case 7:
                        temperature1.Add("Август", temperatureOfDay);
                        break;
                    case 8:
                        temperature1.Add("Сентябрь", temperatureOfDay);
                        break;
                    case 9:
                        temperature1.Add("Октябрь", temperatureOfDay);
                        break;
                    case 10:
                        temperature1.Add("Ноябрь", temperatureOfDay);
                        break;
                    case 11:
                        temperature1.Add("Декабрь", temperatureOfDay);
                        break;
                }
            }
            double[] avarageTemperature= TemperatureValue(temperature1);
            Array.Sort(avarageTemperature);
            Console.WriteLine("Средние значения температуры: ");
            for (int i = 0; i < avarageTemperature.Length; i++)
            {
                Console.WriteLine(avarageTemperature[i]);
            }
            Console.ReadKey();
        }
    }
}
