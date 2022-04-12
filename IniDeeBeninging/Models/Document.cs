using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string File { get; set; } = null!;
    }
}
