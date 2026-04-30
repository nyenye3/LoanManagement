using MainLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoanManagement
{
    public partial class FrmPayment : Form
    {
        public FrmPayment()
        {
            InitializeComponent();
        }

        private void loadLoan()
        {
            DBHelper db = new DBHelper();

            cmbLoanId.DataSource = db.getAllCustomers();
           cmbLoanId.DisplayMember = "customerId";   // what user sees
           cmbLoanId.ValueMember = "customerId";   // actual value

        }
        private void FrmPayment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loanManagementSystemDataSet.payment' table. You can move, or remove it, as needed.
            this.paymentTableAdapter.Fill(this.loanManagementSystemDataSet.payment);
            loadLoan();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();

            payment.loanId = Convert.ToInt32(cmbLoanId.SelectedValue);
            payment.paymentDate = dtpPaymentDate.Value;
            payment.amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
            payment.remainingBalance = Convert.ToDecimal(txtRemainingBalance.Text);
           

            DBHelper db = new DBHelper();
            db.savePayment(payment);

            MessageBox.Show("Payment Information saved successfully!");

        }

        private void paymentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.paymentBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.loanManagementSystemDataSet);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtpPaymentDate_ValueChanged(object sender, EventArgs e)
        {
            DateTime paymentDate = dtpPaymentDate.Value;

            if (paymentDate > DateTime.Now)
            {
                MessageBox.Show("Payment date cannot be in the future", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                dtpPaymentDate.Focus();
                return;
            }
        }

        private void txtAmountPaid_TextChanged(object sender, EventArgs e)
        {
            decimal amountPaid = decimal.Parse(txtAmountPaid.Text);

            if (amountPaid <= 0)
            {
                MessageBox.Show("Payment amount must be greater than 0", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmountPaid.Focus();
                return;
            }
        }
    }
}
