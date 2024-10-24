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


        private void AddOrderForm_Load(object sender, EventArgs e)
        {
            if (!GetCities.SetCityDistrict(CitiesComboBox))
            {
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
            

            if (!System.Text.RegularExpressions.Regex.IsMatch(WeightTextBox.Text.Replace(".", ","), @"^\d{1,6}(,\d{1,2})?$"))
            {
                MessageBox.Show("Вес должен содержать до 6 цифр перед запятой и до 2 знаков после запятой!");
                return;
            }

            DateTime selectedDate = DatedateTimePicker.Value;

            if (selectedDate < DateTime.Now)
            {
                MessageBox.Show("Выбранная дата и время не могут быть из прошлого!");
                return;
            }


            if (databaseManager.AddOrder(weighttb, CitiesComboBox.Text, selectedDate)) MessageBox.Show("Заказ успешно добавлен!");
            else MessageBox.Show("Ошибка при добавлении заказа! Попробуйте позже.");

            Close();
        }
    }
}
