using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using DataLibrary.Models;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string connectionName = "TravelExpertsDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        //public static string EditData(string sql, DynamicParameters p, string paramName)
        //{
        //    using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
        //    {
        //        try
        //        {
        //            cnn.Execute(sql, p);
        //            return p.Get<string>(paramName);
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw;
        //        }
        //    }
        //}

        public static int EditData(string sql, DynamicParameters p)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    return cnn.Execute(sql, p);
                }
                catch (SqlException ex)
                {
                    throw;
                }

            }
        }

        public static int EditData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    return cnn.Execute(sql, data);
                }
                catch (SqlException ex)
                {
                    throw;
                }

            }
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                try
                {
                    return cnn.Query<T>(sql).ToList();
                }
                catch (SqlException ex)
                {
                    throw;
                }
            }
        }

        public static List<T> LoadData<T>(string sql, DynamicParameters p)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, p).ToList();
            }
        }

        public static T LoadSingleData<T>(string sql, DynamicParameters p)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.QuerySingle<T>(sql, p);
            }
        }
    }
}
