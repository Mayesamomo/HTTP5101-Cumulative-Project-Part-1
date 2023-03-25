using HTTP5101_Cumulative_Project_Part1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HTTP5101_Cumulative_Project_Part1.Controllers
{
    public class TeacherDataController : ApiController
    {
        //get access to the database
        private SchoolDbContext school = new SchoolDbContext();

        [HttpGet]
        public IEnumerable<Teacher> ListTeacher()
        {
            //create database connecion instance
            MySqlConnection conn = school.AccessDatabase();

            //open the connection between the server and the database
            conn.Open();

            //establish a new query for the database
            MySqlCommand cmd = conn.CreateCommand();

            // the sql query, select all from the techears' table
            cmd.CommandText = "Select * from teachers";

            //Gather the result of the retrieved query results into a variable
            MySqlDataReader reader = cmd.ExecuteReader();

            //create an empty list of teachers 
            List<Teacher> TeacherDetails = new List<Teacher> { };

            //loop throught the row of the result set and fetch deatils as required
            while(reader.Read())
            {
                //access the column information by the database column name.

                int TeacherId = (int)reader["teacherid"];
                string Teacherfname = (string)reader["teacherfname"];
                string Teacherlname = (string)reader["teacherlname"];
                string TEmployeeNum = (string)reader["employeenumber"];
                DateTime Hiredate = (DateTime)reader["hiredate"];
                decimal Salary = (decimal)reader["salary"];

                Teacher teacherobj = new Teacher();

                teacherobj.TeacherId = TeacherId;
                teacherobj.TeacherFirstName = Teacherfname;
                teacherobj.TeacherLastName = Teacherlname;
                teacherobj.EmployeeNumber = TEmployeeNum;
                teacherobj.HireDate = Hiredate;
                teacherobj.Salary = Salary;

               // string teacherdetails = reader["teacherid"] + " " + reader["teacherfname"] + " " + reader["teacherlname"]
                   // + " " + reader["employeenumber"] + " " + reader["hiredate"] + " " + reader["salary"];

                //add resukt to the list
                TeacherDetails.Add(teacherobj);
            }
            //data fetching done, close the connection 
            conn.Close();

            // retunr the list of teachers
            return TeacherDetails;
        }



        [HttpGet]
        public Teacher getTeacher(int id)
            
        {
            Teacher newTeacher = new Teacher();

            //create database connecion instance
            MySqlConnection conn = school.AccessDatabase();

            //open the connection between the server and the database
            conn.Open();

            //establish a new query for the database
            MySqlCommand cmd = conn.CreateCommand();

            // the sql query, select all from the techears' table
            cmd.CommandText = "Select * from teachers where teacherid =" +id;

            //Gather the result of the retrieved query results into a variable
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                //access the column information by the database column name.

                int TeacherId = (int)reader["teacherid"];
                string Teacherfname = (string)reader["teacherfname"];
                string Teacherlname = (string)reader["teacherlname"];
                string TEmployeeNum = (string)reader["employeenumber"];
                DateTime Hiredate = (DateTime)reader["hiredate"];
                decimal Salary = (decimal)reader["salary"];


                newTeacher.TeacherId = TeacherId;
                newTeacher.TeacherFirstName = Teacherfname;
                newTeacher.TeacherLastName = Teacherlname;
                newTeacher.EmployeeNumber = TEmployeeNum;
                newTeacher.HireDate = Hiredate;
                newTeacher.Salary = Salary;
            }
            //data fetching done, close the connection 
            conn.Close();
            return newTeacher;
        }
    }
}


	