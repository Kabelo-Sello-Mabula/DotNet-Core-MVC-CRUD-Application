using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STUDATACRUD.Data;
using STUDATACRUD.Models;
using STUDATACRUD.Models.Domain;
using System.Security.Cryptography.Xml;

namespace STUDATACRUD.Controllers
{
    public class StudentsController : Controller
    {
        private readonly MVCDemoDbContext mvcDemoDbContext;

        public StudentsController(MVCDemoDbContext mvcDemoDbContext)
        {
            this.mvcDemoDbContext = mvcDemoDbContext;
        }

        //Using the get method to get data from the db (Index Method)

        [HttpGet]

        public async Task<IActionResult> Index()
        {
            var checkStudents = "No";

            var students = await mvcDemoDbContext.Students.ToListAsync();  

            if (students.Count>0)
            { 
                checkStudents = "Yes";
                ViewBag.IsStudent = checkStudents;
            }

            ViewBag.IsStudent = checkStudents;

            return  View(students);

            

           
        }


     


        [HttpGet]
        public IActionResult Add() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentsViewModel addStudentRequest)
        {
            //Conversion from AddStudentsViewModel view model to addStudentRequest
             
            var student = new Student()
            {
                id = Guid.NewGuid(),
                studentNumber = addStudentRequest.studentNumber,
                firstname = addStudentRequest.firstname,
                surname = addStudentRequest.surname,
                DateOfBirth = addStudentRequest.DateOfBirth
            };

            await mvcDemoDbContext.Students.AddAsync(student);
            await mvcDemoDbContext.SaveChangesAsync();  

            return RedirectToAction("index");

        }

        [HttpGet]

        public async Task<IActionResult> View(Guid id)
        {

            var students = await mvcDemoDbContext.Students.FirstOrDefaultAsync(x => x.id == id);


            if (students != null)
            {
                var viewModel = new UpdateStudentViewModel()
                {

                    id = students.id,
                    studentNumber = students.studentNumber,
                    firstname = students.firstname,
                    surname = students.surname,
                    DateOfBirth = students.DateOfBirth

                    

                };

                return await Task.Run(() => View("View",viewModel));

            }


            return RedirectToAction("Index");


        }

        //Action for update the Db

        [HttpPost]  

        public async Task<IActionResult> View(UpdateStudentViewModel model)
        {

            var student = await mvcDemoDbContext.Students.FindAsync(model.id);

            if(student != null)
            {

               
                student.studentNumber = model.studentNumber;
                student.firstname = model.firstname;
                student.surname = model.surname;
                student.DateOfBirth = model.DateOfBirth;

                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }


            return RedirectToAction("Index");


            

        }

        

        //Delete student

        [HttpPost]

        public async Task<IActionResult> Delete(UpdateStudentViewModel model)
        {
            var student = await mvcDemoDbContext.Students.FindAsync(model.id);

            if(student != null)
            {
                mvcDemoDbContext.Students.Remove(student);
                await mvcDemoDbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }



            return RedirectToAction("Index");   

        }



    }
}
