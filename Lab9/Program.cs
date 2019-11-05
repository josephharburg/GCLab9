using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>()
             {
                "Joseph Harburg",
                "Margaret Kelly",
                "John Hambelly",
                "Barb Swift",
                "Tom Kershmit",
                "Mike Hamlet"
                };
            List<string> homeTown = new List<string>()
                {
                "Ann Arbor, Michigan",
                "Milford, New Jersey",
                "New York, New York",
                "Bloomfield Hills, Michigan",
                "Eugene, Oregon",
                "Olympia, Washington"
                };
            List<string> job = new List<string>()
                {
                "Service Sales Rep",
                "Baker",
                "Psychologist",
                "Teacher",
                "Doctor",
                "Therapist"
                };
            List<string> major = new List<string>()
            {
                "C#/.net",
                "Culinary Arts",
                "Psycology",
                "Education",
                "Eastern Medicine",
                "Social Work"
            };
            List<string> color = new List<string>()
            {
                "White",
                "Green",
                "Blue",
                "Red",
                "Yellow",
                "Orange"
            };
            bool repeatMain = true;
            while (repeatMain)
            {
                bool repeatOne = true, repeatTwo = true; ;
                Console.WriteLine("\nWelcome to the Main Menu!");
                for (int index = 0; index < students.Count; index++)
                {
                    Console.WriteLine($"{index + 1}: {students[index]}");
                }

                string userInput = Console.ReadLine();
                int studentNumber = Validator(userInput);

                string studentSelected = students[studentNumber];

                while (repeatOne)
                {
                    GetInfo(studentNumber, studentSelected, homeTown, job, major, color);
                    repeatOne = Repeator($"more about {studentSelected}");
                }
                while (repeatTwo)
                {
                    repeatTwo = Repeator("add another student");
                    if (repeatTwo)
                    {
                        AddStudent(students, homeTown, job, major, color);
                    }
                }

                repeatMain = Repeator("select another student");
                
            }
            Console.WriteLine("GoodBye!");
            return;
        }
        public static int Validator(string userInput)
        {
            bool repeat = true;
            int studentNum = 0;
            while (repeat)
            {
                try
                {
                    studentNum = int.Parse(userInput) - 1;
                    repeat = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Im sorry thats not a number!");
                    repeat = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("That wasnt a number between 1-6");
                    repeat = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not a valid response try again");
                    repeat = true;
                }

            }
            return studentNum;
        }
        public static string Validator()
        {
            bool repeat = true;
            string input = "";
            Regex validate = new Regex(@"^([A-Z]*[a-z],* *)+$");
            while (repeat)
            {
                input = Console.ReadLine();
                if (validate.IsMatch(input))
                {
                    repeat = false;
                    return input;
                }
                else if (input == String.Empty)
                {
                    Console.WriteLine("Im sorry thats not a valid input try again.");
                }
                else
                {
                    Console.WriteLine("Im sorry thats not a valid input try again.");
                }

            }
            return input;
        }
        public static void GetInfo(int studentNum, string name, List<string> homeTown, List<string> job, List<string> major, List<string> color)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine($"What would you like to know about {name}?\n\t You can choose: Hometown, Job, Major, Color.");
                string whatInfo = Console.ReadLine().ToLower();
                if (whatInfo == "hometown")
                {
                    Console.WriteLine($"{name}'s hometown is {homeTown[studentNum]}");
                    repeat = false;
                }
                else if (whatInfo == "job")
                {
                    Console.WriteLine($"{name}'s job is {job[studentNum]}");
                    repeat = false;
                }
                else if (whatInfo == "major")
                {
                    Console.WriteLine($"{name}'s major  is {major[studentNum]}");
                    repeat = false;
                }
                else if (whatInfo == "color")
                {
                    Console.WriteLine($"{name}'s favorite color is {color[studentNum]}");
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid selection.");
                    repeat = true;
                }
            }

        }

        public static bool Repeator(string input)
        {
            bool repeat = true;

            while (repeat)
            {
                Console.WriteLine($"Would you like to {input}?");
                string yorn = Console.ReadLine().ToLower();
                if (yorn == "y" || yorn == "yes")
                {
                    repeat = false;
                }
                else if (yorn == "n" || yorn == "no")
                {
                    repeat = false;
                    return false;
                }
                else
                {
                    Console.WriteLine("Im sorry thats not a valid input.");
                    repeat = true;
                }
            }
            return true;

        }

        public static void AddStudent(List<string> students, List<string> homeTown, List<string> job, List<string> major, List<string> color)
        {
            bool addYorn = true;
            //addYorn = Repeator("add another student");
            while (addYorn)
            {
                Console.WriteLine("Enter the students name:");
                string name = Validator();
                students.Add(name);
                Console.WriteLine($"{name}'s name has been added to the database!");
                Console.WriteLine($"\nEnter {name}'s Hometown:");

                string hometown = Validator();
                homeTown.Add(hometown);
                Console.WriteLine($"{hometown} has been added to {name}'s info.");
                Console.WriteLine($"\nEnter {name}'s job:");

                string currentJob = Validator();
                job.Add(currentJob);
                Console.WriteLine($"{currentJob} has been added to {name}'s info.");
                Console.WriteLine($"\nEnter {name}'s major:");

                string study = Validator();
                major.Add(study);
                Console.WriteLine($"{study} has been added to {name}'s info.");
                Console.WriteLine($"\nEnter {name}'s favorite color:");

                string favColor = Validator();
                color.Add(favColor);
                Console.WriteLine($"{favColor} has been added to {name}'s info.");

                Console.WriteLine($"\n{name}'s info and name has been added to the database");
                addYorn = false;
            }

        }
    }
}
