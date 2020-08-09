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
    public class CourseController : Controller
    {
        private IRepository<Course> repository = null;
        private bool Success = false;
        public CourseController()
        {
            this.repository = new Repository<Course>();
        }
        public CourseController(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public JsonResult CourseList()
        {
            List<CourseModel> postTags = new List<CourseModel>();
            string tags = string.Empty;
            try
            {
                var courses = repository.SelectAll().ToList();
                foreach (Course course in courses)
                {
                    postTags.Add(new CourseModel { CourseID = course.CourseID, Title = course.Title, TeachersCount = course.Teachers.Count() });
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
            CourseModel courseModel = new CourseModel();
            return Json(courseModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NewCourse(CourseModel model)
        {
            try
            {
                var course = new Course
                {
                    Title = model.Title
                };
                repository.Insert(course);
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
            CourseModel postTags = new CourseModel();

            try
            {
                var courses = repository.SelectAll().Where(p => p.CourseID == Convert.ToInt64(id)).ToList();
                foreach (Course course in courses)
                {
                    postTags.Title = course.Title;
                    postTags.CourseID = course.CourseID;
                }
                return Json(postTags, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

            }
            return Json(postTags, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditCourse(CourseModel model)
        {
            try
            {
                var course = new Course
                {
                    Title = model.Title,
                    CourseID = model.CourseID
            };
                repository.Update(course);
                Success = repository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch(Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult Delete(string CourseID)
        {
            try
            {
                //bool success = DeleteTagsByPostId(Convert.ToInt32(PostId));

                repository.Delete(Convert.ToInt32(CourseID));
                Success = repository.Save();

                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch(Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        [NonAction]
        public bool DeleteTagsByPostId(int id)
        {
            try
            {
                var tags = repository.SelectAll().Where(t => t.CourseID == id);
                foreach (var t in tags)
                {
                    repository.Delete(t.CourseID);
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
