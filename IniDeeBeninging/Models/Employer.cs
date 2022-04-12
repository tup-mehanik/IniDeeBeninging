using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Employer
    {
        public Employer()
        {
            AddressesEmployers = new HashSet<AddressesEmployer>();
        }

        public int Id { get; set; }
        public string EmployerName { get; set; } = null!;
        public string Uic { get; set; } = null!;
        public int CustodianId { get; set; }
        public string Email { get; set; } = null!;
        public int CityId { get; set; }
        public string RegisteredSeat { get; set; } = null!;
        public int ContactId { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ContactPerson Contact { get; set; } = null!;
        public virtual PropertyCustodian Custodian { get; set; } = null!;
        public virtual ICollection<AddressesEmployer> AddressesEmployers { get; set; }
    }
}
