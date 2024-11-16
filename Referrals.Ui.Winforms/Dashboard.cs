using Referrals.Library.Models;
using Referrals.Library.Services;

namespace Referrals.Ui.Winforms
{
    public partial class Dashboard : Form
    {
        private readonly IReferralsService _referralsService;
        private readonly BindingSource bindingSource = [];
        private List<Referral> referrals = [];
        private List<ReferralViewModel> referralViewModels = [];

        public Dashboard(IReferralsService referralsService)
        {
            InitializeComponent();
            _referralsService = referralsService;
            this.LoadReferrals();
        }
        public static List<ReferralViewModel> TransformReferrals(List<Referral> referrals)
        {
            var referralViewModels = new List<ReferralViewModel>();
            foreach (var referral in referrals)
            {
                referralViewModels.Add(new ReferralViewModel
                {
                    Id = referral.Id,
                    ReferralNumber = referral.ReferralNumber,
                    ReferralDate = referral.ReferralDate,
                    ParentName = referral.ParentName,
                    ParentEmail = referral.ParentEmail,
                    ParentPhone = referral.ParentPhone,
                    OkToText = referral.OkToText,
                    ChildName = referral.ChildName,
                    ChildAge = referral.ChildAge,
                    Comments = referral.Comments
                });
            }

            return referralViewModels;
        }

        private void LoadReferrals()
        {
            referrals = _referralsService.GetReferrals().ToList();
            referralViewModels = TransformReferrals(referrals);

            bindingSource.DataSource = referralViewModels;
            dgReferrals.DataSource = bindingSource;
            dgReferrals.Columns["Id"].Visible = false;
            dgReferrals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgReferrals.Columns["DaysOpen"].HeaderText = "Days Open";
            dgReferrals.Columns["DaysOpen"].FillWeight = 10;
            dgReferrals.Columns["ReferralNumber"].HeaderText = "Referral Number";
            dgReferrals.Columns["ReferralNumber"].FillWeight = 10;
            dgReferrals.Columns["ReferralDate"].HeaderText = "Referral Date";
            dgReferrals.Columns["ReferralDate"].FillWeight = 20;
            dgReferrals.Columns["ParentName"].HeaderText = "Parent Name";
            dgReferrals.Columns["ParentName"].FillWeight = 20;
            dgReferrals.Columns["ParentEmail"].HeaderText = "Parent Email";
            dgReferrals.Columns["ParentEmail"].FillWeight = 20;
            dgReferrals.Columns["ParentPhone"].Visible = false; // Hide the "Parent Phone" column
            dgReferrals.Columns["FormattedParentPhone"].HeaderText = "Parent Phone";
            dgReferrals.Columns["FormattedParentPhone"].FillWeight = 15;
            dgReferrals.Columns["OkToText"].HeaderText = "Ok to Text";
            dgReferrals.Columns["OkToText"].FillWeight = 10;
            dgReferrals.Columns["ChildName"].HeaderText = "Child Name";
            dgReferrals.Columns["ChildName"].FillWeight = 20;
            dgReferrals.Columns["ChildAge"].HeaderText = "Child Age";
            dgReferrals.Columns["ChildAge"].FillWeight = 10;
            dgReferrals.Columns["Comments"].FillWeight = 25;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddReferralForm(_referralsService);
            var result = addForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadReferrals();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditReferral();
        }

        private void dgReferrals_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditReferral();
        }

        private void EditReferral()
        {
            var referralViewModel = (ReferralViewModel)bindingSource.Current;

            if (referralViewModel == null)
            {
                MessageBox.Show("Please select a referral to edit.");
                return;
            }

            var referral = new Referral
            {
                Id = referralViewModel.Id,
                ReferralNumber = referralViewModel.ReferralNumber,
                ReferralDate = referralViewModel.ReferralDate,
                ParentName = referralViewModel.ParentName,
                ParentEmail = referralViewModel.ParentEmail,
                ParentPhone = referralViewModel.ParentPhone,
                OkToText = referralViewModel.OkToText,
                ChildName = referralViewModel.ChildName,
                ChildAge = referralViewModel.ChildAge,
                Comments = referralViewModel.Comments
            };

            var editForm = new EditReferralForm(_referralsService, referral);
            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.LoadReferrals();
            }
        }

        private void dgReferrals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgReferrals.Columns[e.ColumnIndex].Name == "DaysOpen")
            {
                int daysOpen = (int)e.Value;
                if (daysOpen < 30)
                {
                    e.CellStyle.BackColor = Color.Green;
                    e.CellStyle.ForeColor = Color.White;
                }
                else if (daysOpen >= 30 && daysOpen < 90)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                    e.CellStyle.ForeColor = Color.Black;
                }
                else if (daysOpen >= 90)
                {
                    e.CellStyle.BackColor = Color.Red;
                    e.CellStyle.ForeColor = Color.White;
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var areYouSureDiaglog = MessageBox.Show("Are you sure you want to delete this referral?", "Delete Referral", MessageBoxButtons.YesNo);

            if (areYouSureDiaglog == DialogResult.Yes)
            {
                var referral = (Referral)bindingSource.Current;

                if (referral == null)
                {
                    MessageBox.Show("Please select a referral to delete.");
                    return;
                }

                _referralsService.DeleteReferral(referral.Id);
                this.LoadReferrals();
            }
        }
    }
}
