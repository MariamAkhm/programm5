using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //картинки
using System.IO;  //файлы

namespace clas5
{

    public struct Student
    {
        public string name;
        public string surname;
        public int date;
        public string exam;
        public int bal;
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("class 1");
            Random rand = new Random();
            int peopleInFirstTeam = rand.Next(1, 50);
            int[] firstteam = new int[peopleInFirstTeam];
            int peopleInSecondTeam = rand.Next(1, 50);
            int[] secondteam = new int[peopleInSecondTeam];
            int countFiveInFirst = 0;
            int countFiveInSecondTeam = 0;
            for (int i = 0; i < peopleInFirstTeam; i++)
            {
                firstteam[i] = rand.Next(0, 10);
                if (firstteam[i] == 5)
                {
                    countFiveInFirst++;
                }
            }
            for (int i = 0; i < peopleInSecondTeam; i++)
            {
                secondteam[i] = rand.Next(0, 10);
                if (secondteam[i] == 5)
                {
                    countFiveInSecondTeam++;
                }
            }

            if (countFiveInSecondTeam == countFiveInFirst)
            {
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
            }

            Console.WriteLine("class 2");
            Dictionary<int, Image> img = new Dictionary<int, Image>();

            for (int i = 1; i < 64; i++)
            {
                if (i % 32 == 0)
                {
                    img.Add(i, Image.FromFile($"{i % 33}.jpg"));
                }
                else
                {
                    img.Add(i, Image.FromFile($"{i % 32}.jpg"));
                }
            }
            img.Add(64, Image.FromFile("32.jpg"));

            foreach (var image in img)
            {
                Console.WriteLine(image.Key + " " + image.Value);
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 1; i <= 64; i++)
            {
                int swap = rand.Next(1, 64);
                var t = img[i];
                img[i] = img[swap];
                img[swap] = t;
            }
            foreach (var item in img)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
            Console.Read();
            Console.Clear();

            Console.WriteLine("class 3");
            Dictionary<int, Student> students = new Dictionary<int, Student>();
            StreamReader reader = new StreamReader("students.txt");

            int people = 0;
            while (reader.ReadLine() != null)
            {
                people++;
            }
            reader = new StreamReader("students.txt");

            for (int i = 1; i <= people; i++)
            {
                string str = reader.ReadLine();
                string name = str.Substring(0, str.IndexOf(" "));
                str = str.Remove(0, str.IndexOf(" ") + 1);
                string surname = str.Substring(0, str.IndexOf(" "));
                str = str.Remove(0, str.IndexOf(" ") + 1);
                int date;
                if (!int.TryParse(str.Substring(0, str.IndexOf(" ")), out date))
                {
                    date = 2000;
                }
                str = str.Remove(0, str.IndexOf(" ") + 1);
                string exam = str.Substring(0, str.IndexOf(" "));
                str = str.Remove(0, str.IndexOf(" ") + 1);
                int bal;
                if (!int.TryParse(str, out bal))
                {
                    bal = 0;
                }
                Student student = new Student();
                student.bal = bal;
                student.date = date;
                student.exam = exam;
                student.name = name;
                student.surname = surname;
                students.Add(i, student);
            }
            bool flag = true;
            while (flag)
            {

                Console.WriteLine("Введите команды Удалить,Сортировать,Новый Студент,Вывести,Выйти");
                string str = Console.ReadLine();
                if (str.ToLower() == "вывести")
                {
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.Key} {student.Value.name} {student.Value.surname} {student.Value.date} {student.Value.exam} {student.Value.bal}");
                    }
                }
                else if (str.ToLower() == "новый студент")
                {
                    Console.WriteLine("Введите имя студента");
                    Student student = new Student();
                    student.name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию студента");
                    student.surname = Console.ReadLine();
                    Console.WriteLine("Введите год рождения");
                    while (!int.TryParse(Console.ReadLine(), out student.date))
                    {
                        Console.WriteLine("Неверный ввод,пробуйте еще раз");
                    }
                    Console.WriteLine("Введите экзамен");
                    student.exam = Console.ReadLine();
                    Console.WriteLine("Введите балл");
                    while (!int.TryParse(Console.ReadLine(), out student.bal))
                    {
                        Console.WriteLine("Неверный ввод,пробуйте еще раз");
                    }
                    students.Add(students.Count + 1, student);
                }
                else if (str.ToLower() == "удалить")
                {
                    bool isRemoved = false;
                    Console.WriteLine("Введите имя студента");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию студента");
                    string surname = Console.ReadLine();
                    for (int i = 1; i <= students.Count; i++)
                    {
                        if (students[i].name == name && students[i].surname == surname)
                        {
                            var t = students[i];
                            students[i] = students[students.Count];
                            students[students.Count] = t;
                            students.Remove(students.Count);
                            isRemoved = true;
                        }
                    }
                    if (isRemoved)
                    {
                        Console.WriteLine("Человек был удален!");
                    }
                    else
                    {
                        Console.WriteLine("Не найден такой человек");
                    }
                }
                else if (str.ToLower() == "сортировать")
                {
                    for (int i = 1; i <= students.Count; i++)
                    {
                        for (int j = 1; j <= students.Count - i; j++)
                        {
                            if (students[j].bal > students[j + 1].bal)
                            {
                                var t = students[j];
                                students[j] = students[j + 1];
                                students[j + 1] = t;
                            }
                        }
                    }
                }
            }
        }
    }
}