using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanglaProject.DataBase;

namespace BanglaProject.WindowsForm
{
    public partial class FormReset : Form
    {
        public FormReset()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;



            lblNewUsernameError.Text = "";
            lblNewUsernameError.Visible = false;

            lblNewPasswordError.Text = "";
            lblNewPasswordError.Visible = false;

        }

        private FormAdminView AdminView { get; set; }
        private FormEmployee Employee { get; set; }
        private DataBaseConnection DbConnection { get; set; }
        private string UserId { get; set; }

        public FormReset(DataBaseConnection dbConnection, string userId, FormAdminView adminView) : this()
        {
            this.DbConnection = dbConnection;
            this.UserId = userId;
            this.AdminView = adminView;
        }

        public FormReset(DataBaseConnection dbConnection, string userId, FormEmployee employee) : this()
        {
            this.DbConnection = dbConnection;
            this.UserId = userId;
            this.Employee = employee;
        }


        private void CurrentInfo()
        {
            try
            {
                string sql = $@"select USERNAME, PASSWORD from UserInfo 
                        where USER_ID = '{this.UserId}';";

                var dataTable = this.DbConnection.ExecuteQueryTable(sql);
                if (dataTable.Rows.Count == 1)
                {
                    this.txtCurrentUsername.Text = dataTable.Rows[0]["USERNAME"].ToString();
                    this.txtCurrentPassword.Text = dataTable.Rows[0]["PASSWORD"].ToString();
                }
                else
                {
                    MessageBox.Show(
                    "Unable to find the current user information.",
                    "User Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                    );
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(
                    "An unexpected error occurred.\n\nDetails: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.AdminView != null)
            {
                this.Visible = false;
                AdminView.Visible = true;
            }
            else if (this.Employee != null)
            {
                this.Employee.Visible = true;
                this.Visible = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCurrentUsername.Text) ||
                   string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show(
                    "Please enter your current username and password.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblNewUsernameError.Visible && lblNewUsernameError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Username field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblNewPasswordError.Visible && lblNewPasswordError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Password field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            try
            {
                string newUserName = this.txtNewUsername.Text.ToString();
                string newPassword = this.txtNewPassword.Text.ToString();

                string updateQuery = $@"
                UPDATE UserInfo
               SET USERNAME ='{newUserName}', PASSWORD='{newPassword}'
               WHERE USERNAME = '{this.txtCurrentUsername.Text}' and PASSWORD = '{this.txtCurrentPassword.Text}';";

                

                int count = this.DbConnection.ExecuteDMLQuery(updateQuery);
                if (count == 1)
                {
                    MessageBox.Show(
                    "Your username and password have been updated successfully.",
                    "Update Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
                    this.Visible = false;

                    if (this.AdminView != null)
                    {
                        AdminView.Visible = true;
                    }
                    else if (this.Employee != null)
                    {
                        Employee.Visible = true;
                    }

                    return;
                }
                else
                {
                    MessageBox.Show(
                    "The current username or password you entered is incorrect.",
                    "Update Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
);

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        private void FormReset_Load(object sender, EventArgs e)
        {
            this.CurrentInfo();
        }

        private void FormReset_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                                    "Are you sure you want to close the application?",
                                    "Confirm Exit",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
);

            if (result == DialogResult.No)
                e.Cancel = true;
            else
                Environment.Exit(0);
        }

        private void txtNewPassword_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidatePassword(txtNewPassword, lblNewPasswordError);
        }

        private void txtNewUsername_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateUsername(txtNewUsername, lblNewUsernameError);
        }
    }
}
