using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IniDeeBeninging.Models;
using Microsoft.EntityFrameworkCore;


namespace IniDeeBeninging
{
    public partial class Student_Redact_FOrm : Form
    {
        public Student_Redact_FOrm()
        {
            InitializeComponent();
        }

        private void Student_Redact_FOrm_Load(object sender, EventArgs e)
        {
            using (var ctx = new yah_ini_deeContext())
            {
                var Cities = ctx.Cities.Select(s => s.NameOfCitie()).ToList();
                comboBox1.DataSource = Cities;
                var Schools = ctx.Schools.Select(s => s.NameOfSchool()).ToList();
                comboBox2.DataSource = Schools;
            }
        }
    }
}
