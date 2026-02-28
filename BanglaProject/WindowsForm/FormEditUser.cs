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

namespace BanglaProject
{
    public partial class FormEditUser : Form
    {
        public FormEditUser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;


        }
        private string OriginalRole;
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtFullName.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtMobile.Clear();
            txtPassword.Clear();
            txtNid.Clear();
            txtAddress.Clear();

            cmbRole.SelectedIndex = -1;
            chkIsActive.Checked = false;

            lblFullNameError.Visible = false;
            lblEmailError.Visible = false;
            lblUsernameError.Visible = false;
            lblMobileError.Visible = false;
            lblNidError.Visible = false;
            lblAddressError.Visible = false;

            lblPasswordError.Visible = false;
        }
        private void FormEditUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private FormAdminView AdminView { get; set; }
        private DataBaseConnection DbConnection { get; set; }
        private string UserId { get; set; }

        public FormEditUser(string userId, DataBaseConnection dbConnection, FormAdminView adminView) : this()
        {
            this.AdminView = adminView;
            this.UserId = userId;
            this.DbConnection = dbConnection;
        }

        private void UserCurrentData()
        {
            try
            {
                string sql = "select * from UserInfo where USER_ID = '" + this.UserId + "';";
                var dataTable = DbConnection.ExecuteQueryTable(sql);

                this.txtFullName.Text = dataTable.Rows[0]["FULL_NAME"].ToString();
                this.txtUsername.Text = dataTable.Rows[0]["USERNAME"].ToString();
                this.txtPassword.Text = dataTable.Rows[0]["PASSWORD"].ToString();
                this.txtMobile.Text = dataTable.Rows[0]["MOBILE"].ToString();
                this.txtEmail.Text = dataTable.Rows[0]["EMAIL"].ToString();
                this.txtNid.Text = dataTable.Rows[0]["NID"].ToString();
                this.txtAddress.Text = dataTable.Rows[0]["ADDRESS"].ToString();

                OriginalRole = dataTable.Rows[0]["ROLE"].ToString().ToLower();

                cmbRole.SelectedIndex = cmbRole.FindStringExact(OriginalRole);

                chkIsActive.Checked = Convert.ToBoolean(dataTable.Rows[0]["STATUS"]);


            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred while fetching user data, please try again.\n" + ex.Message);
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.AdminView.Visible = true;
            this.Visible = false;
        }

        private void FormEditUser_Load(object sender, EventArgs e)
        {
            this.UserCurrentData();

            cmbRole.Enabled = false;

        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateFullName(txtFullName, lblFullNameError);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateEmail(txtEmail, lblEmailError);
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateUsername(txtUsername, lblUsernameError);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidatePassword(txtPassword, lblPasswordError);
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateMobile(txtMobile, lblMobileError);
        }

        private void txtNid_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateNID(txtNid, lblNidError);
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateAddress(txtAddress, lblAddressError);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (lblFullNameError.Visible && lblFullNameError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Full Name field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblEmailError.Visible && lblEmailError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Email field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblUsernameError.Visible && lblUsernameError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Username field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblMobileError.Visible && lblMobileError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Mobile field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblPasswordError.Visible && lblPasswordError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Password field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblNidError.Visible && lblNidError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the NID field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            if (lblAddressError.Visible && lblAddressError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Address field before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            
            
            bool fullNameOk = InputValidatorUser.ValidateFullName(txtFullName, lblFullNameError);
            bool emailOk = InputValidatorUser.ValidateEmail(txtEmail, lblEmailError);
            bool usernameOk = InputValidatorUser.ValidateUsername(txtUsername, lblUsernameError);
            bool mobileOk = InputValidatorUser.ValidateMobile(txtMobile, lblMobileError);
            bool passwordOk = InputValidatorUser.ValidatePassword(txtPassword, lblPasswordError);
            bool nidOk = InputValidatorUser.ValidateNID(txtNid, lblNidError);
            bool addressOk = InputValidatorUser.ValidateAddress(txtAddress, lblAddressError);
            bool roleOk = true;


            if (!(fullNameOk && emailOk && usernameOk && mobileOk &&
                  passwordOk && nidOk && addressOk && roleOk ))
            {
                MessageBox.Show(
                    "Please fill all fields correctly before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            try
            {
                string fullName = txtFullName.Text.Replace("'", "''");
                string email = txtEmail.Text.Replace("'", "''");
                string username = txtUsername.Text.Replace("'", "''");
                string password = txtPassword.Text.Replace("'", "''");
                string mobile = txtMobile.Text.Replace("'", "''");
                string nid = txtNid.Text.Replace("'", "''");
                string address = txtAddress.Text.Replace("'", "''");
                int status = chkIsActive.Checked ? 1 : 0;

                string role = OriginalRole;

                string sql = $@"
                                    UPDATE UserInfo SET
                                    FULL_NAME = '{fullName}',
                                    EMAIL = '{email}',
                                    USERNAME = '{username}',
                                    PASSWORD = '{password}',
                                    MOBILE = '{mobile}',
                                    NID = '{nid}',
                                    ADDRESS = '{address}',
                                    ROLE = '{role}',
                                    STATUS = {status}
                                    WHERE USER_ID = '{this.UserId}'
";

                int result = DbConnection.ExecuteDMLQuery(sql);

                if (result > 0)
                {
                    MessageBox.Show("User updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.AdminView.Visible = true;
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Update failed!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user:\n" + ex.Message,
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGeneratePassword_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUsername.Text) &&
                !string.IsNullOrWhiteSpace(txtMobile.Text) &&
                txtMobile.Text.Length >= 4)
            {
                string username = txtUsername.Text.Trim();
                string mobile = txtMobile.Text.Trim();

                string mobileLast4 = mobile.Substring(mobile.Length - 4);


                string newPassword =
                    char.ToUpper(username[0]) +
                    username.Substring(1) +
                    "@" +
                    mobileLast4;

                txtPassword.Text = newPassword;

                MessageBox.Show(
                    "Password generated successfully!",
                    "Password Generated",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                MessageBox.Show(
                    "Please enter username and mobile number first.",
                    "Cannot Generate Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            
        }

        private void FormEditUser_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
