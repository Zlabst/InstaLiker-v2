namespace InstaLiker.Forms
{
    partial class Statistic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Statistic));
            this.gvStats = new System.Windows.Forms.DataGridView();
            this.counter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvStats)).BeginInit();
            this.SuspendLayout();
            // 
            // gvStats
            // 
            this.gvStats.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.counter,
            this.datetime});
            this.gvStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvStats.Location = new System.Drawing.Point(0, 0);
            this.gvStats.Name = "gvStats";
            this.gvStats.ReadOnly = true;
            this.gvStats.Size = new System.Drawing.Size(362, 342);
            this.gvStats.TabIndex = 0;
            // 
            // counter
            // 
            this.counter.DataPropertyName = "step";
            this.counter.HeaderText = "Проход№";
            this.counter.Name = "counter";
            this.counter.ReadOnly = true;
            // 
            // datetime
            // 
            this.datetime.DataPropertyName = "datetime";
            this.datetime.HeaderText = "Время";
            this.datetime.Name = "datetime";
            this.datetime.ReadOnly = true;
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 342);
            this.Controls.Add(this.gvStats);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Statistics";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Статистика";
            ((System.ComponentModel.ISupportInitialize)(this.gvStats)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gvStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn counter;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetime;
    }
}