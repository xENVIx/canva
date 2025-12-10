using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;


using Npgsql;


namespace LibUtil.DB
{

    #region STRUCTS
    public struct SQLConnInfo
    {
        public string server;
        public string catalog;
        public string username;
        public string password;
    }
    public struct SQLParams
    {
        public object val;
        public String paramName;
    }
    #endregion

    public class DBAccess
    {

        #region PUBLIC

        #region METHODS

        #region STATIC

        public static void OnInit(SQLConnInfo connInfo)
        {
            if (_instance == null)
            {
                _instance = new DBAccess(connInfo);

                if (_instance.TestConnection())
                {
                    Console.WriteLine("Success");
                }
                else throw new Exception("Could not connect to database");

            }
            else throw new Exception("Database access already initialized!");
        }

        public static short getShort(DataRow dr, String field)
        {
            short val = DEFAULT_SHORT_VALUE;
            if (dr[field] != System.DBNull.Value)
            {
                try
                {
                    val = Convert.ToInt16(dr[field]);
                }
                catch { }
            }
            return val;
        }

        public static int getInt(DataRow dr, String field)
        {
            int val = DEFAULT_INT_VALUE;
            if (dr[field] != System.DBNull.Value)
            {
                try
                {
                    val = Convert.ToInt32(dr[field]);
                }
                catch { }
            }
            return val;
        }

        public static long getLong(DataRow dr, String field)
        {
            long val = DEFAULT_INT_VALUE;
            if (dr[field] != System.DBNull.Value)
            {
                try
                {
                    val = Convert.ToInt64(dr[field]);
                }
                catch { }
            }
            return val;
        }

        public static String getString(DataRow dR, String field)
        {
            String val = "";

            if (dR[field] != System.DBNull.Value)
            {
                try
                {
                    val = Convert.ToString(dR[field]);
                }
                catch { }
            }


            return val;
        }

        public static float getFloat(DataRow dR, String field)
        {
            float val = DEFAULT_FLOAT_VALUE;
            if (dR[field] != System.DBNull.Value)
            {
                try
                {
                    val = (float)Convert.ToDouble(dR[field]);
                }
                catch { }
            }
            return val;
        }

        public static double getDouble(DataRow dR, String field)
        {
            double val = DEFAULT_DOUBLE_VALUE; ;
            if (dR[field] != System.DBNull.Value)
            {
                try
                {
                    val = Convert.ToDouble(dR[field]);
                }
                catch { }
            }
            return val;
        }

        #endregion

        public bool TestConnection()
        {
            bool retVal = true;

            if (_connection.State == ConnectionState.Open)
            {
                try
                {
                    _connection.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    retVal = false;
                }
            }

            if (retVal)
            {
                try
                {
                    _connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    retVal = false;
                }
                finally
                {
                 
                }
            }


            return retVal;
        }
        
        public DataTable runQuery(String sqlTxt)
        {
            NpgsqlCommand cmd;
            NpgsqlDataReader rdr;
            //SqlCommand cmd;
            //SqlDataReader rdr;

            DataTable tbl = new DataTable();
            int cnt = 0;
            bool StatusOK = false;
            Exception ex = null;

            if (sqlTxt != "")
            {
                do
                {
                    try
                    {

                        if (_connection.State != ConnectionState.Open)
                            _connection.Open();

                        cmd = _connection.CreateCommand();

                        cmd.CommandText = sqlTxt;
                        using (rdr = cmd.ExecuteReader())
                        {
                            tbl.Load(rdr);
                            rdr.Close();
                        }

                        StatusOK = true;
                    }
                    catch (Exception e)
                    {
                        cnt++;
                        StatusOK = false;
                        ex = e;
                        Thread.Sleep(TIME_BETWEEN_RETRIES_MS);
                    }
                    finally
                    {
                        //_connection.Close();
                    }
                }
                while ((cnt < MAX_RETRIES) && !StatusOK);

                if ((!StatusOK) && (ex != null))
                {

                }
            }
            return tbl;
        }

        /// <summary>
        /// Used to run a non-query sql command, such as an INSERT, UPDATE, or DELETE
        /// </summary>
        /// <param name="sqlTxt">SQL string to send to the DB</param>
        /// <returns>Number of rows affected</returns>
        public bool runNonQuery(String sqlTxt)
        {
            //SqlCommand cmd;
            NpgsqlCommand cmd;
            int numRows = 0;
            int cnt = 0;
            bool StatusOK = false;
            Exception ex = null;

            if (sqlTxt != "")
            {
                do
                {
                    try
                    {
                        if (_connection.State == ConnectionState.Closed)
                            _connection.Open();
                        cmd = _connection.CreateCommand();
                        cmd.CommandText = sqlTxt;

                        numRows = cmd.ExecuteNonQuery();
                        StatusOK = true;
                    }
                    catch (Exception e)
                    {
                        cnt++;
                        StatusOK = false;
                        ex = e;
                        Thread.Sleep(TIME_BETWEEN_RETRIES_MS);
                    }
                    finally
                    {
                        _connection.Close();
                    }
                }
                while ((cnt < MAX_RETRIES) && !StatusOK);

                if ((!StatusOK) && (ex != null))
                {
                    numRows = -1;
                }
            }

            if (numRows < 0) return false;
            else return true;
        }


        public bool runNonQueryReturnID(String sqlTxt, out object? ID)
        {
            //SqlCommand cmd;
            NpgsqlCommand cmd;
            int numRows = 0;
            int cnt = 0;
            bool StatusOK = false;
            Exception ex = null;

            ID = null;

            if (sqlTxt != "")
            {
                do
                {
                    try
                    {
                        if (_connection.State == ConnectionState.Closed)
                            _connection.Open();
                        cmd = _connection.CreateCommand();
                        cmd.CommandText = sqlTxt;

                        //numRows = cmd.ExecuteNonQuery();
                        ID = (object)cmd.ExecuteScalar();


                        StatusOK = true;
                    }
                    catch (Exception e)
                    {
                        cnt++;
                        StatusOK = false;
                        ex = e;
                        Thread.Sleep(TIME_BETWEEN_RETRIES_MS);
                    }
                    finally
                    {
                        //_connection.Close();
                    }
                }
                while ((cnt < MAX_RETRIES) && !StatusOK);

                if ((!StatusOK) && (ex != null))
                {
                    numRows = -1;
                    ID = null;
                }
            }

            if (ID == null) return false;
            else return true;
        }



        public bool runProcedure(String sqlProcedure, List<SQLParams> i_params)
        {

            throw new NotImplementedException("Not yet implemented for Pgsql");

            //bool retVal = true;

            //try
            //{

            //    SqlCommand cmd = new SqlCommand(sqlProcedure, _connection);)


            //    cmd.CommandType = CommandType.StoredProcedure;

            //    foreach (SQLParams param in i_params)
            //    {
            //        String paramName = $"@{param.paramName}";
            //        cmd.Parameters.AddWithValue(paramName, param.val);
            //    }

            //    _connection.Open();
            //    cmd.ExecuteNonQuery();

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    retVal = false;
            //}
            //finally
            //{
            //    _connection.Close();
            //}

            //return retVal;
        }

        #endregion

        #region VARIABLES

        #region STATIC
        public static DBAccess Instance { get { if (_instance == null) throw new ArgumentNullException("DBAccess"); return (DBAccess)_instance; } }

        #endregion

        #region GET-SET

        public String ConnectionString { get { return m_conString; } }

        #endregion

        #endregion

        #endregion

        #region PRIVATE

        #region CONSTRUCTORS

        private DBAccess(SQLConnInfo connInfo)
        {
            // example
            // server = HMISRV\\WinCC
            // catalog = MOS_DB
            // user = ps_admin
            // password = hmicc.de

            m_conString = String.Format(m_baseConnStr, connInfo.server, connInfo.catalog, connInfo.username, connInfo.password);
            //_connection = new SqlConnection(m_conString);
            _connection = new NpgsqlConnection(m_conString);
        }
        ~DBAccess()
        {

        }

        #endregion

        #region VARIABLES

        #region STATIC

        private static DBAccess? _instance = null;


        #endregion

        #region CONSTANTS

        private const int MAX_RETRIES = 2;
        private const int TIME_BETWEEN_RETRIES_MS = 100;
        private const int DEFAULT_INT_VALUE = -1;
        private const short DEFAULT_SHORT_VALUE = -1;
        private const float DEFAULT_FLOAT_VALUE = -1.00f;
        private const double DEFAULT_DOUBLE_VALUE = -1.00f;

        #endregion

        private NpgsqlConnection _connection;
        private String m_baseConnStr = "Host={0};Username={2};Password={3};Database={1}";
        private String m_conString = "";

        #endregion

        #endregion

    }
}
