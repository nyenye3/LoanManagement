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

            MessageBox.Show("Loan saved successfully!");
       
        }

        private void FrmLoan_Load(object sender, EventArgs e)
        {
            loadCustomers();


           
        }
    }
}
