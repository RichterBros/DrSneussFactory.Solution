using System.Collections.Generic;

namespace DrSneuss.Models
{
    public class Machine
    {
        public Machine()
        {
            this.Engineers = new HashSet<EngineerMachine>();
        }
        //public virtual Department Department { get; set;}
        //public int? DepartmentId{get; set;}
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public string MachineNumber { get; set; }
        public virtual ICollection<EngineerMachine> Engineers { get; set; }
    }
}