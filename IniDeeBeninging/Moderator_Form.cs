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
    public partial class Moderator_Form : Form
    {
        public Moderator_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ctx = new yah_ini_deeContext();
            var Students = ctx.Students.Select( s => new
            {
                Name = String.Format("{0} {1} {2}", s.FirstName, s.MiddleName, s.Surname),
                Phone = s.Phone,
                Email = s.Email,
                School = s.School.Name,
                EGN = s.Egn,
            }).ToList();
            dataGridView1.DataSource = Students;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var ctx = new yah_ini_deeContext();
            var Emp = ctx.Employers.Select( s => new
            {
                ID = s.Id,
                Name = s.EmployerName,
                UIC = s.Uic,
                ContactPerson = String.Format("{0} {1} {2}", s.Contact.FirstName, s.Contact.MiddleName, s.Contact.Surname),
                ContactPhone = String.Format("{0}", s.Contact.Phone),
                Custodian = String.Format("{0} {1} {2}", s.Custodian.FirstName, s.Custodian.MiddleName, s.Custodian.Surname),
                CustodianPhone = String.Format("{0}", s.Custodian.Phone),
                Email = s.Email,
                RegisteredSeat = String.Format("{0}, {1} {2}", s.RegisteredSeat, s.City.Name, s.City.PostalCode),
            }).ToList();
            dataGridView1.DataSource= Emp;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Moderator_Search_Form msf = new Moderator_Search_Form();
            this.Hide();
            msf.ShowDialog();
            this.Show();
        }
    }
}
