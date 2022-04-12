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
    public partial class Moderator_Search_Form : Form
    {
        public Moderator_Search_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (string.IsNullOrEmpty(name)) MessageBox.Show("Ай да въведеш нещо");
            else
            {
                using (var ctx = new yah_ini_deeContext())
                {
                    var searchedSt = ctx.Students.Where(s => (s.FirstName + " " + s.MiddleName + " " + s.Surname).ToLower().Contains(name.ToLower())).
                    Select(s => new
                    {
                        Name = String.Format("{0} {1} {2}", s.FirstName, s.MiddleName, s.Surname),
                        Phone = s.Phone,
                        School = s.School.Name,
                        Email = s.Email
                    }).ToList();
                    dataGridView1.DataSource = searchedSt;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (string.IsNullOrEmpty(name)) MessageBox.Show("Ай да въведеш нещо");
            else
            {
                using (var ctx = new yah_ini_deeContext())
                {
                    var searchedEmp = ctx.Employers.Where(s => s.EmployerName.ToLower().Contains(name.ToLower()))
                        .Select(s => new
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
                    dataGridView1.DataSource = searchedEmp;

                }
            }
        }
    }
}
