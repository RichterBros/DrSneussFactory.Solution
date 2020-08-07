using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using UniversityRegistrar.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchQuery = null)
    {
      if (searchQuery == null)
      {
        ViewBag.SearchFlag = 0;
        return View(_db.Students.ToList());
      }
      else
      {
        ViewBag.SearchFlag = 1;
        List<Student> searchList = _db.Students.Where(student => student.StudentName.ToLower().Contains(searchQuery.ToLower())).ToList();
        return View(searchList);
      }
    }
    
    public ActionResult Edit(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View(thisStudent);
    } 

    [HttpPost]
    public ActionResult Edit(Student student, int CourseId)
    {
      if(CourseId !=0)  
      {
        _db.StudentCourse.Add(new StudentCourse() {CourseId = CourseId, StudentId = student.StudentId});
      } 
        _db.Entry(student).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      ViewBag.DepartmentId= new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Student student, int CourseId)
    {
      _db.Students.Add(student);
      if(CourseId !=0)
        {
            _db.StudentCourse.Add(new StudentCourse() {CourseId = CourseId, StudentId = student.StudentId});
        }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
 
    public ActionResult Details(int id)
    {
      var thisStudent = _db.Students
        .Include(student => student.Department)
        .Include(student => student.Courses)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(student => student.StudentId == id);

        ViewBag.value = _db.Departments.FirstOrDefault(x => x.DepartmentId == thisStudent.DepartmentId);
      return View(thisStudent);
    }

    public ActionResult AddCourse(int id)
    {
    var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
    ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
    return View(thisStudent);
    }

    [HttpPost]
    public ActionResult AddCourse(Student student, int CourseId)
    {
      if (CourseId != 0)
        {
        _db.StudentCourse.Add(new StudentCourse() { CourseId = CourseId, StudentId = student.StudentId });
        }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      return View(thisStudent);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(students => students.StudentId == id);
      _db.Students.Remove(thisStudent); 
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.StudentCourse.FirstOrDefault(entry => entry.StudentCourseId == joinId);
      _db.StudentCourse.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}