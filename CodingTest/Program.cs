using CodingTest.Helpers;
using CodingTest.Models;
using System;
using System.Collections.Generic;

namespace CodingTest
{
    class Program
    {
        #region Fields
        private static string Input =
            "(Name)John Doe" + Environment.NewLine +
            "(Age)20" + Environment.NewLine +
            "(City)Ashtabula, OH" + Environment.NewLine +
            "(Flags)NYN" + Environment.NewLine +
            Environment.NewLine +
            Environment.NewLine +
            "(Name)Jane Doe" + Environment.NewLine +
            "(City)N Kingsville, OH" + Environment.NewLine +
            "(Flags)YNY" + Environment.NewLine +
            Environment.NewLine +
            Environment.NewLine +
            "(Name)Sally Jones" + Environment.NewLine +
            "(Age)25" + Environment.NewLine +
            "(City)Paris" + Environment.NewLine +
            "(Flags)YYY" + Environment.NewLine;
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine($"Original input");
            Console.WriteLine("========================================================");
            Console.WriteLine(Input);
            Console.WriteLine("========================================================");

            List<Person> people = Input.ToPersonList();

            Console.WriteLine("Output");
            Console.WriteLine("========================================================");
            
            foreach(var person in people)
            {
                string gender = person.Female ? "Female" : "Male";

                bool isState = person.City.Contains(",");

                string student = person.Student ? "Yes" : "No";

                string employee = person.Employee ? "Yes" : "No";

                string city = person.City;
                string state = "N/A";

                if(isState)
                {
                    int indexOfComma = city.IndexOf(",");
                    city = city.Substring(0, indexOfComma);

                    state = person.City.Substring(indexOfComma, person.City.Length - indexOfComma);
                    state = state.Replace(",", "").Trim();
                }

                if(person.Age != null)
                {
                    Console.WriteLine($"{person.Name} [{person.Age}, {gender}]");
                }
                else
                {
                    Console.WriteLine($"{person.Name} [{gender}]");
                }

                Console.WriteLine($"\tCity\t: {city}");
                Console.WriteLine($"\tState\t: {state}");
                Console.WriteLine($"\tStudent\t: {student}");
                Console.WriteLine($"\tEmployee: {employee}");
            }

            Console.WriteLine("========================================================");

            Console.Read();
        }
    }
}
