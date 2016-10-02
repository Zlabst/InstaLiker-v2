using System;
using System.Windows.Forms;

namespace InstaLiker.Forms
{
    public partial class SettingsForm : Form
    {
        // заполнение настроек
        public SettingsForm(string minWaitAfterLike, string periodMinTimer)
        {
            try
            {
                InitializeComponent();

                if (string.IsNullOrWhiteSpace(minWaitAfterLike))
                    minWaitAfterLike = "1";

                if (string.IsNullOrWhiteSpace(periodMinTimer))
                    periodMinTimer = "5";

                numMinWaitAfterLike.Value = int.Parse(minWaitAfterLike);
                numTimerMinPeriod.Value = int.Parse(periodMinTimer);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // новое значение настройки
        public string GetSettMinWaitAfterLike
        {
            get { return numMinWaitAfterLike.Value.ToString("####"); }
        }

        // новое значение настройки
        public string GetSettPeriodMinTimer
        {
            get { return numTimerMinPeriod.Value.ToString("####"); }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}