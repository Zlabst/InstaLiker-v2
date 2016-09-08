using System;
using System.Windows.Forms;

namespace InstaLiker.Forms
{
    public partial class NewTag : Form
    {
        public string GetNewTagName
        {
            get { return tbTagName.Text; }
        }

        public NewTag()
        {
            InitializeComponent();
        }

        private void btnAddNewTag_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
