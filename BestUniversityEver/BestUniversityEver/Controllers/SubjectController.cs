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
    public class SubjectController : Controller
    {
        private IRepository<Subject> repository = null;
        private bool Success = false;
        public SubjectController()
        {
            this.repository = new Repository<Subject>();
        }
        public SubjectController(IRepository<Subject> repository)
        {
            this.repository = repository;
        }

        public JsonResult SubjectList()
        {
            List<SubjectModel> postTags = new List<SubjectModel>();
            string tags = string.Empty;
            try
            {
                var subjects = repository.SelectAll().ToList();
                foreach (Subject subject in subjects)
                {
                    var t = new Teacher { FirstName = subject.Teacher.FirstName, LastName = subject.Teacher.LastName };
                    postTags.Add(new SubjectModel { SubjectID = subject.SubjectID, SubjectName = subject.SubjectName, TeacherName = t.FirstName + ' ' + t.LastName });
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
            SubjectModel subjectModel = new SubjectModel();
            return Json(subjectModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult NewSubject(SubjectModel model)
        {
            try
            {
                var subject = new Subject
                {
                    SubjectID = model.SubjectID,
                    SubjectName = model.SubjectName,
                    Teacher = model.Teacher
                };
                repository.Insert(subject);
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
            SubjectModel postTags = new SubjectModel();

            try
            {
                var subjects = repository.SelectAll().Where(p => p.SubjectID == Convert.ToInt64(id)).ToList();
                foreach (Subject subject in subjects)
                {
                    postTags.SubjectID = subject.SubjectID;
                    postTags.SubjectName = subject.SubjectName;
                    postTags.Teacher = subject.Teacher;
                    postTags.TeacherName = subject.Teacher.FirstName + ' ' + subject.Teacher.LastName;

                }
                return Json(postTags, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

            }
            return Json(postTags, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditSubject(SubjectModel model)
        {
            try
            {
                var subject = new Subject
                {
                    SubjectID = model.SubjectID,
                    SubjectName = model.SubjectName,
                    Teacher = model.Teacher
                };
                repository.Update(subject);
                Success = repository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult Delete(string SubjectId)
        {
            try
            {
                //bool success = DeleteTagsByPostId(Convert.ToInt32(PostId));

                repository.Delete(Convert.ToInt32(SubjectId));
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
                var tags = repository.SelectAll().Where(t => t.SubjectID == id);
                foreach (var t in tags)
                {
                    repository.Delete(t.SubjectID);
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
