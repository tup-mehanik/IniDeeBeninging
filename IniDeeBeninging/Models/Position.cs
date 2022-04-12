using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Position
    {
        public Position()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }
        public string PositionName { get; set; } = null!;

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
