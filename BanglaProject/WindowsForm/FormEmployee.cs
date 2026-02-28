using BanglaProject.DataBase;
using BanglaProject.WindowsForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanglaProject
{
    public partial class FormEmployee : Form
    {
        public FormEmployee()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            //pnlMain.Visible = false;
            //pnlShowCustomer.Visible = false;
            //pnlMainAbout.Visible = true;
        }

        private FormLogin LoginForm { set; get; }
        private DataBaseConnection DbConnection { set; get; }
        private string FullName { set; get; }
        private string UserID { set; get; }

        public FormEmployee(DataBaseConnection DbConnection, string userName, string userId, FormLogin loginData) : this()
        {
            this.DbConnection = DbConnection;
            this.FullName = userName;
            this.UserID = userId;
            this.lblEmployeeName.Text = "Welcome, " + this.FullName;
            this.LoginForm = loginData;
        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            //txtCustomer.Text = "";
            //lblSerchFound.Visible = false;
            btnInformation.BackColor = Color.Teal;
            btnInformation.ForeColor = Color.White;


            btnShowCustomer.BackColor = Color.LemonChiffon;
            btnShowCustomer.ForeColor = Color.Black;


            pnlShowCustomer.Visible = false;
            pnlMainAbout.Visible = false;
            pnlMain.Visible = true;

            try
            {
                string query = @"SELECT * FROM UserInfo 
                                WHERE USER_ID = '" + this.UserID + "'";

                var dataTable = this.DbConnection.ExecuteQueryTable(query);
                this.txtUserId.Text = dataTable.Rows[0]["USER_ID"].ToString();
                this.txtFullName.Text = dataTable.Rows[0]["FULL_NAME"].ToString();
                this.txtEmail.Text = dataTable.Rows[0]["EMAIL"].ToString();
                this.txtUsername.Text = dataTable.Rows[0]["USERNAME"].ToString();
                this.txtPassword.Text = dataTable.Rows[0]["PASSWORD"].ToString();
                this.txtMobile.Text = dataTable.Rows[0]["MOBILE"].ToString();
                this.txtNID.Text = dataTable.Rows[0]["NID"].ToString();
                this.txtAddress.Text = dataTable.Rows[0]["ADDRESS"].ToString();
                this.txtRole.Text = dataTable.Rows[0]["ROLE"].ToString();
                this.txtStatus.Text = dataTable.Rows[0]["STATUS"].ToString();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving user information: " + ex.Message);
            }



        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            pnlShowCustomer.Visible = false;
            pnlMain.Visible = false;
            pnlMainAbout.Visible = true;
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            LoginForm.Visible = true;
        }


        private void btnAddSell_Click(object sender, EventArgs e)
        {
            FormAddSales addSales = new FormAddSales(this.DbConnection, this.UserID, this);
            this.Visible = false;
            addSales.Visible = true;
        }

        private void btnSellReport_Click(object sender, EventArgs e)
        {
            FromSalesReport salesReport = new FromSalesReport(this.DbConnection, this);
            this.Visible = false;
            salesReport.Visible = true;
        }

        private void FormEmployee_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtCustomer.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                string sqlAll = "SELECT * FROM CustomerInfo;";
                var dsAll = DbConnection.ExecuteQuery(sqlAll);

                dgvCustomer.AutoGenerateColumns = false;
                dgvCustomer.DataSource = dsAll.Tables[0];

                dgvCustomer.ClearSelection();
                dgvCustomer.CurrentCell = null;

                lblSerchFound.Text = "";
                lblSerchFound.Visible = false;
                return;
            }

            string safe = searchText.Replace("'", "''");

            string sql = @"
        SELECT *
        FROM CustomerInfo
        WHERE CUSTOMER_MOBILE LIKE '%" + safe + @"%'
        ORDER BY CUSTOMER_ID;
    ";

            var dataset = DbConnection.ExecuteQuery(sql);

            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = dataset.Tables[0];

            dgvCustomer.ClearSelection();
            dgvCustomer.CurrentCell = null;

            if (dataset.Tables[0].Rows.Count > 0)
            {
                lblSerchFound.Text = "Found";
                lblSerchFound.ForeColor = Color.Green;
                lblSerchFound.Visible = true;
            }
            else
            {
                lblSerchFound.Text = "Not Found";
                lblSerchFound.ForeColor = Color.Red;
                lblSerchFound.Visible = true;
            }
        }

        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            btnShowCustomer.BackColor = Color.Teal;
            btnShowCustomer.ForeColor = Color.White;


            btnInformation.BackColor = Color.LemonChiffon;
            btnInformation.ForeColor = Color.Black;

            this.pnlShowCustomer.Visible = true;
            this.pnlMainAbout.Visible = false;
            this.pnlMain.Visible = false;
            try
            {
                string query = "SELECT * FROM CustomerInfo;";
                var dataSet = DbConnection.ExecuteQuery(query);

                dgvCustomer.AutoGenerateColumns = false;
                dgvCustomer.DataSource = dataSet.Tables[0];

                dgvCustomer.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customers: " + ex.Message);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            FormReset reset = new FormReset(this.DbConnection, this.UserID, this);
            reset.Visible = true;
            this.Visible = false;
        }
    }
}
