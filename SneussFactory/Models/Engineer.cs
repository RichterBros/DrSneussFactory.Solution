using System.Collections.Generic;
using System;

namespace DrSneuss.Models
{
    public class Engineer
    {
        public Engineer()
        {
            this.Machines = new HashSet<EngineerMachine>();
        }
        //public int? DepartmentId {get; set;}
        public int EngineerId { get; set; }
        public string EngineerName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //public virtual Department Department { get; set;}
        
        public ICollection<EngineerMachine> Machines { get;} // has all Id's joined data which is associated to the caregory object
    }
}