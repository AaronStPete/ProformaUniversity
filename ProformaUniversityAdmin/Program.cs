using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProformaUniversityAdmin
{
    class Program
    {

        ///static List<Prof> GetAllProfs

        static void Main(string[] args)
        {
            //link to db
            const string CONNECTION_STRING = @"Server=AWASSERMAN01;Database=ProformaUniversity;Trusted_Connection=True;";
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                conn.Open();
                var adminMenuOpen = true;
                while (adminMenuOpen == true)
                {
                    // menu
                    Console.WriteLine("Welcome to the Proforma University admin menu. \n " +
                        "Would you like to add a (course) or (professor) or would you like to (exit)?");
                    var menuInput = Console.ReadLine().ToLower();
                    if (menuInput == "class" || menuInput == "course")
                    {
                        ////add classes
                        var addingClasses = true;
                        while (addingClasses == true)
                        {
                            var newCourse = Factory.CreateCourse();
                            Factory.InsertCourse(conn, newCourse);
                            Console.WriteLine("Would you like to add another course? (y) or (n)");
                            var input = Console.ReadLine();
                            if (input == "n" || input == "no")
                            {
                                addingClasses = false;
                            }
                        }
                    }
                    else if (menuInput == "professor" || menuInput == "prof")
                    {
                        //add Professors
                        var addingProf = true;
                        while (addingProf == true)
                        {
                            var newProf = Factory.CreateProfessors();
                            Factory.InsertProfessor(conn, newProf);
                            Console.WriteLine($"{newProf.Title} {newProf.Name} has been added.");
                            Console.WriteLine("Would you like to add another professor? (y) or (n)");
                            var input = Console.ReadLine();
                            if (input == "n" || input == "no")
                            {
                                addingProf = false;
                            }
                        }
                    }
                    else if (menuInput == "exit" || menuInput == "close")
                    {
                        adminMenuOpen = false;
                    }

                    //view who is enrolled in class
                    //view all classes: who is teaching, who is enrolled
                }
            }
        }
    }
}
