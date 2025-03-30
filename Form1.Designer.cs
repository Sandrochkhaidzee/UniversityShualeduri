namespace WinFormsApp1
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
            OrderComboBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            OrderNameTextBox = new TextBox();
            QuantityTextBox = new TextBox();
            AddOrderButton = new Button();
            UpdateOrderButton = new Button();
            DeleteOrderButton = new Button();
            label4 = new Label();
            ordersDataGridView = new DataGridView();
            SearchBox = new TextBox();
            label5 = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).BeginInit();
            SuspendLayout();
            // 
            // OrderComboBox
            // 
            OrderComboBox.FormattingEnabled = true;
            OrderComboBox.Location = new Point(125, 33);
            OrderComboBox.Name = "OrderComboBox";
            OrderComboBox.Size = new Size(165, 23);
            OrderComboBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
            label1.TabIndex = 1;
            label1.Text = "Select Order:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 84);
            label2.Name = "label2";
            label2.Size = new Size(104, 21);
            label2.TabIndex = 2;
            label2.Text = "Order Name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 114);
            label3.Name = "label3";
            label3.Size = new Size(76, 21);
            label3.TabIndex = 3;
            label3.Text = "Quantity:";
            // 
            // OrderNameTextBox
            // 
            OrderNameTextBox.Location = new Point(122, 82);
            OrderNameTextBox.Name = "OrderNameTextBox";
            OrderNameTextBox.Size = new Size(100, 23);
            OrderNameTextBox.TabIndex = 4;
            // 
            // QuantityTextBox
            // 
            QuantityTextBox.Location = new Point(122, 112);
            QuantityTextBox.Name = "QuantityTextBox";
            QuantityTextBox.Size = new Size(100, 23);
            QuantityTextBox.TabIndex = 5;
            // 
            // AddOrderButton
            // 
            AddOrderButton.Font = new Font("Segoe UI", 12F);
            AddOrderButton.Location = new Point(23, 171);
            AddOrderButton.Name = "AddOrderButton";
            AddOrderButton.Size = new Size(116, 31);
            AddOrderButton.TabIndex = 6;
            AddOrderButton.Text = "Add Order";
            AddOrderButton.UseVisualStyleBackColor = true;
            AddOrderButton.Click += AddOrderButton_Click_1;
            // 
            // UpdateOrderButton
            // 
            UpdateOrderButton.Font = new Font("Segoe UI", 12F);
            UpdateOrderButton.Location = new Point(152, 171);
            UpdateOrderButton.Name = "UpdateOrderButton";
            UpdateOrderButton.Size = new Size(116, 31);
            UpdateOrderButton.TabIndex = 7;
            UpdateOrderButton.Text = "Update Order";
            UpdateOrderButton.UseVisualStyleBackColor = true;
            UpdateOrderButton.Click += UpdateOrderButton_Click_1;
            // 
            // DeleteOrderButton
            // 
            DeleteOrderButton.Font = new Font("Segoe UI", 12F);
            DeleteOrderButton.Location = new Point(283, 171);
            DeleteOrderButton.Name = "DeleteOrderButton";
            DeleteOrderButton.Size = new Size(116, 31);
            DeleteOrderButton.TabIndex = 8;
            DeleteOrderButton.Text = "Delete Order";
            DeleteOrderButton.UseVisualStyleBackColor = true;
            DeleteOrderButton.Click += DeleteOrderButton_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 222);
            label4.Name = "label4";
            label4.Size = new Size(86, 21);
            label4.TabIndex = 9;
            label4.Text = "Order List:";
            // 
            // ordersDataGridView
            // 
            ordersDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ordersDataGridView.Location = new Point(12, 254);
            ordersDataGridView.Name = "ordersDataGridView";
            ordersDataGridView.Size = new Size(399, 172);
            ordersDataGridView.TabIndex = 10;
            // 
            // SearchBox
            // 
            SearchBox.Location = new Point(177, 220);
            SearchBox.Name = "SearchBox";
            SearchBox.Size = new Size(100, 23);
            SearchBox.TabIndex = 11;
            SearchBox.TextChanged += SearchBox_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(126, 225);
            label5.Name = "label5";
            label5.Size = new Size(45, 15);
            label5.TabIndex = 12;
            label5.Text = "Search:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 438);
            Controls.Add(label5);
            Controls.Add(SearchBox);
            Controls.Add(ordersDataGridView);
            Controls.Add(label4);
            Controls.Add(DeleteOrderButton);
            Controls.Add(UpdateOrderButton);
            Controls.Add(AddOrderButton);
            Controls.Add(QuantityTextBox);
            Controls.Add(OrderNameTextBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(OrderComboBox);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)ordersDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox OrderComboBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox OrderNameTextBox;
        private TextBox QuantityTextBox;
        private Button AddOrderButton;
        private Button UpdateOrderButton;
        private Button DeleteOrderButton;
        private Label label4;
        private DataGridView ordersDataGridView;
        private TextBox SearchBox;
        private Label label5;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
    }
}
