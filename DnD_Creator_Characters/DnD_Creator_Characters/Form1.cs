using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
