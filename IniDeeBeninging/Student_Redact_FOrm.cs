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
        public int IDS;
        public Student_Redact_FOrm()
        {
            InitializeComponent();
        }
        public Student_Redact_FOrm( int id ):this()
        {
            IDS = id;
        }
        private void Student_Redact_FOrm_Load(object sender, EventArgs e)
        {
            using (var ctx = new yah_ini_deeContext())
            {
                var Cities = ctx.Cities.Select(s => s.NameOfCitie()).ToList();
                comboBox1.DataSource = Cities;
                var Schools = ctx.Schools.Select(s => s.NameOfSchool()).ToList();
                comboBox2.DataSource = Schools;

                Student st = ctx.Students.Where(s => s.Id==IDS).FirstOrDefault();
                textBox1.Text = st.FirstName;
                textBox2.Text = st.MiddleName;
                textBox3.Text = st.Surname;
                textBox4.Text = st.Egn;
                textBox5.Text = st.Phone;
                textBox6.Text = st.Email;
                textBox7.Text = st.Address;
                comboBox1.SelectedItem = st.City.Name;
                comboBox2.SelectedItem = st.School.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var ctx = new yah_ini_deeContext())
            {
                Student st = ctx.Students.Where(s => s.Id == IDS).FirstOrDefault();
                st.FirstName = textBox1.Text;
                st.MiddleName = textBox2.Text;
                st.Surname = textBox3.Text;
                st.Egn = textBox4.Text;
                st.Phone = textBox5.Text;
                st.Email = textBox6.Text;
                st.Address = textBox7.Text;
                City city = ctx.Cities.Where(s => s.Name == comboBox1.SelectedItem).FirstOrDefault();
                School school = ctx.Schools.Where(s => s.Name == comboBox2.SelectedItem ).FirstOrDefault();
                st.School = school;
                st.City = city;
                
                ctx.SaveChanges();
                MessageBox.Show("Промените са запазени успешно!");
                this.Close();
            }
        }

    }
}
