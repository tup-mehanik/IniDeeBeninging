using System;
using System.Collections.Generic;

namespace IniDeeBeninging.Models
{
    public partial class LoginDatum
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Type { get; set; }
        public int LinkId { get; set; }
    }
}
