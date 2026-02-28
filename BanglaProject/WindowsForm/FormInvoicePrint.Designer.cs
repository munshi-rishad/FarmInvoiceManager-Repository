namespace BanglaProject.WindowsForm
{
    partial class FormInvoicePrint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInvoicePrint));
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.panelTitleNameAdmin = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTitleControlDashboard = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelTitleNameAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.Location = new System.Drawing.Point(2, 1);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(0, 0);
            this.pnlInvoice.TabIndex = 18;
            // 
            // panelTitleNameAdmin
            // 
            this.panelTitleNameAdmin.BackColor = System.Drawing.Color.FloralWhite;
            this.panelTitleNameAdmin.Controls.Add(this.label2);
            this.panelTitleNameAdmin.Controls.Add(this.labelTitleControlDashboard);
            this.panelTitleNameAdmin.Location = new System.Drawing.Point(104, 5);
            this.panelTitleNameAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitleNameAdmin.Name = "panelTitleNameAdmin";
            this.panelTitleNameAdmin.Size = new System.Drawing.Size(151, 45);
            this.panelTitleNameAdmin.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FloralWhite;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(14, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Billing Management";
            // 
            // labelTitleControlDashboard
            // 
            this.labelTitleControlDashboard.AutoSize = true;
            this.labelTitleControlDashboard.BackColor = System.Drawing.Color.FloralWhite;
            this.labelTitleControlDashboard.Font = new System.Drawing.Font("Segoe UI Black", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelTitleControlDashboard.ForeColor = System.Drawing.Color.Firebrick;
            this.labelTitleControlDashboard.Location = new System.Drawing.Point(8, 5);
            this.labelTitleControlDashboard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTitleControlDashboard.Name = "labelTitleControlDashboard";
            this.labelTitleControlDashboard.Size = new System.Drawing.Size(142, 15);
            this.labelTitleControlDashboard.TabIndex = 3;
            this.labelTitleControlDashboard.Text = "Farm Invoice Manager";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoice.BackColor = System.Drawing.Color.White;
            this.txtInvoice.Font = new System.Drawing.Font("Courier New", 10F);
            this.txtInvoice.Location = new System.Drawing.Point(5, 57);
            this.txtInvoice.Multiline = true;
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.ReadOnly = true;
            this.txtInvoice.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInvoice.Size = new System.Drawing.Size(398, 469);
            this.txtInvoice.TabIndex = 22;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.BackColor = System.Drawing.Color.SkyBlue;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(235, 538);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 35);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPrint.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold);
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(74, 538);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 35);
            this.btnPrint.TabIndex = 20;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FloralWhite;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 580);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // FormInvoicePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 581);
            this.Controls.Add(this.pnlInvoice);
            this.Controls.Add(this.panelTitleNameAdmin);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormInvoicePrint";
            this.Text = "FormInvoicePrint";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInvoicePrint_FormClosing);
            this.Load += new System.EventHandler(this.FormInvoicePrint_Load);
            this.panelTitleNameAdmin.ResumeLayout(false);
            this.panelTitleNameAdmin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlInvoice;
        private System.Windows.Forms.Panel panelTitleNameAdmin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTitleControlDashboard;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}