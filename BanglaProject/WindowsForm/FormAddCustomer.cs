using BanglaProject.DataBase;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BanglaProject
{
    public partial class FormAddCustomer : Form
    {
        public FormAddCustomer()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            ClearErrorMessages();
        }

        private FormAddSales AddSales { get; set; }   
        private DataBaseConnection DbConnection { get; set; }

        public FormAddCustomer(DataBaseConnection dbConnection, FormAddSales addSales) : this()
        {
            this.AddSales = addSales;
            this.DbConnection = dbConnection;
        }

        private void ClearErrorMessages()
        {
            lblFullNameError.Text = "";
            lblMobileError.Text = "";

            lblFullNameError.Visible = false;
            lblMobileError.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
                this.Visible = false;
                this.AddSales.Visible = true;
        }

        private void FormAddCustomer_Load(object sender, EventArgs e)
        {
            ClearErrorMessages();
        }

        private void FormAddCustomer_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            InputValidatorUser.ValidateMobile(txtMobile, lblMobileError);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearErrorMessages();
            txtCustomerName.Clear();
            txtMobile.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lblFullNameError.Visible && lblFullNameError.ForeColor == Color.Red)
            {
                MessageBox.Show("Fix Customer Name.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lblMobileError.Visible && lblMobileError.ForeColor == Color.Red)
            {
                MessageBox.Show("Fix Mobile Number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //bool nameOk = InputValidatorUser.ValidateFullName(txtCustomerName, lblFullNameError);
            //bool mobileOk = InputValidatorUser.ValidateMobile(txtMobile, lblMobileError);

            //if (!(nameOk && mobileOk))
            //{
            //    MessageBox.Show("Fill fields correctly.", "Validation Error",
            //        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            try
            {
                string CustomerQuery = "select max(CUSTOMER_ID) from CustomerInfo;";
                string newCustomerId = this.autoGenarateID(CustomerQuery, "PC-");

                string insertQuery = $@"
                INSERT INTO CustomerInfo
                ( CUSTOMER_ID, CUSTOMER_NAME, CUSTOMER_MOBILE)
                VALUES
                ('{newCustomerId}','{this.txtCustomerName.Text}',
                '{this.txtMobile.Text}');";

                var count = this.DbConnection.ExecuteDMLQuery(insertQuery);
                if (count == 1)
                {
                    MessageBox.Show("Customer saved!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnClear_Click(sender, e);

                    this.AddSales.Visible = true;
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
                MessageBox.Show("An error occurred!\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //eta style cng korte hbe pore
        //private string GenerateCustomerId_Global()
        //{
        //    string sql = @"
        //            SELECT ISNULL(MAX(CAST(SUBSTRING(CUSTOMER_ID,3,10) AS INT)),0)
        //            FROM dbo.CustomerInfo
        //            WHERE CUSTOMER_ID LIKE 'C-%'";

        //    object res = DbConnection.ExecuteScalarQuery(sql);

        //    int last = 0;
        //    if (res != null && res != DBNull.Value)
        //        int.TryParse(res.ToString(), out last);

        //    int next = last + 1;

        //    return "C-" + next.ToString("D3");
        //}
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

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearErrorMessages();
            txtCustomerName.Clear();
            txtMobile.Clear();
        }
    }
}
