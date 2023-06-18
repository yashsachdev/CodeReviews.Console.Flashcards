using Microsoft.Data.SqlClient.Server;
using System.Data;

namespace FlashcardApp
{
    internal class Databasecontext
    {
        public string connectionString { get; set; }
        public Databasecontext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using(SqlConnection connection = new SqlConnection(connectionString)) 
            {
                using(SqlCommand command = new SqlCommand(sql, connection)) 
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        public void ExecuteQuery(string sql)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        public SqlDataReader ExecuterReader( string sql, params SqlParameter[] parameters) 
        {
            using( SqlConnection connection = new SqlConnection( connectionString )) 
            {
                using(SqlCommand command = new SqlCommand(sql,connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    return command.ExecuteReader();
                }
            }
        }
        public SqlDataReader ExecuterReader(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);   
            connection.Open();
            SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
                
            
        }
        public int ExecuteScalar(string sql, params SqlParameter[] parameters ) 
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(parameters);
                    connection.Open();
                    object result = command.ExecuteScalar();
                    int count = result != null && result != DBNull.Value ? (int)result : 0;
                    return Convert.ToInt32(result);  
                }
            }
        }
    }
}
