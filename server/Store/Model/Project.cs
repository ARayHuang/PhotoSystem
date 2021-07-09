using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Model
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int status { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        
        public int Owner_id { get; set; }
        public virtual User Owner { get; set; }
    }
}
