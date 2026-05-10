using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UniConnect
{
    public partial class frmAdminLogin : Form
    {
        public frmAdminLogin()
        {
            InitializeComponent();
        }

        private void frmAdminLogin_Load(object sender, EventArgs e)
        {
            LoadLogo();
        }

        private void LoadLogo()
        {
            try
            {
                string logoPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "Resources", "l2lm.png");
                if (File.Exists(logoPath))
                    pbLogo.Image = Image.FromFile(logoPath);
            }
            catch { }
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            string adminId = txtAdminId.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(adminId) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both your admin ID/email and password.",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TODO: validate against MySQL admins table later
            frmAdminDashboard adminDash = new frmAdminDashboard();
            adminDash.Show();
            this.Hide();
        }

        private void btnBackToStudent_Click(object sender, EventArgs e)
        {
            frmStudentLogin studentLogin = new frmStudentLogin();
            studentLogin.Show();
            this.Close();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact the IT department to reset your admin password.",
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}