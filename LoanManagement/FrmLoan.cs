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
    public partial class FrmLoan : Form
    {
        public FrmLoan()
        {
            InitializeComponent();
        }

        private void cmbCustomerId_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void loadCustomers()
        {
            DBHelper db = new DBHelper();

            cmbCustomerId.DataSource = db.getAllCustomers();
            cmbCustomerId.DisplayMember = "FullName";   // what user sees
            cmbCustomerId.ValueMember = "customerId";   // actual value

        }

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            Loan loan = new Loan();

            loan.customerId = Convert.ToInt32(cmbCustomerId.SelectedValue);
            loan.loanAmount = Convert.ToDecimal(txtLoanAmount.Text);
            loan.interestRate = Convert.ToDecimal(txtInterestRate.Text);
            loan.loanTerm = Convert.ToInt32(txtLoanTerm.Text);
            loan.applicationDate = dtpApplicationDate.Value;
            loan.status = cmbStatus.Text;

            DBHelper db = new DBHelper();
            db.saveLoan(loan);

            MessageBox.Show("Loan saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
        }

        private void FrmLoan_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'loanManagementSystemDataSet.loan' table. You can move, or remove it, as needed.
            this.loanTableAdapter.Fill(this.loanManagementSystemDataSet.loan);
            /*  // TODO: This line of code loads data into the 'loanManagementSystemDataSet.loan' table. You can move, or remove it, as needed.
              this.loanTableAdapter.Fill(this.loanManagementSystemDataSet.loan);
              // TODO: This line of code loads data into the 'loanManagementSystemDataSet.loan' table. You can move, or remove it, as needed.
              this.loanTableAdapter.Fill(this.loanManagementSystemDataSet.loan);
              // TODO: This line of code loads data into the 'loanManagementSystemDataSet.loan' table. You can move, or remove it, as needed.
              this.loanTableAdapter.Fill(this.loanManagementSystemDataSet.loan);
              // TODO: This line of code loads data into the 'loanManagementSystemDataSet.loan' table. You can move, or remove it, as needed.
              this.loanTableAdapter.Fill(this.loanManagementSystemDataSet.loan);*/
              loadCustomers();



        }

        private void loanBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
           /* this.Validate();
            this.loanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.loanManagementSystemDataSet);*/

        }

        private void loanBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.loanBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.loanManagementSystemDataSet);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtLoanAmount_TextChanged(object sender, EventArgs e)

        {

            decimal loanAmount = decimal.Parse(txtLoanAmount.Text);

            if (loanAmount <= 0)
        {
          MessageBox.Show("Loan amount must be a greater than zero ", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
   
           txtLoanAmount.Focus();
            return;
         }

        }

        /* private void loanBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
         {
            /* this.Validate();
             this.loanBindingSource.EndEdit();
             this.tableAdapterManager.UpdateAll(this.loanManagementSystemDataSet);

         }

         private void loanBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
         {
             this.Validate();
             this.loanBindingSource.EndEdit();
             this.tableAdapterManager.UpdateAll(this.loanManagementSystemDataSet);

         }

         private void loanBindingNavigatorSaveItem_Click_3(object sender, EventArgs e)
         {
             this.Validate();
             this.loanBindingSource.EndEdit();
             this.tableAdapterManager.UpdateAll(this.loanManagementSystemDataSet);

         }*/
    }
}
