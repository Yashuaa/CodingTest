using CodingTest.Models;
using System.Collections.Generic;

namespace CodingTest.Helpers
{
    public static class CustomExtensions
    {
        public static List<Person> ToPersonList(this string input)
        {
            List<Person> people = new List<Person>();

            Person person = new Person();

            string line = "";
            int index = 0;

            foreach(var letter in input)
            {
                if(index == input.Length - 6)
                {
                    people.Add(person);
                }

                line += letter;

                bool lastLine = CheckIfNewPerson(index, input);

                if (letter.Equals('\n') || lastLine)
                {
                    if(KeyExist(line))
                    {
                        person = SetPersonDetails(line, person);
                    }

                    line = "";
                }

                if (lastLine)
                {
                    people.Add(person);

                    person = new Person();
                }

                index++;
            }

            return people;
        }

        /// <summary>
        /// Receives two strings and returns everything between them
        /// </summary>
        /// <param name="value"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static string GetBetween(this string value, string a, string b)
        {
            int indexA = value.IndexOf(a);
            int indexB = value.IndexOf(b);
            int startFromIndex = indexA + a.Length;

            bool badInput = indexA == -1 || indexB == -1 || startFromIndex >= indexB;

            return badInput ? "Bad input" : value.Substring(startFromIndex, indexB - startFromIndex);
        }

        private static Person SetPersonDetails(string line, Person person)
        {
            if(line.Contains("Name"))
            {
                person.Name = line.GetBetween(")", "\r");
            }

            if(line.Contains("Age"))
            {
                person.Age = line.GetBetween(")", "\r");
            }

            if(line.Contains("City"))
            {
                person.City = line.GetBetween(")", "\r");
            }

            if(line.Contains("Flags"))
            {
                string flags = line.GetBetween(")", "\r");

                person.Female = flags[0].Equals('Y');
                person.Student = flags[1].Equals('Y');
                person.Employee = flags[2].Equals('Y');
            }

            return person;
        }

        private static bool CheckIfNewPerson(int currentIndex, string people)
        {
            if (currentIndex >= people.Length - 6)
                return false;

            if (currentIndex > people.Length)
                return false;

            return people[currentIndex].Equals('\r') && people[currentIndex + 1].Equals('\n')
                && people[currentIndex + 2].Equals('\r') && people[currentIndex + 3].Equals('\n')
                && people[currentIndex + 4].Equals('\r') && people[currentIndex + 5].Equals('\n');
        }

        private static bool KeyExist(string line)
        {
            return line.Contains("Name") || line.Contains("Age") || line.Contains("Flags") || line.Contains("City");
        }
    }
}
