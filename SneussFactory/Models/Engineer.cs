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
        public int? MachineId {get; set;}
        public int EngineerId { get; set; }
        public string EngineerName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual Machine Machine { get; set;}
        
        public ICollection<EngineerMachine> Machines { get; } // has all Id's joined data which is associated to the engineer object
    }
}