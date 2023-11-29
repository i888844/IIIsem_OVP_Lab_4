using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab._4
{
    public partial class inputData : Form
    {
        private Form1 _mainForm;
        private string selectedFilePath = string.Empty;

        public inputData(Form1 mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void UpdateFilePathLabel(string path)
        {
            label2.Text = path;
        }

        public event EventHandler ButtonClicked;

        private void button1_Click(object sender, EventArgs e)
        {
            var inputResult = openFileDialog1.ShowDialog();
            if (inputResult == DialogResult.OK)
            {
                selectedFilePath = openFileDialog1.FileName;
                UpdateFilePathLabel(selectedFilePath);

                var fileContent = File.ReadAllText(selectedFilePath);
                var numbersAsString = fileContent.Split(new char[] { ' ', '\t', '\n', '\r' },
                    StringSplitOptions.RemoveEmptyEntries);
                var numbers = new List<double>();

                foreach (var numStr in numbersAsString)
                    if (double.TryParse(numStr, out var number))
                        numbers.Add(number);

                _mainForm.UpdateNumbers(numbers);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            selectedFilePath = string.Empty;
            UpdateFilePathLabel(selectedFilePath);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}