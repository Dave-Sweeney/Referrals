namespace Referrals.Ui.Winforms
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAdd = new Button();
            btnEdit = new Button();
            btnExit = new Button();
            btnDelete = new Button();
            dgReferrals = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgReferrals).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(365, 625);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(187, 84);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(714, 625);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(187, 84);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "&Edit";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnExit
            // 
            btnExit.Location = new Point(1426, 625);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(194, 84);
            btnExit.TabIndex = 3;
            btnExit.Text = "&Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(1075, 625);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(197, 84);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // dgReferrals
            // 
            dgReferrals.AllowUserToAddRows = false;
            dgReferrals.AllowUserToDeleteRows = false;
            dgReferrals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgReferrals.Location = new Point(90, 100);
            dgReferrals.Name = "dgReferrals";
            dgReferrals.ReadOnly = true;
            dgReferrals.RowHeadersWidth = 82;
            dgReferrals.Size = new Size(1801, 476);
            dgReferrals.TabIndex = 5;
            dgReferrals.CellContentDoubleClick += dgReferrals_CellContentDoubleClick;
            dgReferrals.CellFormatting += dgReferrals_CellFormatting;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1934, 744);
            Controls.Add(dgReferrals);
            Controls.Add(btnDelete);
            Controls.Add(btnExit);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Name = "Dashboard";
            Text = "Dashboard";
            ((System.ComponentModel.ISupportInitialize)dgReferrals).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdd;
        private Button btnEdit;
        private Button btnExit;
        private Button btnDelete;
        private DataGridView dgReferrals;
    }
}