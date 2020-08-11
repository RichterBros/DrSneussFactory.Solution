using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DrSneuss.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DrSneuss.Controllers
{
  public class EngineersController : Controller
  {
    private readonly DrSneussContext _db;

    public EngineersController(DrSneussContext db)
    {
      _db = db;
    }

    public ActionResult Index(string searchQuery = null)
    {
      if (searchQuery == null)
      {
        ViewBag.SearchFlag = 0;
        return View(_db.Engineers.ToList());
      }
      else
      {
        ViewBag.SearchFlag = 1;
        List<Engineer> searchList = _db.Engineers.Where(engineer => engineer.EngineerName.ToLower().Contains(searchQuery.ToLower())).ToList();
        return View(searchList);
      }
    }
    
    public ActionResult Edit(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
      return View(thisEngineer);
    } 

    [HttpPost]
    public ActionResult Edit(Engineer engineer, int MachineId)
    {
      if(MachineId !=0)  
      {
        _db.EngineerMachine.Add(new EngineerMachine() {MachineId = MachineId, EngineerId = engineer.EngineerId});
      } 
        _db.Entry(engineer).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

    public ActionResult Create()
    {
      ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
     
      return View();
    }

    [HttpPost]
    public ActionResult Create(Engineer engineer, int MachineId)
    {
      _db.Engineers.Add(engineer);
      if(MachineId !=0)
        {
          _db.EngineerMachine.Add(new EngineerMachine() {MachineId = MachineId, EngineerId = engineer.EngineerId});
        }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
 
    public ActionResult Details(int id)
    {
      var thisEngineer = _db.Engineers
        
        .Include(engineer=> engineer.Machines)
        .ThenInclude(join => join.Machine)
        .FirstOrDefault(engineer => engineer.EngineerId == id);

        ViewBag.value = _db.Machines.FirstOrDefault(x => x.MachineId == thisEngineer.MachineId);
      return View(thisEngineer);
    }

    public ActionResult AddMachine(int id)
    {
    var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
    ViewBag.MachineId = new SelectList(_db.Machines, "MachineId", "MachineName");
    return View(thisEngineer);
    }

    [HttpPost]
    public ActionResult AddMachine(Engineer engineer, int MachineId)
    {
      if (MachineId != 0)
        {
        _db.EngineerMachine.Add(new EngineerMachine() { MachineId = MachineId, EngineerId = engineer.EngineerId });
        }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      return View(thisEngineer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisEngineer = _db.Engineers.FirstOrDefault(engineers => engineers.EngineerId == id);
      _db.Engineers.Remove(thisEngineer); 
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteMachine(int joinId)
    {
      var joinEntry = _db.EngineerMachine.FirstOrDefault(entry => entry.EngineerMachineId == joinId);
      _db.EngineerMachine.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}