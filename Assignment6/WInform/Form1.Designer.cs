namespace WInform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel3 = new Panel();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            Seek = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            Add = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            splitContainer1 = new SplitContainer();
            dataGridView1 = new DataGridView();
            Customer = new DataGridViewTextBoxColumn();
            CreateTime = new DataGridViewTextBoxColumn();
            TotalPrice = new DataGridViewTextBoxColumn();
            orderIdDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            customerNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            createTimeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            totalPriceDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            bdorder = new BindingSource(components);
            dataGridView2 = new DataGridView();
            totalPriceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            bddetails = new BindingSource(components);
            bdtxt = new BindingSource(components);
            panel3.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bdorder).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bddetails).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bdtxt).BeginInit();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(Seek);
            panel3.Location = new Point(12, 559);
            panel3.Name = "panel3";
            panel3.Size = new Size(1319, 113);
            panel3.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(414, 42);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(410, 34);
            textBox1.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "All", "ID", "TotalPrice>=" });
            comboBox1.Location = new Point(167, 40);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(206, 36);
            comboBox1.TabIndex = 1;
            // 
            // Seek
            // 
            Seek.Location = new Point(24, 32);
            Seek.Name = "Seek";
            Seek.Size = new Size(110, 44);
            Seek.TabIndex = 0;
            Seek.Text = "Seek";
            Seek.UseVisualStyleBackColor = true;
            Seek.Click += button5_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.Controls.Add(Add);
            flowLayoutPanel1.Controls.Add(button2);
            flowLayoutPanel1.Controls.Add(button3);
            flowLayoutPanel1.Controls.Add(button4);
            flowLayoutPanel1.Location = new Point(12, 12);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1319, 53);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // Add
            // 
            Add.Location = new Point(3, 3);
            Add.Name = "Add";
            Add.Size = new Size(131, 40);
            Add.TabIndex = 0;
            Add.Text = "Add";
            Add.UseVisualStyleBackColor = true;
            Add.Click += Add_Click;
            // 
            // button2
            // 
            button2.Location = new Point(140, 3);
            button2.Name = "button2";
            button2.Size = new Size(131, 40);
            button2.TabIndex = 1;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(277, 3);
            button3.Name = "button3";
            button3.Size = new Size(131, 40);
            button3.TabIndex = 2;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(414, 3);
            button4.Name = "button4";
            button4.Size = new Size(131, 40);
            button4.TabIndex = 3;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.AllowDrop = true;
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(15, 86);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView2);
            splitContainer1.Size = new Size(1316, 445);
            splitContainer1.SplitterDistance = 633;
            splitContainer1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Customer, CreateTime, TotalPrice, orderIdDataGridViewTextBoxColumn, customerDataGridViewTextBoxColumn, customerNameDataGridViewTextBoxColumn, createTimeDataGridViewTextBoxColumn, totalPriceDataGridViewTextBoxColumn1 });
            dataGridView1.DataSource = bdorder;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 72;
            dataGridView1.Size = new Size(627, 442);
            dataGridView1.TabIndex = 0;
            // 
            // Customer
            // 
            Customer.DataPropertyName = "CustomerName";
            Customer.HeaderText = "Customer";
            Customer.MinimumWidth = 9;
            Customer.Name = "Customer";
            Customer.ReadOnly = true;
            Customer.Width = 175;
            // 
            // CreateTime
            // 
            CreateTime.DataPropertyName = "CreateTime";
            CreateTime.HeaderText = "CreateTime";
            CreateTime.MinimumWidth = 9;
            CreateTime.Name = "CreateTime";
            CreateTime.Width = 175;
            // 
            // TotalPrice
            // 
            TotalPrice.DataPropertyName = "TotalPrice";
            TotalPrice.HeaderText = "TotalPrice";
            TotalPrice.MinimumWidth = 9;
            TotalPrice.Name = "TotalPrice";
            TotalPrice.ReadOnly = true;
            TotalPrice.Width = 175;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            orderIdDataGridViewTextBoxColumn.MinimumWidth = 9;
            orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            orderIdDataGridViewTextBoxColumn.Width = 175;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            customerDataGridViewTextBoxColumn.DataPropertyName = "Customer";
            customerDataGridViewTextBoxColumn.HeaderText = "Customer";
            customerDataGridViewTextBoxColumn.MinimumWidth = 9;
            customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            customerDataGridViewTextBoxColumn.Width = 175;
            // 
            // customerNameDataGridViewTextBoxColumn
            // 
            customerNameDataGridViewTextBoxColumn.DataPropertyName = "CustomerName";
            customerNameDataGridViewTextBoxColumn.HeaderText = "CustomerName";
            customerNameDataGridViewTextBoxColumn.MinimumWidth = 9;
            customerNameDataGridViewTextBoxColumn.Name = "customerNameDataGridViewTextBoxColumn";
            customerNameDataGridViewTextBoxColumn.ReadOnly = true;
            customerNameDataGridViewTextBoxColumn.Width = 175;
            // 
            // createTimeDataGridViewTextBoxColumn
            // 
            createTimeDataGridViewTextBoxColumn.DataPropertyName = "CreateTime";
            createTimeDataGridViewTextBoxColumn.HeaderText = "CreateTime";
            createTimeDataGridViewTextBoxColumn.MinimumWidth = 9;
            createTimeDataGridViewTextBoxColumn.Name = "createTimeDataGridViewTextBoxColumn";
            createTimeDataGridViewTextBoxColumn.Width = 175;
            // 
            // totalPriceDataGridViewTextBoxColumn1
            // 
            totalPriceDataGridViewTextBoxColumn1.DataPropertyName = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn1.HeaderText = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn1.MinimumWidth = 9;
            totalPriceDataGridViewTextBoxColumn1.Name = "totalPriceDataGridViewTextBoxColumn1";
            totalPriceDataGridViewTextBoxColumn1.ReadOnly = true;
            totalPriceDataGridViewTextBoxColumn1.Width = 175;
            // 
            // bdorder
            // 
            bdorder.DataSource = typeof(Order);
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { totalPriceDataGridViewTextBoxColumn, Quantity, ProductName });
            dataGridView2.DataSource = bddetails;
            dataGridView2.Location = new Point(3, 3);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 72;
            dataGridView2.Size = new Size(673, 442);
            dataGridView2.TabIndex = 0;
            // 
            // totalPriceDataGridViewTextBoxColumn
            // 
            totalPriceDataGridViewTextBoxColumn.DataPropertyName = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn.HeaderText = "TotalPrice";
            totalPriceDataGridViewTextBoxColumn.MinimumWidth = 9;
            totalPriceDataGridViewTextBoxColumn.Name = "totalPriceDataGridViewTextBoxColumn";
            totalPriceDataGridViewTextBoxColumn.ReadOnly = true;
            totalPriceDataGridViewTextBoxColumn.Width = 175;
            // 
            // Quantity
            // 
            Quantity.DataPropertyName = "Quantity";
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 9;
            Quantity.Name = "Quantity";
            Quantity.Width = 175;
            // 
            // ProductName
            // 
            ProductName.DataPropertyName = "ProductName";
            ProductName.HeaderText = "ProductName";
            ProductName.MinimumWidth = 9;
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            ProductName.Width = 175;
            // 
            // bddetails
            // 
            bddetails.DataMember = "Details";
            bddetails.DataSource = bdorder;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1343, 684);
            Controls.Add(splitContainer1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel3);
            Name = "Form1";
            Text = "Form1";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bdorder).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bddetails).EndInit();
            ((System.ComponentModel.ISupportInitialize)bdtxt).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button Add;
        private Button button2;
        private Button button3;
        private Button button4;
        private SplitContainer splitContainer1;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private BindingSource bdorder;
        private BindingSource bddetails;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Customer;
        private DataGridViewTextBoxColumn CreateTime;
        private DataGridViewTextBoxColumn TotalPrice;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button Seek;
        private DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn customerNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn createTimeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn1;
        private BindingSource bdtxt;
        private DataGridViewTextBoxColumn totalPriceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn ProductName;
    }
}
