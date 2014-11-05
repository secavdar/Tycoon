using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project.Domain.Model
{
    public class User
    {
        public User()
        {
            this.LoginHistories = new List<LoginHistory>();
            this.UserServers = new List<UserServer>();
        }

        [Key]
        public int ID { get; set; }
        public int LanguageID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Language Language { get; set; }
        public virtual ICollection<LoginHistory> LoginHistories { get; set; }
        public virtual ICollection<UserServer> UserServers { get; set; }
    }
}