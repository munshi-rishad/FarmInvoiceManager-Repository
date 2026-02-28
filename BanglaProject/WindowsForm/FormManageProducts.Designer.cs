namespace BanglaProject
{
    partial class FormManageProducts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManageProducts));
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleNameAdmin = new System.Windows.Forms.Panel();
            this.labelTitleControlDashboard = new System.Windows.Forms.Label();
            this.lblAdminName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.lblTable = new System.Windows.Forms.Label();
            this.lblsearch = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvProductInfo = new System.Windows.Forms.DataGridView();
            this.PRODUCT_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRODUCT_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CATEGORY_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UNITPRICE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATED_DATE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IS_AVAILABLE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CREATED_BY_USER_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTitleNameAdmin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.pnlTable.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(27, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Billing Management";
            // 
            // panelTitleNameAdmin
            // 
            this.panelTitleNameAdmin.BackColor = System.Drawing.Color.LemonChiffon;
            this.panelTitleNameAdmin.Controls.Add(this.label2);
            this.panelTitleNameAdmin.Controls.Add(this.labelTitleControlDashboard);
            this.panelTitleNameAdmin.Location = new System.Drawing.Point(75, 21);
            this.panelTitleNameAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleNameAdmin.Name = "panelTitleNameAdmin";
            this.panelTitleNameAdmin.Size = new System.Drawing.Size(186, 45);
            this.panelTitleNameAdmin.TabIndex = 2;
            // 
            // labelTitleControlDashboard
            // 
            this.labelTitleControlDashboard.AutoSize = true;
            this.labelTitleControlDashboard.BackColor = System.Drawing.Color.LemonChiffon;
            this.labelTitleControlDashboard.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleControlDashboard.ForeColor = System.Drawing.Color.Firebrick;
            this.labelTitleControlDashboard.Location = new System.Drawing.Point(8, 5);
            this.labelTitleControlDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitleControlDashboard.Name = "labelTitleControlDashboard";
            this.labelTitleControlDashboard.Size = new System.Drawing.Size(171, 20);
            this.labelTitleControlDashboard.TabIndex = 3;
            this.labelTitleControlDashboard.Text = "Farm Invoice Manager";
            // 
            // lblAdminName
            // 
            this.lblAdminName.AutoSize = true;
            this.lblAdminName.BackColor = System.Drawing.Color.Transparent;
            this.lblAdminName.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAdminName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblAdminName.Location = new System.Drawing.Point(5, 14);
            this.lblAdminName.Name = "lblAdminName";
            this.lblAdminName.Size = new System.Drawing.Size(167, 25);
            this.lblAdminName.TabIndex = 26;
            this.lblAdminName.Text = "Welcome,Admin";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Ivory;
            this.panel2.Controls.Add(this.lblAdminName);
            this.panel2.Location = new System.Drawing.Point(439, 21);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 45);
            this.panel2.TabIndex = 27;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Controls.Add(this.btnAddProduct);
            this.panel4.Location = new System.Drawing.Point(236, 87);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 51);
            this.panel4.TabIndex = 40;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.LightGray;
            this.panel10.Controls.Add(this.btnDelete);
            this.panel10.Location = new System.Drawing.Point(484, 87);
            this.panel10.Margin = new System.Windows.Forms.Padding(2);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(120, 51);
            this.panel10.TabIndex = 41;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(4, 10);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(236, 28);
            this.txtSearch.TabIndex = 44;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.LightGray;
            this.panel11.Controls.Add(this.label1);
            this.panel11.Controls.Add(this.txtSearch);
            this.panel11.Location = new System.Drawing.Point(739, 85);
            this.panel11.Margin = new System.Windows.Forms.Padding(2);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(242, 61);
            this.panel11.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(10, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 13);
            this.label1.TabIndex = 45;
            this.label1.Text = "Search by Product Id And Product Name";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.LightGray;
            this.panel12.Controls.Add(this.btnShowAll);
            this.panel12.Location = new System.Drawing.Point(608, 87);
            this.panel12.Margin = new System.Windows.Forms.Padding(2);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(131, 51);
            this.panel12.TabIndex = 43;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(360, 87);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(120, 51);
            this.panel3.TabIndex = 39;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.pnlTable);
            this.panel1.Controls.Add(this.panel12);
            this.panel1.Controls.Add(this.panel11);
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panelTitleNameAdmin);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1010, 730);
            this.panel1.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LightGray;
            this.panel6.Controls.Add(this.btnBack);
            this.panel6.Location = new System.Drawing.Point(43, 87);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(120, 51);
            this.panel6.TabIndex = 48;
            // 
            // pnlTable
            // 
            this.pnlTable.BackColor = System.Drawing.Color.White;
            this.pnlTable.Controls.Add(this.lblTable);
            this.pnlTable.Controls.Add(this.lblsearch);
            this.pnlTable.Controls.Add(this.pnlGrid);
            this.pnlTable.Location = new System.Drawing.Point(43, 160);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(945, 548);
            this.pnlTable.TabIndex = 46;
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.BackColor = System.Drawing.Color.White;
            this.lblTable.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.ForeColor = System.Drawing.Color.IndianRed;
            this.lblTable.Location = new System.Drawing.Point(343, 10);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(225, 30);
            this.lblTable.TabIndex = 26;
            this.lblTable.Text = "Product Information";
            // 
            // lblsearch
            // 
            this.lblsearch.AutoSize = true;
            this.lblsearch.BackColor = System.Drawing.Color.White;
            this.lblsearch.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsearch.ForeColor = System.Drawing.Color.Black;
            this.lblsearch.Location = new System.Drawing.Point(2, 36);
            this.lblsearch.Name = "lblsearch";
            this.lblsearch.Size = new System.Drawing.Size(49, 15);
            this.lblsearch.TabIndex = 47;
            this.lblsearch.Text = "Search ";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Controls.Add(this.dgvProductInfo);
            this.pnlGrid.Location = new System.Drawing.Point(0, 54);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(942, 445);
            this.pnlGrid.TabIndex = 45;
            // 
            // dgvProductInfo
            // 
            this.dgvProductInfo.AllowUserToAddRows = false;
            this.dgvProductInfo.AllowUserToDeleteRows = false;
            this.dgvProductInfo.AllowUserToResizeColumns = false;
            this.dgvProductInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductInfo.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.InactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvProductInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PRODUCT_ID,
            this.PRODUCT_NAME,
            this.QUANTITY,
            this.CATEGORY_NAME,
            this.UNITPRICE,
            this.CREATED_DATE,
            this.IS_AVAILABLE,
            this.CREATED_BY_USER_ID});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProductInfo.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvProductInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductInfo.GridColor = System.Drawing.Color.Black;
            this.dgvProductInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvProductInfo.Name = "dgvProductInfo";
            this.dgvProductInfo.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.CadetBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvProductInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvProductInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductInfo.Size = new System.Drawing.Size(942, 445);
            this.dgvProductInfo.TabIndex = 44;
            this.dgvProductInfo.DoubleClick += new System.EventHandler(this.dgvProductInfo_DoubleClick);
            // 
            // PRODUCT_ID
            // 
            this.PRODUCT_ID.DataPropertyName = "PRODUCT_ID";
            this.PRODUCT_ID.HeaderText = "PRODUCT ID";
            this.PRODUCT_ID.MinimumWidth = 6;
            this.PRODUCT_ID.Name = "PRODUCT_ID";
            this.PRODUCT_ID.ReadOnly = true;
            // 
            // PRODUCT_NAME
            // 
            this.PRODUCT_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PRODUCT_NAME.DataPropertyName = "PRODUCT_NAME";
            this.PRODUCT_NAME.FillWeight = 180F;
            this.PRODUCT_NAME.HeaderText = "PRODUCT NAME";
            this.PRODUCT_NAME.Name = "PRODUCT_NAME";
            this.PRODUCT_NAME.ReadOnly = true;
            // 
            // QUANTITY
            // 
            this.QUANTITY.DataPropertyName = "QUANTITY";
            this.QUANTITY.HeaderText = "STOCKS";
            this.QUANTITY.Name = "QUANTITY";
            this.QUANTITY.ReadOnly = true;
            // 
            // CATEGORY_NAME
            // 
            this.CATEGORY_NAME.DataPropertyName = "CATEGORY_NAME";
            this.CATEGORY_NAME.HeaderText = "CATAGORY";
            this.CATEGORY_NAME.Name = "CATEGORY_NAME";
            this.CATEGORY_NAME.ReadOnly = true;
            // 
            // UNITPRICE
            // 
            this.UNITPRICE.DataPropertyName = "UNITPRICE";
            this.UNITPRICE.HeaderText = "UNIT PRICE";
            this.UNITPRICE.Name = "UNITPRICE";
            this.UNITPRICE.ReadOnly = true;
            // 
            // CREATED_DATE
            // 
            this.CREATED_DATE.DataPropertyName = "CREATED_DATE";
            this.CREATED_DATE.HeaderText = "STORING DATE";
            this.CREATED_DATE.Name = "CREATED_DATE";
            this.CREATED_DATE.ReadOnly = true;
            // 
            // IS_AVAILABLE
            // 
            this.IS_AVAILABLE.DataPropertyName = "IS_AVAILABLE";
            this.IS_AVAILABLE.HeaderText = "AVAILABLE STATUS";
            this.IS_AVAILABLE.Name = "IS_AVAILABLE";
            this.IS_AVAILABLE.ReadOnly = true;
            // 
            // CREATED_BY_USER_ID
            // 
            this.CREATED_BY_USER_ID.DataPropertyName = "CREATED_BY_USER_ID";
            this.CREATED_BY_USER_ID.HeaderText = "CREATED_BY_USER_ID";
            this.CREATED_BY_USER_ID.Name = "CREATED_BY_USER_ID";
            this.CREATED_BY_USER_ID.ReadOnly = true;
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
            this.btnBack.Location = new System.Drawing.Point(2, 7);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnBack.Size = new System.Drawing.Size(113, 38);
            this.btnBack.TabIndex = 42;
            this.btnBack.Text = "Back";
            this.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackColor = System.Drawing.Color.DarkCyan;
            this.btnShowAll.FlatAppearance.BorderSize = 0;
            this.btnShowAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnShowAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnShowAll.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnShowAll.ForeColor = System.Drawing.Color.White;
            this.btnShowAll.Image = ((System.Drawing.Image)(resources.GetObject("btnShowAll.Image")));
            this.btnShowAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowAll.Location = new System.Drawing.Point(3, 5);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnShowAll.Size = new System.Drawing.Size(126, 43);
            this.btnShowAll.TabIndex = 42;
            this.btnShowAll.Text = "Refresh";
            this.btnShowAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowAll.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowAll.UseVisualStyleBackColor = false;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Firebrick;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(5, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(109, 43);
            this.btnDelete.TabIndex = 42;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAddProduct.FlatAppearance.BorderSize = 0;
            this.btnAddProduct.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnAddProduct.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnAddProduct.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnAddProduct.ForeColor = System.Drawing.Color.White;
            this.btnAddProduct.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProduct.Image")));
            this.btnAddProduct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddProduct.Location = new System.Drawing.Point(5, 5);
            this.btnAddProduct.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnAddProduct.Size = new System.Drawing.Size(109, 43);
            this.btnAddProduct.TabIndex = 42;
            this.btnAddProduct.Text = "Add";
            this.btnAddProduct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddProduct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddProduct.UseVisualStyleBackColor = false;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Teal;
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(3, 6);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(113, 43);
            this.btnUpdate.TabIndex = 42;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1010, 730);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormManageProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormManageProducts";
            this.Text = "FormManageProducts";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManageProducts_FormClosing);
            this.Load += new System.EventHandler(this.FormManageProducts_Load);
            this.panelTitleNameAdmin.ResumeLayout(false);
            this.panelTitleNameAdmin.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.pnlTable.ResumeLayout(false);
            this.pnlTable.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTitleNameAdmin;
        private System.Windows.Forms.Label labelTitleControlDashboard;
        private System.Windows.Forms.Label lblAdminName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvProductInfo;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblsearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRODUCT_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.DataGridViewTextBoxColumn CATEGORY_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn UNITPRICE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATED_DATE;
        private System.Windows.Forms.DataGridViewTextBoxColumn IS_AVAILABLE;
        private System.Windows.Forms.DataGridViewTextBoxColumn CREATED_BY_USER_ID;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnBack;
    }
}