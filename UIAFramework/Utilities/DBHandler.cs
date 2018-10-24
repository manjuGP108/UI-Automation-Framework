using System;
using System.Data;
using System.Data.SqlClient;

namespace UIAFramework
{
    public static class DBHandler
    {
        public static DataTable Read(string connStr, string query)
        {
            DataTable Table = new DataTable();
            SqlConnection SqlCon = new SqlConnection(connStr);
            try
            {
                SqlCon.Open();
                SqlCommand SelectCmd = new SqlCommand(query, SqlCon);
                //SqlDataAdapter SqlAdapter = new SqlDataAdapter(SelectCmd);


                using (SqlDataReader dr = SelectCmd.ExecuteReader())
                {
                    Table.Load(dr);
                }


               // SqlAdapter.Fill(Table);
                return Table;
            }
            catch (SqlException ex)
            {
                SqlCon.Close();
                SqlCon.Dispose();
                throw new Exception("Database exception while executing query: " + query + "\nSqlException:" + ex.Message);
            }
        }

        public static void Update(string connStr, string query)
        {
            SqlConnection SqlCon = new SqlConnection(connStr);
            try
            {
                SqlCon.Open();
                SqlCommand UpdateCmd = new SqlCommand(query, SqlCon);
                UpdateCmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                SqlCon.Close();
                SqlCon.Dispose();
                throw new Exception("Database exception while executing query: " + query + "\nSqlException:" + ex.Message);
            }
        }

        public static void Insert(string connStr, string query)
        {
            SqlConnection SqlCon = new SqlConnection(connStr);
            try
            {
                SqlCon.Open();
                SqlCommand InsertCmd = new SqlCommand(query, SqlCon);
                InsertCmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                SqlCon.Close();
                SqlCon.Dispose();
                throw new Exception("Database exception while executing query: " + query + "\nSqlException:" + ex.Message);
            }
        }

        public static void ExecuteSP(string connStr, string SPName)
        {
            SqlConnection SqlCon = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader;
            try
            {
                cmd.CommandText = SPName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = SqlCon;
                cmd.CommandTimeout = 600;
                SqlCon.Open();
                reader = cmd.ExecuteReader();
                // Data is accessible through the DataReader object here.
                SqlCon.Close();
            }
            catch (SqlException ex)
            {
                SqlCon.Close();
                SqlCon.Dispose();
                throw new Exception("Database exception while executing Stored Procedure: " + SPName + "\nSqlException:" + ex.Message);
            }
        }

    }
}
