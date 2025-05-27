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
using Newtonsoft.Json.Linq;

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
            string filePath = textBox2.Text; // Укажите путь к вашему JSON-файлу
            string customText = textBox1.Text; // Текст для вставки
            int insertPosition = 333; // Позиция для вставки (начинается с 0)

            try
            {
                // Читаем содержимое файла
                string content = File.ReadAllText(filePath);

                // Проверяем, не добавлен ли текст ранее
                if (!content.Contains(customText))
                {
                    // Если позиция вставки больше длины контента, добавляем в конец
                    if (insertPosition > content.Length)
                    {
                        insertPosition = content.Length;
                    }

                    // Вставляем текст
                    content = content.Insert(insertPosition, customText);

                    // Записываем изменения обратно в файл
                    File.WriteAllText(filePath, content);
                    MessageBox.Show("Персонаж создан");
                }
                else
                {
                    Console.WriteLine("Текст уже был добавлен ранее.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
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
