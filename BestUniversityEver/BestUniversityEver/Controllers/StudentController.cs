using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BestUniversityEver.DAL;
using BestUniversityEver.Models;
using BestUniversityEver.Models.MetaData;
using BestUniversityEver.Repository;

namespace BestUniversityEver.Controllers
{
    public class StudentController : Controller
    {
        private IRepository<Student> repository = null;
        private bool Success = false;
        public StudentController()
        {
            this.repository = new Repository<Student>();
        }
        public StudentController(IRepository<Student> repository)
        {
            this.repository = repository;
        }

        public JsonResult StudentList()
        {
            List<StudentModel> postTags = new List<StudentModel>();
            string tags = string.Empty;
            try
            {
                var students = repository.SelectAll().ToList();
                foreach (Student student in students)
                {
                    postTags.Add(new StudentModel { StudentID = student.StudentID, BirthDay = student.BirthDay, FirstName = student.FirstName, LastName = student.LastName });
                }
                return Json(postTags, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
            }
            return Json(postTags, JsonRequestBehavior.AllowGet);
        }
        public JsonResult New()
        {
            StudentModel studentModel = new StudentModel();
            return Json(studentModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NewStudent(StudentModel model)
        {
            try
            {
                var student = new Student
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.BirthDay  
                };
                repository.Insert(student);
                Success = repository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public JsonResult Edit(string id)
        {
            StudentModel postTags = new StudentModel();

            try
            {
                var students = repository.SelectAll().Where(p => p.StudentID == Convert.ToInt64(id)).ToList();
                foreach (Student student in students)
                {
                    postTags.StudentID = student.StudentID;
                    postTags.FirstName = student.FirstName;
                    postTags.LastName = student.LastName;
                    postTags.BirthDay = student.BirthDay;

                }
                return Json(postTags, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

            }
            return Json(postTags, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditStudent(StudentModel model)
        {
            try
            {
                var student = new Student
                {
                    StudentID = model.StudentID,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.BirthDay
                };
                repository.Update(student);
                Success = repository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult Delete(string StudentID)
        {
            try
            {
                //bool success = DeleteTagsByPostId(Convert.ToInt32(PostId));

                repository.Delete(Convert.ToInt32(StudentID));
                Success = repository.Save();

                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        [NonAction]
        public bool DeleteTagsByPostId(int id)
        {
            try
            {
                var tags = repository.SelectAll().Where(t => t.StudentID == id);
                foreach (var t in tags)
                {
                    repository.Delete(t.StudentID);
                }
                Success = repository.Save();
                return Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
