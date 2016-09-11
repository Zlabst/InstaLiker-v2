namespace InstaLiker.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.lblWaitAfterLike = new MaterialSkin.Controls.MaterialLabel();
            this.numMinWaitAfterLike = new System.Windows.Forms.NumericUpDown();
            this.lblTimerPeriod = new MaterialSkin.Controls.MaterialLabel();
            this.numTimerMinPeriod = new System.Windows.Forms.NumericUpDown();
            this.btnSave = new MaterialSkin.Controls.MaterialFlatButton();
            ((System.ComponentModel.ISupportInitialize)(this.numMinWaitAfterLike)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerMinPeriod)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWaitAfterLike
            // 
            this.lblWaitAfterLike.AutoSize = true;
            this.lblWaitAfterLike.Depth = 0;
            this.lblWaitAfterLike.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblWaitAfterLike.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWaitAfterLike.Location = new System.Drawing.Point(13, 13);
            this.lblWaitAfterLike.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblWaitAfterLike.Name = "lblWaitAfterLike";
            this.lblWaitAfterLike.Size = new System.Drawing.Size(241, 19);
            this.lblWaitAfterLike.TabIndex = 0;
            this.lblWaitAfterLike.Text = "Интервал между лайками (мин.)";
            // 
            // numMinWaitAfterLike
            // 
            this.numMinWaitAfterLike.Location = new System.Drawing.Point(274, 12);
            this.numMinWaitAfterLike.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinWaitAfterLike.Name = "numMinWaitAfterLike";
            this.numMinWaitAfterLike.Size = new System.Drawing.Size(61, 20);
            this.numMinWaitAfterLike.TabIndex = 1;
            this.numMinWaitAfterLike.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblTimerPeriod
            // 
            this.lblTimerPeriod.AutoSize = true;
            this.lblTimerPeriod.Depth = 0;
            this.lblTimerPeriod.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblTimerPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTimerPeriod.Location = new System.Drawing.Point(12, 32);
            this.lblTimerPeriod.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTimerPeriod.Name = "lblTimerPeriod";
            this.lblTimerPeriod.Size = new System.Drawing.Size(192, 19);
            this.lblTimerPeriod.TabIndex = 2;
            this.lblTimerPeriod.Text = "Повтор процедуры (мин.)";
            // 
            // numTimerMinPeriod
            // 
            this.numTimerMinPeriod.Location = new System.Drawing.Point(274, 34);
            this.numTimerMinPeriod.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimerMinPeriod.Name = "numTimerMinPeriod";
            this.numTimerMinPeriod.Size = new System.Drawing.Size(61, 20);
            this.numTimerMinPeriod.TabIndex = 3;
            this.numTimerMinPeriod.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(241, 63);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = false;
            this.btnSave.Size = new System.Drawing.Size(93, 36);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 103);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.numTimerMinPeriod);
            this.Controls.Add(this.lblTimerPeriod);
            this.Controls.Add(this.numMinWaitAfterLike);
            this.Controls.Add(this.lblWaitAfterLike);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            ((System.ComponentModel.ISupportInitialize)(this.numMinWaitAfterLike)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerMinPeriod)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lblWaitAfterLike;
        private System.Windows.Forms.NumericUpDown numMinWaitAfterLike;
        private MaterialSkin.Controls.MaterialLabel lblTimerPeriod;
        private System.Windows.Forms.NumericUpDown numTimerMinPeriod;
        private MaterialSkin.Controls.MaterialFlatButton btnSave;
    }
}