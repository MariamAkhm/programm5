using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; //картинки
using System.IO;  //файлы

namespace class5
{
    public struct Hospital
    {
        public string name;
        public List <string> diseases;
        public int capacity;
    }

    public struct Granny
    {
        public string name;
        public int age;
        public List<string> diseases;       
    }
    public struct Worker
    {
        public string name;
        public string profession;
        public int empudence;
        public bool isStupidity;
    }


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
            Dictionary<int, string/*Image*/> img = new Dictionary<int, string/*Image*/>();

            for (int i = 1; i < 64; i++)
            {
                if (i % 32 == 0)
                {
                    img.Add(i, /*Image.FromFile*/($"{i % 33}.jpg"));
                }
                else
                {
                    img.Add(i, /*Image.FromFile*/($"{i % 32}.jpg"));
                }
            }
            img.Add(64, /*Image.FromFile*/("32.jpg"));

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
                else if (str.ToLower().Equals("выйти"))
                {
                    flag = false;
                }
            }
            Console.Clear();


            Console.WriteLine("Task 4");
            List<Worker> workers = new List<Worker>();
            Console.WriteLine("Сколько работников в очереди?");
            int count;
            while (!int.TryParse(Console.ReadLine(),out count) || count<0)
            {
                Console.WriteLine("Неверный ввод, введите еще раз");
            }
            for (int i = 0; i < count; i++)
            {
                Worker worker = new Worker();
                Console.WriteLine("Введите имя");
                worker.name = Console.ReadLine();
                Console.WriteLine("Введите его профессию");
                worker.profession = Console.ReadLine();
                Console.WriteLine("Введите степень наглости");
                while(!int.TryParse(Console.ReadLine(),out worker.empudence)|| worker.empudence<0 || worker.empudence>10)
                {
                    Console.WriteLine("Неверный ввод");
                }
                Console.WriteLine("Введите тупой он или нет? -true or false?");
                while (!bool.TryParse(Console.ReadLine(),out worker.isStupidity))
                {
                    Console.WriteLine("Повторите ввод!");
                }
                workers.Add(worker);                                             
            }
            for (int i = 0; i < count; i++) //сортировка по наглости и тупости
            {
                for (int j = 0; j < count-i-1; j++)
                {
                    if (workers[j].isStupidity && workers[j].empudence > workers[j + 1].empudence)
                    {
                        var temp = workers[j];
                        workers[j] = workers[j + 1];
                        workers[j + 1] = temp;
                    }
                }
            }
            Queue<Worker> queue = new Queue<Worker>();
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(workers[i]);
            }
            int capasity = 4;
            List<Stack<Worker>> tablesList = new List<Stack<Worker>>();
            for (int i = 0; i < count; i++) //заполняем столы
            {
                if (queue.Count != 0) 
                {

                    if (queue.Peek().isStupidity)
                    {
                        tablesList.Add(new Stack<Worker>());
                        if (queue.Count < capasity)
                        {
                            for (int j = 0; j < queue.Count; j++)
                            {
                                tablesList[i].Push(workers[j]);
                                queue.Dequeue();
                            }
                        }
                        else
                        {
                            for (int j = 0; j < capasity; j++)
                            {
                                tablesList[i].Push(workers[j]);
                                queue.Dequeue();
                            }

                        }
                    }
                    else
                    {
                        tablesList.Add(new Stack<Worker>());
                        if (queue.Count < capasity - 1)
                        {
                            for (int j = 0; j < queue.Count; j++)
                            {
                                tablesList[i].Push(workers[j]);
                                queue.Dequeue();
                            }

                        }
                        else
                        {
                            for (int j = 0; j < capasity - 1; j++)
                            {
                                tablesList[i].Push(workers[j]);
                                queue.Dequeue();
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Task 5");
            Console.WriteLine("Введите кол-во больниц");           
            while(!int.TryParse(Console.ReadLine(),out count)|| count < 0)
            {
                Console.WriteLine("Неверный ввод!");
            }
            List<Hospital> hospitals = new List<Hospital>(count);

            for (int i = 0; i < count; i++)
            {
                Hospital hospital = new Hospital();
                Console.WriteLine("Введите название больницы");
                hospital.name = Console.ReadLine();
                Console.WriteLine("Введите вместимость больницы");
                while(!int.TryParse(Console.ReadLine(),out hospital.capacity) || hospital.capacity<0)
                {
                    Console.WriteLine("Неверный ввод");
                }
                Console.WriteLine("Введите кол-во заболеваний которые лечит данная больница");
                int countOfDiseases;
                while (!int.TryParse(Console.ReadLine(), out countOfDiseases) || countOfDiseases < 0)
                {
                    Console.WriteLine("Неверный ввод");
                }
                hospital.diseases = new List<string>();
                for (int j = 0; j < countOfDiseases; j++)
                {
                    Console.WriteLine("Введите заболевание");
                    hospital.diseases.Add(Console.ReadLine());
                }
                hospitals.Add(hospital);
            }

            Console.WriteLine("Сколько бабуль?");
            while(!int.TryParse(Console.ReadLine(),out count) || count < 0)
            {
                Console.WriteLine("Неверный ввод!");
            }
            List<Granny> grannies = new List<Granny>(count);

            for (int i = 0; i < count; i++)
            {
                Granny granny = new Granny();
                Console.WriteLine("Введите имя бабушки");
                granny.name = Console.ReadLine();
                Console.WriteLine("Введите возраст бабушки");
                while (!int.TryParse(Console.ReadLine(), out granny.age) || granny.age < 0)
                {
                    Console.WriteLine("Неверный ввод");
                }
                Console.WriteLine("Сколько заболеваний у бабушки");
                int countOfDiseases;
                while (!int.TryParse(Console.ReadLine(), out countOfDiseases) || countOfDiseases < 0)
                {
                    Console.WriteLine("Неверный ввод");
                }
                granny.diseases = new List<string>();
                for (int j = 0; j < countOfDiseases; j++)
                {
                    Console.WriteLine("Введите заболевание");
                    granny.diseases.Add(Console.ReadLine());
                }
                grannies.Add(granny);
            }
            List<int> tempGrannies = new List<int>(hospitals.Count);
            for (int i = 0; i < tempGrannies.Count; i++)
            {
                tempGrannies[i] = 0;
            }
            
            int cryingGrannies = 0;
            for (int i = 0; i < grannies.Count; i++)
            {
                for (int j = 0; j < tempGrannies.Count; j++)
                {
                    if ((grannies[i].diseases.Count >= hospitals[j].diseases.Count / 2) && (tempGrannies[j] < hospitals[j].capacity))
                    {
                        Console.WriteLine($"Бабушка {grannies[i].name} лечится в {hospitals[j]}");
                        tempGrannies[j]++;
                    }
                    else if(grannies[i].diseases.Count == 0)
                    {
                        Console.WriteLine($"Бабушка {grannies[i].name} пришла просто спросить в больницу {hospitals[j]}");
                        tempGrannies[j]++;
                    }
                    else 
                    {
                        Console.WriteLine($"Бабушка {grannies[i].name} осталась плакать");
                        cryingGrannies++;
                    }
                }
            }
        }
    }
}
