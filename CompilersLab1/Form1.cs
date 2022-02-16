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
        //крестик для кнопок
        public string closeButtonFullPath = @"C:\Users\Егор\source\repos\CompilersLab1\X.png";
        public Form1()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        void OpenFile()
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != "")
                    filePath = openFileDialog1.FileName;
                NewPageFunc(filePath);
                using (StreamReader sr = new StreamReader(filePath))
                {
                    TabControl1.SelectedTab.Controls[0].Text = sr.ReadToEnd();
                }
                OutRTB.Text = "";
            }
        }
        void NewPageFunc(string name)
        {
            string title;
            if (name == "")
                title = "newFile" + (TabControl1.TabCount + 1).ToString();
            else
                title = Path.GetFileName(name);
            //создаем объект вкладки
            TabPage myTabPage = new TabPage(title);
            //пихаем в таб контрол
            TabControl1.TabPages.Add(myTabPage);
            //создаем поле для текста
            FastColoredTextBoxNS.FastColoredTextBox newtextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            if (title.Split('.').Last() == "cs")
                newtextBox.Language = FastColoredTextBoxNS.Language.CSharp;

            if (title.Split('.').Last() == "html")
                newtextBox.Language = FastColoredTextBoxNS.Language.HTML;

            if (title.Split('.').Last() == "sql")
                newtextBox.Language = FastColoredTextBoxNS.Language.SQL;

            if (title.Split('.').Last() == "js")
                newtextBox.Language = FastColoredTextBoxNS.Language.JS;

            //размеры поля
            newtextBox.Size = myTabPage.Size;
            //засовываем поле во вкладку
            TabControl1.TabPages[TabControl1.TabPages.Count - 1].Controls.Add(newtextBox);
            //привязываем поле к границам вкладки
            TabControl1.TabPages[TabControl1.TabPages.Count - 1].Controls[0].Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                | AnchorStyles.Left | AnchorStyles.Right;
            //переходим на свежую вкладку
            TabControl1.SelectedTab = TabControl1.TabPages[TabControl1.TabPages.Count - 1];
            //создаем справку путем к файлу (пользователь вспомнит где файл, и программа тоже)
            ToolStripMenuItem path = new ToolStripMenuItem(name);
            //создаем контекстное меню
            ContextMenuStrip menuStrip = new ContextMenuStrip();
            //добавляем в меню поле
            menuStrip.Items.AddRange(new[] { path });
            //присваиваем вкладке созданное меню
            TabControl1.SelectedTab.ContextMenuStrip = menuStrip;
        }
        void NewFileFunc()
        {
            OutRTB.Text = "";
            NewPageFunc("");
        }
        void SaveFunc()
        {

            if (TabControl1.SelectedTab.ContextMenuStrip.Items[0].Text != "")
                try
                {
                    System.IO.File.WriteAllText(TabControl1.SelectedTab.ContextMenuStrip.Items[0].Text, TabControl1.SelectedTab.Controls[0].Text);
                }
                catch
                {
                    SaveAs_Click(null, null);
                }
            else
                SaveAs_Click(null, null);
        }

        void CopyFunc()
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Copy();
        }
        void PasteFunc()
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Paste();
        }
        void CutFunc()
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Cut();
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
            System.IO.File.WriteAllText(filePath, TabControl1.SelectedTab.Controls[0].Text);
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
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.SelectedText = "";
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.SelectAll();
        }

        private void CancelButt_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Undo();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Undo();
        }

        private void RepeatButt_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Redo();
        }

        private void Repeat_Click(object sender, EventArgs e)
        {
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
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

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                var tabPage = this.TabControl1.TabPages[e.Index];
                var tabRect = this.TabControl1.GetTabRect(e.Index);
                tabRect.Inflate(-2, -2);
                // draw Close button to all other TabPages

                var closeImage = new Bitmap(closeButtonFullPath);
                e.Graphics.DrawImage(closeImage,
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, tabPage.Font,
                    tabRect, tabPage.ForeColor, TextFormatFlags.Left);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void TabControl_MouseDown(object sender, MouseEventArgs e)
        {
            // Process MouseDown event only till (tabControl.TabPages.Count - 1) excluding the last TabPage
            for (var i = 0; i < this.TabControl1.TabPages.Count; i++)
            {
                var tabRect = this.TabControl1.GetTabRect(i);
                tabRect.Inflate(-2, -2);
                var closeImage = new Bitmap(closeButtonFullPath);
                var imageRect = new Rectangle(
                    (tabRect.Right - closeImage.Width),
                    tabRect.Top + (tabRect.Height - closeImage.Height) / 2,
                    closeImage.Width,
                    closeImage.Height);
                if (imageRect.Contains(e.Location))
                {
                    this.TabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }

        }
    }
}
