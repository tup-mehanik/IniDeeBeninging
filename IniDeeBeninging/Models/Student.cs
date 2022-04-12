using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Student
    {
        public Student()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Egn { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int CityId { get; set; }
        public string Address { get; set; } = null!;
        public int SchoolId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual School School { get; set; } = null!;
        public virtual ICollection<Application> Applications { get; set; }
    }
}
