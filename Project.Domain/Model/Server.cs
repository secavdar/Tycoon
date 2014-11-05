using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Model
{
    public class Server
    {
        public Server()
        {
            this.UserServers = new List<UserServer>();
        }

        [Key]
        public int ID { get; set; }
        public int ProcessID { get; set; }

        public virtual UserProcess UserProcess { get; set; }
        public virtual ICollection<UserServer> UserServers { get; set; }
    }
}