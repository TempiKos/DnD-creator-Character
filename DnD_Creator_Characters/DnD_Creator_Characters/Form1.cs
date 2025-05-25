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

namespace DnD_Creator_Characters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Получить текст из TextBox
            string inputText = textBox1.Text;

            // Вывести результат (например, в MessageBox)
            MessageBox.Show("Введенный текст: " + inputText);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                // Настройки диалога
                openFileDialog.Title = "Выберите JSON файл";
                openFileDialog.Filter = "JSON файлы (*.json)|*.json|Все файлы (*.*)|*.*";
                openFileDialog.InitialDirectory = GetDownloadsPath();
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox2.Text = openFileDialog.FileName;
                    // Здесь можно добавить обработку файла
                }
            }
        }

        // Получаем путь к папке "Загрузки"
        private string GetDownloadsPath()
        {
            try
            {
                return Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads");
            }
            catch
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }
    }
}
