namespace IniDeeBeninging
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_Student fs = new Form_Student();
            this.Hide();
            fs.ShowDialog();
            this.Show();

        }
    }
}