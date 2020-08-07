using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DrSneuss.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace DrSneuss.Controllers
{
  public class MachinesController : Controller
  {
    private readonly DrSneussContext _db;

    public MachinesController(DrSneussContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchQuery = null)
    {
      if (searchQuery == null)
      {
        ViewBag.SearchFlag = 0;
        return View(_db.Machines.ToList());
      }
      else
      {
        ViewBag.SearchFlag = 1;
        List<Machine> model = _db.Machines.Where(machine => machine.Name.ToLower().Contains(searchQuery.ToLower())).ToList();
        return View(model);
      }
      
    }

    public ActionResult Create()
    {
      // ViewBag.DepartmentId = new SelectList(_db.Departments, "DepartmentId", "DepartmentName");
     ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Machine machine)
    {
      _db.Machines.Add(machine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
          // .Include(course => course.Department)
          .Include(machine => machine.Engineers)
          .ThenInclude(join => join.Engineer)
          .FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    public ActionResult Edit(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Edit(Machine machine)
    {
      _db.Entry(machine).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machine => machine.MachineId == id);
      _db.Machines.Remove(thisMachine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}