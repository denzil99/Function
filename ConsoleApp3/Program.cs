using System;

namespace ConsoleApp3
{
    internal class Program
    {
        // READ!!!!
        // Я использовал byte вместо uint т.к значения небольшие

        /// <summary>
        /// точка входп
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var person = GetInfo();

            PrintPerson(person);

            Console.ReadKey();
        }

        /// <summary>
        /// Метод печатающий значения из кортежа
        /// </summary>
        /// <param name="tuple"></param>
        static void PrintPerson((string name, string surname, byte age,
                string[] pets, string[] favColors) tuple)
        {
            Console.WriteLine();

            Console.WriteLine($"Name: {tuple.name} ");
            Console.WriteLine($"Surname: {tuple.surname} ");
            Console.WriteLine($"Age: {tuple.age} ");

            if (tuple.pets != null)
            {
                int i = 0;
                foreach (var pet in tuple.pets)
                {
                    Console.WriteLine($"Name of {++i} pet is {pet}");
                }
            }
            else { Console.WriteLine($"{tuple.name} don't have a pet"); }


            for (int i = 0; i < tuple.favColors.Length; i++)
            {
                Console.WriteLine($"Your {i + 1} favourite color is: {tuple.favColors[i]}");
            }
        }

        /// <summary>
        /// Метод собирающий данные
        /// </summary>
        /// <returns></returns>
        static (string, string, byte, string[], string[]) GetInfo()
        {


            byte numPets;
            byte numColor;


            (string name, string surname, byte age,
                string[] pets, string[] favColors) Person;


            Console.WriteLine("Enter yor name: ");
            Person.name = ChekedString();

            Console.WriteLine("Enter yor surname: ");
            Person.surname = ChekedString();

            Console.Write("Enter your age: ");
            Person.age = CheckedNum();

            Console.WriteLine("Do u have a pet? Y/N");
            string tempAns = ChekedString();

            Person.pets = new string[0];

            if (tempAns.ToLower() == "y")
            {
                Console.WriteLine("How many pets do u have? ");
                numPets = CheckedNum();
                Person.pets = Pets(numPets);
            }
            else if (tempAns.ToLower() == "n")
            {

                Person.pets = new string[0];

            }

            Console.WriteLine("How many colors do u like?");

            numColor = CheckedNum();
            Person.favColors = FavColors(numColor);

            return (Person.name, Person.surname, Person.age, Person.pets, Person.favColors);

        }

        /// <summary>
        /// Функция возвращает массив с животными
        /// </summary>
        /// <param name="numPets"></param>
        /// <returns></returns>
        static string[] Pets(byte numPets)
        {
            string[] petNames = new string[numPets];

            Console.WriteLine("Enter your pets names");

            for (int i = 0; i < numPets; i++)
            {
                Console.WriteLine($"Name of {i + 1} pet is: ");
                string tempPetName = ChekedString();
                petNames[i] = tempPetName;
            }

            return petNames;
        }

        /// <summary>
        /// Функция возвращает массив с любимыми цветами
        /// </summary>
        /// <param name="numFavColors"></param>
        /// <returns></returns>
        static string[] FavColors(byte numFavColors)
        {
            string[] tempFavColors = new string[numFavColors];
            Console.WriteLine("Enter your favourite colors:");
            for (int i = 0; i < numFavColors; i++)
            {
                Console.WriteLine($"Name of {i + 1} favourite color is: ");
                string tempColor = ChekedString();
                tempFavColors[i] = tempColor;
            }
            return tempFavColors;
        }


        /// <summary>
        /// Функция проверяет введеные числовые значения
        /// </summary>
        /// <returns></returns>
        static byte CheckedNum()
        {
            byte correctNum;
            bool iscorrect = byte.TryParse(Console.ReadLine(), out correctNum);
            if (iscorrect == false)
            {
                Console.WriteLine("You enterd wrong value");
                Console.WriteLine("Enter value again");

                correctNum = CheckedNum();
                return correctNum;
            }
            else if (correctNum > 150)
            {
                Console.WriteLine("You enterd wrong value");
                Console.WriteLine("Enter value again");

                correctNum = CheckedNum();
                return correctNum;
            }
            else
            {
                return correctNum;
            }
        }

        /// <summary>
        ///  Метод проверяет введеные строковые значения
        /// Проверку на наличие цифр в строке не делал
        /// </summary>
        /// <returns></returns>
        static string ChekedString()
        {
            string correctValue = "";
            correctValue = Console.ReadLine();

            int num;
            bool iscorrect = int.TryParse(correctValue, out num);

            if (iscorrect == true)
            {
                Console.WriteLine("You enterd wrong value");
                Console.WriteLine("Enter value again");

                correctValue = ChekedString();
            }
            else if (String.IsNullOrEmpty(correctValue))
            {
                Console.WriteLine("You enterd nothing");
                Console.WriteLine("Enter value again");

                correctValue = ChekedString();
            }


            return correctValue;

        }

    }
}
