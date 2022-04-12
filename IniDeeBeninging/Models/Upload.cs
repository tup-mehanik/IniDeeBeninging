using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Upload
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string File { get; set; } = null!;
    }
}
