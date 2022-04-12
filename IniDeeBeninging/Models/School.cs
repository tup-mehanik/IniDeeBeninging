using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class School
    {
        public School()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CityId { get; set; }
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual City City { get; set; } = null!;
        public virtual ICollection<Student> Students { get; set; }
    }
}
