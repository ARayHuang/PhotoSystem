using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Model
{
    public class Photo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public virtual User Author { get; set; }
    }
}
