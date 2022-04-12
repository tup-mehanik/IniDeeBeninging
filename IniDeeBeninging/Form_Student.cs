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
    public partial class Form_Student : Form
    {
        public int Student_ID;
        public Form_Student()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using ( var ctx = new yah_ini_deeContext())
            {
                //var ad = ctx.Advertisements
                //    .Include(p => p.Position)
                //    .Include(f => f.Field)
                //    .Include(ae => ae.Address)
                //    .ThenInclude(e => e.Employer)
                //    .ThenInclude(c => c.Contact)
                //    .Select( sc => new
                //    {
                //        ID = ad.
                //        Position = ad.Position
                //        //Addres = ad.Addres.

                //    }).ToList();
               /* var ad = ctx.AddressesEmployers
                    .Include(ae => ae.Advertisements)
                    .ThenInclude(p => p.Position)
                    .Include(e => e.Employer)
                    .ThenInclude(c => c.Contact)
                    .Select(s => new
                    {
                        
                        Address = s.Address,
                        Employer = s.Employer.EmployerName,
                        Contact = s.Employer.Contact.FirstName + s.Employer.Contact.MiddleName + s.Employer.Contact.Surname
                    })*/

                var adv = ctx.Advertisements
                   // .Include(ade => ade.Address)
                   // .ThenInclude(e => e.Employer)
                    //.ThenInclude(c => c.Contact)
                    .Select(s => new
                    {
                        ID = s.Id,
                        Field = s.Field.Name,
                        Position = s.Position.PositionName,
                        Salary = s.Salary,
                        Contract_Type = s.Contract.Type,
                        Employer = s.Address.Employer.EmployerName,
                        Contact = s.Address.Employer.Contact.FirstName + " " + s.Address.Employer.Contact.MiddleName + " " + s.Address.Employer.Contact.Surname
                    }).ToList();
                dataGridView1.DataSource = adv;
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student_ID = Int32.Parse(textBox1.Text);
            using ( var ctx = new yah_ini_deeContext() )
            {
                var appliations = ctx.Applications.Where(apl => apl.StudentId == Student_ID)
                    .Select(s => new
                    {
                        StudentId = s.StudentId,
                        EmployerName = s.Adverts.Address.Employer.EmployerName,
                        Position = s.Adverts.Position.PositionName,
                        Salary = s.Adverts.Salary
                    }).ToList();
                dataGridView1.DataSource = appliations;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student_ID = Int32.Parse(textBox1.Text);
            using ( var ctx = new yah_ini_deeContext() )
            {
                var GeneralStudentInformation = ctx.Students.Where(s => s.Id == Student_ID)
                    .Select(s => new
                    {
                        Id = s.Id,
                        Name = s.FirstName + "" + s.MiddleName + " " + s.Surname,
                        School = s.School.Name,
                        PhoneNumber = s.Phone,
                        EGN = s.Egn,
                        Email = s.Email,
                        Address = s.Address+", "+s.City.Name
                    }).ToList() ;
                dataGridView1.DataSource = GeneralStudentInformation;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_SearchByField s = new Student_SearchByField();
            this.Hide();
            s.ShowDialog();
            this.Show();
        }
    }
}
