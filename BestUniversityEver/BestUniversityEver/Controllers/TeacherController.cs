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
    public class TeacherController : Controller
    {
        private IRepository<Teacher> repository = null;
        private bool Success = false;
        public TeacherController()
        {
            this.repository = new Repository<Teacher>();
        }
        public TeacherController(IRepository<Teacher> repository)
        {
            this.repository = repository;
        }

        public JsonResult TeacherList()
        {
            List<TeacherModel> postTags = new List<TeacherModel>();
            string tags = string.Empty;
            try
            {
                var teachers = repository.SelectAll().ToList();
                foreach (Teacher teacher in teachers)
                {
                    postTags.Add(new TeacherModel { FirstName = teacher.FirstName, LastName = teacher.LastName, BirthDay = teacher.BirthDay, Salary = teacher.Salary });
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
            TeacherModel teacherModel = new TeacherModel();
            return Json(teacherModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NewTeacher(TeacherModel model)
        {
            try
            {
                var teacher = new Teacher
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.BirthDay,
                    Salary = model.Salary  
                };
                repository.Insert(teacher);
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
            TeacherModel postTags = new TeacherModel();

            try
            {
                var teachers = repository.SelectAll().Where(p => p.TeacherID == Convert.ToInt64(id)).ToList();
                foreach (Teacher teacher in teachers)
                {
                    postTags.TeacherID = teacher.TeacherID;
                    postTags.FirstName = teacher.FirstName;
                    postTags.LastName = teacher.LastName;
                    postTags.BirthDay = teacher.BirthDay;
                    postTags.Salary = teacher.Salary;
                }
                return Json(postTags, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

            }
            return Json(postTags, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditTeacher(TeacherModel model)
        {
            try
            {
                var teacher = new Teacher
                {
                    FirstName  = model.FirstName,
                    LastName = model.LastName,
                    BirthDay = model.BirthDay,
                    Salary = model.Salary
                };
                repository.Update(teacher);
                Success = repository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult Delete(string TeacherID)
        {
            try
            {
                //bool success = DeleteTagsByPostId(Convert.ToInt32(PostId));

                repository.Delete(Convert.ToInt32(TeacherID));
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
                var tags = repository.SelectAll().Where(t => t.TeacherID == id);
                foreach (var t in tags)
                {
                    repository.Delete(t.TeacherID);
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
