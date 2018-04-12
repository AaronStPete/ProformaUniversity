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


        static void InsertProfessor(SqlConnection conn, Professor newProf) { }


        static void Main(string[] args)
        {
            //link to db
            const string CONNECTION_STRING = @"Server=localhost\AWASSERMAN01;Database=ProformaUniversity;Trusted_Connection=True;";
            using (var conn = new SqlConnection(CONNECTION_STRING))
            {
                //build menu
                ////add classes
                var addingClasses = true;
                while (addingClasses == true)
                {
                    var newCourse = Factory.CreateCourse();
                    Console.WriteLine("Would you like to add another course? (y) or (n)");
                    var input = Console.ReadLine();
                    if (input == "n" || input == "no")
                    {
                        addingClasses = false;
                    }
                }
                //add Professors
                
                //view who is enrolled in class
                //view all classes: who is teaching, who is enrolled
            }

        }
    }
}
