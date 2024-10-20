using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;

class Program
{
    static void Main(string[] args)
    {
        string connectionString = "Data Source=your_database;User Id=your_username;Password=your_password;";

        using (OracleConnection connection = new OracleConnection(connectionString))
        {
            connection.Open();

            string query = "SELECT * FROM your_table";

            using (OracleCommand command = new OracleCommand(query, connection))
            {
                using (OracleDataAdapter adapter = new OracleDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Console.WriteLine(row["column1"].ToString());
                        Console.WriteLine(row["column2"].ToString());
                        // add more columns here
                    }
                }
            }

            connection.Close();
        }
    }
}
