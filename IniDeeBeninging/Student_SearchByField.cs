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
    public partial class Student_SearchByField : Form
    {
        public string con;
        public Student_SearchByField()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con=textBox1.Text;
            using ( var ctx = new yah_ini_deeContext())
            {
                var passingads = ctx.Advertisements
                    .Where(s => s.Field.Name.ToLower().Contains(con.ToLower()))
                    .Select(s => new
                    {
                        ID = s.Id,
                        Position = s.Position.PositionName,
                        Field = s.Field.Name,
                        Employer = s.Address.Employer.EmployerName,
                        Salary = s.Salary,
                        ContractType = s.Contract.Type,

                    }).ToList();
                dataGridView1.DataSource = passingads;
            }
        }
    }
}
