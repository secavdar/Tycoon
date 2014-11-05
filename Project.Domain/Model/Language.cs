using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Model
{
    using Contract;
    public class Language : IActiveState
    {
        [Key]
        public int ID { get; set; }
        public int ProcessID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual UserProcess UserProcess { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}