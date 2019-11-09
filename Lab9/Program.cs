using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            List<StudentInfo> students = new List<StudentInfo>()
            {
                new StudentInfo("Barb Swift", "Bloomfield Hills, MI","Teacher","Education", "Yellow"),
                new StudentInfo("Carl Lemons", "New York, NY", "Doctor", "Eastern Medicine", "Red"),
                new StudentInfo("David Carp", "San Francisco, CA", "Accountant", "Accounting", "Blue"),
                new StudentInfo("Edger Yipsel","Moscow, Russia", "Lyricist", "Literature", "Teal" ),
                new StudentInfo("Joseph Harburg", "Ann Arbor, MI", "Service Sales Rep", "C#", "White"),
                new StudentInfo("PJ Vogt", "Detroit, MI", "Sound Engineer", "Engineering", "Black")
        };
            
            bool repeatMain = true;
            while (repeatMain)
            {
                bool repeatOne = true, repeatTwo = true; ;
                Console.WriteLine("\nWelcome to the Main Menu!");

                for (int index = 0; index < students.Count; index++)
                {
                    Console.WriteLine($"{index + 1}: {students[index].name}");
                }

                Console.WriteLine("Please select a student by typing a number!");
                int studentNumber = Validator(students);

                string studentSelected = students[studentNumber].name;

                while (repeatOne)
                {
                    GetInfo(studentNumber, students);
                    repeatOne = Repeator($"more about {studentSelected}");
                }
                while (repeatTwo)
                {
                    repeatTwo = Repeator("add another student");
                    if (repeatTwo)
                    {
                        AddStudent(students);
                    }
                }

                repeatMain = Repeator("select another student");
                
            }
            Console.WriteLine("GoodBye!");
            return;
        }
        public static int Validator(List<StudentInfo> userInput)
        {
            bool repeat = true;
            int studentNum = 0;
            while (repeat)
            {
                try
                {
                    string input = Console.ReadLine();
                    studentNum = int.Parse(input) - 1;
                    object testIndex = userInput[studentNum];
                    repeat = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Im sorry thats not a number between 1-{userInput.Count}!\n");
                    repeat = true;
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Im sorry thats not a number between 1-{userInput.Count}!\n");
                    repeat = true;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Im sorry thats not a number between 1-{userInput.Count}!\n");
                    repeat = true;
                }
                catch(ArgumentNullException)
                {
                    Console.WriteLine("That was not a valid response try again\n");
                    repeat = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("That was not a valid response try again\n");
                    repeat = true;
                }

            }
            return studentNum;
        }
        public static string Validator()
        {
            bool repeat = true;
            string input = "";
            Regex validate = new Regex(@"^([A-Z]{0,1}'*[a-z]{0,10},* *)+$");
            while (repeat)
            {
                try
                {
                    input = Console.ReadLine();
                    if (validate.IsMatch(input))
                    {
                        repeat = false;
                        return input;
                    }
                    else if (input == String.Empty)
                    {
                        Console.WriteLine("Im sorry thats not a valid input try again.\n");
                    }
                    else
                    {
                        Console.WriteLine("Im sorry thats not a valid input try again.\n");
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Im sorry thats not a valid input try again.\n");
                }
            }
            return input;
        }
        public static void GetInfo(int studentNum, List<StudentInfo> students)
        {
            bool repeat = true;
            while (repeat)
            {
                Console.WriteLine($"What would you like to know about {students[studentNum].name}?\nYou can choose: Hometown, Job, Major, Color.");
                string whatInfo;
                try
                {
                    whatInfo = Console.ReadLine().ToLower();


                    if(string.IsNullOrEmpty(whatInfo))
                    {
                        Console.WriteLine("That is not a valid selection.\n");
                        repeat = true;
                    }
                    else if (whatInfo == "hometown")
                    {
                        Console.WriteLine($"{students[studentNum].name}'s hometown is {students[studentNum].hometown}\n");
                        repeat = false;
                    }
                    else if (whatInfo == "job")
                    {
                        Console.WriteLine($"{students[studentNum].name}'s job is {students[studentNum].job}\n");
                        repeat = false;
                    }
                    else if (whatInfo == "major")
                    {
                        Console.WriteLine($"{students[studentNum].name}'s major is {students[studentNum].major}\n");
                        repeat = false;
                    }
                    else if (whatInfo == "color")
                    {
                        Console.WriteLine($"{students[studentNum].name}'s favorite color is {students[studentNum].color}\n");
                        repeat = false;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid selection.\n");
                        repeat = true;
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("That is not a valid selection.\n");
                    repeat = true;
                }
                catch (NullReferenceException)
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
                try {
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
                        Console.WriteLine("\nIm sorry thats not a valid input.\n");
                        repeat = true;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("\nIm sorry thats not valid input!\n");
                    repeat = true;
                }
                catch(Exception)
                {
                    Console.WriteLine("\nIm sorry thats not valid input!\n");
                    repeat = true;
                }
            }
            return true;
            
        }

        public static void AddStudent(List<StudentInfo> students)
        {
            bool addYorn = true;
            while (addYorn)
            {
                Console.WriteLine("Enter the students name:");
                string name = Validator();

                Console.WriteLine($"\nEnter {name}'s Hometown:");
                string hometown = Validator();

                Console.WriteLine($"\nEnter {name}'s job:");
                string job = Validator();

                Console.WriteLine($"\nEnter {name}'s major:");
                string major = Validator();

                Console.WriteLine($"\nEnter {name}'s favorite color:");
                string color = Validator();

                students.Add(new StudentInfo(name, hometown, job, major, color));
                students.Sort((a, b) => a.name.CompareTo(b.name));

                Console.WriteLine($"\n{name}'s info and name has been added to the database.\n");
                addYorn = false;
            }
            //Just for future referenceVVVVVVVVVVVVVVVVVVVVVV
            //{
            //    bool addYorn = true;

            //    while (addYorn)
            //    {
            //        Console.WriteLine("Enter the students name:");
            //        string name = Validator();
            //        students.Add(name);
            //        students.Sort();
            //        int insertHere = students.IndexOf(name);
            //        Console.WriteLine($"{name}'s name has been added to the database!");
            //        Console.WriteLine($"\nEnter {name}'s Hometown:");

            //        string hometown = Validator();
            //        homeTown.Insert(insertHere,hometown);
            //        Console.WriteLine($"{hometown} has been added to {name}'s info.");
            //        Console.WriteLine($"\nEnter {name}'s job:");

            //        string currentJob = Validator();
            //        job.Insert(insertHere,currentJob);
            //        Console.WriteLine($"{currentJob} has been added to {name}'s info.");
            //        Console.WriteLine($"\nEnter {name}'s major:");

            //        string study = Validator();
            //        major.Insert(insertHere, study);
            //        Console.WriteLine($"{study} has been added to {name}'s info.");
            //        Console.WriteLine($"\nEnter {name}'s favorite color:");

            //        string favColor = Validator();
            //        color.Insert(insertHere, favColor);
            //        Console.WriteLine($"{favColor} has been added to {name}'s info.");

            //        Console.WriteLine($"\n{name}'s info and name has been added to the database.\n");
            //        addYorn = false;
            //    }

        }
    }
}
