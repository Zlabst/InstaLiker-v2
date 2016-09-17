using System.Data;
using System.Windows.Forms;

namespace InstaLiker.Forms
{
    public partial class Statistic : Form
    {
        public Statistic(DataTable srcStats)
        {
            InitializeComponent();

            gvStats.DataSource = srcStats;
        }
    }
}
