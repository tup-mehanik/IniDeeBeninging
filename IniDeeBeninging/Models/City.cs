using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class City
    {
        public City()
        {
            AddressesEmployers = new HashSet<AddressesEmployer>();
            Employers = new HashSet<Employer>();
            Schools = new HashSet<School>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PostalCode { get; set; }

        public virtual ICollection<AddressesEmployer> AddressesEmployers { get; set; }
        public virtual ICollection<Employer> Employers { get; set; }
        public virtual ICollection<School> Schools { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
