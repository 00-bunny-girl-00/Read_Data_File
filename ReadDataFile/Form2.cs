using System.Text.RegularExpressions;


namespace ReadDataFile
{
    public partial class Form2 : Form
    {
        public string file = " ";
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            file = textBox1.Text;

            if (Regex.IsMatch(textBox1.Text, @"([A-Za-z]:\\)((?:.*\\)?)(ЦП.txt)"))
            {
                Form1 form = new Form1(this);
                form.ShowDialog();
            }
            else
            {
                errorProvider1.SetError(textBox1, "Вы не ввели путь или ввели не правильно !-!");
            }
        }
    }
}
