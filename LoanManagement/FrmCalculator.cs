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
    public partial class FrmCalculator : Form
    {
        public FrmCalculator()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            decimal amount = Convert.ToDecimal(txtAmount.Text);
            decimal rate = Convert.ToDecimal(txtRate.Text);
            int loanTerm = Convert.ToInt32(txtTerm.Text);

            // Create Loan object
            Loan loan1 = new Loan(amount, rate, loanTerm);

            // Call methods using the object
            decimal total = loan1.calculateTotalPayable();
            decimal monthly = loan1.calculateMonthlyInstallment();

            // Display results using labels
            txtTotal.Text = total.ToString("F2");
            txtMonthly.Text = monthly.ToString("F2");

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtAmount.Clear();
            txtRate.Clear();
            txtTerm.Clear();
            txtTotal.Clear();
            txtMonthly.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
