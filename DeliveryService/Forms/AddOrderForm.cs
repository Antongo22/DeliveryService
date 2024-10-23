using DeliveryService.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryService.Forms
{
    public partial class AddOrderForm : Form
    {
        int weight;

        public AddOrderForm()
        {
            InitializeComponent();
        }

        bool SetCityDistrict()
        {
            List<string> Cities = GetCities.LoadCitiesFromXml("DataBase\\CityDistrict.xml");

            if (Cities == null || Cities.Count == 0)
            {
                return false;
            }

            CitiesComboBox.Items.AddRange(Cities.ToArray());
            CitiesComboBox.SelectedIndex = 0;

            return true;
        }


        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            if (!SetCityDistrict())
            {
                MessageBox.Show("Произошла ошибка при загрузке городов");
                Close();
            }

            DatedateTimePicker.Format = DateTimePickerFormat.Custom;
            DatedateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void WeightTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(WeightTextBox.Text, out int weighttb) && weighttb >= 0)
            {
                this.weight = weighttb;
            }

            WeightTextBox.Text = weight.ToString();
            WeightTextBox.Select(WeightTextBox.Text.Length, 0);
            WeightTextBox.Focus();
        }
    }
}
