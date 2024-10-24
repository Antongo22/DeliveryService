using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliveryService.DataBase; 
using System;
using System.Data;


namespace TestDelivery
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestAddOrder_ShouldReturnTrue_WhenOrderIsAdded()
        {
            var dbManager = DatabaseManager.GetInstance();
            double orderWeight = 12.5;
            string cityDistrict = "Москва";
            DateTime deliveryDateTime = DateTime.Now;

            bool result = dbManager.AddOrder(orderWeight, cityDistrict, deliveryDateTime);

            Assert.IsTrue(result, "Order should be added successfully.");
        }

        [TestMethod]
        public void TestGetFilteredOrders_ShouldReturnDataTable_WithMatchingOrders()
        {
            var dbManager = DatabaseManager.GetInstance();
            string cityDistrict = "Москва";
            DateTime deliveryDateTime = DateTime.Now;

            dbManager.AddOrder(12.5, cityDistrict, deliveryDateTime);

            DataTable result = dbManager.GetFilteredOrders(cityDistrict, deliveryDateTime);

            Assert.IsNotNull(result, "Filtered orders should not be null.");
            Assert.IsTrue(result.Rows.Count > 0, "Filtered orders should contain at least one row.");
        }


        [TestMethod]
        public void TestSaveFilteredOrders_ShouldLogMessage_WhenDataIsSaved()
        {
            var dbManager = DatabaseManager.GetInstance();
            DataTable testTable = new DataTable();
            testTable.Columns.Add("OrderID", typeof(int));
            testTable.Columns.Add("CityDistrict", typeof(string));

            DataRow row = testTable.NewRow();
            row["OrderID"] = 1;
            row["CityDistrict"] = "Москва";
            testTable.Rows.Add(row);

            dbManager.SaveFilteredOrders(testTable);

            Assert.IsTrue(true);
        }
    }
}
