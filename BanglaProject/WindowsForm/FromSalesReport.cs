using BanglaProject.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BanglaProject.WindowsForm
{
    public partial class FromSalesReport : Form
    {
        public FromSalesReport()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.dgvInvoices.SelectionChanged += dgvInvoices_SelectionChanged;
            this.dgvInvoices.CellClick += dgvInvoices_CellClick;

        }

        private FormAdminView AdminView { get; set; }
        private FormManageProducts ManageProducts { get; set; }
        private FormEmployee Employee { get; set; }
        private DataBaseConnection DbConnection { get; set; }

        public FromSalesReport(DataBaseConnection DbConnection, FormAdminView adminView) : this()
        {
            this.DbConnection = DbConnection;
            this.AdminView = adminView;
            this.PopulateGridView();
            this.CalculateTotal();
            dgvInvoiceDetails.ClearSelection();
            dgvInvoices.ClearSelection();
        }
        

        public FromSalesReport(DataBaseConnection DbConnection, FormEmployee employee) : this()
        {
            this.DbConnection = DbConnection;
            this.Employee = employee;
            this.PopulateGridView();
            this.CalculateTotal();
            dgvInvoiceDetails.ClearSelection();
            dgvInvoices.ClearSelection();
        }
       

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (this.AdminView != null)
            {
                this.Visible = false;
                this.AdminView.Visible = true;
            }
            else if (this.Employee != null)
            {
                this.Visible = false;
                this.Employee.Visible = true;
            }
            else if (this.ManageProducts != null)
            {
                this.Visible = false;
                this.ManageProducts.Visible = true;
            }


        }

        private void PopulateGridView(string sql = "select * from InvoiceDetails;")
        {
            try
            {
                var dataset = this.DbConnection.ExecuteQuery(sql);

                this.dgvInvoices.AutoGenerateColumns = false;


                this.dgvInvoices.DataSource = dataset.Tables[0];

                dgvInvoices.ClearSelection();
                this.dgvInvoices.CurrentCell = null;


            }
            catch (Exception exc)
            {
                MessageBox.Show("An error has occurred in the database system, please try again.\n" + exc.Message);
            }


        }
        private void LoadSalesChart(string fromDate = null, string toDate = null)
        {
            chartSales.Series.Clear();
            chartSales.ChartAreas.Clear();
            chartSales.Titles.Clear();

            chartSales.ChartAreas.Add("Main");

            Series s = new Series("Sales");
            s.ChartType = SeriesChartType.Column;
            s.IsValueShownAsLabel = true;
            chartSales.Series.Add(s);

            string sql;

            if (string.IsNullOrEmpty(fromDate) || string.IsNullOrEmpty(toDate))
            {
                sql =
                    "SELECT INVOICE_DATE, SUM(CAST(FINAL_AMOUNT AS float)) AS TotalSales " +
                    "FROM InvoiceDetails " +
                    "GROUP BY INVOICE_DATE " +
                    "ORDER BY INVOICE_DATE;";
            }
            else
            {
                sql =
                    "SELECT INVOICE_DATE, SUM(CAST(FINAL_AMOUNT AS float)) AS TotalSales " +
                    "FROM InvoiceDetails " +
                    "WHERE INVOICE_DATE >= '" + fromDate + "' " +
                    "AND INVOICE_DATE <= '" + toDate + "' " +
                    "GROUP BY INVOICE_DATE " +
                    "ORDER BY INVOICE_DATE;";
            }

            DataTable dt = DbConnection.ExecuteQueryTable(sql);

            foreach (DataRow row in dt.Rows)
            {
                s.Points.AddXY(
                    Convert.ToDateTime(row["INVOICE_DATE"]).ToString("dd-MMM"),
                    Convert.ToDouble(row["TotalSales"])
                );
            }

            chartSales.Titles.Add("Sales Overview");
        }


        private void ApplyChartFonts()
        {
            Font titleFont = new Font("Segoe UI", 13, FontStyle.Bold);
            Font axisFont = new Font("Segoe UI", 8, FontStyle.Bold);
            Font valueFont = new Font("Segoe UI", 8, FontStyle.Bold);
            Font legendFont = new Font("Segoe UI", 8, FontStyle.Bold);

            foreach (ChartArea area in chartSales.ChartAreas)
            {
                area.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.None;
                area.AxisY.LabelAutoFitStyle = LabelAutoFitStyles.None;

                area.AxisX.LabelStyle.Font = axisFont;
                area.AxisY.LabelStyle.Font = axisFont;
                area.AxisX.TitleFont = axisFont;
                area.AxisY.TitleFont = axisFont;
            }

            foreach (Series s in chartSales.Series)
            {
                s.Font = valueFont;
                s.IsValueShownAsLabel = true;
            }

            foreach (Legend l in chartSales.Legends)
            {
                l.Font = legendFont;
                l.IsTextAutoFit = false;
            }

            foreach (Title t in chartSales.Titles)
            {
                t.Font = titleFont;
            }
        }










        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            FormInvoicePrint formInvoicePrint = new FormInvoicePrint(this.DbConnection, this);
            this.Visible = false;
            formInvoicePrint.Visible = true;
        }

        private void CalculateTotal()
        {
            int totalInvoices = dgvInvoices.Rows.Count;
            this.lblTIAmount.Text =  totalInvoices.ToString();
            double totalAmount = 0;
            foreach (DataGridViewRow row in dgvInvoices.Rows)
            {
                totalAmount += Convert.ToDouble(row.Cells["FINAL_AMOUNT"].Value);
            }
            this.lblTSAmount.Text = "Tk " + totalAmount.ToString("N2");

            double AverageAmount = totalInvoices == 0 ? 0 : totalAmount / totalInvoices;
            this.lblASAmount.Text = "Tk " + AverageAmount.ToString("N2");


        }

      

        private void FromSalesReport_Load(object sender, EventArgs e)
        {
            dgvInvoices.AutoGenerateColumns = false;

            PopulateGridView();
            CalculateTotal();

            LoadSalesChart();
            ApplyChartFonts();

       
            dgvInvoices.ClearSelection();
            dgvInvoiceDetails.ClearSelection();
            dgvInvoices.CurrentCell = null;

            lblSearch.Text = "";
            lblSearch.Visible = false;

        }

        private void FromSalesReport_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fromDate = dtpFromDate.Value.ToString("MM/dd/yyyy");
            string toDate = dtpToDate.Value.ToString("MM/dd/yyyy");

            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("From Date >! To Date");
                return;
            }

            string sql =
                "SELECT * FROM InvoiceDetails " +
                "WHERE INVOICE_DATE >= '" + fromDate + "' " +
                "AND INVOICE_DATE <= '" + toDate + "' " +
                "ORDER BY INVOICE_DATE;";


            PopulateGridView(sql);


            CalculateTotal();


            LoadSalesChart(fromDate, toDate);
            ApplyChartFonts();
        }
        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            dgvInvoices.Rows[e.RowIndex].Selected = true;
            ShowSelectedInvoiceOnLabel();
        }

        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            ShowSelectedInvoiceOnLabel();
        }

        private void ShowSelectedInvoiceOnLabel()
        {
            if (dgvInvoices.SelectedRows.Count == 1)
            {
                string invoiceId = dgvInvoices.SelectedRows[0].Cells["INVOICE_ID"].Value?.ToString() ?? "";
                string customerName = dgvInvoices.SelectedRows[0].Cells["CUSTOMER_NAME"].Value?.ToString() ?? "";

                lblSearch.Text = "Selected: " + invoiceId + " - " + customerName;
                lblSearch.ForeColor = Color.Green;
                lblSearch.Visible = true;

                string sql = $@"select PRODUCT_ID, PRODUCT_NAME, QUANTITY, UNIT_PRICE,
                        SUB_TOTAL from InvoiceItems
                        where INVOICE_ID = '{invoiceId}'";
                try
                {
                    var dataset = this.DbConnection.ExecuteQuery(sql);

                    this.dgvInvoiceDetails.AutoGenerateColumns = false;
                    this.dgvInvoiceDetails.DataSource = dataset.Tables[0];

                    dgvInvoiceDetails.ClearSelection();

                }
                catch (Exception exc)
                {
                    MessageBox.Show("An error has occurred in the database system, please try again.\n" + exc.Message);
                }
            }
            else
            {
                lblSearch.Text = "";
                lblSearch.Visible = false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            PopulateGridView();    
            CalculateTotal();        
            LoadSalesChart();   
            ApplyChartFonts();

            dgvInvoices.ClearSelection();
            dgvInvoices.CurrentCell = null;

            lblSearch.Text = "";
            lblSearch.Visible = false;
            txtSearchCustomer.Text = "";
        }

        private void txtSearchCustomer_TextChanged(object sender, EventArgs e)
        {
            string mobile = txtSearchCustomer.Text.Trim();

            if (string.IsNullOrEmpty(mobile))
            {
                PopulateGridView();
                dgvInvoices.ClearSelection();
                dgvInvoices.CurrentCell = null;

                lblSearch.Text = "";
                lblSearch.Visible = false;
                return;
            }

            string safe = mobile.Replace("'", "''");

            string sql =
                "SELECT * FROM InvoiceDetails " +
                "WHERE CUSTOMER_MOBILE LIKE '%" + safe + "%' " +
                "ORDER BY INVOICE_DATE;";

            PopulateGridView(sql);

            dgvInvoices.ClearSelection();
            dgvInvoices.CurrentCell = null;

            int count = dgvInvoices.Rows.Count;
            if (dgvInvoices.AllowUserToAddRows) count--;

            if (count > 0)
            {
                lblSearch.Text = "Found";
                lblSearch.ForeColor = Color.Green;
                lblSearch.Visible = true;
            }
            else
            {
                lblSearch.Text = "Not Found";
                lblSearch.ForeColor = Color.Red;
                lblSearch.Visible = true;
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (this.AdminView != null)
            {
                this.Visible = false;
                this.AdminView.Visible = true;
            }
            else if (this.Employee != null)
            {
                this.Visible = false;
                this.Employee.Visible = true;
            }
            else if (this.ManageProducts != null)
            {
                this.Visible = false;
                this.ManageProducts.Visible = true;
            }

        }

        private void btnDeleteInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count == 1)
            {
                string invoiceId = dgvInvoices.SelectedRows[0].Cells["INVOICE_ID"].Value?.ToString() ?? "";
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete Invoice ID: " + invoiceId + "?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        string deleteItemsSql = $"DELETE FROM InvoiceItems WHERE INVOICE_ID = '{invoiceId}';";
                        string deleteDetailsSql = $"DELETE FROM InvoiceDetails WHERE INVOICE_ID = '{invoiceId}';";
                        this.DbConnection.ExecuteDMLQuery(deleteItemsSql);
                        this.DbConnection.ExecuteDMLQuery(deleteDetailsSql);
                        MessageBox.Show("Invoice deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PopulateGridView();
                        CalculateTotal();
                        LoadSalesChart();
                        ApplyChartFonts();
                        dgvInvoices.ClearSelection();
                        dgvInvoices.CurrentCell = null;
                        lblSearch.Text = "";
                        lblSearch.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error has occurred while deleting the invoice. Please try again.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                else {
                    MessageBox.Show("Please Select 1 row to Delete" , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
    }
}
