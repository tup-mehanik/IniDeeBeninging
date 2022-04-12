using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class ContactPerson
    {
        public ContactPerson()
        {
            Employers = new HashSet<Employer>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string MiddleName { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual ICollection<Employer> Employers { get; set; }
    }
}
