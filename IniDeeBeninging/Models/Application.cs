using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Application
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int AdvertsId { get; set; }

        public virtual Advertisement Adverts { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
