using System;
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

        public static Students CreateStudent()
        {
            Console.WriteLine("What is the student's full name?");
            var studentFullName = Console.ReadLine();
            Console.WriteLine("What is the student's email?");
            var studentEmail = Console.ReadLine();
            Console.WriteLine("What is the student's phone number?");
            var studentPhoneNumber = Console.ReadLine();
            Console.WriteLine("What is the student's major?");
            var studentMajor = Console.ReadLine();

            var newStudent = new Students
            {
                FullName = studentFullName,
                Email = studentEmail,
                PhoneNumber = studentPhoneNumber,
                Major = studentMajor
            };
            return newStudent;
        }

        public static void InsertStudent(SqlConnection conn, Students newStudent)
        {
            var _insert = "INSERT INTO Students (FullName, Email, PhoneNumber, Major)" + "Values (@FullName, @Email, @PhoneNumber, @Major)";
            var cmd = new SqlCommand(_insert, conn);

            cmd.Parameters.AddWithValue("FullName", newStudent.FullName);
            cmd.Parameters.AddWithValue("Email", newStudent.Email);
            cmd.Parameters.AddWithValue("PhoneNumber", newStudent.PhoneNumber);
            cmd.Parameters.AddWithValue("Major", newStudent.Major);
            cmd.ExecuteScalar();
        }

        public static void EnrollStudent(SqlConnection conn)
        {
            Console.WriteLine("What is the full name of the student that would like to enroll?");
            var studentFullName = Console.ReadLine();
            Console.WriteLine("What is the course number that the student would like to enroll in?");
            var courseNumber = Console.ReadLine();

            ///HOW TO CONNECT STUDENTFULLNAME AND COURSENUMBER TO FK-STUDENTIDS AND FK-COURSEIDS RESPECTIVELY?
            /// query: get student.id from db students
            var _student = "SELECT TOP(1) [ID] FROM [Students] WHERE [FullName] = @Name";
            var stuCMD = new SqlCommand(_student, conn);
            stuCMD.Parameters.AddWithValue("Name", studentFullName);
            var studentReader = stuCMD.ExecuteReader();
            var studentId = 0;
            while (studentReader.Read())
            {
                studentId = (int)studentReader["ID"];
            }
            Console.WriteLine($"{studentId}");

            /// query: get course.id from db courses

            /// then insert in studentenrollment table
            var _insert = "INSERT INTO StudentEnrollment (FK-StudentIDs, FK-CourseIDs) " +
                "VALUES (@FK-StudentIDs, @FK-CourseIDs) ";
            var cmd = new SqlCommand(_insert, conn);

           // cmd.Parameters.AddWithValue("FK-StudentIDs", student.ID);
           // cmd.Parameters.AddWithValue("FK-CourseIDs", course.ID);
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

        public static List<Professor> GetProfessors(SqlConnection conn)
        {
            var _select = "SELECT [ID], [Name], [Title] " +
                " FROM [Professors]";
            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Professor>();
            while (reader.Read())
            {
                var _professor = new Professor(reader);
                Console.WriteLine($"Professor #{_professor.ID} is a {_professor.Title} named {_professor.Name}");
            }
            reader.Close();
            return _rv;
        }

        public static List<Courses> GetCourses(SqlConnection conn)
        {
            var _select = "SELECT [ID], [NUMBER], [LEVEL], [Name], [Room], [StartTime] " +
                " FROM [Courses]";
            var query = new SqlCommand(_select, conn);
            var reader = query.ExecuteReader();
            var _rv = new List<Courses>();
            while (reader.Read())
            {
                var _course = new Courses(reader);
                Console.WriteLine($"Course ID#{_course.ID} Number{_course.Number} Level{_course.Level} is named {_course.CourseName} is located in {_course.Room} on {_course.StartTime}");
            }
            reader.Close();
            return _rv;
        }
    }
}
