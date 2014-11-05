using System;

namespace Project.Domain.Model
{
    public class UserProcess
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime BeginDate { get; set; }
        public Nullable<DateTime> EndDate { get; set; }

        public virtual User User { get; set; }
    }
}