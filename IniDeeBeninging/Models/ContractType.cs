using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class ContractType
    {
        public ContractType()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }
        public string Type { get; set; } = null!;

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
