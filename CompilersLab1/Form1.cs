using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CompilersLab1
{
    public partial class Form1 : Form
    {
        string filePath = "";
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            bool hjswb = InputRTB.CanUndo;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            //сохранение файла
            if (filePath != "")
                System.IO.File.WriteAllText(filePath, InputRTB.Text);
            else
                SaveAs_Click(null, null);

            Close();
        }

        void OpenFile()
        {
            SaveFunc();
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != "")
                    filePath = openFileDialog1.FileName;
                using (StreamReader sr = new StreamReader(filePath))
                {
                    InputRTB.Text = sr.ReadToEnd();
                }
                OutRTB.Text = "";
            }
        }
        void NewFileFunc()
        {

            SaveFunc();
            InputRTB.Text = "";
            OutRTB.Text = "";
            saveFileDialog1.Title = "Введите имя нового файла:";
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filePath = saveFileDialog1.FileName;

        }
        void SaveFunc()
        {
            if(filePath == "" && InputRTB.Text == "")
            if (filePath != "")
                System.IO.File.WriteAllText(filePath, InputRTB.Text);
            else
                SaveAs_Click(null, null);
        }

        void CopyFunc()
        {
            Clipboard.SetText(InputRTB.SelectedText);
        }
        void PasteFunc()
        {
            InputRTB.Paste();
        }
        void CutFunc()
        {
            Clipboard.SetText(InputRTB.SelectedText);
            InputRTB.SelectedText = "";
        }
        private void Open_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenButt_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void SaveButt_Click(object sender, EventArgs e)
        {
            SaveFunc();
        }
        private void Save_Click(object sender, EventArgs e)
        {
            SaveFunc();
        }
        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filePath = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filePath, InputRTB.Text);
        }

        private void New_Click(object sender, EventArgs e)
        {
            NewFileFunc();
        }

        private void NewButt_Click(object sender, EventArgs e)
        {
            NewFileFunc();
        }

        private void CopyButt_Click(object sender, EventArgs e)
        {
            CopyFunc();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            CopyFunc();
        }

        private void PasteButt_Click(object sender, EventArgs e)
        {
            PasteFunc();
        }

        private void Push_Click(object sender, EventArgs e)
        {
            PasteFunc();
        }

        private void CutButt_Click(object sender, EventArgs e)
        {
            CutFunc();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            CutFunc();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            InputRTB.SelectedText = "";
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            InputRTB.SelectAll();
        }

        private void CancelButt_Click(object sender, EventArgs e)
        {
            InputRTB.Undo();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            InputRTB.Undo();
        }

        private void RepeatButt_Click(object sender, EventArgs e)
        {
            InputRTB.Redo();
        }

        private void Repeat_Click(object sender, EventArgs e)
        {
            InputRTB.Redo();
        }

        private void HelpButt_Click(object sender, EventArgs e)
        {
            string path = "help.txt";

            using (StreamReader sr = new StreamReader(path))
                MessageBox.Show(sr.ReadToEnd(), "Справка:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Info_Click(object sender, EventArgs e)
        {
            string path = "help.txt";

            using (StreamReader sr = new StreamReader(path))
                MessageBox.Show(sr.ReadToEnd(), "Справка:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AboutMe_Click(object sender, EventArgs e)
        {
            string path = "aboutme.txt";

            using (StreamReader sr = new StreamReader(path))
                MessageBox.Show(sr.ReadToEnd(), "О программе:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
