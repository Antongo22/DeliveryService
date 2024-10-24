using DeliveryService.DataBase;
using DeliveryService.Forms;
using System.Data;
using System.Xml;

namespace DeliveryService
{
    public partial class MainForm : Form
    {
        DatabaseManager DatabaseManager;
        public MainForm()
        {
            DatabaseManager = DatabaseManager.GetInstance();
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("DataBase/config.xml");

            string city = doc.SelectSingleNode("/Configuration/City").InnerText;
            string date = doc.SelectSingleNode("/Configuration/Date").InnerText;

            DateTime parsedDate = DateTime.ParseExact(date, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);


            if (!GetCities.SetCityDistrict(CitiesComboBox))
            {
                Close();
            }

            if (CitiesComboBox.Items.Contains(city))
            {
                CitiesComboBox.SelectedItem = city;
            }
            else
            {
                MessageBox.Show($"Город \"{city}\" не найден. Установлен первый город из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (CitiesComboBox.Items.Count > 0)
                {
                    CitiesComboBox.SelectedIndex = 0;
                }
            }


            DatedateTimePicker.Format = DateTimePickerFormat.Custom;
            DatedateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            DatedateTimePicker.Value = parsedDate;

            TablesComboBox.SelectedIndex = 0;
        }

        private void CreateOrderButton_Click(object sender, EventArgs e)
        {
            Form form = new AddOrderForm();
            form.ShowDialog();
        }

        private void GetFilteredOrdersButton_Click(object sender, EventArgs e)
        {
            DataTable dt = DatabaseManager.GetFilteredOrders(CitiesComboBox.Text, DatedateTimePicker.Value);
            FilteredOrdersDataGridView.DataSource = dt;
            FilteredOrdersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dt.Rows.Count > 0) SaveFilteredOrdersButton.Enabled = true;
            else SaveFilteredOrdersButton.Enabled = false;
        }

        private void SaveFilteredOrdersButton_Click(object sender, EventArgs e)
        {
            DatabaseManager.SaveFilteredOrders(FilteredOrdersDataGridView.DataSource as DataTable);
            FilteredOrdersDataGridView.DataSource = null;
            SaveFilteredOrdersButton.Enabled = false;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите очистить таблицу фильтрации?", "Подтверждение очистки", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                DatabaseManager.ClearFilteredOrders();
                MessageBox.Show("Таблица успешно очищена.", "Операция завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Операция отменена.", "Отмена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GetTablesDatabutton_Click(object sender, EventArgs e)
        {
            SaveFilteredOrdersButton.Enabled = false;
            DataTable dt = null;
            switch (TablesComboBox.SelectedIndex)
            {
                case 0:
                    dt = DatabaseManager.GetAllOrders();
                    FilteredOrdersDataGridView.DataSource = dt;
                    FilteredOrdersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case 1:
                    dt = DatabaseManager.GetAllFilteredOrders();
                    FilteredOrdersDataGridView.DataSource = dt;
                    FilteredOrdersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;
                case 2:
                    dt = DatabaseManager.GetAllLogs();
                    FilteredOrdersDataGridView.DataSource = dt;
                    FilteredOrdersDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    break;

            }
        }
    }
}
