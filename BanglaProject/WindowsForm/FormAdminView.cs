using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanglaProject.DataBase;
using BanglaProject.WindowsForm;

namespace BanglaProject
{
    public partial class FormAdminView : Form
    {
        public FormAdminView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            dgvUserInfo.ClearSelection();
            lblsearch.Text = "";

            // default view
            pnlCustomer.Visible = false;
            pnlInformation.Visible = false;
            pnlShowCustomer.Visible = false;
            //pnlGrid.Visible = true; 
            //pnlGrid.Visible = true; 
            this.dgvUserInfo.CellClick += dgvUserInfo_CellClick;
            this.dgvUserInfo.SelectionChanged += dgvUserInfo_SelectionChanged;

         


        }

        private string AdminUserID { get; set; }

        private FormLogin LoginForm { set; get; }
        private DataBaseConnection DbConnection { set; get; }
        private string FullName { set; get; }

        private string SelectedUserID { set; get; }

        public FormAdminView(DataBaseConnection DbConnection, string userName, string adminUserId, FormLogin loginData) : this()
        {
            this.DbConnection = DbConnection;
            this.FullName = userName;
            this.AdminUserID = adminUserId;
            this.LoginForm = loginData;

            lblAdminName.Text = "Welcome, " + this.FullName;
            PopulateGridView();
        }


        private void btnLogOut_Click_1(object sender, EventArgs e)
        {
            LoginForm.Visible = true;
            this.Visible = false;
        }



        private void PopulateGridView(string sql = "select * from UserInfo;")
        {
            try
            {
                var dataset = this.DbConnection.ExecuteQuery(sql);

                this.dgvUserInfo.AutoGenerateColumns = false;
                this.dgvUserInfo.DataSource = dataset.Tables[0];

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred in the database system, please try again.\n" + exc.Message);
            }


        }
        private void ShowSelectedCustomer()
        {
            if (dgvCustomer.SelectedRows.Count == 1)
            {
                string customerId = dgvCustomer.SelectedRows[0].Cells[0].Value.ToString();
                string customerName = dgvCustomer.SelectedRows[0].Cells[1].Value.ToString();

                lblSerchFound.Text = "Selected: " + customerId + " - " + customerName;
                lblSerchFound.ForeColor = Color.Green;
                lblSerchFound.Visible = true;
            }
            else
            {
                lblSerchFound.Text = "";
                lblSerchFound.Visible = false;
            }
        }





        //private void button6_Click(object sender, EventArgs e)
        //{
        //    this.Visible = false;
        //    FormEditUser editUserForm = new FormEditUser(this);
        //    editUserForm.Visible = true;

        //}

        //private void button5_Click(object sender, EventArgs e)
        //{
        //    SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=C#;Integrated Security=True;Encrypt=False");
        //    conn.Open();
        //    SqlCommand cmd = new SqlCommand("select * from USERS;", conn);
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataSet ds = new DataSet();
        //    da.Fill(ds);
        //    dgvUserInfo.DataSource = ds.Tables[0];
        //    conn.Close();
        //    lblTable.Visible = true;
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            btnShowCustomer.BackColor = Color.LemonChiffon;
            btnShowCustomer.ForeColor = Color.Black;
            pnlShowCustomer.Visible = false;
            btnManageUser.BackColor = Color.Teal;
            btnManageUser.ForeColor = Color.White;

            btnInformation.BackColor = Color.LemonChiffon;
            btnInformation.ForeColor = Color.Black;

            pnlInformation.Visible = false;
            pnlGrid.Visible = true;
            pnlButtonHide.Visible = true;
            txtSearch.Clear();
            this.dgvUserInfo.ClearSelection();

        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = false;
            FormManageProducts manageProduct = new FormManageProducts(FullName,this.DbConnection ,this.LoginForm,this);
            this.Visible = false;
            manageProduct.Visible = true;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM CustomerInfo;";
            var dataset = this.DbConnection.ExecuteQuery(sql);

            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = dataset.Tables[0];

            dgvCustomer.ClearSelection();
            dgvCustomer.CurrentCell = null;

            lblSerchFound.Text = "";
            lblSerchFound.Visible = false;

            txtSearch.Clear();
            this.PopulateGridView();
            this.dgvUserInfo.ClearSelection();

        }

        private void FormAdminView_Load(object sender, EventArgs e)
        {
           
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.MultiSelect = false;
            dgvCustomer.ClearSelection();
            dgvCustomer.CurrentCell = null;
            lblSerchFound.Visible = false;


            dgvUserInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserInfo.MultiSelect = false;
            dgvUserInfo.ClearSelection();
            dgvUserInfo.CurrentCell = null;

            
            lblSerchFound.Text = "";
            lblSerchFound.Visible = false;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //FormEditUser editUserForm = new FormEditUser(this);
            //editUserForm.Visible = true;
            if (IsUserSelected() && this.SelectedUserID == this.dgvUserInfo.SelectedRows[0].Cells["USER_ID"].Value.ToString())
            {
                this.Visible = false;
                FormEditUser editUserForm = new FormEditUser(SelectedUserID, this.DbConnection, this);
                editUserForm.Visible = true;
            }
            else
            {
                MessageBox.Show("Please select a user first(Double click to Select).", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private bool IsUserSelected()
        {
            if (this.dgvUserInfo.SelectedRows.Count == 1)
            {
                //MessageBox.Show("Please select a user first.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            //if (this.SelectedUserID == null)
            //{
            //    MessageBox.Show("Please select a user first.", "No User Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            return false;
        }

        private void dgvUserInfo_DoubleClick(object sender, EventArgs e)
        {
            this.SelectedUserID = this.dgvUserInfo.SelectedRows[0].Cells["USER_ID"].Value.ToString();
        }

        private void btnAddSell_Click(object sender, EventArgs e)
        {
            FormAddSales addSales = new FormAddSales(this.DbConnection,this.AdminUserID, this);
            this.Visible = false;
            addSales.Visible = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            dgvUserInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUserInfo.MultiSelect = false;

            if (dgvUserInfo.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select a row first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string userId = dgvUserInfo.SelectedRows[0].Cells["USER_ID"].Value.ToString();

            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete this user?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) return;

            try
            {
                string safeUserId = userId.Replace("'", "''");
                string sql = "DELETE FROM UserInfo WHERE USER_ID = '" + safeUserId + "'";
                int result = DbConnection.ExecuteDMLQuery(sql);

                if (result > 0)
                {
                    MessageBox.Show("User deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PopulateGridView();
                    dgvUserInfo.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Delete failed!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // FK error
                string msg = ex.Message.ToLower();

                if (msg.Contains("reference constraint") || msg.Contains("conflicted with the reference"))
                {
                    MessageBox.Show(
                        "This user cannot be deleted because it is referenced by existing customer records. " +
                        "Please delete or update the related customer data first.",
                        "Delete Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }
        private void SearchUser()
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                this.PopulateGridView();
                lblsearch.Text = "";
                lblsearch.Visible = false;
                return;
            }

            string safe = searchText.Replace("'", "''");

            string sql = @"
                            SELECT *
                            FROM UserInfo
                            WHERE FULL_NAME LIKE '%" + safe + @"%'
                               OR USERNAME LIKE '%" + safe + @"%'
                               OR USER_ID LIKE '%" + safe + @"%'
                            ORDER BY USER_ID;";

            var dataset = this.DbConnection.ExecuteQuery(sql);

            this.dgvUserInfo.AutoGenerateColumns = false;
            this.dgvUserInfo.DataSource = dataset.Tables[0];

            if (dataset.Tables[0].Rows.Count > 0)
            {
                lblsearch.Text = "Found";
                lblsearch.ForeColor = Color.Green;
                lblsearch.Visible = true;
            }
            else
            {
                lblsearch.Text = "Not Found";
                lblsearch.ForeColor = Color.Red;
                lblsearch.Visible = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchUser();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInformation_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = false;
            pnlButtonHide.Visible= false;
            pnlShowCustomer.Visible = false;
            pnlInformation.Visible = true;
            pnlGrid.Visible = false;

            btnShowCustomer.BackColor = Color.LemonChiffon;
            btnShowCustomer.ForeColor = Color.Black;

            btnInformation.BackColor = Color.Teal;
            btnInformation.ForeColor = Color.White;

            btnManageUser.BackColor = Color.LemonChiffon;
            btnManageUser.ForeColor = Color.Black;

            string query = "SELECT * FROM UserInfo WHERE USER_ID = '" + this.AdminUserID + "'";
            DataTable dt = this.DbConnection.ExecuteQueryTable(query);

            if (dt.Rows.Count > 0)
            {
                txtUserId.Text = dt.Rows[0]["USER_ID"].ToString();
                txtFullName.Text = dt.Rows[0]["FULL_NAME"].ToString();
                txtEmail.Text = dt.Rows[0]["EMAIL"].ToString();
                txtUsername.Text = dt.Rows[0]["USERNAME"].ToString();
                txtPassword.Text = dt.Rows[0]["PASSWORD"].ToString();
                txtMobile.Text = dt.Rows[0]["MOBILE"].ToString();
                txtNID.Text = dt.Rows[0]["NID"].ToString();
                txtAddress.Text = dt.Rows[0]["ADDRESS"].ToString();
                txtRole.Text = dt.Rows[0]["ROLE"].ToString();
                txtStatus.Text = dt.Rows[0]["STATUS"].ToString();
            }
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = false;
            pnlButtonHide.Visible = true;
            btnShowCustomer.BackColor = Color.LemonChiffon;
            btnShowCustomer.ForeColor = Color.Black;

            btnManageUser.BackColor = Color.Teal;
            btnManageUser.ForeColor = Color.White;

            btnInformation.BackColor = Color.LemonChiffon;
            btnInformation.ForeColor = Color.Black;

            pnlInformation.Visible = false;
            pnlGrid.Visible = true;
            pnlShowCustomer.Visible = false;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormAddUser addUser = new FormAddUser(this);
            addUser.Visible = true;
        }

        private void btnSellReport_Click(object sender, EventArgs e)
        {
            FromSalesReport salesReport = new FromSalesReport(this.DbConnection, this);
            this.Visible = false;
            salesReport.Visible = true;
        }

        private void FormAdminView_FormClosing(object sender, FormClosingEventArgs e)
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
        private void dgvUserInfo_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvUserInfo.SelectedRows.Count == 1)
                {
                    string userId = dgvUserInfo.SelectedRows[0].Cells["USER_ID"].Value.ToString();
                    string name = dgvUserInfo.SelectedRows[0].Cells["FULL_NAME"].Value.ToString();

                    this.SelectedUserID = userId;

                    lblsearch.Text = "Selected: " + userId + " - " + name;
                    lblsearch.ForeColor = Color.Green;
                    lblsearch.Visible = true;
                }
                else
                {
                    lblsearch.Text = "";
                    lblsearch.Visible = false;
                }
            }
            catch
            {
                lblsearch.Text = "";
                lblsearch.Visible = false;
            }
        }


        private void btnShowCustomer_Click(object sender, EventArgs e)
        {
            pnlCustomer.Visible = true;
            pnlButtonHide.Visible = false;
            btnShowCustomer.BackColor = Color.Teal;
            btnShowCustomer.ForeColor = Color.White;

            

            btnManageUser.BackColor = Color.LemonChiffon;
            btnManageUser.ForeColor = Color.Black;

            btnInformation.BackColor = Color.LemonChiffon;
            btnInformation.ForeColor = Color.Black;


            pnlInformation.Visible = false;
            pnlGrid.Visible = false;
            pnlShowCustomer.Visible = true;


            string sql = "select * from CustomerInfo;";
            var dataset = this.DbConnection.ExecuteQuery(sql);

            this.dgvCustomer.AutoGenerateColumns = false;
            this.dgvCustomer.DataSource = dataset.Tables[0];

            dgvCustomer.ClearSelection();
            dgvCustomer.CurrentCell = null;

            lblSerchFound.Text = "";
            lblSerchFound.Visible = false;

            txtSearch.Clear();



        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            SearchUser();
        }

        private void pnlGrid_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUserInfo.SelectedRows.Count == 1)
            {
                this.SelectedUserID = dgvUserInfo.SelectedRows[0].Cells["USER_ID"].Value.ToString();

                string name = dgvUserInfo.SelectedRows[0].Cells["FULL_NAME"].Value.ToString();

                lblsearch.Text = "Selected: " + SelectedUserID + " - " + name;
                lblsearch.ForeColor = Color.Green;
                lblsearch.Visible = true;
            }
        }
        private void dgvUserInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgvUserInfo.Rows[e.RowIndex].Selected = true;

            string userId = dgvUserInfo.Rows[e.RowIndex].Cells["USER_ID"].Value.ToString();
            string name = dgvUserInfo.Rows[e.RowIndex].Cells["FULL_NAME"].Value.ToString();

            SelectedUserID = userId;

            lblsearch.Text = "Selected: " + userId + " - " + name;
            lblsearch.ForeColor = Color.Green;
            lblsearch.Visible = true;
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

    dgvCustomer.Rows[e.RowIndex].Selected = true;

    string id = dgvCustomer.Rows[e.RowIndex].Cells["CUSTOMER_ID"].Value.ToString();
    string name = dgvCustomer.Rows[e.RowIndex].Cells["CUSTOMER_NAME"].Value.ToString();

    lblSerchFound.Text = "Selected: " + id + " - " + name;
    lblSerchFound.ForeColor = Color.Green;
    lblSerchFound.Visible = true;
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowSelectedCustomer();
        }

        private void btnCustomerRefresh_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM CustomerInfo;";
            var dataset = this.DbConnection.ExecuteQuery(sql);

            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = dataset.Tables[0];

            dgvCustomer.ClearSelection();
            dgvCustomer.CurrentCell = null;

            lblSerchFound.Text = "";
            lblSerchFound.Visible = false;

            txtSearch.Clear();
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

        private void btnCustomerDekete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count != 1)
            {
                MessageBox.Show(
                    "Please select a customer first.",
                    "No Selection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            string customerId = dgvCustomer.SelectedRows[0]
                                .Cells["CUSTOMER_ID"]
                                .Value.ToString();

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this customer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                string sql = "DELETE FROM CustomerInfo WHERE CUSTOMER_ID = '" + customerId + "'";
                int affected = DbConnection.ExecuteDMLQuery(sql);

                if (affected > 0)
                {
                    MessageBox.Show(
                        "Customer deleted successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    RefreshCustomerGrid();
                }
                else
                {
                    MessageBox.Show(
                        "Delete failed!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }
        private void RefreshCustomerGrid()
        {
            string sql = "SELECT * FROM CustomerInfo;";
            var ds = DbConnection.ExecuteQuery(sql);

            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.DataSource = ds.Tables[0];

            dgvCustomer.ClearSelection();
            dgvCustomer.CurrentCell = null;

            lblSerchFound.Text = "";
            lblSerchFound.Visible = false;

            txtCustomer.Clear();
        }

       

        private void btnReset_Click(object sender, EventArgs e)
        {
            FormReset resetForm = new FormReset(this.DbConnection, this.AdminUserID, this);
            this.Visible = false;
            resetForm.Visible = true;
        }
    }

}
