using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab._4
{
    public partial class properties : Form
    {
        public properties()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out var count) && int.TryParse(textBox2.Text, out var minValue) &&
                int.TryParse(textBox3.Text, out var maxValue))
            {
                var random = new Random();
                var numbers = new List<int>();
                for (var i = 0; i < count; i++)
                {
                    var randomNumber = random.Next(minValue, maxValue + 1);
                    numbers.Add(randomNumber);
                }

                var mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                mainForm?.UpdateNumbers(numbers);
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректные значения.");
            }
        }
    }
}