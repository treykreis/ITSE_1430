﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{

    /// <summary>Provides an implementation of IProductDatabase using SQL server</summary>
    public class SqlProductDatabase : ProductDatabase 
    {
        #region Construction
        public SqlProductDatabase (string connectionString)
        {
            _connectionString = connectionString;
        }

        private readonly string _connectionString;
        #endregion
        protected override Product AddCore( Product product )
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Product> GetAllCore()
        {
            var products = new List<Product>();
           
            using (var connection = OpenDatabase())
            {
                var cmd = new SqlCommand("GetAllProducts", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //reader.GetName(0);
                        //reader.GetFieldType(1)
                        //Convert.ToInt32(reader["Id"]);

                        var product = new Product() 
                        {
                            Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0),
                            Name = reader.GetFieldValue<string>(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            IsDiscontinued = reader.GetBoolean(4)
                        };
                    };
                };

                return products;
            };
        }

        protected override Product GetCore( int id )
        {
            throw new NotImplementedException();
        }

        protected override void RemoveCore( int id )
        {
            throw new NotImplementedException();
        }

        protected override Product UpdateCore( Product existing, Product newItem )
        {
            throw new NotImplementedException();
        }

        private SqlConnection OpenDatabase()
        {

            var connection = new SqlConnection(_connectionString);

            connection.Open();

            return connection;

        }
    }
}
