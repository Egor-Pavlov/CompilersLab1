namespace CompilersLab1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.New = new System.Windows.Forms.ToolStripMenuItem();
            this.Open = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseThisTab = new System.Windows.Forms.ToolStripMenuItem();
            this.Save = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Change = new System.Windows.Forms.ToolStripDropDownButton();
            this.Cancel = new System.Windows.Forms.ToolStripMenuItem();
            this.Repeat = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.Push = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TextBttn = new System.Windows.Forms.ToolStripDropDownButton();
            this.ProblemStatement = new System.Windows.Forms.ToolStripMenuItem();
            this.Grammar = new System.Windows.Forms.ToolStripMenuItem();
            this.GrammarClassification = new System.Windows.Forms.ToolStripMenuItem();
            this.MethodOfAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.Diagnosis = new System.Windows.Forms.ToolStripMenuItem();
            this.Example = new System.Windows.Forms.ToolStripMenuItem();
            this.Liter = new System.Windows.Forms.ToolStripMenuItem();
            this.Source = new System.Windows.Forms.ToolStripMenuItem();
            this.Start = new System.Windows.Forms.ToolStripButton();
            this.Help = new System.Windows.Forms.ToolStripDropDownButton();
            this.Info = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutMe = new System.Windows.Forms.ToolStripMenuItem();
            this.StartButt = new System.Windows.Forms.Button();
            this.PasteButt = new System.Windows.Forms.Button();
            this.CopyButt = new System.Windows.Forms.Button();
            this.CutButt = new System.Windows.Forms.Button();
            this.RepeatButt = new System.Windows.Forms.Button();
            this.CancelButt = new System.Windows.Forms.Button();
            this.SaveButt = new System.Windows.Forms.Button();
            this.OpenButt = new System.Windows.Forms.Button();
            this.NewButt = new System.Windows.Forms.Button();
            this.HelpButt = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.label2 = new System.Windows.Forms.Label();
            this.OutRTB = new System.Windows.Forms.RichTextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.Change,
            this.TextBttn,
            this.Start,
            this.Help});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(899, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New,
            this.Open,
            this.CloseThisTab,
            this.Save,
            this.SaveAs,
            this.Exit});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(74, 32);
            this.toolStripDropDownButton1.Text = "Файл";
            // 
            // New
            // 
            this.New.Name = "New";
            this.New.Size = new System.Drawing.Size(230, 32);
            this.New.Text = "Создать";
            this.New.Click += new System.EventHandler(this.New_Click);
            // 
            // Open
            // 
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(230, 32);
            this.Open.Text = "Открыть";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // CloseThisTab
            // 
            this.CloseThisTab.Name = "CloseThisTab";
            this.CloseThisTab.Size = new System.Drawing.Size(230, 32);
            this.CloseThisTab.Text = "Закрыть";
            this.CloseThisTab.Click += new System.EventHandler(this.CloseThisTab_Click);
            // 
            // Save
            // 
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(230, 32);
            this.Save.Text = "Сохранить";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SaveAs
            // 
            this.SaveAs.Name = "SaveAs";
            this.SaveAs.Size = new System.Drawing.Size(230, 32);
            this.SaveAs.Text = "Сохранить как";
            this.SaveAs.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(230, 32);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Change
            // 
            this.Change.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Change.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cancel,
            this.Repeat,
            this.Copy,
            this.Cut,
            this.Push,
            this.Delete,
            this.SelectAll});
            this.Change.Image = ((System.Drawing.Image)(resources.GetObject("Change.Image")));
            this.Change.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Change.Name = "Change";
            this.Change.Size = new System.Drawing.Size(93, 32);
            this.Change.Text = "Правка";
            // 
            // Cancel
            // 
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(225, 32);
            this.Cancel.Text = "Отменить";
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Repeat
            // 
            this.Repeat.Name = "Repeat";
            this.Repeat.Size = new System.Drawing.Size(225, 32);
            this.Repeat.Text = "Повторить";
            this.Repeat.Click += new System.EventHandler(this.Repeat_Click);
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(225, 32);
            this.Copy.Text = "Копировать";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Cut
            // 
            this.Cut.Name = "Cut";
            this.Cut.Size = new System.Drawing.Size(225, 32);
            this.Cut.Text = "Вырезать";
            this.Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // Push
            // 
            this.Push.Name = "Push";
            this.Push.Size = new System.Drawing.Size(225, 32);
            this.Push.Text = "Вставить";
            this.Push.Click += new System.EventHandler(this.Push_Click);
            // 
            // Delete
            // 
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(225, 32);
            this.Delete.Text = "Удалить";
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // SelectAll
            // 
            this.SelectAll.Name = "SelectAll";
            this.SelectAll.Size = new System.Drawing.Size(225, 32);
            this.SelectAll.Text = "Выделить все ";
            this.SelectAll.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // TextBttn
            // 
            this.TextBttn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TextBttn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProblemStatement,
            this.Grammar,
            this.GrammarClassification,
            this.MethodOfAnalysis,
            this.Diagnosis,
            this.Example,
            this.Liter,
            this.Source});
            this.TextBttn.Image = ((System.Drawing.Image)(resources.GetObject("TextBttn.Image")));
            this.TextBttn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TextBttn.Name = "TextBttn";
            this.TextBttn.Size = new System.Drawing.Size(73, 32);
            this.TextBttn.Text = "Текст";
            // 
            // ProblemStatement
            // 
            this.ProblemStatement.Name = "ProblemStatement";
            this.ProblemStatement.Size = new System.Drawing.Size(456, 32);
            this.ProblemStatement.Text = "Постановка задачи";
            this.ProblemStatement.Click += new System.EventHandler(this.ProblemStatement_Click);
            // 
            // Grammar
            // 
            this.Grammar.Name = "Grammar";
            this.Grammar.Size = new System.Drawing.Size(456, 32);
            this.Grammar.Text = "Грамматика";
            this.Grammar.Click += new System.EventHandler(this.Grammar_Click);
            // 
            // GrammarClassification
            // 
            this.GrammarClassification.Name = "GrammarClassification";
            this.GrammarClassification.Size = new System.Drawing.Size(456, 32);
            this.GrammarClassification.Text = "Классификация грамматики";
            this.GrammarClassification.Click += new System.EventHandler(this.GrammarClassification_Click);
            // 
            // MethodOfAnalysis
            // 
            this.MethodOfAnalysis.Name = "MethodOfAnalysis";
            this.MethodOfAnalysis.Size = new System.Drawing.Size(456, 32);
            this.MethodOfAnalysis.Text = "Метод анализа";
            this.MethodOfAnalysis.Click += new System.EventHandler(this.MethodOfAnalysis_Click);
            // 
            // Diagnosis
            // 
            this.Diagnosis.Name = "Diagnosis";
            this.Diagnosis.Size = new System.Drawing.Size(456, 32);
            this.Diagnosis.Text = "Диагностика и нейтрализация ошибок";
            this.Diagnosis.Click += new System.EventHandler(this.Diagnosis_Click);
            // 
            // Example
            // 
            this.Example.Name = "Example";
            this.Example.Size = new System.Drawing.Size(456, 32);
            this.Example.Text = "Тестовый пример";
            this.Example.Click += new System.EventHandler(this.Example_Click);
            // 
            // Liter
            // 
            this.Liter.Name = "Liter";
            this.Liter.Size = new System.Drawing.Size(456, 32);
            this.Liter.Text = "Список литературы";
            this.Liter.Click += new System.EventHandler(this.Liter_Click);
            // 
            // Source
            // 
            this.Source.Name = "Source";
            this.Source.Size = new System.Drawing.Size(456, 32);
            this.Source.Text = "Исходный код программы";
            this.Source.Click += new System.EventHandler(this.Source_Click);
            // 
            // Start
            // 
            this.Start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Start.Image = ((System.Drawing.Image)(resources.GetObject("Start.Image")));
            this.Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(59, 32);
            this.Start.Text = "Пуcк";
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Help
            // 
            this.Help.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Info,
            this.AboutMe});
            this.Help.Image = ((System.Drawing.Image)(resources.GetObject("Help.Image")));
            this.Help.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Help.Name = "Help";
            this.Help.Size = new System.Drawing.Size(104, 32);
            this.Help.Text = "Помощь";
            // 
            // Info
            // 
            this.Info.Name = "Info";
            this.Info.Size = new System.Drawing.Size(222, 32);
            this.Info.Text = "Справка";
            this.Info.Click += new System.EventHandler(this.Info_Click);
            // 
            // AboutMe
            // 
            this.AboutMe.Name = "AboutMe";
            this.AboutMe.Size = new System.Drawing.Size(222, 32);
            this.AboutMe.Text = "О программе";
            this.AboutMe.Click += new System.EventHandler(this.AboutMe_Click);
            // 
            // StartButt
            // 
            this.StartButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.StartButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StartButt.Image = global::CompilersLab1.Properties.Resources.start4;
            this.StartButt.Location = new System.Drawing.Point(709, 31);
            this.StartButt.Margin = new System.Windows.Forms.Padding(4);
            this.StartButt.Name = "StartButt";
            this.StartButt.Size = new System.Drawing.Size(72, 60);
            this.StartButt.TabIndex = 13;
            this.StartButt.UseVisualStyleBackColor = false;
            this.StartButt.Click += new System.EventHandler(this.StartButt_Click);
            // 
            // PasteButt
            // 
            this.PasteButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.PasteButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PasteButt.Image = global::CompilersLab1.Properties.Resources.Paste;
            this.PasteButt.Location = new System.Drawing.Point(629, 31);
            this.PasteButt.Margin = new System.Windows.Forms.Padding(4);
            this.PasteButt.Name = "PasteButt";
            this.PasteButt.Size = new System.Drawing.Size(72, 60);
            this.PasteButt.TabIndex = 12;
            this.PasteButt.UseVisualStyleBackColor = false;
            this.PasteButt.Click += new System.EventHandler(this.PasteButt_Click);
            // 
            // CopyButt
            // 
            this.CopyButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CopyButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyButt.Image = global::CompilersLab1.Properties.Resources.Copy;
            this.CopyButt.Location = new System.Drawing.Point(549, 31);
            this.CopyButt.Margin = new System.Windows.Forms.Padding(4);
            this.CopyButt.Name = "CopyButt";
            this.CopyButt.Size = new System.Drawing.Size(72, 60);
            this.CopyButt.TabIndex = 11;
            this.CopyButt.UseVisualStyleBackColor = false;
            this.CopyButt.Click += new System.EventHandler(this.CopyButt_Click);
            // 
            // CutButt
            // 
            this.CutButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CutButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CutButt.Image = global::CompilersLab1.Properties.Resources.Cut;
            this.CutButt.Location = new System.Drawing.Point(469, 31);
            this.CutButt.Margin = new System.Windows.Forms.Padding(4);
            this.CutButt.Name = "CutButt";
            this.CutButt.Size = new System.Drawing.Size(72, 60);
            this.CutButt.TabIndex = 10;
            this.CutButt.UseVisualStyleBackColor = false;
            this.CutButt.Click += new System.EventHandler(this.CutButt_Click);
            // 
            // RepeatButt
            // 
            this.RepeatButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.RepeatButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RepeatButt.Image = global::CompilersLab1.Properties.Resources.Redo;
            this.RepeatButt.Location = new System.Drawing.Point(389, 31);
            this.RepeatButt.Margin = new System.Windows.Forms.Padding(4);
            this.RepeatButt.Name = "RepeatButt";
            this.RepeatButt.Size = new System.Drawing.Size(72, 60);
            this.RepeatButt.TabIndex = 9;
            this.RepeatButt.UseVisualStyleBackColor = false;
            this.RepeatButt.Click += new System.EventHandler(this.RepeatButt_Click);
            // 
            // CancelButt
            // 
            this.CancelButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.CancelButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButt.Image = global::CompilersLab1.Properties.Resources.Undo;
            this.CancelButt.Location = new System.Drawing.Point(309, 31);
            this.CancelButt.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButt.Name = "CancelButt";
            this.CancelButt.Size = new System.Drawing.Size(72, 60);
            this.CancelButt.TabIndex = 8;
            this.CancelButt.UseVisualStyleBackColor = false;
            this.CancelButt.Click += new System.EventHandler(this.CancelButt_Click);
            // 
            // SaveButt
            // 
            this.SaveButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.SaveButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveButt.Image = global::CompilersLab1.Properties.Resources.Save;
            this.SaveButt.Location = new System.Drawing.Point(177, 31);
            this.SaveButt.Margin = new System.Windows.Forms.Padding(4);
            this.SaveButt.Name = "SaveButt";
            this.SaveButt.Size = new System.Drawing.Size(72, 60);
            this.SaveButt.TabIndex = 7;
            this.SaveButt.UseVisualStyleBackColor = false;
            this.SaveButt.Click += new System.EventHandler(this.SaveButt_Click);
            // 
            // OpenButt
            // 
            this.OpenButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OpenButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenButt.Image = global::CompilersLab1.Properties.Resources.Open;
            this.OpenButt.Location = new System.Drawing.Point(87, 31);
            this.OpenButt.Margin = new System.Windows.Forms.Padding(4);
            this.OpenButt.Name = "OpenButt";
            this.OpenButt.Size = new System.Drawing.Size(83, 60);
            this.OpenButt.TabIndex = 6;
            this.OpenButt.UseVisualStyleBackColor = false;
            this.OpenButt.Click += new System.EventHandler(this.OpenButt_Click);
            // 
            // NewButt
            // 
            this.NewButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.NewButt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NewButt.Image = global::CompilersLab1.Properties.Resources.New;
            this.NewButt.Location = new System.Drawing.Point(16, 31);
            this.NewButt.Margin = new System.Windows.Forms.Padding(4);
            this.NewButt.Name = "NewButt";
            this.NewButt.Size = new System.Drawing.Size(63, 60);
            this.NewButt.TabIndex = 5;
            this.NewButt.UseVisualStyleBackColor = false;
            this.NewButt.Click += new System.EventHandler(this.NewButt_Click);
            // 
            // HelpButt
            // 
            this.HelpButt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.HelpButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HelpButt.Image = global::CompilersLab1.Properties.Resources.Help;
            this.HelpButt.Location = new System.Drawing.Point(789, 31);
            this.HelpButt.Margin = new System.Windows.Forms.Padding(4);
            this.HelpButt.Name = "HelpButt";
            this.HelpButt.Size = new System.Drawing.Size(72, 60);
            this.HelpButt.TabIndex = 14;
            this.HelpButt.UseVisualStyleBackColor = false;
            this.HelpButt.Click += new System.EventHandler(this.HelpButt_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 98);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.OutRTB);
            this.splitContainer1.Size = new System.Drawing.Size(875, 698);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.TabIndex = 15;
            // 
            // TabControl1
            // 
            this.TabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabControl1.Location = new System.Drawing.Point(4, 3);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(862, 468);
            this.TabControl1.TabIndex = 23;
            this.TabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl1_DrawItem);
            this.TabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TabControl1_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 25);
            this.label2.TabIndex = 23;
            this.label2.Text = "Результат:";
            // 
            // OutRTB
            // 
            this.OutRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutRTB.Location = new System.Drawing.Point(4, 38);
            this.OutRTB.Margin = new System.Windows.Forms.Padding(4);
            this.OutRTB.Name = "OutRTB";
            this.OutRTB.ReadOnly = true;
            this.OutRTB.Size = new System.Drawing.Size(862, 178);
            this.OutRTB.TabIndex = 21;
            this.OutRTB.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(899, 808);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.HelpButt);
            this.Controls.Add(this.StartButt);
            this.Controls.Add(this.PasteButt);
            this.Controls.Add(this.CopyButt);
            this.Controls.Add(this.CutButt);
            this.Controls.Add(this.RepeatButt);
            this.Controls.Add(this.CancelButt);
            this.Controls.Add(this.SaveButt);
            this.Controls.Add(this.OpenButt);
            this.Controls.Add(this.NewButt);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(906, 591);
            this.Name = "Form1";
            this.Text = "Компилятор";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem New;
        private System.Windows.Forms.ToolStripMenuItem Open;
        private System.Windows.Forms.ToolStripMenuItem SaveAs;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.ToolStripDropDownButton Change;
        private System.Windows.Forms.ToolStripMenuItem Cancel;
        private System.Windows.Forms.ToolStripMenuItem Repeat;
        private System.Windows.Forms.ToolStripDropDownButton TextBttn;
        private System.Windows.Forms.ToolStripButton Start;
        private System.Windows.Forms.ToolStripMenuItem Cut;
        private System.Windows.Forms.ToolStripMenuItem Push;
        private System.Windows.Forms.ToolStripMenuItem Delete;
        private System.Windows.Forms.ToolStripMenuItem SelectAll;
        private System.Windows.Forms.ToolStripMenuItem ProblemStatement;
        private System.Windows.Forms.ToolStripMenuItem Grammar;
        private System.Windows.Forms.ToolStripMenuItem GrammarClassification;
        private System.Windows.Forms.ToolStripMenuItem MethodOfAnalysis;
        private System.Windows.Forms.ToolStripMenuItem Diagnosis;
        private System.Windows.Forms.ToolStripMenuItem Example;
        private System.Windows.Forms.ToolStripMenuItem Liter;
        private System.Windows.Forms.ToolStripMenuItem Source;
        private System.Windows.Forms.ToolStripDropDownButton Help;
        private System.Windows.Forms.ToolStripMenuItem Info;
        private System.Windows.Forms.ToolStripMenuItem AboutMe;
        private System.Windows.Forms.Button NewButt;
        private System.Windows.Forms.Button OpenButt;
        private System.Windows.Forms.Button SaveButt;
        private System.Windows.Forms.Button CancelButt;
        private System.Windows.Forms.Button RepeatButt;
        private System.Windows.Forms.Button CutButt;
        private System.Windows.Forms.Button CopyButt;
        private System.Windows.Forms.Button PasteButt;
        private System.Windows.Forms.Button StartButt;
        private System.Windows.Forms.Button HelpButt;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem Save;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox OutRTB;
        private System.Windows.Forms.TabControl TabControl1;
        private System.Windows.Forms.ToolStripMenuItem CloseThisTab;
    }
}

