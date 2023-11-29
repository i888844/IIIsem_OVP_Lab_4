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
    public partial class saving : Form
    {
        private string generatedText = "";

        public saving()
        {
            InitializeComponent();
        }

        public void SetGeneratedText(string text)
        {
            generatedText = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filePath = @"C:\Users\i8888\YandexDisk\Работы\Лабораторные работы\Основы визуального программирования\Lab. №4\output.txt";
            SaveToFile(filePath, generatedText);
            MessageBox.Show("Файл успешно сохранен.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.Title = "Save File";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                SaveToFile(saveFileDialog.FileName, generatedText);
                MessageBox.Show("Файл успешно сохранен.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveToFile(string filePath, string text)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.Write(text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}");
            }
        }
    }
}
