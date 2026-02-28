using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using BanglaProject.DataBase;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BanglaProject.WindowsForm;

namespace BanglaProject
{
    public partial class FormAddSales : Form
    {
        public FormAddSales()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            lblMobileError.Text = "";
            lblFullNameError.Text = "";

        }

        private FormAdminView AdminView { get; set; }
        private FormEmployee Employee { get; set; }
        private string CurrentUserID { get; set; }
        private DataBaseConnection DbConnection { get; set; }

        public FormAddSales(DataBaseConnection DbConnection,string userID, FormAdminView admin) : this()
        {
            this.AdminView = admin;
            this.CurrentUserID = userID;
            this.DbConnection = DbConnection;
        }

        public FormAddSales(DataBaseConnection DbConnection,string userId, FormEmployee employee) : this()
        {
            this.Employee = employee;
            this.CurrentUserID = userId;
            this.DbConnection = DbConnection;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FormAddCustomer addCustomer = new FormAddCustomer(this.DbConnection, this);
            this.Visible = false;
            addCustomer.Visible = true;
        }

        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex < 0 || cmbProduct.SelectedValue == null)
                return;

            string sql = $"select UNITPRICE, QUANTITY from ProductInfo where PRODUCT_ID = '{cmbProduct.SelectedValue}';";
            var dataTable = this.DbConnection.ExecuteQueryTable(sql);

            if (dataTable.Rows.Count > 0)
            {
                txtUnitPrice.Text = dataTable.Rows[0]["UNITPRICE"].ToString();
                txtAvailableStocks.Text = dataTable.Rows[0]["QUANTITY"].ToString();
            }
        }

        //kaj korte hbe
        //private void PopulateGridView(string sql = "select * from ProductInfo;")
        //{
        //    try
        //    {
        //        var dataset = this.DbConnection.ExecuteQuery(sql);

        //        this.dgvProductInfo.AutoGenerateColumns = false;
        //        this.dgvProductInfo.DataSource = dataset.Tables[0];

        //    }
        //    catch (Exception exc)
        //    {
        //        MessageBox.Show("An error has occurred in the database system, please try again.\n" + exc.Message);
        //    }
        //}

        private void ClearAllFields()
        {
            txtCustomerName.Text = "";
            lblFullNameError.Text = "";
            lblMobileError.Text = "";
            cmbNumber.Text = "";
            cmbProduct.SelectedIndex = -1;
            txtUnitPrice.Text = "";
            txtQuantity.Text = "";
            txtAvailableStocks.Text = "";
            txtItemTotal.Text = "";
            txtTotalAmount.Text = "";
            txtDiscount.Text = "";
            txtFinalAmount.Text = "";
            dgvProductInfo.Rows.Clear();
            dgvProductInfo.ClearSelection();
            lblSearch.Text = "";
            lblSearch.Visible = false;
        }


        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedIndex < 0 || cmbProduct.SelectedValue == null)
            {
                MessageBox.Show(
                 "Please select a product before adding an item.",
                 "Product Required",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning
             );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show(
                 "Please enter the quantity to add.",
                 "Quantity Required",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Warning
             );

                return;
            }

            try
            {
                string productId = cmbProduct.SelectedValue.ToString();
                string query = $@"SELECT PRODUCT_ID, PRODUCT_NAME, UNITPRICE, QUANTITY, CREATED_DATE 
                  FROM ProductInfo 
                  WHERE PRODUCT_ID = '{productId}'";

                var dataTable = this.DbConnection.ExecuteQueryTable(query);

                if (dataTable.Rows.Count == 1)
                {
                    dgvProductInfo.Rows.Add(
                        dataTable.Rows[0]["PRODUCT_ID"].ToString(),
                        dataTable.Rows[0]["PRODUCT_NAME"].ToString(),
                        dataTable.Rows[0]["QUANTITY"].ToString(),
                        dataTable.Rows[0]["UNITPRICE"].ToString(),
                        dataTable.Rows[0]["CREATED_DATE"].ToString(),
                        this.txtQuantity.Text,
                        this.txtItemTotal.Text
                    );
                    CalculateSubTotal();
                    CalculateNetPayable();
                    cmbProduct.SelectedIndex = -1;
                    txtUnitPrice.Text = "";
                    txtQuantity.Text = "";
                    txtAvailableStocks.Text = "";
                    txtItemTotal.Text = "";

                }
                else
                {
                    MessageBox.Show(
                    "The selected product could not be found. Please refresh and try again.",
                    "Product Not Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(
                "A database error occurred while adding the item.\n\nPlease try again.\n\nDetails: " + exc.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            }
            this.dgvProductInfo.ClearSelection();
        }
        private void CalculateSubTotal()
        {
            double subTotal = 0;

            foreach (DataGridViewRow row in dgvProductInfo.Rows)
            {
                if (row.Cells[6].Value != null && row.Cells[6].Value.ToString() != "")
                {
                    subTotal += Convert.ToDouble(row.Cells[6].Value);
                }
            }

            txtTotalAmount.Text = subTotal.ToString("0.00");
        }

        private void CalculateNetPayable()
        {
            double subTotal = txtTotalAmount.Text == "" ? 0 : Convert.ToDouble(txtTotalAmount.Text);
            double discount = txtDiscount.Text == "" ? 0 : Convert.ToDouble(txtDiscount.Text);

            double discountAmount = (subTotal * discount) / 100;
            double netPayable = subTotal - discountAmount;

            this.txtFinalAmount.Text = netPayable.ToString("0.00");
        }
        private void UpdateSelectedLabel()
        {
            if (dgvProductInfo.SelectedRows.Count == 1)
            {
                string productId = dgvProductInfo.SelectedRows[0].Cells[0].Value?.ToString();
                string productName = dgvProductInfo.SelectedRows[0].Cells[1].Value?.ToString();

                lblSearch.Text = "Selected: " + productId + " - " + productName;
                lblSearch.ForeColor = Color.Green;
                lblSearch.Visible = true;
            }
            else
            {
                lblSearch.Text = "";
                lblSearch.Visible = false;
            }
        }






        private void propulateProductName()
        {
            string sql = @"select PRODUCT_ID, PRODUCT_NAME, IS_AVAILABLE from ProductInfo 
                            WHERE IS_AVAILABLE = 1;";
            var dataTable = this.DbConnection.ExecuteQueryTable(sql);

            cmbProduct.DataSource = dataTable;
            cmbProduct.DisplayMember = "PRODUCT_NAME";
            cmbProduct.ValueMember = "PRODUCT_ID";
            cmbProduct.SelectedIndex = -1;
        }

        private void propulateCustomerMobile()
        {
            string query = "select CUSTOMER_ID, CUSTOMER_MOBILE from CustomerInfo;";
            var dataTableCustomer = this.DbConnection.ExecuteQueryTable(query);

            cmbNumber.DataSource = dataTableCustomer;
            cmbNumber.DisplayMember = "CUSTOMER_MOBILE";
            cmbNumber.ValueMember = "CUSTOMER_ID";
            cmbNumber.SelectedIndex = -1;
        }



        private void FormAddSales_Load(object sender, EventArgs e)
        {
            dgvProductInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductInfo.MultiSelect = false;
            dgvProductInfo.ClearSelection();

            lblSearch.Text = "";
            lblPremiumMember.Visible = false;
            lblSearch.Visible = false;

            lblDateDefault.Text = DateTime.Now.ToShortDateString();

            try
            {
                this.propulateProductName();
                this.propulateCustomerMobile();
            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred.\n" + exc.Message);
            }
            isFormLoaded = true;

        }



        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity = this.txtQuantity.Text == "" ? 0 : Convert.ToInt32(this.txtQuantity.Text);
            double unitPrice = this.txtUnitPrice.Text == "" ? 0 : Convert.ToDouble(this.txtUnitPrice.Text);

            int stock = this.txtAvailableStocks.Text == "" ? 0 : Convert.ToInt32(this.txtAvailableStocks.Text);

            if (quantity > stock)
            {
                MessageBox.Show(
                "The entered quantity exceeds the available stock.\n\nPlease enter a smaller quantity.",
                "Invalid Quantity",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

                this.txtQuantity.Text = "";
                this.cmbProduct.SelectedIndex = -1;
                this.txtUnitPrice.Text = "";
                return;
            }


            double total = quantity * unitPrice;

            this.txtItemTotal.Text = total.ToString();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAllFields();

        }

        private void txtFinalAmount_TextChanged(object sender, EventArgs e)
        {
            CalculateNetPayable();
        }

        private void txtDiscount_TextChanged_1(object sender, EventArgs e)
        {
            if (double.TryParse(txtDiscount.Text, out double discount))
            {
                if (discount < 0 || discount > 100)
                {
                    MessageBox.Show(
                    "Discount must be a value between 0 and 100.",
                    "Invalid Discount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                    txtDiscount.Text = "";
                }
                else
                {
                    CalculateNetPayable();
                }
            }
            else if (!string.IsNullOrEmpty(txtDiscount.Text))
            {
                txtDiscount.Text = "";
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvProductInfo.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                "Please select an item from the list before removing it.",
                "No Item Selected",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

                return;
            }

            int index = dgvProductInfo.SelectedRows[0].Index;

            dgvProductInfo.Rows.RemoveAt(index);

            CalculateSubTotal();
            CalculateNetPayable();

            if (dgvProductInfo.Rows.Count > 0)
            {
                int newIndex = Math.Min(index, dgvProductInfo.Rows.Count - 1);
                dgvProductInfo.ClearSelection();
                dgvProductInfo.Rows[newIndex].Selected = true;
            }

            UpdateSelectedLabel();
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                MessageBox.Show(
                "Please enter the customer's name.",
                "Customer Name Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

                return;
            }


            if (string.IsNullOrWhiteSpace(cmbNumber.Text))
            {
                MessageBox.Show(
                "Please select or enter the customer's mobile number.",
                "Customer Mobile Required",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

                return;
            }


            if (dgvProductInfo.Rows.Count == 0)
            {
                MessageBox.Show(
                "Please add at least one product item before saving the invoice.",
                "No Items Added",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

                return;
            }


            string customerName = txtCustomerName.Text.Trim();
            string customerNumber = cmbNumber.Text;

            try
            {
                bool saveInvoice = this.SaveInvoiceDetailsDB();
                bool saveItems = this.SaveInvoiceItemsDB();
                bool updateStock = this.UpdateStockQuentity();

                if (saveInvoice && saveItems && updateStock)
                {
                    MessageBox.Show(
                    "Invoice saved successfully and stock quantities have been updated.",
                    "Saved Successfully",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                }
                else
                {
                    MessageBox.Show(
                    "Unable to save the invoice. Please check the information and try again.",
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                    return;
                }
            }
            catch {
                MessageBox.Show(
                "An unexpected error occurred while saving the invoice.\n\nPlease try again.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

                return;
            }


            

            FormInvoicePrint invoicePrint = new FormInvoicePrint(this.DbConnection, InvoiceID, this);

            this.Visible = false;
            invoicePrint.Visible = true;
        }

        private string InvoiceID { set; get; }
        private bool SaveInvoiceDetailsDB()
        {
            try
            {
                string customerID = "";
                string customerName = txtCustomerName.Text.Trim();
                string customerNumber = cmbNumber.Text;
                string userID = CurrentUserID;

                string invQuery = "select max(INVOICE_ID) from InvoiceDetails;";
                InvoiceID = this.autoGenarateID(invQuery, "INV-");

                if (this.lblPremiumMember.Text == "Premium Member")
                {
                    string query = $@"Select CUSTOMER_ID from CustomerInfo
                                where CUSTOMER_MOBILE = '{this.cmbNumber.Text}'";
                    var dataTable = DbConnection.ExecuteQueryTable(query);

                    if (dataTable.Rows.Count == 1)
                    {
                        customerID = dataTable.Rows[0]["CUSTOMER_ID"].ToString();
                    }
                    else
                    {
                        MessageBox.Show(
                        "Premium customer record was not found for this mobile number.",
                        "Customer Not Found",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                        return false;
                    }

                }
                else
                {
                    string CustomerQuery = @"SELECT MAX(Customer_ID)
                            FROM InvoiceDetails
                             WHERE Customer_ID LIKE 'RC-%';";
                            
                    customerID = this.autoGenarateID(CustomerQuery, "RC-");
                }

                double totalAmount = txtTotalAmount.Text == "" ? 0 : Convert.ToDouble(txtTotalAmount.Text);
                double finalAmount = txtFinalAmount.Text == "" ? 0 : Convert.ToDouble(txtFinalAmount.Text);

                double discount = txtDiscount.Text == "" ? 0 : Convert.ToDouble(txtDiscount.Text);
                double discountAmount = (totalAmount * discount) / 100;

                DateTime date = DateTime.Parse(lblDateDefault.Text);
                string formattedDate = date.ToString("yyyy-MM-dd");

                string insertQuery = $@"
                INSERT INTO InvoiceDetails
                (INVOICE_ID, USER_ID, CUSTOMER_ID, CUSTOMER_NAME, CUSTOMER_MOBILE, TOTAL_AMOUNT, DISCOUNT_AMOUNT, FINAL_AMOUNT, INVOICE_DATE)
                VALUES
                ('{InvoiceID}','{userID}','{customerID}','{customerName}',
                '{customerNumber}','{totalAmount}','{discountAmount}','{finalAmount}',
                    '{formattedDate}');";

                var count = this.DbConnection.ExecuteDMLQuery(insertQuery);
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(
                    "Invoice details could not be saved. Please try again.",
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                "A database error occurred while saving invoice details.\n\nPlease try again.\n\nDetails: " + ex.Message,
                "Database Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );

            }
            return false;

        }

        private string autoGenarateID(string sql, string prefix)
        {
            var newId = "";
            string query = sql;
            var dataTable = this.DbConnection.ExecuteQueryTable(query);
            if (dataTable.Rows.Count == 0 || dataTable.Rows[0][0] == DBNull.Value)
            {
                newId = prefix + "001";

            }
            else
            {

                var oldId = dataTable.Rows[0][0].ToString();
                var split = oldId.Split('-');
                var temp = Convert.ToInt32(split[1]);
                newId = prefix + (++temp).ToString("d3");
            }
            return newId;
        }

        private bool SaveInvoiceItemsDB()
        {
            
            if (dgvProductInfo.Rows.Count == 0)
            {
                MessageBox.Show(
                "There are no items in the invoice to save.",
                "No Items",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning
            );

                return false;
            }

            foreach (DataGridViewRow row in dgvProductInfo.Rows)
            {

                if (row.IsNewRow)
                    continue;

                string productID = row.Cells["Product_ID"].Value.ToString();
                string productName = row.Cells["Product_Name"].Value.ToString();
                int quantity = Convert.ToInt32(row.Cells["PRODUCT_QUANTITY"].Value);
                double unitPrice = Convert.ToDouble(row.Cells["UnitPrice"].Value);
                double subTotal = Convert.ToDouble(row.Cells["Total"].Value);

                string insertQuery = $@"INSERT INTO InvoiceItems
                (INVOICE_ID, PRODUCT_ID, PRODUCT_NAME, QUANTITY, UNIT_PRICE, SUB_TOTAL)
                VALUES
                ('{InvoiceID}','{productID}','{productName}','{quantity}',
                '{unitPrice}','{subTotal}');";

                var count = this.DbConnection.ExecuteDMLQuery(insertQuery);

                if (count != 1)
                {
                    MessageBox.Show(
                    "One or more invoice items could not be saved. Please try again.",
                    "Save Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                    return false;
                }
            }
                return true;
            
        }

        private bool UpdateStockQuentity()
        {
            foreach (DataGridViewRow row in dgvProductInfo.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string productID = row.Cells["Product_ID"].Value.ToString();
                int soldQuantity = Convert.ToInt32(row.Cells["PRODUCT_QUANTITY"].Value);

                string updateQuery = $@"
            UPDATE ProductInfo
            SET QUANTITY = QUANTITY - {soldQuantity}
            WHERE PRODUCT_ID = '{productID}';";

                int count = this.DbConnection.ExecuteDMLQuery(updateQuery);

                if (count != 1)
                {
                    MessageBox.Show(
                        "Stock quantity could not be updated for Product ID: " + productID,
                        "Stock Update Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return false;
                }
            }

            return true;
        }

        private void FormAddSales_FormClosing(object sender, FormClosingEventArgs e)
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



        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateFullName(txtCustomerName, lblFullNameError);
        }

        private void cmbNumber_TextChanged(object sender, EventArgs e)
        {
            if (!isFormLoaded) return;

            bool mobileOk = InputValidatorUser.ValidateMobileComboBox(cmbNumber, lblMobileError);

            txtCustomerName.Text = "";
            lblPremiumMember.Text = "";
            lblPremiumMember.Visible = false;

            if (!mobileOk)
                return;

            string sql = $"select CUSTOMER_NAME from CustomerInfo where CUSTOMER_MOBILE = '{cmbNumber.Text.Trim()}';";
            var dataTable = this.DbConnection.ExecuteQueryTable(sql);

            if (dataTable.Rows.Count > 0)
            {
                txtCustomerName.Text = dataTable.Rows[0]["CUSTOMER_NAME"].ToString();
                lblPremiumMember.Text = "Premium Member";
                lblPremiumMember.ForeColor = Color.Green;
                lblPremiumMember.Visible = true;
            }
            else
            {
                lblPremiumMember.Text = "Non Premium Member";
                lblPremiumMember.ForeColor = Color.Red;
                lblPremiumMember.Visible = true;
            }
        }

        private void dgvProductInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dgvProductInfo.ClearSelection();
            dgvProductInfo.Rows[e.RowIndex].Selected = true;

            UpdateSelectedLabel();
        }

        private bool isFormLoaded = false;

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            if (this.Employee != null)
            {
                this.Visible = false;
                this.Employee.Visible = true;

            }
            else if (this.AdminView != null)
            {
                this.Visible = false;
                this.AdminView.Visible = true;
            }
        }
    }
}
