using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using IniDeeBeninging.Models;


namespace IniDeeBeninging
{
    public partial class Employer_Redact_Form : Form
    {
        int EMPID;
        public Employer_Redact_Form()
        {
            InitializeComponent();
        }
        public Employer_Redact_Form( int idemp ) : this()
        {
            EMPID = idemp;
        }

        private void Employer_Redact_Form_Load(object sender, EventArgs e)
        {
            using ( var ctx = new yah_ini_deeContext())
            {
                var Cities = ctx.Cities.Select(s => s.Name).ToList();
                comboBox1.DataSource = Cities;


                Employer emp = ctx.Employers.Where(s => s.Id == EMPID).FirstOrDefault();
                textBox1.Text = emp.EmployerName;
                textBox2.Text = emp.Uic;
                textBox3.Text = emp.Email;
                textBox4.Text = emp.RegisteredSeat;
                int c = emp.CityId;
                comboBox1.SelectedItem =ctx.Cities.Where(s => s.Id==c).Select(s => s.Name).FirstOrDefault().ToString();

                ContactPerson cp = ctx.ContactPeople.Where(s => s.Id==emp.ContactId).FirstOrDefault();
                textBox9.Text = cp.FirstName;
                textBox8.Text = cp.MiddleName;
                textBox7.Text = cp.FirstName;
                textBox6.Text = cp.Email;
                textBox5.Text = cp.Phone;

                PropertyCustodian pc = ctx.PropertyCustodians.Where(s => s.Id == emp.CustodianId).FirstOrDefault();
                textBox15.Text = pc.FirstName;
                textBox14.Text = pc.MiddleName;
                textBox13.Text = pc.Surname;
                textBox12.Text = pc.Egn;
                textBox11.Text = pc.Phone;
                textBox10.Text = pc.Email;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using ( var ctx = new yah_ini_deeContext() )
            {
                Employer emp = ctx.Employers.Where(s => s.Id == EMPID).FirstOrDefault();
                ContactPerson cp = ctx.ContactPeople.Where(s => s.Id == emp.ContactId).FirstOrDefault();
                PropertyCustodian pc = ctx.PropertyCustodians.Where(s => s.Id == emp.CustodianId).FirstOrDefault();
                
                pc.Email = textBox10.Text;
                pc.Phone = textBox11.Text;
                pc.Egn = textBox12.Text;
                pc.Surname = textBox13.Text;
                pc.MiddleName = textBox14.Text;
                pc.FirstName = textBox15.Text;

                cp.FirstName = textBox9.Text;
                cp.MiddleName = textBox8.Text;
                cp.FirstName = textBox7.Text;
                cp.Email = textBox6.Text;
                cp.Phone = textBox5.Text;

                textBox1.Text = emp.EmployerName;
                textBox2.Text = emp.Uic;
                textBox3.Text = emp.Email;
                textBox4.Text = emp.RegisteredSeat;

                emp.RegisteredSeat = textBox4.Text;
                emp.Email = textBox3.Text;
                emp.Uic = textBox2.Text;
                emp.EmployerName = textBox1.Text;
                emp.CityId = ctx.Cities.Where(s => s.Name == comboBox1.SelectedItem.ToString()).Select(s => s.Id).FirstOrDefault();

                ctx.SaveChanges();
                MessageBox.Show("Промените са запазени");
                this.Close();
            }
        }
    }
}
