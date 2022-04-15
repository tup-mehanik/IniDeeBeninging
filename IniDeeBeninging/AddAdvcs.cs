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
    public partial class AddAdvcs : Form
    {
        public int EMPID;
        public AddAdvcs()
        {
            InitializeComponent();
        }

        public AddAdvcs( int idemp ) : this()
        {
            EMPID = idemp;
        }

        private void AddAdvcs_Load(object sender, EventArgs e)
        {
            using (var ctx = new yah_ini_deeContext())
            {
                label7.Text = ctx.Employers.Where(s => s.Id==EMPID).Select(s => s.EmployerName).FirstOrDefault();
                var Positions = ctx.Positions.Select(s => s.PositionName).ToList();
                comboBox1.DataSource = Positions;
                var Address = ctx.AddressesEmployers.Where(s => s.EmployerId == EMPID)
                    .Select(s => s.Address).ToList();
                comboBox2.DataSource = Address;
                var Fields = ctx.Fields.Select(s => s.Name).ToList();
                comboBox3.DataSource = Fields;
                var Contr = ctx.ContractTypes.Select(s => s.Type).ToList();
                comboBox4.DataSource = Contr;

                comboBox1.SelectedItem = null;
                comboBox2.SelectedItem = null;
                comboBox3.SelectedItem = null;
                comboBox4.SelectedItem = null;
                textBox1.Text = ctx.Advertisements.Where(s => s.Id == EMPID).Select(s => s.IsValid).ToString();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ctx = new yah_ini_deeContext();
            string pos, addr, field, contr;
            decimal salary;
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Ай да избирьеш ина катигория");
                return;
            }
            else
            {
                pos = comboBox1.SelectedItem.ToString();
                addr = comboBox2.SelectedItem.ToString();
                field = comboBox3.SelectedItem.ToString();
                contr = comboBox4.SelectedItem.ToString();
                if (textBox1.Text == "") MessageBox.Show("Ай да въвидьеш заплатка");
                else
                {
                    salary = Decimal.Parse(textBox1.Text);
                    Advertisement adv = new Advertisement();
                    adv.PositionId=ctx.Positions.Where(s => s.PositionName==pos).Select(s => s.Id).FirstOrDefault();
                    adv.AddressId=ctx.AddressesEmployers.Where( s => s.Address==addr).Select(s => s.Id).FirstOrDefault();
                    adv.FieldId=ctx.Fields.Where(s => s.Name==field).Select(s => s.Id).FirstOrDefault();
                    adv.ContractId=ctx.ContractTypes.Where(s => s.Type==contr).Select(s => s.Id).FirstOrDefault();
                    adv.PostDate = DateTime.Today;
                    adv.Salary = salary;
                    adv.IsValid = Encoding.ASCII.GetBytes("1");
                    
                    ctx.Advertisements.Add(adv);
                    ctx.SaveChanges();
                    MessageBox.Show("Обявата е добавена успешно");
                    this.Close();
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
