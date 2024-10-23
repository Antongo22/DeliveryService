using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace DeliveryService.DataBase
{
    internal static class GetCities
    {
        public static List<string> LoadCitiesFromXml(string filePath)
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
                DatabaseManager databaseManager = DatabaseManager.GetInstance();
                databaseManager.LogError("Ошибка при загрузке города из XML: " + ex.Message);
            }

            return cities;
        }
    }
}
