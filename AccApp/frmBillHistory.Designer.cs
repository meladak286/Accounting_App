namespace AccApp
{
    partial class frmBillHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvBill = new System.Windows.Forms.DataGridView();
            this.dgvBillProducts = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBillTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBillDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteBill = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBill
            // 
            this.dgvBill.AllowUserToAddRows = false;
            this.dgvBill.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvBill.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBill.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBill.BackgroundColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.colCustomerName,
            this.colBillTotal,
            this.colBillDate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBill.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvBill.EnableHeadersVisualStyles = false;
            this.dgvBill.GridColor = System.Drawing.Color.Navy;
            this.dgvBill.Location = new System.Drawing.Point(0, 0);
            this.dgvBill.MultiSelect = false;
            this.dgvBill.Name = "dgvBill";
            this.dgvBill.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBill.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBill.RowHeadersWidth = 51;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBill.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBill.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBill.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MidnightBlue;
            this.dgvBill.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBill.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvBill.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Navy;
            this.dgvBill.RowTemplate.Height = 26;
            this.dgvBill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBill.Size = new System.Drawing.Size(1050, 251);
            this.dgvBill.TabIndex = 81;
            this.dgvBill.Tag = "BillHistory";
            this.dgvBill.VirtualMode = true;
            this.dgvBill.SelectionChanged += new System.EventHandler(this.dgvBill_SelectionChanged);
            // 
            // dgvBillProducts
            // 
            this.dgvBillProducts.AllowUserToAddRows = false;
            this.dgvBillProducts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.dgvBillProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBillProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBillProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBillProducts.BackgroundColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvBillProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductName,
            this.Column2,
            this.Column3,
            this.ColProductQty,
            this.ColProductPrice,
            this.ColProductTotalPrice});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBillProducts.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvBillProducts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvBillProducts.EnableHeadersVisualStyles = false;
            this.dgvBillProducts.GridColor = System.Drawing.Color.Navy;
            this.dgvBillProducts.Location = new System.Drawing.Point(0, 321);
            this.dgvBillProducts.MultiSelect = false;
            this.dgvBillProducts.Name = "dgvBillProducts";
            this.dgvBillProducts.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Arial", 14F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBillProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvBillProducts.RowHeadersWidth = 51;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBillProducts.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvBillProducts.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvBillProducts.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MidnightBlue;
            this.dgvBillProducts.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgvBillProducts.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.SkyBlue;
            this.dgvBillProducts.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Navy;
            this.dgvBillProducts.RowTemplate.Height = 26;
            this.dgvBillProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBillProducts.Size = new System.Drawing.Size(1050, 200);
            this.dgvBillProducts.TabIndex = 82;
            this.dgvBillProducts.Tag = "";
            this.dgvBillProducts.VirtualMode = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "bid";
            this.Column1.HeaderText = "Column1";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // colCustomerName
            // 
            this.colCustomerName.DataPropertyName = "cname";
            this.colCustomerName.HeaderText = "Customer Name";
            this.colCustomerName.MinimumWidth = 6;
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.ReadOnly = true;
            // 
            // colBillTotal
            // 
            this.colBillTotal.DataPropertyName = "total";
            this.colBillTotal.HeaderText = "Total";
            this.colBillTotal.MinimumWidth = 6;
            this.colBillTotal.Name = "colBillTotal";
            this.colBillTotal.ReadOnly = true;
            // 
            // colBillDate
            // 
            this.colBillDate.DataPropertyName = "bdate";
            this.colBillDate.HeaderText = "Bill Date";
            this.colBillDate.MinimumWidth = 6;
            this.colBillDate.Name = "colBillDate";
            this.colBillDate.ReadOnly = true;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "ProductName";
            this.colProductName.HeaderText = "Product Name";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BillId";
            this.Column2.HeaderText = "Column2";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "ProductId";
            this.Column3.HeaderText = "Column3";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // ColProductQty
            // 
            this.ColProductQty.DataPropertyName = "Quantity";
            this.ColProductQty.HeaderText = "Product Quantity";
            this.ColProductQty.MinimumWidth = 6;
            this.ColProductQty.Name = "ColProductQty";
            this.ColProductQty.ReadOnly = true;
            // 
            // ColProductPrice
            // 
            this.ColProductPrice.DataPropertyName = "Price";
            this.ColProductPrice.HeaderText = "Product Price";
            this.ColProductPrice.MinimumWidth = 6;
            this.ColProductPrice.Name = "ColProductPrice";
            this.ColProductPrice.ReadOnly = true;
            // 
            // ColProductTotalPrice
            // 
            this.ColProductTotalPrice.DataPropertyName = "TotalPrice";
            this.ColProductTotalPrice.HeaderText = "Total Price";
            this.ColProductTotalPrice.MinimumWidth = 6;
            this.ColProductTotalPrice.Name = "ColProductTotalPrice";
            this.ColProductTotalPrice.ReadOnly = true;
            // 
            // btnDeleteBill
            // 
            this.btnDeleteBill.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDeleteBill.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteBill.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBill.Location = new System.Drawing.Point(416, 257);
            this.btnDeleteBill.Name = "btnDeleteBill";
            this.btnDeleteBill.Size = new System.Drawing.Size(219, 58);
            this.btnDeleteBill.TabIndex = 83;
            this.btnDeleteBill.Text = "Delete bill";
            this.btnDeleteBill.UseVisualStyleBackColor = false;
            this.btnDeleteBill.Click += new System.EventHandler(this.btnDeleteBill_Click);
            // 
            // frmBillHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(1050, 521);
            this.Controls.Add(this.btnDeleteBill);
            this.Controls.Add(this.dgvBillProducts);
            this.Controls.Add(this.dgvBill);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Name = "frmBillHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bill History";
            this.Load += new System.EventHandler(this.frmBillHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBill;
        private System.Windows.Forms.DataGridView dgvBillProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBillTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBillDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductTotalPrice;
        private System.Windows.Forms.Button btnDeleteBill;
    }
}