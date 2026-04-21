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
    public partial class FrmCustomerReg : Form
    {
        public FrmCustomerReg()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string CustomerId = txtCustomerId.Text;
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string TrnId = txtTrnId.Text;
            string PhoneNumber = txtPhoneNumber.Text;
            string Email = txtEmail.Text;
            string Address = txtAddress.Text;
            string MonthlyIncome = txtMonthlyIncome.Text;

         

            if (FirstName == "")
            {
                MessageBox.Show("Please enter First Name", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (LastName== "")
            {
                MessageBox.Show("Please enter Last Name", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (TrnId == "")
            {
                MessageBox.Show("Please enter National ID OR TRN Number", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (PhoneNumber == "")
            {
                MessageBox.Show("Please enter Phone Number", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Email == "")
            {
                MessageBox.Show("Please enter Email Address", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEmploymentStatus.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select employment status", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MonthlyIncome =="")
            {
                MessageBox.Show("Please enter Monthly Income", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            MessageBox.Show("Customer Information saved successfully ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTrnId.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            cmbEmploymentStatus.SelectedIndex = -1;
            txtMonthlyIncome.Clear();
            txtCustomerId.Focus();
            
          
        }

        
    }
}
