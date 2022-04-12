﻿using System;
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
    
    public partial class Employer_Form : Form
    {
        public int EmpID;
        public Employer_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Ай да въведеш ино число");
            else
            {
                using (var ctx = new yah_ini_deeContext())
                {
                    EmpID = Int32.Parse(textBox1.Text);
                    var cand = ctx.Applications.Where(s => s.Adverts.Address.Employer.Id == EmpID)
                        .Select(s => new
                        {
                            Name = String.Format("{0} {1} {2}", s.Student.FirstName, s.Student.MiddleName, s.Student.Surname),
                            Phone = s.Student.Phone,
                            School = s.Student.School.Name,
                            EGN = s.Student.Egn,
                            Position = s.Adverts.Position.PositionName
                        }).ToList();
                    dataGridView1.DataSource = cand;
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Ай да въведеш ино число");
            else
            {
                using (var ctx = new yah_ini_deeContext())
                {
                    EmpID = Int32.Parse(textBox1.Text);
                    var alladv = ctx.Advertisements.Where(s => s.Address.EmployerId == EmpID)
                        .Select(s => new
                        {
                            Position = s.Position.PositionName,
                            Salary = s.Salary,
                            Аffiliate = String.Format("{0}, {1} {2}", s.Address.Address, s.Address.City.Name, s.Address.City.PostalCode),
                            Contrac = s.Contract.Type
                        }).ToList();
                    dataGridView1.DataSource = alladv;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Ай да въведеш ино число");
            else
            {
                using (var ctx = new yah_ini_deeContext())
                {
                    EmpID = Int32.Parse(textBox1.Text);
                    var aff = ctx.AddressesEmployers.Where(s => s.EmployerId == EmpID)
                        .Select(s => new
                        {
                            ID = s.Id,
                            Address = String.Format("{0}, {1} {2}", s.Address, s.City.Name, s.City.PostalCode)
                        }).ToList();
                    dataGridView1.DataSource = aff;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Ай да въведеш ино число");
            else
            {
                using (var ctx = new yah_ini_deeContext())
                {
                    EmpID = Int32.Parse(textBox1.Text);
                    var general_info = ctx.Employers.Where(s => s.Id == EmpID)
                        .Select( s => new
                        {
                            ID = s.Id,
                            Name = s.EmployerName,
                            UIC = s.Uic,
                            ContactPerson = String.Format("{0} {1} {2}",s.Contact.FirstName,s.Contact.MiddleName,s.Contact.Surname),
                            ContactPhone = String.Format("{0}", s.Contact.Phone),
                            Custodian = String.Format("{0} {1} {2}", s.Custodian.FirstName, s.Custodian.MiddleName, s.Custodian.Surname),
                            CustodianPhone = String.Format("{0}", s.Custodian.Phone),
                            Email = s.Email,
                            RegisteredSeat = String.Format("{0}, {1} {2}", s.RegisteredSeat, s.City.Name, s.City.PostalCode),
                        }).ToList();
                    dataGridView1.DataSource = general_info;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Ай да въведеш ино число");
            else
            {
                EmpID = Int32.Parse(textBox1.Text);
                Emp_Search_Form esf = new Emp_Search_Form(EmpID);
                this.Hide();
                esf.ShowDialog();
                this.Show();
            }
        }
    }
}