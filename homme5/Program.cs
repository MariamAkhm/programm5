using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace homme5
{
    class Program
    {


        static bool DecodePass(string[] variantsPass, ref string passBinary)
        {
            for (int i = 0; i < variantsPass.Length; i++)
            {
                string temp = "";
                for (int j = 0; j < variantsPass[i].Length; j++)
                {
                    temp = temp + Convert.ToString(variantsPass[i][j], 2);
                }
                if (temp == passBinary)
                {
                    passBinary = variantsPass[i];
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("home2");
            Console.WriteLine("Что кричит Гордон Рамзи?");
            string words = Console.ReadLine();
            string vowels = "уеэёыаоюияУЕЁЭОАЫЯИЮ";
            if (words.Split().Length.Equals(4))
            {
                string gordonswords = words.Replace(" ", "!!! ").Replace("а", "@").Replace("А", "@").ToUpper();
                for (int i = 0; i < gordonswords.Length; i++)
                {
                    if (vowels.Contains(gordonswords[i]))
                    {
                        gordonswords = gordonswords.Replace(gordonswords[i], '*');
                    }
                }
                Console.WriteLine(gordonswords + "!!!");
            }
            else
            {
                Console.WriteLine("Гордон Рамзи молчит");
            }
            Console.ReadKey();

            Console.WriteLine("home1");
            string[] probablyPass = { "password", "pass123", "pass" };
            StreamReader reader = new StreamReader("pass.txt");
            string passBinary = reader.ReadToEnd();
            passBinary = passBinary.Replace(" ", "");
            if (DecodePass(probablyPass, ref passBinary))
            {
                Console.WriteLine(passBinary);
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.ReadKey();
        }
    }
}

