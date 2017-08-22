using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Common
{
    /// <summary>
    /// 数据库读取帮助类
    ///  System.Data.Common（ADO.Net 基础类库） 和 System.Data.SqlClient（SqlServer）
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// 创建一个DbConnection链接对象
        /// </summary>
        /// <param name="connStr">链接字符串</param>
        /// <param name="type">指示数据库类型，目前只实现了sqlserver一种数据库，如果需要链接其他的数据库则需要实现其他的数据库</param>
        /// <returns>如果connStr为空则返回为null，否则返回创建成功的对象，并打开链接</returns>
        private static DbConnection CreateConnection(string connStr, DatabaseType type = DatabaseType.SqlServer)
        {
            //判断链接字符串是否为空
            if (string.IsNullOrEmpty(connStr))
            {
                return null;
            }

            DbConnection conn = null;
            //根据不同的数据类型，生成对应的连接对象
            switch (type)
            {
                case DatabaseType.SqlServer:
                    conn = new SqlConnection();
                    break;
                default:
                    return null;
            }

            conn.ConnectionString = connStr;
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 执行指定的增，删，改sql语句或者指定的存储过程
        /// </summary>
        /// <param name="connStr">链接字符串</param>
        /// <param name="sql">sql语句或者存储过程名称</param>
        /// <param name="commandType">指示为存储过程或者普通sql查询</param>
        /// <param name="paras">参数</param>
        /// <returns>如果connStr或者sql为空则返回-1，否则返回查询结果</returns>
        public static int ExecuteNonQuery(string connStr, string sql, CommandType commandType = CommandType.Text, params DbParameter[] paras)
        {
            if (string.IsNullOrEmpty(sql) || string.IsNullOrEmpty(connStr))
            {
                return -1;
            }

            using (DbConnection conn = CreateConnection(connStr))
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (commandType == CommandType.Text && paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }

                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 执行指定的增，删，改sql语句或者指定的存储过程
        /// </summary>
        /// <param name="conn">DbConnection链接对象</param>
        /// <param name="sql">sql语句或者存储过程名称</param>
        /// <param name="commandType">指示为存储过程或者普通sql查询</param>
        /// <param name="paras">参数</param>
        /// <returns>如果sql为空则返回-1，conn为null返回-2，否则返回查询结果</returns>
        public static int ExecuteNonQuery(DbConnection conn, string sql, CommandType commandType = CommandType.Text, params DbParameter[] paras)
        {
            if (string.IsNullOrEmpty(sql))
            {
                return -1;
            }

            if (conn == null)
            {
                return -2;
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            int res = 0;
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (commandType == CommandType.Text && paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }

                res = cmd.ExecuteNonQuery();
            }
            conn.Close();
            conn.Dispose();

            return res;
        }

        /// <summary>
        /// 执行指定的增，删，改sql语句或者指定的存储过程
        /// </summary>
        /// <param name="connStr">链接字符串</param>
        /// <param name="sql">sql语句或者存储过程名称</param>
        /// <param name="commandType">指示为存储过程或者普通sql查询</param>
        /// <param name="paras">参数</param>
        /// <returns>如果connStr或者sql为空则返回-1，否则返回查询结果</returns>
        public static object ExecuteScalar(string connStr, string sql, CommandType commandType = CommandType.Text, params DbParameter[] paras)
        {
            if (string.IsNullOrEmpty(sql) || string.IsNullOrEmpty(connStr))
            {
                return -1;
            }

            using (DbConnection conn = CreateConnection(connStr))
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (commandType == CommandType.Text && paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }

                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 执行指定的增，删，改sql语句或者指定的存储过程
        /// </summary>
        /// <param name="conn">DbConnection链接对象</param>
        /// <param name="sql">sql语句或者存储过程名称</param>
        /// <param name="commandType">指示为存储过程或者普通sql查询</param>
        /// <param name="paras">参数</param>
        /// <returns>如果sql为空则返回-1，conn为null返回-2，否则返回查询结果</returns>
        public static object ExecuteScalar(DbConnection conn, string sql, CommandType commandType = CommandType.Text, params DbParameter[] paras)
        {
            if (string.IsNullOrEmpty(sql))
            {
                return -1;
            }

            if (conn == null)
            {
                return -2;
            }

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }

            int res = 0;
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (commandType == CommandType.Text && paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }

                res = cmd.ExecuteNonQuery();
            }
            conn.Close();
            conn.Dispose();

            return res;
        }

        /// <summary>
        /// 查询数据，返回DataTable格式数据
        /// </summary>
        /// <param name="connStr">链接字符串</param>
        /// <param name="sql">sql语句或者存储过程名称</param>
        /// <param name="commandType">指示为存储过程或者普通sql查询</param>
        /// <param name="paras">参数</param>
        /// <returns>如果connStr或者sql为空则返回null，否则返回查询结果</returns>
        public static DataTable ExecuteQuery(string connStr, string sql, CommandType commandType = CommandType.Text, params DbParameter[] paras)
        {
            DataTable dataTable = new DataTable();
            if (string.IsNullOrEmpty(sql) || string.IsNullOrEmpty(connStr))
            {
                return null;
            }

            using (DbConnection conn = CreateConnection(connStr))
            using (DbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (commandType == CommandType.Text && paras != null)
                {
                    cmd.Parameters.AddRange(paras);
                }

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        return null;
                    }

                    dataTable.Load(reader);
                }

                //using (DbDataAdapter adapter =new SqlDataAdapter(cmd as SqlCommand))
                //{
                //    adapter.Fill(dataTable);
                //}
                return dataTable;
            }
        }

        public static void InsertBigData(DbConnection conn, DataTable dt, string tableName, int batchsize = 10000)
        {
            if (dt == null || dt.Rows.Count <= 0)
            {
                return;
            }

            SqlConnection sqlConnection = conn as SqlConnection;
            if (sqlConnection != null)
            {
                SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnection);
                bulkCopy.DestinationTableName = tableName;
                bulkCopy.BatchSize = batchsize;
                using (SqlTransaction tran = sqlConnection.BeginTransaction())
                {
                    try
                    {
                        if (sqlConnection.State == ConnectionState.Closed)
                        {
                            bulkCopy.WriteToServer(dt);
                        }
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                }
            }
            sqlConnection.Close();
        }

    }
}
