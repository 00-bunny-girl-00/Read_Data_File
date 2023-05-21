using Microsoft.VisualBasic.Logging;
using System;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;

namespace ReadDataFile
{
    public partial class Form1 : Form
    {
        public string file;

        bool trueOrFalse = false;

        string[] list = { "Начальная память", "Максимальная память", "Фиксированная память" };

        public Form1(Form2 text)
        {
            InitializeComponent();
            file = text.file;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                label7.Text = file;

                string[] lines = File.ReadAllLines(file);

                label2.Text = lines[5];
                label3.Text = lines[6];
                label4.Text = lines[7];

                double[] numberOfVisitors = { double.Parse(lines[1]), double.Parse(lines[2]), double.Parse(lines[4]) };

                chart.Titles.Add(lines[0]);

                chart1.Titles.Add("Используемая память программой JAVA");
                chart1.Series["Используемая память"].Points.Add(double.Parse(lines[3]));

                for (int i = 0; i < list.Length; i++)
                {
                    chart.Series[list[i]].Points.Add(numberOfVisitors[i]);
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(label7, "Файл не найден, пробуйте снова 0з0");
            }
        }

        public void UpdateData()
        {
            while (trueOrFalse)
            {
                string[] lines = File.ReadAllLines(file);

                double[] numberOfVisitors = { double.Parse(lines[1]), double.Parse(lines[2]), double.Parse(lines[4]) };

                chart1.Series["Используемая память"].Points.Add(double.Parse(lines[3]));

                for (int i = 0; i < list.Length; i++)
                {
                    chart.Series[list[i]].Points.Add(numberOfVisitors[i]);
                }

                Thread.Sleep(1000);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Продолжить обновление данных";
            trueOrFalse = true;
            Thread thread = new Thread(new ThreadStart(UpdateData));
            thread.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            trueOrFalse = false;
        }
    }
}