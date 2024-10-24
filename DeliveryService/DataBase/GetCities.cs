using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DeliveryService.DataBase
{
    internal static class GetCities
    {
        static List<string> LoadCitiesFromXml(string filePath, DatabaseManager databaseManager)
        {
            List<string> cities = new List<string>();

            try
            {
                XDocument xmlDocument = XDocument.Load(filePath);

                foreach (var cityElement in xmlDocument.Descendants("City"))
                {
                    cities.Add(cityElement.Value);
                }
            }
            catch (Exception ex)
            {
                databaseManager.LogError("Ошибка при загрузке города из XML: " + ex.Message);
            }

            return cities;
        }


        public static bool SetCityDistrict(ComboBox CitiesComboBox)
        {
            DatabaseManager databaseManager = DatabaseManager.GetInstance();

            List<string> Cities = LoadCitiesFromXml("DataBase\\CityDistrict.xml", databaseManager);

            if (Cities == null || Cities.Count == 0)
            {
                databaseManager.LogError("Произошла ошибка при загрузке городов!");
                MessageBox.Show("Произошла ошибка при загрузке городов!");
                return false;
            }

            CitiesComboBox.Items.AddRange(Cities.ToArray());
            CitiesComboBox.SelectedIndex = 0;

            return true;
        }
    }
}
