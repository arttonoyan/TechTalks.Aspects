using System;
using System.Collections.Generic;

namespace TechTalks.DemoData
{
    public partial class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public byte Gender { get; set; }
        public int UniversityId { get; set; }

        public virtual University University { get; set; } = null!;
    }
}
