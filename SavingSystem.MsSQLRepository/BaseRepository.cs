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
        protected readonly string CnStr;
        protected QueryManager QueryManager;

        protected BaseRepository(string cnString = "SavSysEntities")
        {
            CnStr = ConfigurationManager.ConnectionStrings[cnString].ConnectionString;
            QueryManager = new QueryManager();
        }


        public virtual IEnumerable<T> GetAll()
        {
            IList<T> items;
            IList<PropertyInfo> properties = typeof(T).GetProperties();
            var tableName = typeof(T).GetCustomAttribute<TableNameAttribute>().Name;
            if (tableName == null) { throw new NullReferenceException("Table name attribute of type cannot be empty or null."); }
            List<string> columnsStrings = GetColumnsStringsOnAttributesProperties(properties);

            using (var connection = new SqlConnection(CnStr))
            {
                var query = QueryManager.GenerateSelectAllQuery(tableName, columnsStrings);
                using (var command = new SqlCommand(query, connection))
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

        public virtual IEnumerable<T> GetAll(int profileId)
        {
            IList<T> items;
            var type = new T();
            IList<PropertyInfo> properties = type.GetType().GetProperties();
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName == null) { throw new NullReferenceException("Table name attribute of type cannot be empty or null."); }
            List<string> columnsStrings = GetColumnsStringsOnAttributesProperties(properties);

            using (var connection = new SqlConnection(CnStr))
            {
                var query = QueryManager.GenerateSelectAllQuery(tableName.Name, columnsStrings, profileId);
                using (var command = new SqlCommand(query, connection))
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

        public virtual T Get(int profileId, int fieldId)
        {
            IList<T> items;
            var type = new T();
            IList<PropertyInfo> properties = type.GetType().GetProperties();
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName == null) { throw new NullReferenceException("Table name attribute of type cannot be empty or null."); }
            List<string> columnsStrings = GetColumnsStringsOnAttributesProperties(properties);

            using (var connection = new SqlConnection(CnStr))
            {
                var query = QueryManager.GenerateSelectOneFild(tableName.Name, columnsStrings, profileId, fieldId);
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    IList<string> columns = GetColumnsTable(reader);
                    items = ReadData<T>(reader, columns, properties);
                    connection.Close();
                    //reader.Close();
                }
            }
            return items.First();
        }
        
        public virtual bool Add(int profileId, T type)
        {
            IList<PropertyInfo> properties = type.GetType().GetProperties();
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName == null) { throw new NullReferenceException("Table name attribute of type cannot be empty or null."); }
            List<string> columnsStrings = GetColumnsStringsOnAttributesProperties(properties);
            var columnAttribures = GetAttributesInProperties(properties);

            using (var connection = new SqlConnection(CnStr))
            {
                var query = QueryManager.GenerateInsertQuery(tableName.Name, columnsStrings);
                var command = new SqlCommand(query, connection);

                foreach (var column in columnAttribures)
                {
                    var propValue = type.GetType().GetProperty(column.PropertyName).GetValue(type);
                    if (propValue != null)
                    {
                        command.Parameters.AddWithValue("@" + column.ColumnName, propValue);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@" + column.ColumnName, DBNull.Value);
                    }
                }
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }
        
        public virtual bool Update(int fieldId, T type)
        {
            IList<PropertyInfo> properties = type.GetType().GetProperties();
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName == null) { throw new NullReferenceException("Table name attribute of type cannot be empty or null."); }
            List<string> columnsStrings = GetColumnsStringsOnAttributesProperties(properties);
            var columnAttribures = GetAttributesInProperties(properties);

            using (var connection = new SqlConnection(CnStr))
            {
                var query = QueryManager.GenerateUpdateQuery(tableName.Name, columnsStrings, fieldId);
                var command = new SqlCommand(query, connection);

                foreach (var column in columnAttribures)
                {
                    var propValue = type.GetType().GetProperty(column.PropertyName).GetValue(type);
                    if (propValue != null)
                    {
                        command.Parameters.AddWithValue("@" + column.ColumnName, propValue);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@" + column.ColumnName, DBNull.Value);
                    }
                }
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }
        
        public virtual bool Delete(int fieldId, T type)
        {
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName == null) { throw new NullReferenceException("Table name attribute of type cannot be empty or null."); }
            
            using (var connection = new SqlConnection(CnStr))
            {
                var query = QueryManager.GenerateDeleteQuery(tableName.Name, fieldId);
                var command = new SqlCommand(query, connection);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            return true;
        }


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

        
        protected List<string> GetColumnsStringsOnAttributesProperties(IEnumerable<PropertyInfo> properties)
        {
            var columnsNames = new List<string>();
            foreach (var property in properties)
            {
                Attribute attribute = property.GetCustomAttribute(typeof(ColumnNameAttribute));
                var columnNameAttribute = (ColumnNameAttribute)attribute;
                if (columnNameAttribute != null)
                {
                    columnsNames.Add(columnNameAttribute.ColumnName);
                }
            }
            return columnsNames;
        }


        protected IList<PropertyInfo> GetPropertiesOnAttributes(IEnumerable<PropertyInfo> properties)
        {
            var propertiesOnAttr = new List<PropertyInfo>();
            foreach (var property in properties)
            {
                if (property.GetCustomAttribute(typeof(ColumnNameAttribute)) != null)
                {
                    propertiesOnAttr.Add(property);
                }
            }
            return propertiesOnAttr;
        }


        protected IList<ColumnNameAttribute> GetAttributesInProperties(IEnumerable<PropertyInfo> properties)
        {
            var attributes = new List<ColumnNameAttribute>();
            foreach (var property in properties)
            {
                Attribute attribute = property.GetCustomAttribute(typeof(ColumnNameAttribute));
                var columnNameAttribute = (ColumnNameAttribute)attribute;
                if (attribute != null)
                {
                    attributes.Add(columnNameAttribute);
                }
            }
            return attributes;
        }
        #endregion
    }
}
