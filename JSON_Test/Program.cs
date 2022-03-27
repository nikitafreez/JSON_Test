using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace JSON_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();

            string[] names = new string[] { "Arina", "Noelle", "Jean", "Yae", "Ei", "Klee", "Yoimiya",
                "Albedo", "Ayaka", "Barbara", "Bennet", "Venti", "Goro", "Diluc", "Diona", "Itto", "Kadzuha", "Kokomi",
                "Keya", "Lisa", "Mona", "Sayu", "Sata", "Fishle", "Aloy", "Amber", "Eula", "Ryan"};
            var nameList = new List<string>(names);
            string[] surnames = new string[] { "Harrington", "Ivashchenko", "Young", "West", "Kelly", "Wright", "Hamilton", "Spencer", "Hancock", "Reynolds", "Watts", "Warren"
               , "Hines", "Caldwell", "Robertson", "Strickland", "Gosling", "Cameron"};
            var surnameList = new List<string>(surnames);

            const int HOW_MANY_PERSONS = 1000;
            Random rnd = new Random();
            for (int i = 0; i < HOW_MANY_PERSONS; i++)
            {
                Person person = new Person();
                string personName = nameList[rnd.Next(0, nameList.Count)];
                string personSurname = surnameList[rnd.Next(0, surnameList.Count)];
                person.name = personName;
                person.surname = personSurname;
                person.age = rnd.Next(14, 100);
                person.height = rnd.Next(120, 210);

                persons.Add(person);
            }

            perToJSONAsync(persons);
            Console.WriteLine("|-----------------------------------------------------------------------|");
            Console.WriteLine("|\tName\t|\tSurname\t\t|\tAge\t|\tHeight\t|");
            Console.WriteLine("|-----------------------------------------------------------------------|");
            foreach(Person person in persons)
            {
                Console.WriteLine("|\t" + person.name + "\t|\t" + person.surname + "    \t|\t" + person.age + "\t|\t" + person.height + "\t|");
            }

            Console.WriteLine("|-----------------------------------------------------------------------|");
        }

        public static void perToJSONAsync(List<Person> person)
        {
            using (FileStream fs = new FileStream("person.json", FileMode.OpenOrCreate))
            {
                JsonSerializer.SerializeAsync(fs, person);
                Console.WriteLine(person.Count);
            }
        }
    }

    public class Person
    {
        public string name { get; set; }
        public string surname { get; set; }
        public int age { get; set; }
        public int height { get; set; }

        public Person(string name, string surname, int age, int height)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
            this.height = height;
        }
        public Person()
        {

        }
    }
}
