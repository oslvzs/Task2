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

        [HttpGet]
        public ViewResult Index(){
            return View(students.ToList());
         }

        [HttpPost]
        // Student/Add?name=TEST
        public IActionResult Add(string name)
        {
            StudentModel model = new StudentModel { Name = name };
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                students.Add(new StudentModel { Name = name });
                return Redirect("Index");
            }
            else return Redirect("Index");
        }

        [HttpPut]
        // Student/Edit/5&name=TEST
        public IActionResult Edit(int id, string name)
        {
            StudentModel model = new StudentModel { Name = name };
            TryValidateModel(model);
            if (ModelState.IsValid)
            {
                students[id].Name = name;
                return Redirect("Index");
            }
            else {
                return Redirect("Index");
            }
        }

        [HttpDelete]
        // GET: Student/Delete/5
        public IActionResult Delete(int id)
        {
            string name = students[id].Name;
            students.RemoveAt(id);
            return Redirect("Index");
        }

    }
}