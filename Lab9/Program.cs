using System;
using System.Collections.Generic;
namespace Lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string>()
             {
                "Joseph H",
                "Margaret K",
                "John H",
                "Barb S",
                "Tom H",
                "Mike H"
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

            Console.WriteLine("Welcome to the Main Menu!");
            bool repeatMain = true, repeatOne = true;
            while(repeatMain)
            {
                string userInput = Console.ReadLine();
                int studentNumber = Validator(userInput);

                string studentSelected = students[studentNumber];
                while (repeatOne)
                {
                    GetInfo(studentNumber,studentSelected, homeTown, job, major, color);
                    repeatOne = Repeator(studentSelected);
                }
                while(repeatMain)
                {
                    repeatMain = Repeator("another student");
                }
            }

        }
        public static int Validator(string userInput)
        {
            bool repeat = true;
            int studentNum = 0;
            while (repeat)
            {
                try
                {
                    studentNum = int.Parse(userInput);
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
                else if(whatInfo == "job")
                {
                    Console.WriteLine($"{name}'s job is {job[studentNum]}");
                    repeat = false;
                }
                else if (whatInfo == "major" )
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
                Console.WriteLine($"Would you like to learn more about {input}?");
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
                    Console.WriteLine("Im sorry thats not a valid input. please");
                    repeat = true;
                }
            }
            return true;

        }
         
        public static void AddStudent()
        {
           
            
        }
    }
}
