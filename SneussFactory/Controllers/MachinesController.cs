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
        List<Machine> model = _db.Machines.Where(machine => machine.MachineName.ToLower().Contains(searchQuery.ToLower())).ToList();
        return View(model);
      }
      
    }

    public ActionResult Create(int id)
    {
      var thisMachine= _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
     ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachine);
    }

    [HttpPost]
    public ActionResult Create(Machine machine, int EngineerId)
    {
      _db.Machines.Add(machine);
      
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = machine.MachineId});
      
      
      
      
      // _db.Entry(machine).State = EntityState.Modified;
      
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    
    
    
    public ActionResult Details(int id)
    {
      var thisMachine = _db.Machines
         
          .Include(machine => machine.Engineers)
          .ThenInclude(join => join.Engineer)
          .FirstOrDefault(machine => machine.MachineId == id);
              
               ViewBag.value = _db.Machines.FirstOrDefault(x => x.MachineId == thisMachine.MachineId);
     
      return View(thisMachine);
    }

  public ActionResult Edit(int id)
    {
      var thisMachine= _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "EngineerName");
      return View(thisMachine);
    } 

    [HttpPost]
    public ActionResult Edit(Machine machine, int EngineerId)
    {
      if(EngineerId !=0)  
      {
        _db.EngineerMachine.Add(new EngineerMachine() {EngineerId = EngineerId, MachineId = machine.MachineId});
      } 
        _db.Entry(machine).State = EntityState.Modified;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }
      
  public ActionResult Delete(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      return View(thisMachine);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMachine = _db.Machines.FirstOrDefault(machines => machines.MachineId == id);
      _db.Machines.Remove(thisMachine); 
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
    


  





 
  
  
  
  
  
  
  
  
  
  
  
  
  