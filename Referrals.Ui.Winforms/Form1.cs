using Referrals.Library.Models;
using Referrals.Library.Services;

namespace Referrals.Ui.Winforms
{
    public partial class Form1 : Form
    {
        private readonly IReferralsService _referralsService;
        private readonly BindingSource _bindingSource = new BindingSource();
        private readonly DataGridView _dataGridView = new DataGridView();
        private readonly List<Referral> referrals = [];

        public Form1(IReferralsService referralsService)
        {
            _referralsService = referralsService;
            referrals = _referralsService.GetReferrals().ToList();
            _bindingSource.DataSource = referrals;
            _dataGridView.DataSource = _bindingSource;
            _dataGridView.AutoGenerateColumns = true;
            _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            _dataGridView.Dock = DockStyle.Fill;
            Controls.Add(_dataGridView);
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
