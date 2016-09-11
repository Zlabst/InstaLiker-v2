using System;
using System.Data;
using System.Windows.Forms;
using InstaLiker.Models;

namespace InstaLiker.Forms
{
    public partial class Main : Form, IMainView
    {
        private Facade _facade;

        public Main()
        {
            InitializeComponent();
        }

        public void NavigateToPage(Uri uriTag, out string htmlBody)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => { wcBrowser.Source = uriTag; }));
            }
            else
                wcBrowser.Source = uriTag;

            WaitLoading();

            htmlBody = GetStringHtmlDoc();
        }

        public void ChangeStatus(string message)
        {
            if (InvokeRequired)
                Invoke(new Action(() => { lblStatusBar.Text = message; }));
            else
                lblStatusBar.Text = message;
        }

        public void RefreshBrowser()
        {
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    wcBrowser.Reload(true);
                    WaitLoading();
                }));
            else
            {
                wcBrowser.Reload(true);
                WaitLoading();
            }
        }

        public void GetHtmlDocument(out string htmlDocument)
        {
            htmlDocument = GetStringHtmlDoc();
        }

        // проставление лайка
        public void PressLike(int tagId)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    WaitLoading();
                    wcBrowser.ExecuteJavascript("document.querySelector('a._ebwb5._1tv0k').click()");
                    UpdateSourceTab(tagId);
                }));
            }
            else
            {
                WaitLoading();
                wcBrowser.ExecuteJavascript("document.querySelector('a._ebwb5._1tv0k').click()");
                UpdateSourceTab(tagId);
            }
        }

        public void EnableCtrls(bool state)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    btnStart.Visible = !state;
                    btnStop.Visible = state;
                }));
            }
            else
            {
                btnStart.Visible = !state;
                btnStop.Visible = state;
            }
        }

        // загрузка формы
        private void Main_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        // загрузка данных отображающихся на форме
        private void LoadData()
        {
            _facade = new Facade(this, new DataContext());
            gvTags.DataSource = _facade.GetSourceTags;
            wcBrowser.Source = new Uri("https://www.instagram.com/accounts/login/");
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

            _facade.DeleteTag((int) gvTags.SelectedCells[0].Value);
        }

        // старт процедуры
        private void btnStart_Click(object sender, EventArgs e)
        {
            _facade.StartParser();
        }

        // остановка процедуры
        private void btnStop_Click(object sender, EventArgs e)
        {
            EnableCtrls(false);
            _facade.StopParser();
        }

        // обновление таблицы с данными
        private void UpdateSourceTab(int tagId)
        {
            var row = ((DataTable) gvTags.DataSource).Rows.Find(tagId);

            if (row["CountPerDate"] == DBNull.Value)
                row["CountPerDate"] = 1;
            else
                row["CountPerDate"] = (int) row["CountPerDate"] + 1;
        }

        // ожидание загрузки страницы
        private void WaitLoading()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    while (wcBrowser.IsLoading)
                        Application.DoEvents();
                }));
            }
            else
                while (wcBrowser.IsLoading)
                    Application.DoEvents();
        }

        // формирование нового HtmlDocument
        private string GetStringHtmlDoc()
        {
            string result = null;

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    WaitLoading();
                    result = wcBrowser.ExecuteJavascriptWithResult("document.getElementsByTagName('html')[0].outerHTML");
                }));
            }
            else
            {
                WaitLoading();
                result = wcBrowser.ExecuteJavascriptWithResult("document.getElementsByTagName('html')[0].outerHTML");
            }

            return result;
        }
    }
}