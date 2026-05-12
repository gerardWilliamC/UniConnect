using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using UniConnect.Database;
using UniConnect.Database;
using UniConnect.Models;

namespace UniConnect
{
    public partial class frmStudentLogin : Form
    {
        public frmStudentLogin()
        {
            InitializeComponent();
            LoadLogo();
        }

        private void LoadLogo()
        {
            pbLogo.Image = Properties.Resources.l2dm;
        }

        private void btnStudentLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both your email and password.",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DatabaseHelper db = new DatabaseHelper();
            Student student;

            try
            {
                student = db.ValidateStudent(email, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not connect to the database.\n\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (student == null)
            {
                MessageBox.Show("Invalid email or password. Please try again.",
                    "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Text = "";
                txtPassword.Focus();
                return;
            }

            // Successful login — save to session and open the dashboard
            Session.CurrentStudent = student;

            frmStudentDashboard dashboard = new frmStudentDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void btnAdminLogin_Click(object sender, EventArgs e)
        {
            frmAdminLogin adminLogin = new frmAdminLogin();
            adminLogin.Show();
            this.Hide();
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact the registrar's office to reset your password.",
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}