using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //bool iscorrect;
            //byte age;
            //iscorrect = byte.TryParse(Console.ReadLine(), out age);
            //Console.WriteLine(age);
            //Console.ReadKey
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public (string, string) GetInfo()
        {
            string name;
            string surname;
            bool iscorrect;
            byte age;
            bool havePet;
            byte numPets;

            string[] pets;


            Console.WriteLine("Enter yor name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter yor surname: ");
            surname = Console.ReadLine();
            Console.Write("Enter your age: ");
            age = CheckedNum();
            Console.WriteLine("Do u have a pet? Y/N");
            string tempAns = Console.ReadLine();
            if (tempAns == "Y")
            {
                havePet = true;
                Console.WriteLine("How many pets do u have?: ");
                numPets = CheckedNum();
                pets = Pets(numPets);
            }
            else { havePet = false; }



        }

        public string[] Pets(byte numPets)
        {
            string[] petNames = new string[numPets];
            Console.WriteLine("Enter your pets names");
            for (int i = 0; i < numPets; i++)
            {
                Console.WriteLine($"Name of {i + 1} pet is: ");
                string tempPetName = Console.ReadLine();
                petNames[i] = tempPetName;
            }
            return petNames;

        }

        public byte CheckedNum()
        {
            byte correctNum;
            bool iscorrect = byte.TryParse(Console.ReadLine(), out correctNum); ;
            if (iscorrect == false)
            {
                Console.WriteLine("You enterd wrong value");
                Console.WriteLine("Enter value again");
                CheckedNum();
            }
            return correctNum;
        }

    }
}
