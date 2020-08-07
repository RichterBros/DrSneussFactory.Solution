using System.Collections.Generic;
using System;

namespace DrSneuss.Models
{
  public class Department
  {
    public Department()
    {
      this.Courses = new HashSet<Course>();
      this.Students = new HashSet<Student>();
    }

    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }

    public virtual ICollection<Student> Students { get; }
    public virtual ICollection<Course> Courses { get; }
  }
}