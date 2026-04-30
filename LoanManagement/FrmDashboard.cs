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


        private Timer clockTimer;

        public void LoadStatusBar(string username, string role)
        {
            // User info from login / DB
            lblUser.Text = $"{username} ({role})";

            // Date (set once)
            lblDate.Text = DateTime.Today.ToString("dd-MMM-yyyy");

            // System status
            lblStatus.Text = "System Online";

            // Start live clock
            StartClock();
        }

        private void StartClock()
        {
            clockTimer = new Timer();
            clockTimer.Interval = 1000;

            clockTimer.Tick += (s, e) =>
            {
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            };

            clockTimer.Start();
        }
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
          
            DialogResult result = MessageBox.Show(  "Are you sure you want to logout?","Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                FrmLogin2 login = new FrmLogin2();
                login.Show();
                this.Hide(); // or this.Close();
            }
        }
        

        private void statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void FrmDashboard_Load(object sender, EventArgs e)
        {
           // pnlDasboard.Dock = DockStyle.Fill;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show( "Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(new FrmCalculator());
        }
    }
    
}
