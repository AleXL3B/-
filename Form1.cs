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

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        private string currentFilePath = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void ClickOpen(object sender, MouseEventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Текстовые файлы (*.txt)|*.txt;";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    currentFilePath = ofd.FileName;
                    TextBox1.Text = File.ReadAllText(currentFilePath);
                }
            }

        }

        private void ClickSave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFilePath))
            {
                File.WriteAllText(currentFilePath, TextBox1.Text);
                MessageBox.Show("Файл успешно сохранен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Сначала открой файл или используйте Save as TXT", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
