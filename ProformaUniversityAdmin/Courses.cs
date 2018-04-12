using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProformaUniversityAdmin
{
    class Courses
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public string Level { get; set; }
        public string CourseName { get; set; }
        public string Room { get; set; }
        public string StartTime { get; set; }

        public Courses()
        {

        }

        public Courses(SqlDataReader reader)
        {
            ID = (int)reader["ID"];
            Number = reader["Name"].ToString();
            Level = reader["Level"].ToString();
            CourseName = reader["Name"].ToString();
            Room = reader["Room"].ToString();
            StartTime = reader["StartTime"].ToString();
        }

    }
}
