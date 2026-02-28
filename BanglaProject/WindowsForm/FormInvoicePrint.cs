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

namespace BanglaProject.WindowsForm
{
    public partial class FormInvoicePrint : Form
    {
        public FormInvoicePrint()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }

        private FormAddSales AddSales { get; set; }
        private string InvoiceID { get; set; }
        private DataBaseConnection DbConnection { get; set; }
        private FromSalesReport SalesReport { get; set; }

        public FormInvoicePrint( DataBaseConnection DbConnection,string invoiceID, FormAddSales addSales) : this()
        {
            this.DbConnection = DbConnection;
            this.AddSales = addSales;
            this.InvoiceID = invoiceID;

        }




        public FormInvoicePrint(DataBaseConnection DbConnection, FromSalesReport salesReport) : this()
        {
            this.DbConnection = DbConnection;
            this.SalesReport = salesReport;
        }
        private void FormInvoicePrint_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void FormInvoicePrint_Load(object sender, EventArgs e)
        {
            txtInvoice.Font = new Font("Consolas", 10);
            txtInvoice.ScrollBars = ScrollBars.Vertical;

            try
            {

                StringBuilder sb = new StringBuilder();

                // ================= INVOICE DETAILS =================
                string detailsQuery = $@"
            SELECT CUSTOMER_NAME, CUSTOMER_MOBILE,
           TOTAL_AMOUNT, DISCOUNT_AMOUNT, FINAL_AMOUNT, INVOICE_DATE
            FROM InvoiceDetails
            WHERE INVOICE_ID = '{InvoiceID}'";

                DataTable dtDetails = DbConnection.ExecuteQueryTable(detailsQuery);
                if (dtDetails == null || dtDetails.Rows.Count == 0) return;

                DataRow drDetails = dtDetails.Rows[0];

                string customerName = drDetails["CUSTOMER_NAME"].ToString();
                string customerMobile = drDetails["CUSTOMER_MOBILE"].ToString();
                decimal totalAmount = Convert.ToDecimal(drDetails["TOTAL_AMOUNT"]);
                decimal discountAmount = Convert.ToDecimal(drDetails["DISCOUNT_AMOUNT"]);
                decimal finalAmount = Convert.ToDecimal(drDetails["FINAL_AMOUNT"]);
                DateTime invoiceDate = Convert.ToDateTime(drDetails["INVOICE_DATE"]);

                // ================= HEADER =================
                sb.AppendLine("================================================");
                sb.AppendLine("                FARM INVOICE MANAGER            ");
                sb.AppendLine("================================================");
                sb.AppendLine($"Invoice ID      : {InvoiceID}");
                sb.AppendLine($"Customer Name   : {customerName}");
                sb.AppendLine($"Customer Mobile : {customerMobile}");
                sb.AppendLine($"Date            : {invoiceDate:dd/MM/yyyy}");
                sb.AppendLine($"Time            : {invoiceDate:hh:mm:ss tt}");
                sb.AppendLine("================================================");
                sb.AppendLine("SL  ITEM                 QTY    PRICE     TOTAL");
                sb.AppendLine("------------------------------------------------");

                // ================= INVOICE ITEMS =================
                string itemsQuery = $@"
        SELECT P.PRODUCT_NAME, I.QUANTITY, I.UNIT_PRICE, I.SUB_TOTAL
        FROM InvoiceItems I
        INNER JOIN ProductInfo P ON I.PRODUCT_ID = P.PRODUCT_ID
        WHERE I.INVOICE_ID = '{InvoiceID}'";

                DataTable dtItems = DbConnection.ExecuteQueryTable(itemsQuery);

                int sl = 1;
                foreach (DataRow row in dtItems.Rows)
                {
                    string name = row["PRODUCT_NAME"].ToString();
                    string qty = row["QUANTITY"].ToString();
                    string price = Convert.ToDecimal(row["UNIT_PRICE"]).ToString("0.00");
                    string subTotal = Convert.ToDecimal(row["SUB_TOTAL"]).ToString("0.00");

                    sb.AppendLine(
                        $"{sl.ToString().PadLeft(2)}  " +
                        $"{name.PadRight(20)}" +
                        $"{qty.PadLeft(5)}" +
                        $"{price.PadLeft(9)}" +
                        $"{subTotal.PadLeft(10)}"
                    );

                    sl++;
                }

                // ================= TOTAL SECTION =================
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"{"Total Amount",-32}{totalAmount,16:0.00}");
                sb.AppendLine($"{"Discount",-32}{discountAmount,16:0.00}");
                sb.AppendLine("------------------------------------------------");
                sb.AppendLine($"{"Final Amount",-32}{finalAmount,16:0.00}");
                sb.AppendLine("================================================");
                sb.AppendLine("           Thank you for your purchase!         ");
                sb.AppendLine("================================================");

                txtInvoice.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error has occurred while generating the invoice.\n" + ex.Message);

            }
        }




        private void button1_Click(object sender, EventArgs e)
        {
            if (this.SalesReport != null)
            {
                this.Visible = false;
                this.SalesReport.Visible = true;
            }
            if (this.AddSales != null)
            {
                this.Visible = false;
                this.AddSales.Visible = true;
            }
        }

        private void FormInvoicePrint_FormClosing(object sender, FormClosingEventArgs e)
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
