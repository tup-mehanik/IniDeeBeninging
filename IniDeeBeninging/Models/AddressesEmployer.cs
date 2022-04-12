using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class AddressesEmployer
    {
        public AddressesEmployer()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }
        public int EmployerId { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; } = null!;

        public virtual City City { get; set; } = null!;
        public virtual Employer Employer { get; set; } = null!;
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
