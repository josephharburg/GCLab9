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
                "Barb Swift",
                "Joseph Harburg",
                "John Hasbelly",
                "Margaret Kelly",
                "Mike Hamlet",
                "Tom Kershmit",
                };
            List<string> homeTown = new List<string>()
                {
                "Bloomfield Hills, Michigan",
                "Ann Arbor, Michigan",
                "New York, New York",
                "Milford, New Jersey",
                "Eugene, Oregon",
                "Olympia, Washington"
                };
            List<string> job = new List<string>()
                {
                "Teacher",
                "Service Sales Rep",
                "Psychologist",
                "Baker",
                "Doctor",
                "Therapist"
                };
            List<string> major = new List<string>()
            {
                "Education",
                "C#/.net",
                "Psycology",
                "Culinary Arts",
                "Eastern Medicine",
                "Social Work"
            };
            List<string> color = new List<string>()
            {
                "Red",
                "White",
                "Blue",
                "Green",
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

                Console.WriteLine("Please select a student by typing a number!");
                int studentNumber = Validator(students);

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
        public static int Validator(List<string> userInput)
        {
            bool repeat = true;
            int studentNum = 0;
            while (repeat)
            {
                try
                {
                    string input = Console.ReadLine();
                    studentNum = int.Parse(input) - 1;
                    string testIndexRange = userInput[studentNum];
                    repeat = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Im sorry thats not a number between 1-{userInput.Count}!");
                    repeat = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Im sorry thats not a number between 1-{userInput.Count}!");
                    repeat = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Im sorry thats not a number between 1-{userInput.Count}!");
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
                Console.WriteLine($"What would you like to know about {name}?\nYou can choose: Hometown, Job, Major, Color.");
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
                    Console.WriteLine($"{name}'s major is {major[studentNum]}");
                    repeat = false;
                }
                else if (whatInfo == "color")
                {
                    Console.WriteLine($"{name}'s favorite color is {color[studentNum]}");
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid selection.\n");
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
                students.Sort();
                int insertHere = students.IndexOf(name);
                Console.WriteLine($"{name}'s name has been added to the database!");
                Console.WriteLine($"\nEnter {name}'s Hometown:");

                string hometown = Validator();
                homeTown.Insert(insertHere,hometown);
                Console.WriteLine($"{hometown} has been added to {name}'s info.");
                Console.WriteLine($"\nEnter {name}'s job:");

                string currentJob = Validator();
                job.Insert(insertHere,currentJob);
                Console.WriteLine($"{currentJob} has been added to {name}'s info.");
                Console.WriteLine($"\nEnter {name}'s major:");

                string study = Validator();
                major.Insert(insertHere, study);
                Console.WriteLine($"{study} has been added to {name}'s info.");
                Console.WriteLine($"\nEnter {name}'s favorite color:");

                string favColor = Validator();
                color.Insert(insertHere, favColor);
                Console.WriteLine($"{favColor} has been added to {name}'s info.");

                Console.WriteLine($"\n{name}'s info and name has been added to the database.\n");
                addYorn = false;
            }

        }
    }
}
