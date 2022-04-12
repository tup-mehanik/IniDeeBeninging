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

        private void button5_Click(object sender, EventArgs e)
        {
            Employer_Form ef = new Employer_Form();
            this.Hide();
            ef.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Moderator_Form mf = new Moderator_Form();
            this.Hide();
            mf.ShowDialog();
            this.Show();
        }
    }
}