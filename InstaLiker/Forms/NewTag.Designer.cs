namespace InstaLiker.Forms
{
    partial class NewTag
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
            this.tbTagName = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnAddNewTag = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // tbTagName
            // 
            this.tbTagName.Depth = 0;
            this.tbTagName.Hint = "";
            this.tbTagName.Location = new System.Drawing.Point(13, 13);
            this.tbTagName.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbTagName.Name = "tbTagName";
            this.tbTagName.PasswordChar = '\0';
            this.tbTagName.SelectedText = "";
            this.tbTagName.SelectionLength = 0;
            this.tbTagName.SelectionStart = 0;
            this.tbTagName.Size = new System.Drawing.Size(172, 23);
            this.tbTagName.TabIndex = 0;
            this.tbTagName.UseSystemPasswordChar = false;
            // 
            // btnAddNewTag
            // 
            this.btnAddNewTag.AutoSize = true;
            this.btnAddNewTag.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddNewTag.Depth = 0;
            this.btnAddNewTag.Location = new System.Drawing.Point(53, 49);
            this.btnAddNewTag.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAddNewTag.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnAddNewTag.Name = "btnAddNewTag";
            this.btnAddNewTag.Primary = false;
            this.btnAddNewTag.Size = new System.Drawing.Size(85, 36);
            this.btnAddNewTag.TabIndex = 1;
            this.btnAddNewTag.Text = "Добавить";
            this.btnAddNewTag.UseVisualStyleBackColor = true;
            this.btnAddNewTag.Click += new System.EventHandler(this.btnAddNewTag_Click);
            // 
            // NewTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 100);
            this.Controls.Add(this.btnAddNewTag);
            this.Controls.Add(this.tbTagName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewTag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавление нового Тега";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField tbTagName;
        private MaterialSkin.Controls.MaterialFlatButton btnAddNewTag;
    }
}