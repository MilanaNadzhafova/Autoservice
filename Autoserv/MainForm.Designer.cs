
namespace Autoserv
{
    partial class MainForm
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
            this.MainPanel = new System.Windows.Forms.Panel();
            this.BtnChange = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.DelClient = new System.Windows.Forms.Button();
            this.CheckBirthday = new System.Windows.Forms.CheckBox();
            this.CmbSort = new System.Windows.Forms.ComboBox();
            this.SearchLab = new System.Windows.Forms.Label();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.GenderFilterLab = new System.Windows.Forms.Label();
            this.PageFilterLab = new System.Windows.Forms.Label();
            this.CmbGenderFilter = new System.Windows.Forms.ComboBox();
            this.CmbPagesCount = new System.Windows.Forms.ComboBox();
            this.PageLab = new System.Windows.Forms.Label();
            this.BtnNextPage = new System.Windows.Forms.Button();
            this.BtnPreviosPage = new System.Windows.Forms.Button();
            this.ClientTable = new System.Windows.Forms.DataGridView();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTable)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.MainPanel.Controls.Add(this.BtnChange);
            this.MainPanel.Controls.Add(this.AddBtn);
            this.MainPanel.Controls.Add(this.DelClient);
            this.MainPanel.Controls.Add(this.CheckBirthday);
            this.MainPanel.Controls.Add(this.CmbSort);
            this.MainPanel.Controls.Add(this.SearchLab);
            this.MainPanel.Controls.Add(this.TxtSearch);
            this.MainPanel.Controls.Add(this.GenderFilterLab);
            this.MainPanel.Controls.Add(this.PageFilterLab);
            this.MainPanel.Controls.Add(this.CmbGenderFilter);
            this.MainPanel.Controls.Add(this.CmbPagesCount);
            this.MainPanel.Controls.Add(this.PageLab);
            this.MainPanel.Controls.Add(this.BtnNextPage);
            this.MainPanel.Controls.Add(this.BtnPreviosPage);
            this.MainPanel.Controls.Add(this.ClientTable);
            this.MainPanel.Controls.Add(this.BottomPanel);
            this.MainPanel.Controls.Add(this.TopPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1083, 506);
            this.MainPanel.TabIndex = 0;
            // 
            // BtnChange
            // 
            this.BtnChange.Location = new System.Drawing.Point(272, 64);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(111, 29);
            this.BtnChange.TabIndex = 24;
            this.BtnChange.Text = "Изменить";
            this.BtnChange.UseVisualStyleBackColor = true;
            this.BtnChange.Click += new System.EventHandler(this.BtnChange_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(19, 64);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(111, 29);
            this.AddBtn.TabIndex = 23;
            this.AddBtn.Text = "Добавить";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DelClient
            // 
            this.DelClient.Location = new System.Drawing.Point(147, 64);
            this.DelClient.Name = "DelClient";
            this.DelClient.Size = new System.Drawing.Size(111, 29);
            this.DelClient.TabIndex = 22;
            this.DelClient.Text = "Удалить";
            this.DelClient.UseVisualStyleBackColor = true;
            this.DelClient.Click += new System.EventHandler(this.DelClient_Click);
            // 
            // CheckBirthday
            // 
            this.CheckBirthday.AutoSize = true;
            this.CheckBirthday.Location = new System.Drawing.Point(592, 400);
            this.CheckBirthday.Name = "CheckBirthday";
            this.CheckBirthday.Size = new System.Drawing.Size(161, 26);
            this.CheckBirthday.TabIndex = 21;
            this.CheckBirthday.Text = "День рождение";
            this.CheckBirthday.UseVisualStyleBackColor = true;
            this.CheckBirthday.CheckedChanged += new System.EventHandler(this.CheckBirthday_CheckedChanged);
            // 
            // CmbSort
            // 
            this.CmbSort.AutoCompleteCustomSource.AddRange(new string[] {
            "10",
            "50",
            "200",
            "Все"});
            this.CmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSort.FormattingEnabled = true;
            this.CmbSort.Items.AddRange(new object[] {
            "Без сортировки",
            "По фамилии",
            "По количеству посещений",
            "По дате последнего посещения"});
            this.CmbSort.Location = new System.Drawing.Point(795, 398);
            this.CmbSort.Margin = new System.Windows.Forms.Padding(4);
            this.CmbSort.Name = "CmbSort";
            this.CmbSort.Size = new System.Drawing.Size(276, 30);
            this.CmbSort.TabIndex = 18;
            this.CmbSort.SelectedIndexChanged += new System.EventHandler(this.CmbSortDate_SelectedIndexChanged);
            // 
            // SearchLab
            // 
            this.SearchLab.AutoSize = true;
            this.SearchLab.Location = new System.Drawing.Point(389, 64);
            this.SearchLab.Name = "SearchLab";
            this.SearchLab.Size = new System.Drawing.Size(67, 22);
            this.SearchLab.TabIndex = 16;
            this.SearchLab.Text = "Поиск:";
            // 
            // TxtSearch
            // 
            this.TxtSearch.Location = new System.Drawing.Point(462, 61);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(236, 30);
            this.TxtSearch.TabIndex = 15;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // GenderFilterLab
            // 
            this.GenderFilterLab.AutoSize = true;
            this.GenderFilterLab.Location = new System.Drawing.Point(8, 402);
            this.GenderFilterLab.Name = "GenderFilterLab";
            this.GenderFilterLab.Size = new System.Drawing.Size(49, 22);
            this.GenderFilterLab.TabIndex = 14;
            this.GenderFilterLab.Text = "Пол:";
            // 
            // PageFilterLab
            // 
            this.PageFilterLab.AutoSize = true;
            this.PageFilterLab.Location = new System.Drawing.Point(717, 64);
            this.PageFilterLab.Name = "PageFilterLab";
            this.PageFilterLab.Size = new System.Drawing.Size(190, 22);
            this.PageFilterLab.TabIndex = 13;
            this.PageFilterLab.Text = "Количество страниц:";
            // 
            // CmbGenderFilter
            // 
            this.CmbGenderFilter.AutoCompleteCustomSource.AddRange(new string[] {
            "Все",
            "М",
            "Ж"});
            this.CmbGenderFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbGenderFilter.FormattingEnabled = true;
            this.CmbGenderFilter.Items.AddRange(new object[] {
            "Все",
            "М",
            "Ж"});
            this.CmbGenderFilter.Location = new System.Drawing.Point(75, 399);
            this.CmbGenderFilter.Margin = new System.Windows.Forms.Padding(4);
            this.CmbGenderFilter.Name = "CmbGenderFilter";
            this.CmbGenderFilter.Size = new System.Drawing.Size(160, 30);
            this.CmbGenderFilter.TabIndex = 12;
            this.CmbGenderFilter.SelectedIndexChanged += new System.EventHandler(this.CmbGenderFilter_SelectedIndexChanged);
            // 
            // CmbPagesCount
            // 
            this.CmbPagesCount.AutoCompleteCustomSource.AddRange(new string[] {
            "10",
            "50",
            "200",
            "Все"});
            this.CmbPagesCount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPagesCount.FormattingEnabled = true;
            this.CmbPagesCount.Items.AddRange(new object[] {
            "Все",
            "10",
            "30",
            "200"});
            this.CmbPagesCount.Location = new System.Drawing.Point(911, 61);
            this.CmbPagesCount.Margin = new System.Windows.Forms.Padding(4);
            this.CmbPagesCount.Name = "CmbPagesCount";
            this.CmbPagesCount.Size = new System.Drawing.Size(160, 30);
            this.CmbPagesCount.TabIndex = 11;
            this.CmbPagesCount.SelectedIndexChanged += new System.EventHandler(this.CmbPagesCount_SelectedIndexChanged);
            // 
            // PageLab
            // 
            this.PageLab.AutoSize = true;
            this.PageLab.Location = new System.Drawing.Point(444, 402);
            this.PageLab.Name = "PageLab";
            this.PageLab.Size = new System.Drawing.Size(32, 22);
            this.PageLab.TabIndex = 5;
            this.PageLab.Text = "10";
            // 
            // BtnNextPage
            // 
            this.BtnNextPage.Location = new System.Drawing.Point(373, 399);
            this.BtnNextPage.Name = "BtnNextPage";
            this.BtnNextPage.Size = new System.Drawing.Size(53, 27);
            this.BtnNextPage.TabIndex = 4;
            this.BtnNextPage.Text = ">";
            this.BtnNextPage.UseVisualStyleBackColor = true;
            this.BtnNextPage.Click += new System.EventHandler(this.BtnNextPage_Click);
            // 
            // BtnPreviosPage
            // 
            this.BtnPreviosPage.Location = new System.Drawing.Point(314, 399);
            this.BtnPreviosPage.Name = "BtnPreviosPage";
            this.BtnPreviosPage.Size = new System.Drawing.Size(53, 27);
            this.BtnPreviosPage.TabIndex = 3;
            this.BtnPreviosPage.Text = "<";
            this.BtnPreviosPage.UseVisualStyleBackColor = true;
            this.BtnPreviosPage.Click += new System.EventHandler(this.BtnPreviosPage_Click);
            // 
            // ClientTable
            // 
            this.ClientTable.AllowUserToAddRows = false;
            this.ClientTable.AllowUserToDeleteRows = false;
            this.ClientTable.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ClientTable.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientTable.Location = new System.Drawing.Point(16, 98);
            this.ClientTable.Name = "ClientTable";
            this.ClientTable.ReadOnly = true;
            this.ClientTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ClientTable.Size = new System.Drawing.Size(1055, 269);
            this.ClientTable.TabIndex = 2;
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 456);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(1083, 50);
            this.BottomPanel.TabIndex = 1;
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TopPanel.Controls.Add(this.BtnExit);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1083, 54);
            this.TopPanel.TabIndex = 0;
            // 
            // BtnExit
            // 
            this.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExit.Location = new System.Drawing.Point(1038, 12);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(33, 32);
            this.BtnExit.TabIndex = 1;
            this.BtnExit.Text = "X";
            this.BtnExit.UseVisualStyleBackColor = true;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 506);
            this.ControlBox = false;
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ClientTable)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.DataGridView ClientTable;
        private System.Windows.Forms.Label PageLab;
        private System.Windows.Forms.Button BtnNextPage;
        private System.Windows.Forms.Button BtnPreviosPage;
        private System.Windows.Forms.ComboBox CmbPagesCount;
        private System.Windows.Forms.Label GenderFilterLab;
        private System.Windows.Forms.Label PageFilterLab;
        private System.Windows.Forms.ComboBox CmbGenderFilter;
        private System.Windows.Forms.Label SearchLab;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.ComboBox CmbSort;
        private System.Windows.Forms.CheckBox CheckBirthday;
        private System.Windows.Forms.Button DelClient;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button BtnChange;
    }
}

