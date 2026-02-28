using BanglaProject.DataBase;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BanglaProject.WindowsForm
{
    public partial class FormFindPassword : Form
    {
        private FormLogin LoginForm;
        private DataBaseConnection DbConnection { set; get; }

        public FormFindPassword()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            lblSearch.Text = "";
        }

        public FormFindPassword(DataBaseConnection dbConnection,FormLogin loginData) : this()
        {
            this.LoginForm = loginData;
            this.DbConnection = dbConnection;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LoginForm.Visible = true;
            this.Visible = false;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            string username = txtUsername.Text.Trim();
            string mobile = txtMobile.Text.Trim();

            if (userId == "" || username == "" || mobile == "")
            {
                MessageBox.Show("Please fill all fields");
                return;
            }
            try
            {
                string sql =
                    $@"SELECT PASSWORD FROM UserInfo  
                WHERE USER_ID='{userId} ' 
                AND USERNAME='{username}' 
                AND MOBILE='{mobile}'";

                DataTable dt = DbConnection.ExecuteQueryTable(sql);

                if (dt != null && dt.Rows.Count == 1)
                {
                    txtPassword.Text = dt.Rows[0]["PASSWORD"].ToString();
                    lblSearch.Text = "Found";
                    lblSearch.ForeColor = Color.Green;
                }
                else
                {
                    txtPassword.Clear();
                    lblSearch.Text = "Not Found";
                    lblSearch.ForeColor = Color.Red;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred while searching for the password. Please try again.\n" + ex.Message);
            }
        }

        private void FormFindPassword_FormClosing(object sender, FormClosingEventArgs e)
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

        private void FormFindPassword_Load(object sender, EventArgs e)
        {

        }
    }
}
