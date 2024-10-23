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
        DatabaseManager databaseManager;

        public AddOrderForm()
        {
            databaseManager = DatabaseManager.GetInstance();
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
            DatedateTimePicker.CustomFormat = "dd.MM.yyyy HH:mm:ss";
            DatedateTimePicker.MinDate = DateTime.Now;
            DatedateTimePicker.MaxDate = DateTime.Now.AddMonths(1);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if ( !(double.TryParse(WeightTextBox.Text.Replace(".", ","), out double weighttb)) || weighttb < 0 )
            {
                MessageBox.Show("Введите корректный вес!");
                return;
            }

            DateTime selectedDate = DatedateTimePicker.Value;

            if (selectedDate < DateTime.Now)
            {
                MessageBox.Show("Выбранная дата и время не могут быть из прошлого!");
                return;
            }


            databaseManager.AddOrder(weighttb, CitiesComboBox.Text, selectedDate);
        }

        private void WeightTextBox_TextChanged(object sender, EventArgs e)
        {   

        }
    }
}
