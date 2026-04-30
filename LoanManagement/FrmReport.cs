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
    public partial class FrmReport : Form
    {
        public FrmReport()
        {
            InitializeComponent();
        }
        private void GenerateReport(string reportType)
        {
            DBHelper db = new DBHelper();
            DataTable dt = new DataTable();

            switch (reportType)
            {
                case "All Loans":
                    dt = db.ExecuteQuery("SELECT * FROM Loan");
                    break;

                case "Active Loans":
                    dt = db.ExecuteQuery("SELECT * FROM Loan WHERE status = 'Active'");
                    break;

                case "Completed Loans":
                    dt = db.ExecuteQuery("SELECT * FROM Loan WHERE status = 'Completed'");
                    break;

                case "Payments":
                    dt = db.ExecuteQuery("SELECT * FROM Payment");
                    break;

                case "Outstanding Balance":
                    dt = db.ExecuteQuery(@"
                SELECT loanId, SUM(remainingBalance) AS TotalBalance 
                FROM Payment 
                GROUP BY loanId");
                    break;
            }

            dataGridViewReport.DataSource = dt;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            if (cmbReportType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a report type.");
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString();

            GenerateReport(reportType);
        }

        private void FrmReport_Load(object sender, EventArgs e)
        {
            
           /* cmbReportType.Items.Add("All Loans");
            cmbReportType.Items.Add("Active Loans");
            cmbReportType.Items.Add("Completed Loans");
            cmbReportType.Items.Add("Payments");
            cmbReportType.Items.Add("Outstanding Balance");*/
        }
    
    }
}
