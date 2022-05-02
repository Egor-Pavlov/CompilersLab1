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
using System.Text.RegularExpressions;
using System.Windows;
using System.Diagnostics;

namespace CompilersLab1
{
    public partial class Form1 : Form
    {
        string filePath = "";
        //крестик для кнопок
        public string closeButtonFullPath = @"..\..\X.png";
        public Form1()
        {
            InitializeComponent();
            //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            this.FormClosing += Exit_Click;

            OutRTB.Font = new Font("San Serif", 14, FontStyle.Regular);
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            for (int i = TabControl1.TabPages.Count - 1; i >= 0; i--)
            {
                if (TabControl1.TabPages[i].Text[0] == '*')
                {
                    DialogResult result = MessageBox.Show("Сохранить файл " + TabControl1.TabPages[i].Text.Replace("*", "").Replace(" ", "")
                        + " перед закрытием?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                                MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.Yes)
                        SaveFunc();
                }
                this.TabControl1.TabPages.RemoveAt(i);
            }
            Application.Exit();
        }

        void OpenFile()
        {
            if (openFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (openFileDialog1.FileName != "")
                    filePath = openFileDialog1.FileName;
                NewPageFunc(filePath);
                OutRTB.Text = "";
            }
        }
        void NewPageFunc(string name)
        {
            string title;
            string format = Path.GetFileName(name).Split('.').Last();
            if (name == "")
                title = "newFile" + (TabControl1.TabCount + 1).ToString() + "     ";
            else
                title = Path.GetFileName(name) + "     ";
            //создаем объект вкладки
            TabPage myTabPage = new TabPage(title);
            myTabPage.Font = new Font("San Serif", 10, FontStyle.Regular);
            //пихаем в таб контрол
            TabControl1.TabPages.Add(myTabPage);
            //создаем поле для текста
            FastColoredTextBoxNS.FastColoredTextBox newtextBox = new FastColoredTextBoxNS.FastColoredTextBox();
            if (format == "cs")
                newtextBox.Language = FastColoredTextBoxNS.Language.CSharp;

            else if (format == "html")
                newtextBox.Language = FastColoredTextBoxNS.Language.HTML;

            else if (format == "sql")
                newtextBox.Language = FastColoredTextBoxNS.Language.SQL;

            else if (format == "js")
                newtextBox.Language = FastColoredTextBoxNS.Language.JS;

            newtextBox.TextChanged += new EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(FCTB_textChanged);
            //размеры поля
            newtextBox.Size = myTabPage.Size;
            newtextBox.Font = new Font("San Serif", 14, FontStyle.Regular);
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

            //читаем текст
            if (name != "")
            {
                using (StreamReader sr = new StreamReader(name))
                {
                    newtextBox.Text = sr.ReadToEnd();
                }
            }
            myTabPage.Text = title;
        }
        //стили текста для оформления
        FastColoredTextBoxNS.Style RedStyle = new FastColoredTextBoxNS.TextStyle(Brushes.Red, null, FontStyle.Bold);
        FastColoredTextBoxNS.Style GreenStyle = new FastColoredTextBoxNS.TextStyle(Brushes.Green, null, FontStyle.Italic);
        FastColoredTextBoxNS.Style BlueStyle = new FastColoredTextBoxNS.TextStyle(Brushes.Blue, null, FontStyle.Regular);
        FastColoredTextBoxNS.Style BoldStyle = new FastColoredTextBoxNS.TextStyle(Brushes.DeepPink, null, FontStyle.Bold);
        FastColoredTextBoxNS.Style ConstStyle = new FastColoredTextBoxNS.TextStyle(Brushes.ForestGreen, null, FontStyle.Regular);
        FastColoredTextBoxNS.Style OrangeStyle = new FastColoredTextBoxNS.TextStyle(Brushes.Orange, null, FontStyle.Regular);

        public void FCTB_textChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
       {
            if (TabControl1.SelectedTab.Text[0] != '*')
                TabControl1.SelectedTab.Text = "*" + TabControl1.SelectedTab.Text;

            FastColoredTextBoxNS.FastColoredTextBox tb = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];

            if (tb.Language == FastColoredTextBoxNS.Language.Custom)
            {
                //очистить стиль в измененном блоке текста
                e.ChangedRange.ClearStyle(FastColoredTextBoxNS.StyleIndex.All);

                //подсветка нескольких слов через регулярное выражение
                e.ChangedRange.SetStyle(ConstStyle, @"(\s+[0-9]+(\.)?([\d])*)");
                e.ChangedRange.SetStyle(RedStyle, @"(True|False|echo|NULL)");
                e.ChangedRange.SetStyle(BlueStyle, @"\$\w+");
                e.ChangedRange.SetStyle(OrangeStyle, "\".+\"");
                e.ChangedRange.SetStyle(OrangeStyle, "\'.\'");
                e.ChangedRange.SetStyle(GreenStyle, "<!--.+-->");
                e.ChangedRange.SetStyle(GreenStyle, @"/*.+\*/");

                //e.ChangedRange.SetStyle(BlueStyle, @"(\s+(class|struct|var|new|enum|int|double|string|bool|char|float|void|public|private|protected)\s+)");
                //e.ChangedRange.SetStyle(BoldStyle, @"\b((class|struct|enum)|(int|double|string|bool|char|float|void))\s+(?<range>[\w_]+?)\b");
                //e.ChangedRange.SetStyle(GreenStyle, @"//.*$", RegexOptions.Multiline);
            }
        }
        void NewFileFunc()
        {
            OutRTB.Text = "";
            NewPageFunc("");
        }
        void SaveFunc()
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            //если во вкладке записан путь
            if (TabControl1.SelectedTab.ContextMenuStrip.Items[0].Text != "")
                try
                {
                    System.IO.File.WriteAllText(TabControl1.SelectedTab.ContextMenuStrip.Items[0].Text, TabControl1.SelectedTab.Controls[0].Text);
                    //убираем значок несохраненного файла
                    TabControl1.SelectedTab.Text = TabControl1.SelectedTab.Text.Replace("*", "");
                }
                catch
                {
                    //если что-то с путем то просим ввести его
                    SaveAs_Click(null, null);
                }
            //если пути нет(новый файл)
            else
                SaveAs_Click(null, null);
        }

        void CopyFunc()
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Copy();
        }
        void PasteFunc()
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Paste();
        }
        void CutFunc()
        {
            if (TabControl1.TabPages.Count == 0)
                return;
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
        //сохранить как
        private void SaveAs_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Count == 0)
                return;

            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            ToolStripMenuItem path = new ToolStripMenuItem(saveFileDialog1.FileName);
            // получаем выбранный файл
            TabControl1.SelectedTab.ContextMenuStrip.Items.Clear();
            TabControl1.SelectedTab.ContextMenuStrip.Items.AddRange(new[] { path });
            System.IO.File.WriteAllText(TabControl1.SelectedTab.ContextMenuStrip.Items[0].Text, TabControl1.SelectedTab.Controls[0].Text);
            TabControl1.SelectedTab.Text.Replace("*", "");
            //если файл был переименован
            string title = Path.GetFileName(Path.GetFileName(TabControl1.SelectedTab.ContextMenuStrip.Items[0].Text));
            if (title != TabControl1.SelectedTab.Text.Replace(" ", ""))
            {
                TabControl1.SelectedTab.Text = title + "     ";
            }
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
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.SelectedText = "";
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.SelectAll();
        }

        private void CancelButt_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Undo();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Undo();
        }

        private void RepeatButt_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Redo();
        }

        private void Repeat_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            FastColoredTextBoxNS.FastColoredTextBox InputRTB = (FastColoredTextBoxNS.FastColoredTextBox)TabControl1.SelectedTab.Controls[0];
            InputRTB.Redo();
        }

        private void HelpButt_Click(object sender, EventArgs e)
        {

            Info_Click(null, null);
        }

        private void Info_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=16"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AboutMe_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=21"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TabControl1_DrawItem(object sender, DrawItemEventArgs e)
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

        private void TabControl1_MouseDown(object sender, MouseEventArgs e)
        {
            // обрабатываем куда нажали мышкой
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
                //если нажали на крестик - закрываем
                if (imageRect.Contains(e.Location))
                {
                    //предлагаем сохранить
                    if (TabControl1.TabPages[i].Text[0] == '*')
                    {
                        DialogResult result = MessageBox.Show(
                            "Сохранить файл " + TabControl1.SelectedTab.Text.Replace("*", "").Replace(" ", "") + " перед закрытием?",
                            "Сообщение",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.DefaultDesktopOnly);
                        if (result == DialogResult.Yes)
                            SaveFunc();
                    }
                    this.TabControl1.TabPages.RemoveAt(i);
                    break;
                }
            }
        }

        private void CloseThisTab_Click(object sender, EventArgs e)
        {
            if (TabControl1.TabPages.Count == 0)
                return;
            //предлагаем сохранить
            if (TabControl1.SelectedTab.Text[0] == '*')
            {
                DialogResult result = MessageBox.Show(
                    "Сохранить файл " + TabControl1.SelectedTab.Text.Replace("*", "").Replace(" ", "") + " перед закрытием?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.DefaultDesktopOnly);
                if (result == DialogResult.Yes)
                    SaveFunc();
            }
            this.TabControl1.TabPages.RemoveAt(TabControl1.TabPages.IndexOf(TabControl1.SelectedTab));
        }

        private void StartButt_Click(object sender, EventArgs e)
        {
            Start_Click(null, null);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (TabControl1.SelectedTab == null)
            {
                MessageBox.Show("Не выбран файл для обработки", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var text = TabControl1.SelectedTab.Controls[0].Text.Split('\n');
                Scaner s;
                StateMachine stateMachine;
                List<Lexem> lexems = new List<Lexem>();
                OutRTB.Text = "";


                for (int j = 0; j < text.Length; j++)
                {

                    s = new Scaner(text[j]);
                    s.Scan();

                    int i = 0;
                    int stringNum = 0;
                    while (i < s.lexems.Count)
                    {
                        lexems.Clear();
                        for (; i < s.lexems.Count; i++)
                        {

                            if (s.lexems[i].Code != Codes.NewStr)
                                lexems.Add(s.lexems[i]);
                            else
                            {
                                i++;
                                break;
                            }
                        }
                        stringNum++;
                        if (lexems.Count >= 1)
                        {
                            if (lexems.Count == 1 && lexems[0].Code != Codes.NewStr)
                            {
                                stateMachine = new StateMachine(lexems, j + 1);
                                OutRTB.Text += stateMachine.Result;
                            }
                            else if (lexems.Count > 1)
                            {
                                stateMachine = new StateMachine(lexems, j + 1);
                                OutRTB.Text += stateMachine.Result;
                            }

                        }

                    }

                }
            }
             catch
            {
                OutRTB.Text = "Произошла неизвестная ошибка :(";
            }
        }

        private void ProblemStatement_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=5"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grammar_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=6"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GrammarClassification_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=7"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MethodOfAnalysis_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=8"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Diagnosis_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=10"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Example_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=11"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Liter_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=15"));
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Source_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo("Doc.pdf");
                Process.Start(new ProcessStartInfo("cmd", $"/c start microsoftedge file://" + fileInfo.FullName + "#page=23"));
                
            }
            catch
            {
                MessageBox.Show("Невозможно открыть справку :(", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
