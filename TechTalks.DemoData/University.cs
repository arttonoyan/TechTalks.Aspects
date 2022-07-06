using System;
using System.Collections.Generic;

namespace TechTalks.DemoData
{
    public partial class University
    {
        public University()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; }
    }
}
