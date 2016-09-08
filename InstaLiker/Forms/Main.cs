using System;
using System.ComponentModel;
using System.Windows.Forms;
using InstaLiker.Models;

namespace InstaLiker.Forms
{
    public partial class Main : Form, IMainView
    {
        private Facade _facade;

        public ISynchronizeInvoke MainThread
        {
            get { return this; }
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
           LoadData();
        }

        // загрузка данных отображающихся на форме
        private void LoadData()
        {
            _facade = new Facade(this, new DataContext());
            wcBrowser.Source = new Uri("https://www.instagram.com/accounts/login/");
            gvTags.DataSource = _facade.GetSourceTags;
        }

        // вызов настроек
        private void msiSettings_Click(object sender, EventArgs e)
        {
            var setFrm = new SettingsForm(_facade.GetSettMinWaitAfterLike, _facade.GetSettPeriodMinTimer);

            if (setFrm.ShowDialog() != DialogResult.OK)
                return;

            _facade.UpdateSettings(setFrm.GetSettMinWaitAfterLike, setFrm.GetSettPeriodMinTimer);
        }

        // добавление нового тега
        private void btnAddTag_Click(object sender, EventArgs e)
        {
            var tagFrm = new NewTag();

            if (tagFrm.ShowDialog() != DialogResult.OK)
                return;

            if (string.IsNullOrWhiteSpace(tagFrm.GetNewTagName))
                return;

            _facade.AddNewTag(tagFrm.GetNewTagName);
        }

        // удаление тега
        private void btnDelTag_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить выбранный тег?", Application.ProductName, MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            _facade.DeleteTag((int)gvTags.SelectedCells[0].Value);
        }
    }
}
