using BanglaProject.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanglaProject
{
    public partial class FormAddUser : Form
    {
        public FormAddUser()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ClearErrorMessages();
        }
        private void ClearErrorMessages()
        {
            lblFullNameError.Text = "";
            lblEmailError.Text = "";
            lblUsernameError.Text = "";
            lblMobileError.Text = "";
            lblNidError.Text = "";
            lblAddressError.Text = "";
            lblRoleError.Text = "";
            lblPasswordError.Text = "";

            lblFullNameError.Visible = false;
            lblEmailError.Visible = false;
            lblUsernameError.Visible = false;
            lblMobileError.Visible = false;
            lblNidError.Visible = false;
            lblAddressError.Visible = false;
            lblRoleError.Visible = false;
            lblPasswordError.Visible = false;
        }

        private FormAdminView AdminView { get; set; }

       
        public FormAddUser(FormAdminView adminView) :this()
        {
            this.AdminView = adminView;
        }
        
        

        

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.AdminView.Visible = true;
            this.Visible = false;
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


        private void btnUserSave_Click(object sender, EventArgs e)
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
            if (lblRoleError.Visible && lblRoleError.ForeColor == Color.Red)
            {
                MessageBox.Show(
                    "Please fix the Role field before saving.",
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
            bool roleOk = InputValidatorUser.ValidateRole(cmbRole, lblRoleError);
            bool statusOk = InputValidatorUser.ValidateStatus(chkIsActive, lblRoleError);

            if (!(fullNameOk && emailOk && usernameOk && mobileOk &&
                  passwordOk && nidOk && addressOk && roleOk && statusOk))
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
                string roleText = cmbRole.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(roleText))
                {
                    MessageBox.Show("Please select a role first.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newUserId = GenerateUserId_Global(roleText);

                DataBaseConnection db = new DataBaseConnection();

                string sql = @"
INSERT INTO dbo.UserInfo
(USER_ID, ROLE, FULL_NAME, USERNAME, EMAIL, MOBILE, PASSWORD, NID, ADDRESS, CREATED_DATE, STATUS)
VALUES
(@USER_ID, @ROLE, @FULL_NAME, @USERNAME, @EMAIL, @MOBILE, @PASSWORD, @NID, @ADDRESS, CAST(GETDATE() AS DATE), @STATUS)
";

                int result = db.ExecuteDMLQuery(sql,
                    new SqlParameter("@USER_ID", newUserId),
                    new SqlParameter("@ROLE", roleText),
                    new SqlParameter("@FULL_NAME", txtFullName.Text.Trim()),
                    new SqlParameter("@USERNAME", txtUsername.Text.Trim()),
                    new SqlParameter("@EMAIL", txtEmail.Text.Trim()),
                    new SqlParameter("@MOBILE", txtMobile.Text.Trim()),
                    new SqlParameter("@PASSWORD", txtPassword.Text.Trim()),
                    new SqlParameter("@NID", txtNid.Text.Trim()),
                    new SqlParameter("@ADDRESS", txtAddress.Text.Trim()),
                    new SqlParameter("@STATUS", chkIsActive.Checked ? 1 : 0)
                );

                if (result > 0)
                {
                    MessageBox.Show("User saved successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClear_Click_1(sender, e);

                    if (this.AdminView != null)
                        this.AdminView.Visible = true;

                    this.Visible = false;
                    return;
                }
                else
                {
                    MessageBox.Show("Insert failed!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void  txtFullName_TextChanged(object sender, EventArgs e)
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

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateMobile(txtMobile, lblMobileError);
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidatePassword(txtPassword, lblPasswordError);
        }

        private void txtNid_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateNID(txtNid, lblNidError);
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateAddress(txtAddress, lblAddressError);
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateRole(cmbRole, lblRoleError);
        }

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateStatus(chkIsActive, lblRoleError);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
           ClearErrorMessages();
            txtFullName.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtMobile.Clear();
            txtPassword.Clear();
            txtNid.Clear();
            txtAddress.Clear();
            cmbRole.SelectedIndex = -1;
            chkIsActive.Checked = false;

        }
        private string GenerateUserId_Global(string role)
        {
            DataBaseConnection db = new DataBaseConnection();

            string prefix = role.Trim().ToLower() == "admin" ? "A" : "E";

            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(USER_ID,3,10) AS INT)),0) FROM UserInfo WHERE USER_ID LIKE '[AE]-%'";

            object res = db.ExecuteScalarQuery(sql);

            int last = 0;
            if (res != null && res != DBNull.Value)
                int.TryParse(res.ToString(), out last);

            int next = last + 1;

            return prefix + "-" + next.ToString("D3");
        }

        private void FormAddUser_Load(object sender, EventArgs e)
        {
            ClearErrorMessages();

        }

        private void FormAddUser_FormClosing(object sender, FormClosingEventArgs e)
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


