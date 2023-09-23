using CSharpTraining.Helper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CSharpTraining.Services
{
    public class DapperService
    {
        public readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;
        public DapperService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }
        public string GetConnection() { return _sqlConnectionStringBuilder.ConnectionString; }


        public int Excute(string Query)
        {
            using IDbConnection db = new SqlConnection(GetConnection());
            return db.Execute(Query);
        }

        public List<T> Query<T>(string Query)
        {
            using IDbConnection db = new SqlConnection(GetConnection());
            return db.Query<T>(Query).ToList();
        }

        public T QueryFirstOrDefault<T>(string Query)
        {
            using IDbConnection db = new SqlConnection(GetConnection());
            return db.QueryFirstOrDefault<T>(Query);
        }
    }
}
