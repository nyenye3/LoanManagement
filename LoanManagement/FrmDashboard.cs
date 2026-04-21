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
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }

        private User CurrentUser;
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
        } 

    }
}
