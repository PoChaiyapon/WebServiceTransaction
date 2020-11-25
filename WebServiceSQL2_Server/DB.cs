using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebServiceSQL2_Server
{
    public class DB
    {
        private static String DBSERVER = string.Empty;
        private static String DBNAME = string.Empty;
        private static String DBUSER = string.Empty;
        private static String DBPASS = string.Empty;

        public static String ConnectionStr { get { return String.Format("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}", DBSERVER, DBNAME, DBUSER, DBPASS); } }

        public static void SetConfig(string _dbserv, string _dbname, string _dbuser, string _dbpass)
        {
            DBSERVER = _dbserv;
            DBNAME = _dbname;
            DBUSER = _dbuser;
            DBPASS = _dbpass;
        }

        //Check Sql connection
        public static bool Check_SqlConnect()
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionStr);
                conn.Open();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public static DataSet execSQL(string sql)
        {
            SqlConnection conn = new SqlConnection(ConnectionStr);
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand cmd = conn.CreateCommand();
            try
            {
                cmd.CommandText = sql;
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                conn.Open();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
                da.Dispose();
                cmd.Dispose();
            }
        }
    }
}