using BanglaProject.DataBase;
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
    public partial class FormUpdateProduct : Form
    {
        private FormManageProducts ManageProducts { get; set; }
        private DataBaseConnection DbConnection { get; set; }
        private string ProductId { get; set; }

        public FormUpdateProduct()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        public FormUpdateProduct(string productId, DataBaseConnection db, FormManageProducts manageProducts) : this()
        {
            this.ProductId = productId;
            this.DbConnection = db;
            this.ManageProducts = manageProducts;
        }

        private void FormUpdateProduct_Load(object sender, EventArgs e)
        {
            ClearErrors();

            if (DbConnection == null)
                DbConnection = new DataBaseConnection();

            if (string.IsNullOrWhiteSpace(ProductId))
            {
                MessageBox.Show("No product selected!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Visible = false;
                if (ManageProducts != null) ManageProducts.Visible = true;
                return;
            }

            LoadProductData(ProductId);
        }

        private void LoadProductData(string productId)
        {
            try
            {
                string sql = "SELECT * FROM ProductInfo WHERE PRODUCT_ID = @ID";

                DataTable dt = DbConnection.ExecuteQueryTable(sql, new SqlParameter("@ID", productId));

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Product not found!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                txtProductName.Text = dt.Rows[0]["PRODUCT_NAME"].ToString();
                txtQunatity.Text = dt.Rows[0]["QUANTITY"].ToString();
                txtCategory.Text = dt.Rows[0]["CATEGORY_NAME"].ToString();
                txtPrice.Text = dt.Rows[0]["UNITPRICE"].ToString();

                DateTime d;
                if (DateTime.TryParse(dt.Rows[0]["CREATED_DATE"].ToString(), out d))
                    dtpDate.Value = d;
                else
                    dtpDate.Value = DateTime.Now.Date;

                bool st;
                if (bool.TryParse(dt.Rows[0]["IS_AVAILABLE"].ToString(), out st))
                    chkIsActive.Checked = st;
                else
                    chkIsActive.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ClearErrors()
        {
            lblNameError.Text = "";
            lblQuantityError.Text = "";
            lblCategoryError.Text = "";
            lblPriceError.Text = "";
            lblDateError.Text = "";

            lblNameError.Visible = false;
            lblQuantityError.Visible = false;
            lblCategoryError.Visible = false;
            lblPriceError.Visible = false;
            lblDateError.Visible = false;
        }

        private void ClearForm()
        {
            txtProductName.Text = "";
            txtQunatity.Text = "";
            txtCategory.Text = "";
            txtPrice.Text = "";
            dtpDate.Value = DateTime.Now.Date;
            chkIsActive.Checked = false;
            ClearErrors();
        }

        private bool HasRedError()
        {
            if (lblNameError.Visible && lblNameError.ForeColor == Color.Red) return true;
            if (lblQuantityError.Visible && lblQuantityError.ForeColor == Color.Red) return true;
            if (lblCategoryError.Visible && lblCategoryError.ForeColor == Color.Red) return true;
            if (lblPriceError.Visible && lblPriceError.ForeColor == Color.Red) return true;
            if (lblDateError.Visible && lblDateError.ForeColor == Color.Red) return true;
            return false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (HasRedError())
            {
                MessageBox.Show("Please fix the highlighted errors before updating.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool nameOk = InputValidatorProduct.ValidateName(txtProductName, lblNameError);
            bool qtyOk = InputValidatorProduct.ValidateQuantity(txtQunatity, lblQuantityError);
            bool catOk = InputValidatorProduct.ValidateCategory(txtCategory, lblCategoryError);
            bool priceOk = InputValidatorProduct.ValidatePrice(txtPrice, lblPriceError);
            bool dateOk = InputValidatorProduct.ValidateDate(dtpDate, lblDateError);

            if (!(nameOk && qtyOk && catOk && priceOk && dateOk ))
            {
                MessageBox.Show("Please fix the highlighted errors before updating.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int quantity = int.Parse(txtQunatity.Text.Trim());
                int price = int.Parse(txtPrice.Text.Trim());

                string sql = @"
UPDATE ProductInfo
SET PRODUCT_NAME = @NAME,
    QUANTITY = @QTY,
    CATEGORY_NAME = @CAT,
    UNITPRICE = @PRICE,
    CREATED_DATE = @DATE,
    IS_AVAILABLE = @STATUS
WHERE PRODUCT_ID = @ID";

                int result = DbConnection.ExecuteDMLQuery(sql,
                    new SqlParameter("@NAME", txtProductName.Text.Trim()),
                    new SqlParameter("@QTY", quantity),
                    new SqlParameter("@CAT", txtCategory.Text.Trim()),
                    new SqlParameter("@PRICE", price),
                    new SqlParameter("@DATE", dtpDate.Value.Date),
                    new SqlParameter("@STATUS", chkIsActive.Checked),
                    new SqlParameter("@ID", ProductId)
                );

                if (result > 0)
                {
                    MessageBox.Show("Product updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (ManageProducts != null)
                    {
                        ManageProducts.Visible = true;
                    }

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
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (ManageProducts != null)
            {
                this.Visible = false;
                this.ManageProducts.Visible = true;
            }
        }

        private void FormUpdateProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ManageProducts != null)
                ManageProducts.Visible = true;
        }

        private void FormUpdateProduct_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            InputValidatorProduct.ValidateName(txtProductName, lblNameError);
        }

        private void txtQunatity_TextChanged(object sender, EventArgs e)
        {
            InputValidatorProduct.ValidateQuantity(txtQunatity, lblQuantityError);
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            InputValidatorProduct.ValidateCategory(txtCategory, lblCategoryError);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            InputValidatorProduct.ValidatePrice(txtPrice, lblPriceError);
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            InputValidatorProduct.ValidateDate(dtpDate, lblDateError);
        }

        
    }
}