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
using System.Xml.Linq;

namespace BanglaProject
{
    public partial class FormAddProduct : Form
    {
        public FormAddProduct()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }

        private FormManageProducts ManageProducts { get; set; }
        private DataBaseConnection DbConnection { get; set; }

        public FormAddProduct(DataBaseConnection DbConnection, FormManageProducts address) : this()
        {
            this.ManageProducts = address;
            this.DbConnection = DbConnection;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ManageProducts.Visible = true;
        }

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            lblNameError.Text = "";
            lblQuantityError.Text = "";
            lblCategoryError.Text = "";
            lblPriceError.Text = "";
            lblDateError.Text = "";
            lblStatusError.Text = "";

            lblNameError.Visible = false;
            lblQuantityError.Visible = false;
            lblCategoryError.Visible = false;
            lblPriceError.Visible = false;
            lblDateError.Visible = false;
            lblStatusError.Visible = false;
        }

        private void FormAddProduct_FormClosing(object sender, FormClosingEventArgs e)
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

        private void chkIsActive_CheckedChanged(object sender, EventArgs e)
        {
            InputValidatorProduct.ValidateStatus(chkIsActive, lblStatusError);
        }
        private bool HasRedError()
        {
            if (lblNameError.Visible && lblNameError.ForeColor == Color.Red) return true;
            if (lblQuantityError.Visible && lblQuantityError.ForeColor == Color.Red) return true;
            if (lblCategoryError.Visible && lblCategoryError.ForeColor == Color.Red) return true;
            if (lblPriceError.Visible && lblPriceError.ForeColor == Color.Red) return true;
            if (lblDateError.Visible && lblDateError.ForeColor == Color.Red) return true;
            if (lblStatusError.Visible && lblStatusError.ForeColor == Color.Red) return true;

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (HasRedError())
            {
                MessageBox.Show(
                    "Please fix the highlighted errors before saving.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            //bool nameOk = InputValidatorProduct.ValidateName(txtProductName, lblNameError);
            //bool qtyOk = InputValidatorProduct.ValidateQuantity(txtQunatity, lblQuantityError);
            //bool catOk = InputValidatorProduct.ValidateCategory(txtCategory, lblCategoryError);
            //bool priceOk = InputValidatorProduct.ValidatePrice(txtPrice, lblPriceError);
            //bool dateOk = InputValidatorProduct.ValidateDate(dtpDate, lblDateError);
            //bool statusOk = InputValidatorProduct.ValidateStatus(chkIsActive, lblStatusError);

            //if (!(nameOk && qtyOk && catOk && priceOk && dateOk && statusOk))
            //{
            //    MessageBox.Show(
            //        "Please fix the highlighted errors before saving.",
            //        "Validation Error",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Warning
            //    );
            //    return;
            //}

            try
            {
                string productId = GenerateProductId();

                int quantity = int.Parse(txtQunatity.Text.Trim());
                int price = int.Parse(txtPrice.Text.Trim());

                string sql = @"
                    INSERT INTO ProductInfo
                     (PRODUCT_ID, PRODUCT_NAME, QUANTITY, CATEGORY_NAME, UNITPRICE,
                     CREATED_DATE, IS_AVAILABLE, CREATED_BY_USER_ID)
                      VALUES
                    (@ID,@NAME,@QTY,@CAT,@PRICE,@DATE,@STATUS,@CREATED_BY_USER_ID)";

                int result = DbConnection.ExecuteDMLQuery(sql,
                    new SqlParameter("@ID", productId),
                    new SqlParameter("@NAME", txtProductName.Text.Trim()),
                    new SqlParameter("@QTY", quantity),
                    new SqlParameter("@CAT", txtCategory.Text.Trim()),
                    new SqlParameter("@PRICE", price),
                    new SqlParameter("@DATE", dtpDate.Value.Date),
                    new SqlParameter("@STATUS", chkIsActive.Checked),
                    new SqlParameter("@CREATED_BY_USER_ID", "A-001")
                );

                if (result > 0)
                {
                    MessageBox.Show(
                        "Product saved successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    btnClear_Click(sender, e);

                    this.Visible = false;
                    ManageProducts.Visible = true;
                }
                else
                {
                    MessageBox.Show(
                        "Insert failed!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred During Insertion: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private string GenerateProductId()
        {
            string sql =
                "SELECT ISNULL(MAX(CAST(SUBSTRING(PRODUCT_ID,5,10) AS INT)),0) FROM ProductInfo";

            object res = DbConnection.ExecuteScalarQuery(sql);
            int last = 0;
            if (res != null) int.TryParse(res.ToString(), out last);

            return "FIM-" + (last + 1).ToString("D3");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductName.Clear();
            txtQunatity.Clear();
            txtCategory.Clear();
            txtPrice.Clear();

            chkIsActive.Checked = false;

            lblNameError.Visible = false;
            lblQuantityError.Visible = false;
            lblCategoryError.Visible = false;
            lblPriceError.Visible = false;
            lblDateError.Visible = false;
            lblStatusError.Visible = false;
        }
    }
}
