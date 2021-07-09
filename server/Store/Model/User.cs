using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Model
{
    public class User
    {
        public int Id { get; set; }
        public int Role { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
