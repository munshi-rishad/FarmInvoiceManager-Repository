using BanglaProject.DataBase;
using BanglaProject.WindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BanglaProject
{
    public partial class FormLogin : Form
    {

        private DataBaseConnection DbConnection { get; set; }

        public FormLogin()
        {
            InitializeComponent();
            this.DbConnection = new DataBaseConnection();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string password = this.txtPassword.Text;
            string username = this.txtUsername.Text;

            if (this.txtUsername.Text == "" || this.txtPassword.Text == "")
            {
                MessageBox.Show(
                 "Please enter your username (or User ID) and password to continue.",
                 "Missing Information",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning
 );
                return;
            }


            try
            {
                string query = $"SELECT USER_ID, FULL_NAME, ROLE, STATUS FROM UserInfo  WHERE (USERNAME = '{ username }' or USER_ID = '{ username }') AND PASSWORD = '{ password }'";

                var dataTable = this.DbConnection.ExecuteQueryTable(query);

                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show(
                     "Login failed. The username/User ID or password you entered is incorrect.",
                     "Login Failed",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error
                 );

                    return;
                }

                bool status = (bool)dataTable.Rows[0]["STATUS"];
                string role = dataTable.Rows[0]["ROLE"].ToString().ToLower();
                string fullName = dataTable.Rows[0]["FULL_NAME"].ToString();
                string userId = dataTable.Rows[0]["USER_ID"].ToString();

                //account inactive
                if (!status)
                {
                    MessageBox.Show(
                    "Your account is currently inactive. Please contact the administrator for activation.",
                    "Account Inactive",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
);

                    return;
                }

                // Account active
                if (role == "admin")
                {
                    MessageBox.Show(
                    "Welcome! You have logged in as Admin successfully.",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
);

                    FormAdminView adminView = new FormAdminView(DbConnection, fullName, userId, this);

                    this.Visible = false;
                    adminView.Visible = true;
                    txtUsername.Clear();
                    txtPassword.Clear();

                }

                else if (role == "employee")
                {
                    MessageBox.Show(
                    "Welcome! You have logged in as Employee successfully.",
                    "Login Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );


                    FormEmployee employee = new FormEmployee(DbConnection, fullName, userId, this);
                    

                    this.Visible = false;
                    employee.Visible = true;
                    txtUsername.Clear();
                    txtPassword.Clear();

                }
                else
                {
                    MessageBox.Show(
                     "Access denied. Your account role is not recognized. Please contact the administrator.",
                     "Access Denied",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Error
                 );

                    return;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(
                "Something went wrong while trying to log you in.\n\nPlease try again.\n\nDetails: " + ex.Message,
                "Login Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
);


            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtPassword.Clear();
            this.txtUsername.Clear();
        }

        private void chkPassShow_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPassShow.Checked)
            {
                this.txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                this.txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void lblForget_Click(object sender, EventArgs e)
        {
            FormFindPassword frm = new FormFindPassword(this.DbConnection, this);
            this.Visible = false;
            frm.Visible = true;
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
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
