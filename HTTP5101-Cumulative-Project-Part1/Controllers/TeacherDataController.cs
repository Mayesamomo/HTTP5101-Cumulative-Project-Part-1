using HTTP5101_Cumulative_Project_Part1.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.WebPages;

namespace HTTP5101_Cumulative_Project_Part1.Controllers
{
    public class TeacherDataController : ApiController
    {
        //get access to the database
        private SchoolDbContext school = new SchoolDbContext();

        //search for teacher
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeacher(string SearchKey = null)
        {
            Teacher newTeacher = new Teacher();

            //create database connecion instance
            MySqlConnection conn = school.AccessDatabase();

            //open the connection between the server and the database
            conn.Open();

            //establish a new query for the database
            MySqlCommand cmd = conn.CreateCommand();

            // the sql query, select all from the techears' table
            cmd.CommandText = "Select * from teachers where lower(teacherfname) like lower(@key) or lower(teacherlname) like lower(@key) or lower(concat(teacherfname, ' ', teacherlname)) like lower(@key)";
            cmd.Parameters.AddWithValue("@Key", "%" + SearchKey + "%");

            cmd.Prepare();
            //Append Result set into a variable
            MySqlDataReader reader = cmd.ExecuteReader();

            //create an empty list to store objects of Teachers
            List<Teacher> teachers = new List<Teacher> { }; //in class question, what is the difference between using () and {} 

            //loop through each row of the result set 
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
                //Add the teacher's name to the List
                teachers.Add(newTeacher);
            }
            //Close the connection between the MySQL Database and Server
            conn.Close();

            //Return the list of teacher's names
            return teachers;

        }

        //get Teacher by Id

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


	