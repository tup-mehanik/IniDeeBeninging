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
    public partial class Emp_Search_Form : Form
    {
        public int Emp_Id;
        public Emp_Search_Form()
        {
            InitializeComponent();
        }
        public Emp_Search_Form( int EID):this()
        {
            Emp_Id= EID;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (string.IsNullOrEmpty(name)) MessageBox.Show("Ай да въведеш нещо");
            else
            {
                using ( var ctx = new yah_ini_deeContext() )
                {
                    var cand = ctx.Applications.Where(s => s.Adverts.Address.EmployerId ==Emp_Id && (s.Student.FirstName+" "+s.Student.MiddleName+" "+s.Student.Surname).ToLower().Contains(name.ToLower())).
                    Select ( s => new
                    {
                        Name = String.Format("{0} {1} {2}",s.Student.FirstName, s.Student.MiddleName, s.Student.Surname),
                        Phone = s.Student.Phone,
                        School = s.Student.School.Name,
                        Email = s.Student.Email
                    }).ToList();
                    dataGridView1.DataSource = cand;
                }
            }
        }
    }
}
