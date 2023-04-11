using HTTP5101_Cumulative_Project_Part1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HTTP5101_Cumulative_Project_Part1.Controllers
{
    public class TeacherController : Controller
        
    {
        TeacherDataController teacherController = new TeacherDataController();
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
       //GET: teacher/List
        public ActionResult List(string SearchKey = null)
        {
          
            IEnumerable<Teacher> teachers = teacherController.ListTeacher(SearchKey);
            return View(teachers);
        }

        public TeacherDataController GetTeacherController()
        {
            return teacherController;
        }

        //GET: /Teacher/Show/{id}
        public ActionResult show(int id)
        {

            Teacher teacher = teacherController.getTeacher(id);


            return View(teacher);
        }
    }
}