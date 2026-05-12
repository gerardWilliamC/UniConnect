using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Models;

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
            string email = txtAdminId.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both your admin ID/email and password.",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper db = new DatabaseHelper();
            Admin admin;

            try
            {
                admin = db.ValidateAdmin(email, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the database.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (admin == null)
            {
                MessageBox.Show("Invalid credentials, or you are not authorized to access this portal.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
                txtPassword.Focus();
                return;
            }

            Session.CurrentAdmin = admin;

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