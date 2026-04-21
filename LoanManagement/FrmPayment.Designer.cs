namespace LoanManagement
{
    partial class FrmPayment
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
            this.lblPaymentId = new System.Windows.Forms.Label();
            this.lblLoanId = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.lblAmountPaid = new System.Windows.Forms.Label();
            this.lblRemainingBalance = new System.Windows.Forms.Label();
            this.txtPaymenId = new System.Windows.Forms.TextBox();
            this.txtAmountPaid = new System.Windows.Forms.TextBox();
            this.txtRemainingBalance = new System.Windows.Forms.TextBox();
            this.cmbLoanId = new System.Windows.Forms.ComboBox();
            this.dtpPaymentDate = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPaymentId
            // 
            this.lblPaymentId.AutoSize = true;
            this.lblPaymentId.Location = new System.Drawing.Point(83, 50);
            this.lblPaymentId.Name = "lblPaymentId";
            this.lblPaymentId.Size = new System.Drawing.Size(62, 13);
            this.lblPaymentId.TabIndex = 0;
            this.lblPaymentId.Text = "Payment ID";
            // 
            // lblLoanId
            // 
            this.lblLoanId.AutoSize = true;
            this.lblLoanId.Location = new System.Drawing.Point(83, 117);
            this.lblLoanId.Name = "lblLoanId";
            this.lblLoanId.Size = new System.Drawing.Size(52, 13);
            this.lblLoanId.TabIndex = 1;
            this.lblLoanId.Text = "Loan ID *";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Location = new System.Drawing.Point(83, 175);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(81, 13);
            this.lblPaymentDate.TabIndex = 2;
            this.lblPaymentDate.Text = "Payment Date *";
            // 
            // lblAmountPaid
            // 
            this.lblAmountPaid.AutoSize = true;
            this.lblAmountPaid.Location = new System.Drawing.Point(83, 240);
            this.lblAmountPaid.Name = "lblAmountPaid";
            this.lblAmountPaid.Size = new System.Drawing.Size(74, 13);
            this.lblAmountPaid.TabIndex = 3;
            this.lblAmountPaid.Text = "Amount Paid *";
            // 
            // lblRemainingBalance
            // 
            this.lblRemainingBalance.AutoSize = true;
            this.lblRemainingBalance.Location = new System.Drawing.Point(83, 296);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(102, 13);
            this.lblRemainingBalance.TabIndex = 4;
            this.lblRemainingBalance.Text = "Remaining Balance ";
            // 
            // txtPaymenId
            // 
            this.txtPaymenId.Location = new System.Drawing.Point(192, 43);
            this.txtPaymenId.Name = "txtPaymenId";
            this.txtPaymenId.Size = new System.Drawing.Size(200, 20);
            this.txtPaymenId.TabIndex = 5;
            // 
            // txtAmountPaid
            // 
            this.txtAmountPaid.Location = new System.Drawing.Point(192, 240);
            this.txtAmountPaid.Name = "txtAmountPaid";
            this.txtAmountPaid.Size = new System.Drawing.Size(200, 20);
            this.txtAmountPaid.TabIndex = 6;
            // 
            // txtRemainingBalance
            // 
            this.txtRemainingBalance.Location = new System.Drawing.Point(192, 293);
            this.txtRemainingBalance.Name = "txtRemainingBalance";
            this.txtRemainingBalance.Size = new System.Drawing.Size(200, 20);
            this.txtRemainingBalance.TabIndex = 7;
            // 
            // cmbLoanId
            // 
            this.cmbLoanId.FormattingEnabled = true;
            this.cmbLoanId.Items.AddRange(new object[] {
            "-- Select Loan --"});
            this.cmbLoanId.Location = new System.Drawing.Point(192, 114);
            this.cmbLoanId.Name = "cmbLoanId";
            this.cmbLoanId.Size = new System.Drawing.Size(200, 21);
            this.cmbLoanId.TabIndex = 8;
            // 
            // dtpPaymentDate
            // 
            this.dtpPaymentDate.Location = new System.Drawing.Point(192, 168);
            this.dtpPaymentDate.Name = "dtpPaymentDate";
            this.dtpPaymentDate.Size = new System.Drawing.Size(200, 20);
            this.dtpPaymentDate.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSave.Location = new System.Drawing.Point(162, 348);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnClear.Location = new System.Drawing.Point(264, 348);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 11;
            this.btnClear.Text = "Clear ";
            this.btnClear.UseVisualStyleBackColor = false;
            // 
            // FrmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpPaymentDate);
            this.Controls.Add(this.cmbLoanId);
            this.Controls.Add(this.txtRemainingBalance);
            this.Controls.Add(this.txtAmountPaid);
            this.Controls.Add(this.txtPaymenId);
            this.Controls.Add(this.lblRemainingBalance);
            this.Controls.Add(this.lblAmountPaid);
            this.Controls.Add(this.lblPaymentDate);
            this.Controls.Add(this.lblLoanId);
            this.Controls.Add(this.lblPaymentId);
            this.Name = "FrmPayment";
            this.Text = "Payment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPaymentId;
        private System.Windows.Forms.Label lblLoanId;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label lblAmountPaid;
        private System.Windows.Forms.Label lblRemainingBalance;
        private System.Windows.Forms.TextBox txtPaymenId;
        private System.Windows.Forms.TextBox txtAmountPaid;
        private System.Windows.Forms.TextBox txtRemainingBalance;
        private System.Windows.Forms.ComboBox cmbLoanId;
        private System.Windows.Forms.DateTimePicker dtpPaymentDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
    }
}