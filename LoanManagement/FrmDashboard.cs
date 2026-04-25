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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;



namespace LoanManagement
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

       /* private User CurrentUser;
        private void BuildStatusStrip()
            
        {
            lblUser.Text = $"  👤 {CurrentUser.Username} ({CurrentUser.Role})";
            lblDate.Text = $"  📅 {DateTime.Today:dd-MMM-yyyy}";
            lblTime.Text = $"  🕐 {DateTime.Now:HH:mm:ss}";
            lblStatus.Text = "  ✅ System Online";

           // statusStrip.Items.AddRange(new ToolStripItem[]
           // { lblUser, new ToolStripSeparator(), lblDate, new ToolStripSeparator(), lblTime, new ToolStripSeparator(), lblStatus });
           // statusStrip.BackColor = Color.FromArgb(30, 80, 160);
           // foreach (ToolStripItem item in statusStrip.Items)
              //  item.ForeColor = Color.White;

           // Controls.Add(statusStrip);
        }*/

        private void LoadForm(Form form)
        {
            // Close existing child forms
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }

            // Open new form
            form.MdiParent = this;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //FrmCustomerReg frm = new FrmCustomerReg();
           // frm.MdiParent = this; 
           // frm.Show();
           
            LoadForm(new FrmCustomerReg());
        
        }

        private void loansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* FrmLoan frm = new FrmLoan();
             frm.MdiParent= this;
             frm.Show();*/
            LoadForm(new FrmLoan());
        }

        private void paymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* FrmPayment frm = new FrmPayment();
             frm.MdiParent= this;
             frm.Show();*/

            LoadForm(new FrmPayment());
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* FrmReport frm = new FrmReport();
             frm.MdiParent= this;
             frm.Show();*/

            LoadForm(new FrmReport());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            /*if (MessageBox.Show("Are you sure you want to logout?", "Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataStore.CurrentUser = null;
                clock.Stop();
                new FrmLogin2().Show();
                Close();
            }*/
        }
    }
}
