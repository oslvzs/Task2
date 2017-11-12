using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task2.Models;

namespace Task2.Controllers
{
    public class StudentController : Controller
    {
        static List<StudentModel> students = new List<StudentModel>();

        public ViewResult Index(){
            return View(students.ToList());
         }

        // GET: Student/Add?name=TEST
        public string Add(string name)
        {
            
            students.Add(new StudentModel { Name = name });
            return "Добавлен студент с именем " + name;
        }

        // GET: Student/Edit/5&name=TEST
        public string Edit(int id, string name)
        {
            students[id].Name = name;
            return "Изменено имя студента с id " + id + " на имя: " + name;
        }

        // GET: Student/Delete/5
        public string Delete(int id)
        {
            string name = students[id].Name;
            students.RemoveAt(id);
            return "Студент " + name + " удален";
        }

    }
}