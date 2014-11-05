using System;

namespace Project.Domain.Model
{
    public class UserServer
    {
        public int ID { get; set; }
        public int ProcessID { get; set; }
        public int ServerID { get; set; }

        public virtual User User { get; set; }
        public virtual Server Server { get; set; }
    }
}