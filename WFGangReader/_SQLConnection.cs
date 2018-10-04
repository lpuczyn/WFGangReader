using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WFGangReader
{
    public class _SQLConnection
    {
        private string errorInfo = "";
        private string connectionString = "";
        private SqlConnection conn = null;
        public void UpdateConnectionString(String host,
                                            String dbname,
                                            String user,
                                            String pass)
        {
            this.connectionString =
                    "Data Source=" + host + ";" +
                    "Initial Catalog=" + dbname + ";" +
                    "User id=" + user + ";" +
                    "Password=" + pass + ";";
        }
        public bool ConnectDb()
        {
            this.errorInfo = "";
            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                return true;
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("#" + i + "|" + ex.Errors[i].Message);
                    this.errorInfo = errorMessages.ToString();
                }
                conn.Close();
                return false;
            }
        }

        public DataTable ExecSql(string query)
        {
            this.errorInfo = "";
            DataTable rDT = new DataTable();
            try
            {
                SqlDataAdapter ada = new SqlDataAdapter(query, conn);
                ada.Fill(rDT);
                return rDT;
            }
            catch(SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("#" + i + "|" + ex.Errors[i].Message);
                    this.errorInfo = errorMessages.ToString();
                    if (this.errorInfo.Length > 100)
                    {
                        this.errorInfo.Remove(100);
                    }
                }
                return new DataTable();
            }                      
        }
        public string GetErrorInfo()
        {
            return this.errorInfo;
        }

        public void Close()
        {
            this.conn.Close();
            this.conn = null;
        }

        public bool Connected()
        {
            if( conn == null || conn.State != ConnectionState.Open)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
