using System.Data;
using WinFormsApp1.Repositories;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly OrderRepository _repository = new OrderRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadOrdersAsync();
        }

        private async Task LoadOrdersAsync()
        {
            try
            {
                DataSet ordersDataSet = await _repository.GetOrdersAsync();

                DataTable orders = ordersDataSet.Tables["Orders"];

                OrderComboBox.DataSource = orders;
                OrderComboBox.DisplayMember = "OrderName";
                OrderComboBox.ValueMember = "OrderId";

                ordersDataGridView.DataSource = orders;

                ordersDataGridView.Columns["OrderId"].HeaderText = "Order ID";
                ordersDataGridView.Columns["OrderName"].HeaderText = "Order Name";
                ordersDataGridView.Columns["Quantity"].HeaderText = "Quantity";
                ordersDataGridView.Columns["CustomerName"].HeaderText = "Customer Name";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OrderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OrderComboBox.SelectedItem is DataRowView row)
            {
                var orderId = row["OrderId"].ToString();

                OrderNameTextBox.Text = row["OrderName"].ToString();
                QuantityTextBox.Text = row["Quantity"].ToString();
            }
        }

        private async void AddOrderButton_Click_1(object sender, EventArgs e)
        {
            string orderName = OrderNameTextBox.Text.Trim();
            bool isValidQuantity = int.TryParse(QuantityTextBox.Text, out int quantity);
            int customerId = 1;

            if (string.IsNullOrWhiteSpace(orderName))
            {
                MessageBox.Show("Order name cannot be empty.");
                return;
            }

            if (!isValidQuantity)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            int orderId = await _repository.AddOrderAsync(orderName, quantity, customerId);
            MessageBox.Show($"Order {orderId} added!");
            await LoadOrdersAsync();
        }

        private async void UpdateOrderButton_Click_1(object sender, EventArgs e)
        {
            if (OrderComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            int orderId = (int)OrderComboBox.SelectedValue;
            string orderName = OrderNameTextBox.Text.Trim();

            bool isValidQuantity = int.TryParse(QuantityTextBox.Text, out int quantity);

            if (string.IsNullOrWhiteSpace(orderName))
            {
                MessageBox.Show("Order name cannot be empty.");
                return;
            }

            if (!isValidQuantity)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            if (orderId <= 0)
            {
                MessageBox.Show("Invalid Order ID. It must be greater than 0.");
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.");
                return;
            }

            bool success = await _repository.UpdateOrderAsync(orderId, orderName, quantity);
            MessageBox.Show(success ? "Order updated!" : "Update failed.");
            await LoadOrdersAsync();
        }

        private async void DeleteOrderButton_Click_1(object sender, EventArgs e)
        {
            if (OrderComboBox.SelectedValue == null)
            {
                MessageBox.Show("Please select an order.");
                return;
            }

            int orderId = (int)OrderComboBox.SelectedValue;

            if (orderId <= 0)
            {
                MessageBox.Show("Invalid Order ID. It must be greater than 0.");
                return;
            }

            bool success = await _repository.DeleteOrderAsync(orderId);
            MessageBox.Show(success ? "Order deleted!" : "Delete failed.");
            await LoadOrdersAsync();
        }
    }
}
