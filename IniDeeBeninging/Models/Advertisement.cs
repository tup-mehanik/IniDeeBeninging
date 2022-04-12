using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Advertisement
    {
        public Advertisement()
        {
            Applications = new HashSet<Application>();
        }

        public int Id { get; set; }
        public int PositionId { get; set; }
        public int AddressId { get; set; }
        public int FieldId { get; set; }
        public DateTime PostDate { get; set; }
        public byte[] IsValid { get; set; } = null!;
        public decimal Salary { get; set; }
        public int ContractId { get; set; }
        public int Views { get; set; }

        public virtual AddressesEmployer Address { get; set; } = null!;
        public virtual ContractType Contract { get; set; } = null!;
        public virtual Field Field { get; set; } = null!;
        public virtual Position Position { get; set; } = null!;
        public virtual ICollection<Application> Applications { get; set; }
    }
}
