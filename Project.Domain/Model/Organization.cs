using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Model
{
    public class Organization
    {
        public Organization()
        {
            this.Companies = new List<Company>();
        }

        [Key]
        public int ID { get; set; }
        public int ProcessID { get; set; }

        public virtual UserProcess UserProcess { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
    }
}