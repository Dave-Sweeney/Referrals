using Referrals.Library.Models;
using Referrals.Library.Services;

namespace Referrals.Ui.Winforms;

public partial class EditReferralForm : Form
{
    private IReferralsService _referralsService;
    private Button btnCancel;
    private Button btnSave;
    private Label lblComments;
    private CheckBox cbOkToText;
    private Label lblParentPhone;
    private Label lblParentEmail;
    private Label lblParentName;
    private TextBox txtComment;
    private TextBox txtParentEmail;
    private TextBox txtParentName;
    private Label lblReferralDate;
    private Label lblReferralNumber;
    private TextBox txtReferralNumber;
    private DateTimePicker dtpReferralDate;
    private MaskedTextBox maskedPhoneNumber;
    private DataGridView dataGridView1;
    private DataGridView dataGridView2;
    private Label label1;
    private Label label2;
    private Button btnAddChild;
    private Button btnAddNote;
    private Referral referral;

    private void InitializeComponent()
    {
        btnCancel = new Button();
        btnSave = new Button();
        lblComments = new Label();
        cbOkToText = new CheckBox();
        lblParentPhone = new Label();
        lblParentEmail = new Label();
        lblParentName = new Label();
        txtComment = new TextBox();
        txtParentEmail = new TextBox();
        txtParentName = new TextBox();
        lblReferralDate = new Label();
        lblReferralNumber = new Label();
        txtReferralNumber = new TextBox();
        dtpReferralDate = new DateTimePicker();
        maskedPhoneNumber = new MaskedTextBox();
        dataGridView1 = new DataGridView();
        dataGridView2 = new DataGridView();
        label1 = new Label();
        label2 = new Label();
        btnAddChild = new Button();
        btnAddNote = new Button();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
        SuspendLayout();
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(818, 1167);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(192, 83);
        btnCancel.TabIndex = 31;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // btnSave
        // 
        btnSave.Location = new Point(530, 1167);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(192, 83);
        btnSave.TabIndex = 30;
        btnSave.Text = "&Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // lblComments
        // 
        lblComments.AutoSize = true;
        lblComments.Location = new Point(159, 897);
        lblComments.Name = "lblComments";
        lblComments.Size = new Size(130, 32);
        lblComments.TabIndex = 29;
        lblComments.Text = "Comments";
        // 
        // cbOkToText
        // 
        cbOkToText.AutoSize = true;
        cbOkToText.Location = new Point(159, 318);
        cbOkToText.Name = "cbOkToText";
        cbOkToText.Size = new Size(155, 36);
        cbOkToText.TabIndex = 20;
        cbOkToText.Text = "Ok to Text";
        cbOkToText.UseVisualStyleBackColor = true;
        // 
        // lblParentPhone
        // 
        lblParentPhone.AutoSize = true;
        lblParentPhone.Location = new Point(159, 238);
        lblParentPhone.Name = "lblParentPhone";
        lblParentPhone.Size = new Size(161, 32);
        lblParentPhone.TabIndex = 26;
        lblParentPhone.Text = "Parent Phone:";
        // 
        // lblParentEmail
        // 
        lblParentEmail.AutoSize = true;
        lblParentEmail.Location = new Point(818, 131);
        lblParentEmail.Name = "lblParentEmail";
        lblParentEmail.Size = new Size(150, 32);
        lblParentEmail.TabIndex = 25;
        lblParentEmail.Text = "Parent Email:";
        // 
        // lblParentName
        // 
        lblParentName.AutoSize = true;
        lblParentName.Location = new Point(159, 131);
        lblParentName.Name = "lblParentName";
        lblParentName.Size = new Size(157, 32);
        lblParentName.TabIndex = 24;
        lblParentName.Text = "Parent Name:";
        // 
        // txtComment
        // 
        txtComment.AcceptsReturn = true;
        txtComment.Location = new Point(159, 932);
        txtComment.Multiline = true;
        txtComment.Name = "txtComment";
        txtComment.Size = new Size(1213, 205);
        txtComment.TabIndex = 23;
        // 
        // txtParentEmail
        // 
        txtParentEmail.Location = new Point(818, 166);
        txtParentEmail.Name = "txtParentEmail";
        txtParentEmail.Size = new Size(563, 39);
        txtParentEmail.TabIndex = 18;
        // 
        // txtParentName
        // 
        txtParentName.Location = new Point(159, 166);
        txtParentName.Name = "txtParentName";
        txtParentName.Size = new Size(563, 39);
        txtParentName.TabIndex = 17;
        // 
        // lblReferralDate
        // 
        lblReferralDate.AutoSize = true;
        lblReferralDate.Location = new Point(818, 38);
        lblReferralDate.Name = "lblReferralDate";
        lblReferralDate.Size = new Size(152, 32);
        lblReferralDate.TabIndex = 35;
        lblReferralDate.Text = "Referral Date";
        // 
        // lblReferralNumber
        // 
        lblReferralNumber.AutoSize = true;
        lblReferralNumber.Location = new Point(159, 38);
        lblReferralNumber.Name = "lblReferralNumber";
        lblReferralNumber.Size = new Size(195, 32);
        lblReferralNumber.TabIndex = 34;
        lblReferralNumber.Text = "Referral Number:";
        // 
        // txtReferralNumber
        // 
        txtReferralNumber.Location = new Point(159, 73);
        txtReferralNumber.Name = "txtReferralNumber";
        txtReferralNumber.Size = new Size(563, 39);
        txtReferralNumber.TabIndex = 32;
        // 
        // dtpReferralDate
        // 
        dtpReferralDate.Location = new Point(818, 73);
        dtpReferralDate.Name = "dtpReferralDate";
        dtpReferralDate.Size = new Size(563, 39);
        dtpReferralDate.TabIndex = 36;
        // 
        // maskedPhoneNumber
        // 
        maskedPhoneNumber.Location = new Point(159, 273);
        maskedPhoneNumber.Name = "maskedPhoneNumber";
        maskedPhoneNumber.Size = new Size(554, 39);
        maskedPhoneNumber.TabIndex = 37;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Location = new Point(159, 418);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersWidth = 82;
        dataGridView1.Size = new Size(1213, 177);
        dataGridView1.TabIndex = 39;
        // 
        // dataGridView2
        // 
        dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView2.Location = new Point(159, 670);
        dataGridView2.Name = "dataGridView2";
        dataGridView2.RowHeadersWidth = 82;
        dataGridView2.Size = new Size(1213, 177);
        dataGridView2.TabIndex = 40;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(159, 383);
        label1.Name = "label1";
        label1.Size = new Size(104, 32);
        label1.TabIndex = 41;
        label1.Text = "Children";
        label1.Click += label1_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(159, 635);
        label2.Name = "label2";
        label2.Size = new Size(77, 32);
        label2.TabIndex = 42;
        label2.Text = "Notes";
        // 
        // btnAddChild
        // 
        btnAddChild.Location = new Point(1222, 366);
        btnAddChild.Name = "btnAddChild";
        btnAddChild.Size = new Size(150, 46);
        btnAddChild.TabIndex = 43;
        btnAddChild.Text = "+";
        btnAddChild.UseVisualStyleBackColor = true;
        btnAddChild.Click += btnAddChild_Click;
        // 
        // btnAddNote
        // 
        btnAddNote.Location = new Point(1222, 621);
        btnAddNote.Name = "btnAddNote";
        btnAddNote.Size = new Size(150, 46);
        btnAddNote.TabIndex = 44;
        btnAddNote.Text = "+";
        btnAddNote.UseVisualStyleBackColor = true;
        btnAddNote.Click += btnAddNote_Click;
        // 
        // EditReferralForm
        // 
        ClientSize = new Size(1551, 1300);
        Controls.Add(btnAddNote);
        Controls.Add(btnAddChild);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(dataGridView2);
        Controls.Add(dataGridView1);
        Controls.Add(maskedPhoneNumber);
        Controls.Add(dtpReferralDate);
        Controls.Add(lblReferralDate);
        Controls.Add(lblReferralNumber);
        Controls.Add(txtReferralNumber);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(lblComments);
        Controls.Add(cbOkToText);
        Controls.Add(lblParentPhone);
        Controls.Add(lblParentEmail);
        Controls.Add(lblParentName);
        Controls.Add(txtComment);
        Controls.Add(txtParentEmail);
        Controls.Add(txtParentName);
        Name = "EditReferralForm";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    public EditReferralForm(IReferralsService referralsService, Referral referral)
    {
        _referralsService = referralsService;
        this.referral = referral;

        InitializeComponent();

        maskedPhoneNumber.Mask = "(999) 000-0000";
        maskedPhoneNumber.Text = referral.ParentPhone;
        txtReferralNumber.Text = referral.ReferralNumber;
        txtParentName.Text = referral.ParentName;
        txtParentEmail.Text = referral.ParentEmail;
        txtParentPhone.Text = referral.ParentPhone;
        cbOkToText.Checked = referral.OkToText;
        txtChildName.Text = referral.ChildName;
        dtpReferralDate.Value = referral.ReferralDate;
        numericAge.Value = referral.ChildAge;
        txtComment.Text = referral.Comments;
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        var updatedReferral = new Referral
        {
            Id = referral.Id,
            ReferralNumber = txtReferralNumber.Text,
            ReferralDate = dtpReferralDate.Value,
            ParentName = txtParentName.Text,
            ParentEmail = txtParentEmail.Text,
            ParentPhone = maskedPhoneNumber.Text,
            OkToText = cbOkToText.Checked,
            ChildName = txtChildName.Text,
            ChildAge = (int)numericAge.Value,
            Comments = txtComment.Text
        };

        _referralsService.UpdateReferral(updatedReferral);
        this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        Close();
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void btnAddChild_Click(object sender, EventArgs e)
    {

    }

    private void btnAddNote_Click(object sender, EventArgs e)
    {

    }
}