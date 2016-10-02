using System;
using System.Data;
using System.Windows.Forms;
using Awesomium.Core;
using InstaLiker.Models;

namespace InstaLiker.Forms
{
    public partial class Main : Form, IMainView
    {
        private Facade _facade;
        private bool _isLoadingCompleted;

        public Main()
        {
            InitializeComponent();
        }

        #region IView

        public void NavigateToPage(Uri uriTag, out string htmlBody)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    wcBrowser.Source = uriTag;
                    _isLoadingCompleted = false;
                }));
            }
            else
            {
                wcBrowser.Source = uriTag;
                _isLoadingCompleted = false;
            }

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
                    wcBrowser.Reload(false);
                    WaitLoading();
                }));
            else
            {
                wcBrowser.Reload(false);
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

        #endregion


        // загрузка данных отображающихся на форме
        private void LoadData()
        {
            _facade = new Facade(this, new DataContext());
            gvTags.DataSource = _facade.GetSourceTags;
            wcBrowser.Source = new Uri("https://www.instagram.com/accounts/login/");
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
                Invoke(new Action(CheckBrowserStatus));
            else
                CheckBrowserStatus();
        }

        // проверка загрузки браузера
        private void CheckBrowserStatus()
        {
            while (!_isLoadingCompleted || !wcBrowser.IsLive || !wcBrowser.IsDocumentReady)
            {
                Application.DoEvents();

                if (!wcBrowser.IsLive)
                {
                    wcBrowser.Reload(false);

                    while (!_isLoadingCompleted || !wcBrowser.IsDocumentReady)
                        Application.DoEvents();
                }
            }
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

        #region Events

        // загрузка формы
        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // вызов настроек
        private void msiSettings_Click(object sender, EventArgs e)
        {
            try
            {
                var setFrm = new SettingsForm(_facade.GetSettMinWaitAfterLike, _facade.GetSettPeriodMinTimer);

                if (setFrm.ShowDialog() != DialogResult.OK)
                    return;

                _facade.UpdateSettings(setFrm.GetSettMinWaitAfterLike, setFrm.GetSettPeriodMinTimer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // вызов статистики
        private void msiStats_Click(object sender, EventArgs e)
        {
            try
            {
                new Statistic(_facade.GetStatistics).ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // добавление нового тега
        private void btnAddTag_Click(object sender, EventArgs e)
        {
            try
            {
                var tagFrm = new NewTag();

                if (tagFrm.ShowDialog() != DialogResult.OK)
                    return;

                if (string.IsNullOrWhiteSpace(tagFrm.GetNewTagName))
                    return;

                _facade.AddNewTag(tagFrm.GetNewTagName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // удаление тега
        private void btnDelTag_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить выбранный тег?", Application.ProductName, MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question) == DialogResult.Cancel)
                    return;

                _facade.DeleteTag((int) gvTags.SelectedCells[0].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // старт процедуры
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                WaitLoading();

                _facade.StartParser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // остановка процедуры
        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                EnableCtrls(false);
                _facade.StopParser();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // загрузка браузера окончена
        private void Awesomium_Windows_Forms_WebControl_LoadingFrameComplete(object sender, FrameEventArgs e)
        {
            if (e.IsMainFrame)
                _isLoadingCompleted = true;
        }

        // начало загрузки браузера
        private void Awesomium_Windows_Forms_WebControl_LoadingFrame(object sender, LoadingFrameEventArgs e)
        {
            if (e.IsMainFrame)
                _isLoadingCompleted = false;
        }

        #endregion
    }
}