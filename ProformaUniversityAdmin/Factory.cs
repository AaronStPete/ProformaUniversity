﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProformaUniversityAdmin
{
    class Factory
    {
        public static Courses CreateCourse()
        {
            Console.WriteLine("What is the course number?");
            var courseNumber = Console.ReadLine();
            Console.WriteLine("What is the course level?");
            var courseLevel = Console.ReadLine();
            Console.WriteLine("What is the course name?");
            var courseName = Console.ReadLine();
            Console.WriteLine("What is the room number?");
            var roomNumber = Console.ReadLine();
            Console.WriteLine("When does the class start? yyyy-mm-dd");
            var startTime = Console.ReadLine();

            var input = new Courses {
                CourseName = courseName,
                Level = courseLevel,
                Number = courseNumber,
                Room = roomNumber,
                StartTime = startTime
            };
            return input;
        }

        //public static Professors CreateProfessors()
        //{

        //}
    }
}
