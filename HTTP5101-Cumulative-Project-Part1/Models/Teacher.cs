using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HTTP5101_Cumulative_Project_Part1.Models
{
    public class Teacher
    {

        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string EmployeeNumber { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
    }
}