using Referrals.Library.Models;
using Referrals.Library.Services;

namespace Referrals.Ui.Winforms;

public partial class AddReferralForm : Form
{
    private readonly IReferralsService _referralsService;

    private void InitializeComponent()
    {
        txtParentName = new TextBox();
        textBox2 = new TextBox();
        txtParentPhone = new TextBox();
        txtChildName = new TextBox();
        textBox6 = new TextBox();
        txtComment = new TextBox();
        lblParentName = new Label();
        lblParentEmail = new Label();
        lblParentPhone = new Label();
        cbOkToText = new CheckBox();
        lblChildName = new Label();
        lblChildAge = new Label();
        lblComments = new Label();
        btnSave = new Button();
        btnCancel = new Button();
        lblReferralDate = new Label();
        lblReferralNumber = new Label();
        txtReferralDate = new TextBox();
        txtReferralNumber = new TextBox();
        SuspendLayout();
        // 
        // txtParentName
        // 
        txtParentName.Location = new Point(275, 212);
        txtParentName.Name = "txtParentName";
        txtParentName.Size = new Size(563, 39);
        txtParentName.TabIndex = 0;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(275, 299);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(563, 39);
        textBox2.TabIndex = 1;
        // 
        // txtParentPhone
        // 
        txtParentPhone.Location = new Point(275, 384);
        txtParentPhone.Name = "txtParentPhone";
        txtParentPhone.Size = new Size(563, 39);
        txtParentPhone.TabIndex = 2;
        // 
        // txtChildName
        // 
        txtChildName.Location = new Point(275, 515);
        txtChildName.Name = "txtChildName";
        txtChildName.Size = new Size(563, 39);
        txtChildName.TabIndex = 4;
        // 
        // textBox6
        // 
        textBox6.Location = new Point(275, 615);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(563, 39);
        textBox6.TabIndex = 5;
        // 
        // txtComment
        // 
        txtComment.AcceptsReturn = true;
        txtComment.Location = new Point(275, 713);
        txtComment.Multiline = true;
        txtComment.Name = "txtComment";
        txtComment.Size = new Size(563, 205);
        txtComment.TabIndex = 7;
        // 
        // lblParentName
        // 
        lblParentName.AutoSize = true;
        lblParentName.Location = new Point(275, 177);
        lblParentName.Name = "lblParentName";
        lblParentName.Size = new Size(157, 32);
        lblParentName.TabIndex = 8;
        lblParentName.Text = "Parent Name:";
        // 
        // lblParentEmail
        // 
        lblParentEmail.AutoSize = true;
        lblParentEmail.Location = new Point(275, 264);
        lblParentEmail.Name = "lblParentEmail";
        lblParentEmail.Size = new Size(150, 32);
        lblParentEmail.TabIndex = 9;
        lblParentEmail.Text = "Parent Email:";
        // 
        // lblParentPhone
        // 
        lblParentPhone.AutoSize = true;
        lblParentPhone.Location = new Point(275, 349);
        lblParentPhone.Name = "lblParentPhone";
        lblParentPhone.Size = new Size(161, 32);
        lblParentPhone.TabIndex = 10;
        lblParentPhone.Text = "Parent Phone:";
        // 
        // cbOkToText
        // 
        cbOkToText.AutoSize = true;
        cbOkToText.Location = new Point(275, 429);
        cbOkToText.Name = "cbOkToText";
        cbOkToText.Size = new Size(155, 36);
        cbOkToText.TabIndex = 3;
        cbOkToText.Text = "Ok to Text";
        cbOkToText.UseVisualStyleBackColor = true;
        // 
        // lblChildName
        // 
        lblChildName.AutoSize = true;
        lblChildName.Location = new Point(275, 480);
        lblChildName.Name = "lblChildName";
        lblChildName.Size = new Size(140, 32);
        lblChildName.TabIndex = 12;
        lblChildName.Text = "Child Name";
        // 
        // lblChildAge
        // 
        lblChildAge.AutoSize = true;
        lblChildAge.Location = new Point(275, 580);
        lblChildAge.Name = "lblChildAge";
        lblChildAge.Size = new Size(118, 32);
        lblChildAge.TabIndex = 13;
        lblChildAge.Text = "Child Age";
        // 
        // lblComments
        // 
        lblComments.AutoSize = true;
        lblComments.Location = new Point(275, 678);
        lblComments.Name = "lblComments";
        lblComments.Size = new Size(130, 32);
        lblComments.TabIndex = 14;
        lblComments.Text = "Comments";
        // 
        // btnSave
        // 
        btnSave.Location = new Point(275, 944);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(192, 83);
        btnSave.TabIndex = 15;
        btnSave.Text = "&Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(646, 944);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(192, 83);
        btnCancel.TabIndex = 16;
        btnCancel.Text = "&Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Click += btnCancel_Click;
        // 
        // lblReferralDate
        // 
        lblReferralDate.AutoSize = true;
        lblReferralDate.Location = new Point(275, 93);
        lblReferralDate.Name = "lblReferralDate";
        lblReferralDate.Size = new Size(157, 32);
        lblReferralDate.TabIndex = 20;
        lblReferralDate.Text = "Referral Date:";
        // 
        // lblReferralNumber
        // 
        lblReferralNumber.AutoSize = true;
        lblReferralNumber.Location = new Point(275, 6);
        lblReferralNumber.Name = "lblReferralNumber";
        lblReferralNumber.Size = new Size(195, 32);
        lblReferralNumber.TabIndex = 19;
        lblReferralNumber.Text = "Referral Number:";
        // 
        // txtReferralDate
        // 
        txtReferralDate.Location = new Point(275, 128);
        txtReferralDate.Name = "txtReferralDate";
        txtReferralDate.Size = new Size(563, 39);
        txtReferralDate.TabIndex = 18;
        // 
        // txtReferralNumber
        // 
        txtReferralNumber.Location = new Point(275, 41);
        txtReferralNumber.Name = "txtReferralNumber";
        txtReferralNumber.Size = new Size(563, 39);
        txtReferralNumber.TabIndex = 17;
        // 
        // AddReferralForm
        // 
        ClientSize = new Size(1174, 1155);
        Controls.Add(lblReferralDate);
        Controls.Add(lblReferralNumber);
        Controls.Add(txtReferralDate);
        Controls.Add(txtReferralNumber);
        Controls.Add(btnCancel);
        Controls.Add(btnSave);
        Controls.Add(lblComments);
        Controls.Add(lblChildAge);
        Controls.Add(lblChildName);
        Controls.Add(cbOkToText);
        Controls.Add(lblParentPhone);
        Controls.Add(lblParentEmail);
        Controls.Add(lblParentName);
        Controls.Add(txtComment);
        Controls.Add(textBox6);
        Controls.Add(txtChildName);
        Controls.Add(txtParentPhone);
        Controls.Add(textBox2);
        Controls.Add(txtParentName);
        Name = "AddReferralForm";
        ResumeLayout(false);
        PerformLayout();
    }

    public AddReferralForm(IReferralsService referralsService)
    {
        _referralsService = referralsService;
        this.InitializeComponent();
    }

    private TextBox txtParentName;
    private TextBox textBox2;
    private TextBox txtParentPhone;
    private TextBox txtChildName;
    private TextBox textBox6;
    private TextBox txtComment;
    private Label lblParentName;
    private Label lblParentEmail;
    private Label lblParentPhone;
    private CheckBox cbOkToText;
    private Label lblChildName;
    private Label lblChildAge;
    private Label lblComments;
    private Button btnSave;
    private Button btnCancel;
    private Label lblReferralDate;
    private Label lblReferralNumber;
    private TextBox txtReferralDate;
    private TextBox txtReferralNumber;

    private void btnSave_Click(object sender, EventArgs e)
    {
        _referralsService.AddReferral(new Referral
        {
            ReferralNumber = txtReferralNumber.Text,
            ReferralDate = DateTime.Parse(txtReferralDate.Text),
            ParentName = txtParentName.Text,
            ParentEmail = textBox2.Text,
            ParentPhone = txtParentPhone.Text,
            OkToText = cbOkToText.Checked,
            ChildName = txtChildName.Text,
            ChildAge = int.Parse(textBox6.Text),
            Comments = txtComment.Text
        });

        this.DialogResult = DialogResult.OK;
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        Close();
    }

    private void txtParentPhone_TextChanged(object sender, EventArgs e)
    {
        // Sanitize input by removing all non-numeric characters
        string sanitizedInput = new string(txtParentPhone.Text.Where(char.IsDigit).ToArray());
        txtParentPhone.Text = sanitizedInput;
        txtParentPhone.SelectionStart = sanitizedInput.Length; // Move cursor to the end
    }
}