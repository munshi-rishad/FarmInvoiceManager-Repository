namespace BanglaProject.WindowsForm
{
    partial class FromSalesReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FromSalesReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleNameAdmin = new System.Windows.Forms.Panel();
            this.labelTitleControlDashboard = new System.Windows.Forms.Label();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.INVOICE_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CUSTOMER_MOBILE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DISCOUNT_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FINAL_AMOUNT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INVOICE_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSalesReport = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblTotalSales = new System.Windows.Forms.Label();
            this.lblTotalInvoices = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeleteInvoice = new System.Windows.Forms.Button();
            this.lblASAmount = new System.Windows.Forms.Label();
            this.lblTSAmount = new System.Windows.Forms.Label();
            this.lblTIAmount = new System.Windows.Forms.Label();
            this.lblAvarageSales = new System.Windows.Forms.Label();
            this.grbSelectDate = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.PRODUCT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNITPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TOTAL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearchCustomer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTitleNameAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.grbSelectDate.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Billing Management";
            // 
            // panelTitleNameAdmin
            // 
            this.panelTitleNameAdmin.BackColor = System.Drawing.Color.White;
            this.panelTitleNameAdmin.Controls.Add(this.label2);
            this.panelTitleNameAdmin.Controls.Add(this.labelTitleControlDashboard);
            this.panelTitleNameAdmin.Location = new System.Drawing.Point(816, 14);
            this.panelTitleNameAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleNameAdmin.Name = "panelTitleNameAdmin";
            this.panelTitleNameAdmin.Size = new System.Drawing.Size(159, 35);
            this.panelTitleNameAdmin.TabIndex = 3;
            // 
            // labelTitleControlDashboard
            // 
            this.labelTitleControlDashboard.AutoSize = true;
            this.labelTitleControlDashboard.BackColor = System.Drawing.Color.White;
            this.labelTitleControlDashboard.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelTitleControlDashboard.ForeColor = System.Drawing.Color.Firebrick;
            this.labelTitleControlDashboard.Location = new System.Drawing.Point(8, 4);
            this.labelTitleControlDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitleControlDashboard.Name = "labelTitleControlDashboard";
            this.labelTitleControlDashboard.Size = new System.Drawing.Size(142, 15);
            this.labelTitleControlDashboard.TabIndex = 3;
            this.labelTitleControlDashboard.Text = "Farm Invoice Manager";
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowUserToAddRows = false;
            this.dgvInvoices.AllowUserToDeleteRows = false;
            this.dgvInvoices.AllowUserToResizeColumns = false;
            this.dgvInvoices.AllowUserToResizeRows = false;
            this.dgvInvoices.BackgroundColor = System.Drawing.Color.White;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INVOICE_ID,
            this.USER_ID,
            this.CUSTOMER_ID,
            this.CUSTOMER_NAME,
            this.CUSTOMER_MOBILE,
            this.TOTAL_AMOUNT,
            this.DISCOUNT_AMOUNT,
            this.FINAL_AMOUNT,
            this.INVOICE_DATE});
            this.dgvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoices.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoices.Margin = new System.Windows.Forms.Padding(2);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.RowHeadersWidth = 51;
            this.dgvInvoices.RowTemplate.Height = 24;
            this.dgvInvoices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoices.Size = new System.Drawing.Size(953, 195);
            this.dgvInvoices.TabIndex = 0;
            // 
            // INVOICE_ID
            // 
            this.INVOICE_ID.DataPropertyName = "INVOICE_ID";
            this.INVOICE_ID.FillWeight = 80F;
            this.INVOICE_ID.HeaderText = "INVOICE ID";
            this.INVOICE_ID.Name = "INVOICE_ID";
            this.INVOICE_ID.ReadOnly = true;
            // 
            // USER_ID
            // 
            this.USER_ID.DataPropertyName = "USER_ID";
            this.USER_ID.FillWeight = 80F;
            this.USER_ID.HeaderText = "USER ID";
            this.USER_ID.Name = "USER_ID";
            this.USER_ID.ReadOnly = true;
            // 
            // CUSTOMER_ID
            // 
            this.CUSTOMER_ID.DataPropertyName = "CUSTOMER_ID";
            this.CUSTOMER_ID.FillWeight = 80F;
            this.CUSTOMER_ID.HeaderText = "CUSTOMER ID";
            this.CUSTOMER_ID.Name = "CUSTOMER_ID";
            this.CUSTOMER_ID.ReadOnly = true;
            this.CUSTOMER_ID.Width = 120;
            // 
            // CUSTOMER_NAME
            // 
            this.CUSTOMER_NAME.DataPropertyName = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.FillWeight = 120F;
            this.CUSTOMER_NAME.HeaderText = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.Name = "CUSTOMER_NAME";
            this.CUSTOMER_NAME.ReadOnly = true;
            this.CUSTOMER_NAME.Width = 120;
            // 
            // CUSTOMER_MOBILE
            // 
            this.CUSTOMER_MOBILE.DataPropertyName = "CUSTOMER_MOBILE";
            this.CUSTOMER_MOBILE.FillWeight = 120F;
            this.CUSTOMER_MOBILE.HeaderText = "CUSTOMER_MOBILE";
            this.CUSTOMER_MOBILE.Name = "CUSTOMER_MOBILE";
            this.CUSTOMER_MOBILE.ReadOnly = true;
            this.CUSTOMER_MOBILE.Width = 120;
            // 
            // TOTAL_AMOUNT
            // 
            this.TOTAL_AMOUNT.DataPropertyName = "TOTAL_AMOUNT";
            this.TOTAL_AMOUNT.HeaderText = "AMOUNT";
            this.TOTAL_AMOUNT.Name = "TOTAL_AMOUNT";
            this.TOTAL_AMOUNT.ReadOnly = true;
            // 
            // DISCOUNT_AMOUNT
            // 
            this.DISCOUNT_AMOUNT.DataPropertyName = "DISCOUNT_AMOUNT";
            this.DISCOUNT_AMOUNT.HeaderText = "DISCOUNT";
            this.DISCOUNT_AMOUNT.Name = "DISCOUNT_AMOUNT";
            this.DISCOUNT_AMOUNT.ReadOnly = true;
            // 
            // FINAL_AMOUNT
            // 
            this.FINAL_AMOUNT.DataPropertyName = "FINAL_AMOUNT";
            this.FINAL_AMOUNT.HeaderText = "FINAL AMOUNT";
            this.FINAL_AMOUNT.Name = "FINAL_AMOUNT";
            this.FINAL_AMOUNT.ReadOnly = true;
            // 
            // INVOICE_DATE
            // 
            this.INVOICE_DATE.DataPropertyName = "INVOICE_DATE";
            this.INVOICE_DATE.HeaderText = "INVOICE_DATE";
            this.INVOICE_DATE.Name = "INVOICE_DATE";
            this.INVOICE_DATE.ReadOnly = true;
            // 
            // lblSalesReport
            // 
            this.lblSalesReport.AutoSize = true;
            this.lblSalesReport.BackColor = System.Drawing.Color.White;
            this.lblSalesReport.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblSalesReport.ForeColor = System.Drawing.Color.Firebrick;
            this.lblSalesReport.Location = new System.Drawing.Point(456, 20);
            this.lblSalesReport.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSalesReport.Name = "lblSalesReport";
            this.lblSalesReport.Size = new System.Drawing.Size(99, 20);
            this.lblSalesReport.TabIndex = 9;
            this.lblSalesReport.Text = "Sales Report";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.CadetBlue;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(407, 19);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(88, 41);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTo.Location = new System.Drawing.Point(204, 35);
            this.lblTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(60, 17);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To Date:";
            // 
            // lblTotalSales
            // 
            this.lblTotalSales.AutoSize = true;
            this.lblTotalSales.BackColor = System.Drawing.Color.White;
            this.lblTotalSales.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblTotalSales.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblTotalSales.Location = new System.Drawing.Point(234, 174);
            this.lblTotalSales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSales.Name = "lblTotalSales";
            this.lblTotalSales.Size = new System.Drawing.Size(96, 21);
            this.lblTotalSales.TabIndex = 12;
            this.lblTotalSales.Text = "Total Sales";
            // 
            // lblTotalInvoices
            // 
            this.lblTotalInvoices.AutoSize = true;
            this.lblTotalInvoices.BackColor = System.Drawing.Color.White;
            this.lblTotalInvoices.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInvoices.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTotalInvoices.Location = new System.Drawing.Point(51, 174);
            this.lblTotalInvoices.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalInvoices.Name = "lblTotalInvoices";
            this.lblTotalInvoices.Size = new System.Drawing.Size(120, 21);
            this.lblTotalInvoices.TabIndex = 11;
            this.lblTotalInvoices.Text = "Total Invoices";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFromDate.Location = new System.Drawing.Point(85, 29);
            this.dtpFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(115, 23);
            this.dtpFromDate.TabIndex = 6;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(4, 31);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(77, 17);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "From Date:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F);
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpToDate.Location = new System.Drawing.Point(267, 30);
            this.dtpToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(131, 23);
            this.dtpToDate.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.BackColor = System.Drawing.Color.DarkCyan;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(827, 570);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(134, 41);
            this.btnRefresh.TabIndex = 20;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteInvoice.BackColor = System.Drawing.Color.Firebrick;
            this.btnDeleteInvoice.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnDeleteInvoice.ForeColor = System.Drawing.Color.White;
            this.btnDeleteInvoice.Location = new System.Drawing.Point(827, 640);
            this.btnDeleteInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(134, 41);
            this.btnDeleteInvoice.TabIndex = 20;
            this.btnDeleteInvoice.Text = "Delete Invoice";
            this.btnDeleteInvoice.UseVisualStyleBackColor = false;
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // lblASAmount
            // 
            this.lblASAmount.AutoSize = true;
            this.lblASAmount.BackColor = System.Drawing.Color.White;
            this.lblASAmount.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblASAmount.ForeColor = System.Drawing.Color.Salmon;
            this.lblASAmount.Location = new System.Drawing.Point(406, 208);
            this.lblASAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblASAmount.Name = "lblASAmount";
            this.lblASAmount.Size = new System.Drawing.Size(95, 21);
            this.lblASAmount.TabIndex = 16;
            this.lblASAmount.Text = "ASAmount";
            // 
            // lblTSAmount
            // 
            this.lblTSAmount.AutoSize = true;
            this.lblTSAmount.BackColor = System.Drawing.Color.White;
            this.lblTSAmount.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.lblTSAmount.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.lblTSAmount.Location = new System.Drawing.Point(235, 208);
            this.lblTSAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTSAmount.Name = "lblTSAmount";
            this.lblTSAmount.Size = new System.Drawing.Size(93, 21);
            this.lblTSAmount.TabIndex = 15;
            this.lblTSAmount.Text = "TSAmount";
            // 
            // lblTIAmount
            // 
            this.lblTIAmount.AutoSize = true;
            this.lblTIAmount.BackColor = System.Drawing.Color.White;
            this.lblTIAmount.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.lblTIAmount.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblTIAmount.Location = new System.Drawing.Point(90, 208);
            this.lblTIAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTIAmount.Name = "lblTIAmount";
            this.lblTIAmount.Size = new System.Drawing.Size(26, 21);
            this.lblTIAmount.TabIndex = 14;
            this.lblTIAmount.Text = "TI";
            // 
            // lblAvarageSales
            // 
            this.lblAvarageSales.AutoSize = true;
            this.lblAvarageSales.BackColor = System.Drawing.Color.White;
            this.lblAvarageSales.Font = new System.Drawing.Font("Segoe UI Black", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))));
            this.lblAvarageSales.ForeColor = System.Drawing.Color.LightCoral;
            this.lblAvarageSales.Location = new System.Drawing.Point(391, 174);
            this.lblAvarageSales.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvarageSales.Name = "lblAvarageSales";
            this.lblAvarageSales.Size = new System.Drawing.Size(122, 21);
            this.lblAvarageSales.TabIndex = 13;
            this.lblAvarageSales.Text = "Avarage Sales";
            // 
            // grbSelectDate
            // 
            this.grbSelectDate.BackColor = System.Drawing.Color.FloralWhite;
            this.grbSelectDate.Controls.Add(this.btnSearch);
            this.grbSelectDate.Controls.Add(this.lblFrom);
            this.grbSelectDate.Controls.Add(this.lblTo);
            this.grbSelectDate.Controls.Add(this.dtpFromDate);
            this.grbSelectDate.Controls.Add(this.dtpToDate);
            this.grbSelectDate.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.grbSelectDate.Location = new System.Drawing.Point(31, 59);
            this.grbSelectDate.Margin = new System.Windows.Forms.Padding(2);
            this.grbSelectDate.Name = "grbSelectDate";
            this.grbSelectDate.Padding = new System.Windows.Forms.Padding(2);
            this.grbSelectDate.Size = new System.Drawing.Size(495, 69);
            this.grbSelectDate.TabIndex = 10;
            this.grbSelectDate.TabStop = false;
            this.grbSelectDate.Text = "Select Date";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.txtSearchCustomer);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lblSearch);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblInvoice);
            this.panel1.Controls.Add(this.chartSales);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDeleteInvoice);
            this.panel1.Controls.Add(this.lblASAmount);
            this.panel1.Controls.Add(this.lblTSAmount);
            this.panel1.Controls.Add(this.lblTIAmount);
            this.panel1.Controls.Add(this.lblAvarageSales);
            this.panel1.Controls.Add(this.lblTotalSales);
            this.panel1.Controls.Add(this.lblTotalInvoices);
            this.panel1.Controls.Add(this.grbSelectDate);
            this.panel1.Controls.Add(this.lblSalesReport);
            this.panel1.Controls.Add(this.panelTitleNameAdmin);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 730);
            this.panel1.TabIndex = 4;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.SkyBlue;
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(31, 9);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnBack.Size = new System.Drawing.Size(113, 38);
            this.btnBack.TabIndex = 71;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(30, 540);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 20);
            this.label4.TabIndex = 70;
            this.label4.Text = "Invoices Details";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.dgvInvoiceDetails);
            this.panel3.Location = new System.Drawing.Point(29, 563);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(741, 155);
            this.panel3.TabIndex = 69;
            // 
            // dgvInvoiceDetails
            // 
            this.dgvInvoiceDetails.AllowUserToAddRows = false;
            this.dgvInvoiceDetails.AllowUserToDeleteRows = false;
            this.dgvInvoiceDetails.AllowUserToResizeColumns = false;
            this.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvInvoiceDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_ID,
            this.PRODUCT_NAME,
            this.UNITPRICE,
            this.PRODUCT_QUANTITY,
            this.TOTAL});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvInvoiceDetails.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceDetails.GridColor = System.Drawing.Color.Black;
            this.dgvInvoiceDetails.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceDetails.Name = "dgvInvoiceDetails";
            this.dgvInvoiceDetails.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvInvoiceDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(741, 155);
            this.dgvInvoiceDetails.TabIndex = 45;
            // 
            // PRODUCT_ID
            // 
            this.PRODUCT_ID.DataPropertyName = "PRODUCT_ID";
            this.PRODUCT_ID.HeaderText = "PRODUCT ID";
            this.PRODUCT_ID.Name = "PRODUCT_ID";
            this.PRODUCT_ID.ReadOnly = true;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.HeaderText = "PRODUCT NAME";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            // 
            // UNITPRICE
            // 
            this.UNITPRICE.DataPropertyName = "UNIT_PRICE";
            this.UNITPRICE.HeaderText = "UNIT PRICE";
            this.UNITPRICE.Name = "UNITPRICE";
            this.UNITPRICE.ReadOnly = true;
            // 
            // PRODUCT_QUANTITY
            // 
            this.PRODUCT_QUANTITY.DataPropertyName = "QUANTITY";
            this.PRODUCT_QUANTITY.HeaderText = "QUANTITY";
            this.PRODUCT_QUANTITY.Name = "PRODUCT_QUANTITY";
            this.PRODUCT_QUANTITY.ReadOnly = true;
            // 
            // TOTAL
            // 
            this.TOTAL.DataPropertyName = "SUB_TOTAL";
            this.TOTAL.HeaderText = "SUB TOTAL";
            this.TOTAL.Name = "TOTAL";
            this.TOTAL.ReadOnly = true;
            // 
            // txtSearchCustomer
            // 
            this.txtSearchCustomer.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchCustomer.Location = new System.Drawing.Point(795, 282);
            this.txtSearchCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearchCustomer.Multiline = true;
            this.txtSearchCustomer.Name = "txtSearchCustomer";
            this.txtSearchCustomer.Size = new System.Drawing.Size(186, 23);
            this.txtSearchCustomer.TabIndex = 68;
            this.txtSearchCustomer.TextChanged += new System.EventHandler(this.txtSearchCustomer_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(800, 308);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Search by Customer Number";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.BackColor = System.Drawing.Color.White;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.Black;
            this.lblSearch.Location = new System.Drawing.Point(31, 306);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(49, 15);
            this.lblSearch.TabIndex = 66;
            this.lblSearch.Text = "Search ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FloralWhite;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(37, 145);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Summary";
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.BackColor = System.Drawing.Color.White;
            this.lblInvoice.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.ForeColor = System.Drawing.Color.Black;
            this.lblInvoice.Location = new System.Drawing.Point(30, 282);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(98, 20);
            this.lblInvoice.TabIndex = 65;
            this.lblInvoice.Text = "Invoices List";
            // 
            // chartSales
            // 
            this.chartSales.BackColor = System.Drawing.Color.FloralWhite;
            this.chartSales.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea2.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea2);
            this.chartSales.Enabled = false;
            legend2.Name = "Legend1";
            this.chartSales.Legends.Add(legend2);
            this.chartSales.Location = new System.Drawing.Point(550, 59);
            this.chartSales.Name = "chartSales";
            this.chartSales.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartSales.Series.Add(series2);
            this.chartSales.Size = new System.Drawing.Size(431, 212);
            this.chartSales.TabIndex = 21;
            this.chartSales.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgvInvoices);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.panel2.Location = new System.Drawing.Point(28, 323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(953, 195);
            this.panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1010, 730);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FromSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FromSalesReport";
            this.Text = "FromSalesReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FromSalesReport_FormClosing);
            this.Load += new System.EventHandler(this.FromSalesReport_Load);
            this.panelTitleNameAdmin.ResumeLayout(false);
            this.panelTitleNameAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.grbSelectDate.ResumeLayout(false);
            this.grbSelectDate.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTitleNameAdmin;
        private System.Windows.Forms.Label labelTitleControlDashboard;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Label lblSalesReport;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblTotalSales;
        private System.Windows.Forms.Label lblTotalInvoices;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeleteInvoice;
        private System.Windows.Forms.Label lblASAmount;
        private System.Windows.Forms.Label lblTSAmount;
        private System.Windows.Forms.Label lblTIAmount;
        private System.Windows.Forms.Label lblAvarageSales;
        private System.Windows.Forms.GroupBox grbSelectDate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn USER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn CUSTOMER_MOBILE;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DISCOUNT_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn FINAL_AMOUNT;
        private System.Windows.Forms.DataGridViewTextBoxColumn INVOICE_DATE;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearchCustomer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNITPRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn TOTAL;
    }
}