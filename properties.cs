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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int count) && int.TryParse(textBox2.Text, out int minValue) && int.TryParse(textBox3.Text, out int maxValue))
            {
                Random random = new Random();
                List<int> numbers = new List<int>(); // Теперь список чисел будет типа int
                for (int i = 0; i < count; i++)
                {
                    int randomNumber = random.Next(minValue, maxValue + 1); // Генерация случайного числа типа int
                    numbers.Add(randomNumber);
                }
                Form1 mainForm = Application.OpenForms.OfType<Form1>().FirstOrDefault();
                mainForm?.UpdateNumbers(numbers);
                this.Close();
            }
            else
            {
                MessageBox.Show("Введите корректные значения.");
            }
        }
    }
}
