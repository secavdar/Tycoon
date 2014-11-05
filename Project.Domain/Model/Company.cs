using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Model
{
    public class Company
    {
        [Key]
        public int ID { get; set; }
        public int ProcessID { get; set; }
        public int OrganizationID { get; set; }
        public string Name { get; set; }

        public virtual UserProcess UserProcess { get; set; }
        public virtual Organization Organization { get; set; }
    }
}