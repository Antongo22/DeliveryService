﻿using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DeliveryService.DataBase
{
    public class DatabaseManager
    {
        private readonly string _connectionString = $"Data Source={AppDomain.CurrentDomain.BaseDirectory}/DataBase/deliveryDB.db;";
        private readonly string _errorlog = $"{AppDomain.CurrentDomain.BaseDirectory}/DataBase/errorslog.txt";

        private static DatabaseManager _instance;

        private static readonly object _lock = new object();

        private DatabaseManager()
        {
            if(!File.Exists(_errorlog))
                File.Create(_errorlog).Close();
            InitializeDatabase();
        }

        public static DatabaseManager GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DatabaseManager();
                }
            }
            return _instance;
        }

        private void InitializeDatabase()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string createOrdersTable = @"
                        CREATE TABLE IF NOT EXISTS Orders (
                            OrderID INTEGER PRIMARY KEY AUTOINCREMENT,
                            OrderWeight DECIMAL(7, 3),
                            CityDistrict TEXT,
                            DeliveryDateTime DATETIME
                        );";

                    string createLogsTable = @"
                        CREATE TABLE IF NOT EXISTS DeliveryLogs (
                            LogID INTEGER PRIMARY KEY AUTOINCREMENT,
                            LogMessage TEXT,
                            LogDateTime DATETIME,
                            LogType TEXT
                        );";

                    string createFilteredOrdersTable = @"
                        CREATE TABLE IF NOT EXISTS FilteredOrders (
                            FilteredOrderID INTEGER PRIMARY KEY AUTOINCREMENT,
                            OrderID INTEGER,
                            CityDistrict TEXT,
                            FilterDateTime DATETIME,
                            FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
                        );";

                    ExecuteNonQuery(createOrdersTable, connection);
                    ExecuteNonQuery(createLogsTable, connection);
                    ExecuteNonQuery(createFilteredOrdersTable, connection);
                }
            }
            catch (Exception ex)
            {
                LogError("Error initializing database: " + ex.Message);
            }
        }

        private void ExecuteNonQuery(string query, SQLiteConnection connection)
        {
            try
            {
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                LogError("Error executing query: " + ex.Message);
            }
        }

        public bool AddOrder(double orderWeight, string cityDistrict, DateTime deliveryDateTime)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                    INSERT INTO Orders (OrderWeight, CityDistrict, DeliveryDateTime)
                    VALUES (@OrderWeight, @CityDistrict, @DeliveryDateTime);";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderWeight", orderWeight);
                        command.Parameters.AddWithValue("@CityDistrict", cityDistrict);
                        command.Parameters.AddWithValue("@DeliveryDateTime", deliveryDateTime);

                        command.ExecuteNonQuery();
                    }
                }

                AddLog($"New order created", "create");

                return true;
            }
            catch (Exception ex)
            {
                LogError("Error adding order: " + ex.Message);
                return false;
            }
        }

        public DataTable GetFilteredOrders(string cityDistrict, DateTime firstDeliveryDateTime)
        {
            DataTable filteredOrders = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT * FROM Orders
                    WHERE CityDistrict = @CityDistrict 
                    AND DeliveryDateTime BETWEEN @FirstDeliveryDateTime AND DATETIME(@FirstDeliveryDateTime, '+30 minutes');";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CityDistrict", cityDistrict);
                        command.Parameters.AddWithValue("@FirstDeliveryDateTime", firstDeliveryDateTime);

                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(filteredOrders);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError("Error retrieving filtered orders: " + ex.Message);
            }

            return filteredOrders;
        }

        public void SaveFilteredOrders(DataTable filteredOrders)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    foreach (DataRow row in filteredOrders.Rows)
                    {
                        string query = @"
                        INSERT INTO FilteredOrders (OrderID, CityDistrict, FilterDateTime)
                        VALUES (@OrderID, @CityDistrict, @FilterDateTime);";

                        using (SQLiteCommand command = new SQLiteCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@OrderID", row["OrderID"]);
                            command.Parameters.AddWithValue("@CityDistrict", row["CityDistrict"]);
                            command.Parameters.AddWithValue("@FilterDateTime", DateTime.Now);

                            command.ExecuteNonQuery();
                        }
                    }

                    AddLog("Filtered orders successfully saved to the database.", "save");
                }
            }
            catch (Exception ex)
            {
                LogError("Error saving filtered orders: " + ex.Message);
            }
        }

        public void ClearFilteredOrders()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM FilteredOrders;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    AddLog("Filtered orders table cleared.", "clear");
                }
            }
            catch (Exception ex)
            {
                LogError("Error clearing filtered orders: " + ex.Message);
            }
        }

        #region logs
        public void AddLog(string message, string logType)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                    INSERT INTO DeliveryLogs (LogMessage, LogDateTime, LogType)
                    VALUES (@LogMessage, @LogDateTime, @LogType);";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LogMessage", message);
                        command.Parameters.AddWithValue("@LogDateTime", DateTime.Now);
                        command.Parameters.AddWithValue("@LogType", logType);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(_errorlog, DateTime.Now + ":" + logType + ":" + message + "\n");
            }
        }

        public void LogError(string errorMessage)
        {
            AddLog(errorMessage, "Error");
        }
        #endregion

        #region retrieve
        public DataTable GetAllOrders()
        {
            DataTable ordersTable = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Orders;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(ordersTable);
                        }
                    }
                }

                AddLog("Retrieved all orders from Orders table.", "retrieve");
            }
            catch (Exception ex)
            {
                LogError("Error retrieving all orders: " + ex.Message);
            }

            return ordersTable;
        }

        public DataTable GetAllFilteredOrders()
        {
            DataTable filteredOrdersTable = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM FilteredOrders;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(filteredOrdersTable);
                        }
                    }
                }

                AddLog("Retrieved all orders from FilteredOrders table.", "retrieve");
            }
            catch (Exception ex)
            {
                LogError("Error retrieving all filtered orders: " + ex.Message);
            }

            return filteredOrdersTable;
        }

        public DataTable GetAllLogs()
        {
            DataTable logsTable = new DataTable();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM DeliveryLogs;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(logsTable);
                        }
                    }
                }

                AddLog("Retrieved all logs from DeliveryLogs table.", "retrieve");
            }
            catch (Exception ex)
            {
                LogError("Error retrieving all logs: " + ex.Message);
            }

            return logsTable;
        }

        #endregion
    }
}
