using System;
using System.ComponentModel;
using System.Windows.Forms;
using CECRunningChart.Services.User;

namespace CECRunningChart
{
    public partial class LogonForm : Form
    {
        public LogonForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
                return;

            try
            {
                IUserService userService = new UserService();
                bool isUserAuthorized = false; // userService.ValidateUser(txtUserName.Text, txtPassword.Text);
                if (!isUserAuthorized)
                {
                    lblError.Text = "Invalid user name or password. Please try again.";
                    return;
                }
                MainForm mainForm = new MainForm();
                mainForm.Show();
                //this.Close();
                this.Hide();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errUserName.SetError(txtUserName, "User Name is required.");
                //e.Cancel = true;
            }
            else
            {
                errUserName.Clear();
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                errPassword.SetError(txtPassword, "Password is required.");
                //e.Cancel = true;
            }
            else
            {
                errPassword.Clear();
            }
        }
    }
}
