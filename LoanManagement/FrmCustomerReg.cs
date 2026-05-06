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

            if (cmbEmploymentStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Please select employment status", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MonthlyIncome =="")
            {
                MessageBox.Show("Please enter Monthly Income", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }




            Customer customer = new Customer();

            customer.firstName = txtFirstName.Text;
            customer.lastName = txtLastName.Text;
            customer.idTrn = txtTrnId.Text;
            customer.phoneNumber = txtPhoneNumber.Text; 
            customer.email = txtEmail.Text;
            customer.Address = txtAddress.Text;
            customer.employmentStatus = cmbEmploymentStatus.Text;
            customer.monthlyIncome = Convert.ToDecimal(txtMonthlyIncome.Text);

            DBHelper db = new DBHelper();
            db.saveCustomer(customer);


            MessageBox.Show("Customer saved successfully ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information); 
            
        }

        /*private void FrmCourse_Load(object sender, EventArgs e)
        {
            //Get an instance of DB Helper
            DBHelper db = new DBHelper();

            //Call the getAllCustomer method
            List<Customer> allCustomer = db.getAllCustomer();

        }*/
    


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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            /*int id = Convert.ToInt32(txtCustomerId.Text);



            DBHelper db = new DBHelper();
            db.deleteCustomer(id);

            MessageBox.Show("Customer deleted!");*/


        }

        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.loanManagementSystemDataSet);

        }

        private void FrmCustomerReg_Load(object sender, EventArgs e)
        {
             //TODO: This line of code loads data into the 'loanManagementSystemDataSet.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.loanManagementSystemDataSet.customers);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            /*if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Email must contain '@' symbol", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtEmail.Focus();
                return;
            }*/
        }
    }
}
