using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    class SQLDatabase : IRepository
    {
        Logger logs = Logger.getInstance();
        public void AddProduct(string data, string operation)
        {
            string[] result = data.Split(',');
            string query = "";
            string queryValue = "";
            foreach(string response in result)
            {
                string[] keyPair = response.Split(':');
                Console.WriteLine(keyPair[0] + ": " + keyPair[1]);
                query += "@" + keyPair[0] + ",";
                queryValue += keyPair[1] + ",";
            }
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = "Data Source=TAVDESK083;Initial Catalog=Travel;Integrated Security=True";
            query = query.Remove(query.Length - 1, 1);
            string con = "insert into " + operation + " values(" + query + ")";
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(con,sqlConnection);
            string[] dynamicColumn = query.Split(',');
            string[] dynamicColumnValue = queryValue.Split(',');
            for(int index = 0; index < dynamicColumn.Length; index++)
            {
                sqlCommand.Parameters.AddWithValue(dynamicColumn[index], dynamicColumnValue[index]);
            }
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
            logs.loggingDetails("Saving into database");

        }
    }
}
