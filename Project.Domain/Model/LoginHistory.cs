using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Model
{
    public class LoginHistory
    {
        [Key]
        public int ID { get; set; }
        public int ProcessID { get; set; }

        public virtual UserProcess UserProcess { get; set; }
        [ForeignKey("UserID")]
        public virtual User User { get; set; }
    }
}