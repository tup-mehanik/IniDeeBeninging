using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Field
    {
        public Field()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
