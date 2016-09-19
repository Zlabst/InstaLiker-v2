namespace InstaLiker.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.laytabMain = new System.Windows.Forms.TableLayoutPanel();
            this.laytabBrowser = new System.Windows.Forms.TableLayoutPanel();
            this.wcBrowser = new Awesomium.Windows.Forms.WebControl(this.components);
            this.lblStatusBar = new MaterialSkin.Controls.MaterialLabel();
            this.laytabData = new System.Windows.Forms.TableLayoutPanel();
            this.gvTags = new System.Windows.Forms.DataGridView();
            this.tagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TagId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countPerDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStart = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnStop = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnAddTag = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnDelTag = new MaterialSkin.Controls.MaterialRaisedButton();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.msiMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.msiSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.msiStats = new System.Windows.Forms.ToolStripMenuItem();
            this.laytabMain.SuspendLayout();
            this.laytabBrowser.SuspendLayout();
            this.laytabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvTags)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // laytabMain
            // 
            this.laytabMain.ColumnCount = 2;
            this.laytabMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.laytabMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.laytabMain.Controls.Add(this.laytabBrowser, 0, 1);
            this.laytabMain.Controls.Add(this.laytabData, 1, 1);
            this.laytabMain.Controls.Add(this.menu, 0, 0);
            this.laytabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laytabMain.Location = new System.Drawing.Point(0, 0);
            this.laytabMain.Name = "laytabMain";
            this.laytabMain.RowCount = 3;
            this.laytabMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.050505F));
            this.laytabMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.91919F));
            this.laytabMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.030303F));
            this.laytabMain.Size = new System.Drawing.Size(864, 494);
            this.laytabMain.TabIndex = 0;
            // 
            // laytabBrowser
            // 
            this.laytabBrowser.ColumnCount = 1;
            this.laytabBrowser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.laytabBrowser.Controls.Add(this.wcBrowser, 0, 0);
            this.laytabBrowser.Controls.Add(this.lblStatusBar, 0, 1);
            this.laytabBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laytabBrowser.Location = new System.Drawing.Point(3, 27);
            this.laytabBrowser.Name = "laytabBrowser";
            this.laytabBrowser.RowCount = 2;
            this.laytabBrowser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.laytabBrowser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.laytabBrowser.Size = new System.Drawing.Size(426, 448);
            this.laytabBrowser.TabIndex = 0;
            // 
            // wcBrowser
            // 
            this.wcBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wcBrowser.Location = new System.Drawing.Point(3, 3);
            this.wcBrowser.Size = new System.Drawing.Size(420, 397);
            this.wcBrowser.TabIndex = 0;
            this.wcBrowser.LoadingFrame += new Awesomium.Core.LoadingFrameEventHandler(this.Awesomium_Windows_Forms_WebControl_LoadingFrame);
            this.wcBrowser.LoadingFrameComplete += new Awesomium.Core.FrameEventHandler(this.Awesomium_Windows_Forms_WebControl_LoadingFrameComplete);
            // 
            // lblStatusBar
            // 
            this.lblStatusBar.AutoSize = true;
            this.lblStatusBar.Depth = 0;
            this.lblStatusBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatusBar.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblStatusBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblStatusBar.Location = new System.Drawing.Point(3, 403);
            this.lblStatusBar.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblStatusBar.Name = "lblStatusBar";
            this.lblStatusBar.Size = new System.Drawing.Size(420, 45);
            this.lblStatusBar.TabIndex = 1;
            this.lblStatusBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // laytabData
            // 
            this.laytabData.ColumnCount = 8;
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.72044F));
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.72043F));
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.72043F));
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.72043F));
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.72043F));
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.72043F));
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.72043F));
            this.laytabData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.956972F));
            this.laytabData.Controls.Add(this.gvTags, 1, 0);
            this.laytabData.Controls.Add(this.btnStart, 1, 14);
            this.laytabData.Controls.Add(this.btnStop, 4, 14);
            this.laytabData.Controls.Add(this.btnAddTag, 5, 12);
            this.laytabData.Controls.Add(this.btnDelTag, 6, 12);
            this.laytabData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.laytabData.Location = new System.Drawing.Point(435, 27);
            this.laytabData.Name = "laytabData";
            this.laytabData.RowCount = 15;
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.666668F));
            this.laytabData.Size = new System.Drawing.Size(426, 448);
            this.laytabData.TabIndex = 1;
            // 
            // gvTags
            // 
            this.gvTags.AllowUserToAddRows = false;
            this.gvTags.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvTags.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gvTags.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvTags.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTags.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gvTags.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tagName,
            this.TagId,
            this.countPerDate});
            this.laytabData.SetColumnSpan(this.gvTags, 6);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvTags.DefaultCellStyle = dataGridViewCellStyle5;
            this.gvTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvTags.Location = new System.Drawing.Point(61, 3);
            this.gvTags.MultiSelect = false;
            this.gvTags.Name = "gvTags";
            this.gvTags.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvTags.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gvTags.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.laytabData.SetRowSpan(this.gvTags, 12);
            this.gvTags.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvTags.Size = new System.Drawing.Size(342, 342);
            this.gvTags.TabIndex = 0;
            // 
            // tagName
            // 
            this.tagName.DataPropertyName = "tagName";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tagName.DefaultCellStyle = dataGridViewCellStyle3;
            this.tagName.HeaderText = "Тег";
            this.tagName.Name = "tagName";
            this.tagName.ReadOnly = true;
            // 
            // TagId
            // 
            this.TagId.DataPropertyName = "TagId";
            this.TagId.HeaderText = "TagId";
            this.TagId.Name = "TagId";
            this.TagId.ReadOnly = true;
            this.TagId.Visible = false;
            // 
            // countPerDate
            // 
            this.countPerDate.DataPropertyName = "countPerDate";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countPerDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.countPerDate.HeaderText = "Кол-во сегодня";
            this.countPerDate.Name = "countPerDate";
            this.countPerDate.ReadOnly = true;
            // 
            // btnStart
            // 
            this.laytabData.SetColumnSpan(this.btnStart, 3);
            this.btnStart.Depth = 0;
            this.btnStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStart.Location = new System.Drawing.Point(61, 409);
            this.btnStart.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStart.Name = "btnStart";
            this.btnStart.Primary = true;
            this.btnStart.Size = new System.Drawing.Size(168, 36);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.laytabData.SetColumnSpan(this.btnStop, 3);
            this.btnStop.Depth = 0;
            this.btnStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStop.Location = new System.Drawing.Point(235, 409);
            this.btnStop.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStop.Name = "btnStop";
            this.btnStop.Primary = true;
            this.btnStop.Size = new System.Drawing.Size(168, 36);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnAddTag
            // 
            this.btnAddTag.Depth = 0;
            this.btnAddTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAddTag.Location = new System.Drawing.Point(293, 351);
            this.btnAddTag.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddTag.Name = "btnAddTag";
            this.btnAddTag.Primary = true;
            this.btnAddTag.Size = new System.Drawing.Size(52, 23);
            this.btnAddTag.TabIndex = 5;
            this.btnAddTag.Text = "+";
            this.btnAddTag.UseVisualStyleBackColor = true;
            this.btnAddTag.Click += new System.EventHandler(this.btnAddTag_Click);
            // 
            // btnDelTag
            // 
            this.btnDelTag.Depth = 0;
            this.btnDelTag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDelTag.Location = new System.Drawing.Point(351, 351);
            this.btnDelTag.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDelTag.Name = "btnDelTag";
            this.btnDelTag.Primary = true;
            this.btnDelTag.Size = new System.Drawing.Size(52, 23);
            this.btnDelTag.TabIndex = 6;
            this.btnDelTag.Text = "-";
            this.btnDelTag.UseVisualStyleBackColor = true;
            this.btnDelTag.Click += new System.EventHandler(this.btnDelTag_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(432, 24);
            this.menu.TabIndex = 2;
            // 
            // msiMenu
            // 
            this.msiMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msiSettings,
            this.msiStats});
            this.msiMenu.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.msiMenu.Name = "msiMenu";
            this.msiMenu.Size = new System.Drawing.Size(52, 20);
            this.msiMenu.Text = "Меню";
            // 
            // msiSettings
            // 
            this.msiSettings.Image = global::InstaLiker.Properties.Resources.Settings1;
            this.msiSettings.Name = "msiSettings";
            this.msiSettings.Size = new System.Drawing.Size(136, 22);
            this.msiSettings.Text = "Настройки";
            this.msiSettings.Click += new System.EventHandler(this.msiSettings_Click);
            // 
            // msiStats
            // 
            this.msiStats.Name = "msiStats";
            this.msiStats.Size = new System.Drawing.Size(136, 22);
            this.msiStats.Text = "Статистика";
            this.msiStats.Click += new System.EventHandler(this.msiStats_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(864, 494);
            this.Controls.Add(this.laytabMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InstaLiker";
            this.Load += new System.EventHandler(this.Main_Load);
            this.laytabMain.ResumeLayout(false);
            this.laytabMain.PerformLayout();
            this.laytabBrowser.ResumeLayout(false);
            this.laytabBrowser.PerformLayout();
            this.laytabData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvTags)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel laytabMain;
        private System.Windows.Forms.TableLayoutPanel laytabBrowser;
        private Awesomium.Windows.Forms.WebControl wcBrowser;
        private MaterialSkin.Controls.MaterialLabel lblStatusBar;
        private System.Windows.Forms.TableLayoutPanel laytabData;
        private System.Windows.Forms.DataGridView gvTags;
        private MaterialSkin.Controls.MaterialRaisedButton btnStart;
        private MaterialSkin.Controls.MaterialRaisedButton btnStop;
        private MaterialSkin.Controls.MaterialRaisedButton btnAddTag;
        private MaterialSkin.Controls.MaterialRaisedButton btnDelTag;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TagId;
        private System.Windows.Forms.DataGridViewTextBoxColumn countPerDate;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem msiMenu;
        private System.Windows.Forms.ToolStripMenuItem msiSettings;
        private System.Windows.Forms.ToolStripMenuItem msiStats;
    }
}