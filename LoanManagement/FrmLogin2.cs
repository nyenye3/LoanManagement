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
    public partial class FrmLogin2 : Form
    {
        public FrmLogin2()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            //role = cboRole.SelectedIndex;

            if (username == "")
            {
                MessageBox.Show("Please enter username", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            if (password == "")
            {
                MessageBox.Show("Please enter password", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
      

            if (cboRole.SelectedIndex == 0)
            {
                MessageBox.Show("Please select role", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            DBHelper db = new DBHelper();   

            User user = db.Login(username, password);

            if (user != null)
            {
                MessageBox.Show("Welcome " + username, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmDashboard dash = new FrmDashboard();
                dash.LoadStatusBar(user.Username, user.Role);
                dash.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.AliceBlue;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }

        private void pnlCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassword.Clear();
            cboRole.SelectedIndex = 0;
            txtUsername.Focus();
        }

        private void FrmLogin2_Load(object sender, EventArgs e)
        {
            cboRole.SelectedIndex = 0;
        }
    }

        
}
