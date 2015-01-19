using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using SavingSystem.BaseRepository.Interfaces;
using SavingSystem.Comon.Attributes;
using SavingSystem.QueryBuilder;


namespace SavingSystem.MsSQLRepository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private string cnStr;
        protected QueryManager QueryManager = new QueryManager();

        protected BaseRepository(string cnString = "SavSysEntities")
        {
            cnStr = ConfigurationManager.ConnectionStrings[cnString].ConnectionString;
        }

        public IEnumerable<T> GetAll()
        {
            IList<T> items;
            T type = default(T);
            IList<PropertyInfo> properties = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                var query = QueryManager.GenerateSelectAllQuery(type, ref properties);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    IList<string> columns = GetColumnsTable(reader);
                    items = ReadData<T>(reader, columns, properties);
                    connection.Close();
                }
            }
            return items;
        }

        public IEnumerable<T> GetAll(int profileId)
        {
            IList<T> items;
            T type = new T();
            IList<PropertyInfo> properties = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                var query = QueryManager.GenerateSelectAllQuery(type, ref properties, profileId);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    IList<string> columns = GetColumnsTable(reader);
                    items = ReadData<T>(reader, columns, properties);
                    connection.Close();
                }
            }
            return items;
        }

        public T Get(int profileId, int fieldId)
        {
            IList<T> items;
            T type = default(T);
            IList<PropertyInfo> properties = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                var query = QueryManager.GenerateSelectAllQuery(type, ref properties, profileId, fieldId);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    IList<string> columns = GetColumnsTable(reader);
                    items = ReadData<T>(reader, columns, properties);
                    connection.Close();
                }
            }
            return items.First();
        }

        public bool Add(int profileId, T type)
        {
            List<ColumnNameAttribute> attributes = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                var query = QueryManager.GenerateInsertQuery(type, ref attributes);
                SqlCommand command = new SqlCommand(query, connection);

                foreach (var attribute in attributes)
                {
                    var propValue = type.GetType().GetProperty(attribute.PropertyName).GetValue(type);
                    if (propValue != null)
                    {
                        command.Parameters.AddWithValue("@" + attribute.ColumnName, propValue);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@" + attribute.ColumnName, DBNull.Value);
                    }
                }
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }


        public abstract bool Update(int profileId, int itemId, T item);
        public abstract bool Delete(int profileId, int itemId);




        #region Help methods
        protected IList<T> ReadData<T>(SqlDataReader reader, IList<string> columns, IList<PropertyInfo> properties) where T : new()
        {
            var objects = new List<T>();
            while (reader.Read())
            {
                var obj = new T();
                foreach (string column in columns)
                {
                    foreach (PropertyInfo property in properties)
                    {
                        var attribute = (ColumnNameAttribute)property.GetCustomAttribute(typeof(ColumnNameAttribute));
                        if (attribute == null)
                        {
                            continue;
                        }
                        if (attribute.ColumnName == column)
                        {
                            if (!(reader[column] is DBNull))
                            {
                                property.SetValue(obj, reader[column]);
                            }
                        }
                    }
                }
                objects.Add(obj);
            }
            return objects;
        }


        protected IList<string> GetColumnsTable(SqlDataReader reader)
        {
            var columns = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }
            return columns;
        }


        protected void DeleteItemInTableById(string tableName, int id)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                string query = string.Format("Delete from {0} where Id = {1}", tableName, id);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }


        protected void OpenExecCloseConn(SqlConnection connection, SqlCommand command)
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        
        #endregion
    }
}
