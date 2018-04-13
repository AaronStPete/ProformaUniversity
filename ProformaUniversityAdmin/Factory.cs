﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            var newCourse = new Courses {
                CourseName = courseName,
                Level = courseLevel,
                Number = courseNumber,
                Room = roomNumber,
                StartTime = startTime
            };
            return newCourse;
        }

        public static Professor CreateProfessors()
        {
            Console.WriteLine("What is the professor's title?");
            var profTitle = Console.ReadLine();
            Console.WriteLine("What is the professor's full name?");
            var profName = Console.ReadLine();

            var newProf = new Professor
            {
                Name = profName,
                Title = profTitle
            };
            return newProf;
        }

        public static void InsertProfessor(SqlConnection conn, Professor newProf)
        {
            var _insert = "INSERT INTO Professors (Name, Title)" + "Values (@Name, @Title)";
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", newProf.Name);
            cmd.Parameters.AddWithValue("Title", newProf.Title);
            cmd.ExecuteScalar();
        }

        public static void InsertCourse(SqlConnection conn, Courses newCourse)
        {
            var _insert = "INSERT INTO Courses (Name, Level, Number, Room, StartTime)" + "Values (@Name, @Level, @Number, @Room, @StartTime)";
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("Name", newCourse.CourseName);
            cmd.Parameters.AddWithValue("Level", newCourse.Level);
            cmd.Parameters.AddWithValue("Number", newCourse.Number);
            cmd.Parameters.AddWithValue("Room", newCourse.Room);
            cmd.Parameters.AddWithValue("StartTime", newCourse.StartTime);
            cmd.ExecuteScalar();
        }
    }
}
