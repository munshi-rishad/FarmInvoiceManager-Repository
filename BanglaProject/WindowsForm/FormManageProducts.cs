using BanglaProject.DataBase;
using BanglaProject.WindowsForm;
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

namespace BanglaProject
{
    public partial class FormManageProducts : Form
    {
        public FormManageProducts()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private string SelectedProductID { get; set; }


        private FormLogin Login { get; set; }

        private FormAdminView AdminView { get; set; }

        private DataBaseConnection DbConnection { get; set; }

        public FormManageProducts(string userName,DataBaseConnection DbConnection ,FormLogin login, FormAdminView adminView) : this()
        {
            this.lblAdminName.Text = "Welcome, " + userName;
            this.AdminView = adminView;
            this.DbConnection = DbConnection;
            this.Login = login;
            this.PopulateGridView();
        }

        private void btnManageUser_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.AdminView.Visible = true;
        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already in Manage Products section.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
        private void PopulateGridView(string sql = "select * from ProductInfo;")
        {
            try
            {
                var dataset = this.DbConnection.ExecuteQuery(sql);

                this.dgvProductInfo.AutoGenerateColumns = false;
                this.dgvProductInfo.DataSource = dataset.Tables[0];

            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred in the database system, please try again.\n" + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dgvProductInfo.DataSource = null;
            lblTable.Visible = false;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            lblsearch.Visible = false;
            this.PopulateGridView();
            this.dgvProductInfo.ClearSelection();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            FormAddProduct addProduct = new FormAddProduct(this.DbConnection, this);
            this.Visible = false;
            addProduct.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product first.",
                    "No Product Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = dgvProductInfo.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();

            FormUpdateProduct updateProduct = new FormUpdateProduct(productId, this.DbConnection, this);
            this.Visible = false;
            updateProduct.Visible = true;
        }

        private void FormManageProducts_Load(object sender, EventArgs e)
        {
            lblsearch.Visible = false;

            dgvProductInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductInfo.MultiSelect = false;

            dgvProductInfo.CellClick += dgvProductInfo_CellClick;

        }
        private void dgvProductInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgvProductInfo.Rows[e.RowIndex].Selected = true;

            string id = dgvProductInfo.Rows[e.RowIndex].Cells["PRODUCT_ID"].Value?.ToString();
            string name = dgvProductInfo.Rows[e.RowIndex].Cells["PRODUCT_NAME"].Value?.ToString();

            SelectedProductID = id;

            lblsearch.Text = $"Selected: {id} - {name}";
            lblsearch.ForeColor = Color.Green;
            lblsearch.Visible = true;
        }
        


        

        private void FormManageProducts_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            
            this.Visible = false;
            Login.Visible = true;
           
        }
        private void SearchProduct()
        {
            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                this.PopulateGridView();
                this.dgvProductInfo.ClearSelection();
                lblsearch.Text = "";
                return;
            }

            string safe = searchText.Replace("'", "''");

            string sql = @"
SELECT *
FROM ProductInfo
WHERE PRODUCT_NAME LIKE '%" + safe + @"%'
   OR PRODUCT_ID LIKE '%" + safe + @"%'
ORDER BY PRODUCT_ID;
";

            var dataset = this.DbConnection.ExecuteQuery(sql);

            this.dgvProductInfo.AutoGenerateColumns = false;
            this.dgvProductInfo.DataSource = dataset.Tables[0];
            this.dgvProductInfo.ClearSelection();

            if (dataset.Tables[0].Rows.Count > 0)
            {
                lblsearch.Text = "Found";
                lblsearch.ForeColor = Color.Green;
            }
            else
            {
                lblsearch.Text = "Not Found";
                lblsearch.ForeColor = Color.Red;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.dgvProductInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductInfo.MultiSelect = false;

            if (dgvProductInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row first.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string productId = dgvProductInfo.SelectedRows[0].Cells[0].Value.ToString();

            DialogResult dr = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr != DialogResult.Yes) return;

            try
            {
                DataBaseConnection db = this.DbConnection;

                string sql = "DELETE FROM ProductInfo WHERE PRODUCT_ID = '" + productId.Replace("'", "''") + "'";
                int result = db.ExecuteDMLQuery(sql);

                if (result > 0)
                {
                    MessageBox.Show("Product deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    dgvProductInfo.Rows.RemoveAt(dgvProductInfo.SelectedRows[0].Index);
                }
                else
                {
                    MessageBox.Show("Delete failed!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvProductInfo_DoubleClick(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count == 1)
            {
                SelectedProductID = dgvProductInfo.SelectedRows[0].Cells["PRODUCT_ID"].Value.ToString();
                lblsearch.Text = "Selected: " + SelectedProductID;
                lblsearch.ForeColor = Color.Green;
                lblsearch.Visible = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.AdminView.Visible = true;
        }
    }
}
