using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Registrar.Controllers
{
  public class CoursesController : Controller
  {
    private readonly RegistrarContext _db;

    public CoursesController(RegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Course> model = _db.Courses.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course, int DepartmentId)
    {
      _db.Courses.Add(course);
      _db.SaveChanges();
      if (DepartmentId != 0)
      {
        _db.CourseDepartment.Add(new CourseDepartment() { DepartmentId = DepartmentId, CourseId = course.CourseId});
      }
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCourse = _db.Courses
        .Include(course => course.JoinEntities)
        .ThenInclude(join => join.Student)
        .FirstOrDefault(Course => Course.CourseId == id);
      return View(thisCourse);
    }

    public ActionResult Edit(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      return View(thisCourse);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCourse = _db.Courses.FirstOrDefault(course => course.CourseId == id);
      _db.Courses.Remove(thisCourse);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}