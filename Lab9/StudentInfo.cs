using System;
using System.Collections.Generic;
using System.Text;

namespace Lab9
{
    class StudentInfo
    {
        public string name;
        public string hometown;
        public string job;
        public string major;
        public string color;
        // default constructor
        public StudentInfo()
        {

        }
        // Overloaded 
        public StudentInfo(string name, string hometown, string job, string major, string color)
        {
            this.name = name;
            this.hometown = hometown;
            this.job = job;
            this.major = major;
            this.color = color;
        }
    }
}
