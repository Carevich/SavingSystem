using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using SavingSystem.Comon.Attributes;

namespace SavingSystem.QueryBuilder
{
    public class QueryManager
    {
        public string GenerateSelectAllQuery<T>(T type, ref IList<PropertyInfo> properties)
        {
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName.Name == null)
            {
                return null;
            }
            properties = type.GetType().GetProperties();
            var attributes = GetAttributesProperties(properties);
            var sb = new StringBuilder();

            sb.Append("SELECT");
            sb.Append(" ");
            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    sb.Append(attribute.ColumnName);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("FROM");
            sb.Append(" ");
            sb.Append(tableName.Name);

            return sb.ToString();
        }

        public string GenerateSelectAllQuery<T>(T type, ref IList<PropertyInfo> properties, int profileId)
        {
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName.Name == null)
            {
                return null;
            }
            properties = type.GetType().GetProperties();
            var attributes = GetAttributesProperties(properties);
            var sb = new StringBuilder();

            sb.Append("SELECT");
            sb.Append(" ");
            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    sb.Append(attribute.ColumnName);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("FROM");
            sb.Append(" ");
            sb.Append(tableName.Name);
            sb.Append(" ");
            sb.Append("WHERE ProfileId = ");
            sb.Append(profileId.ToString(CultureInfo.InvariantCulture));
            sb.Append(";");

            return sb.ToString();
        }

        public string GenerateSelectAllQuery<T>(T type, ref IList<PropertyInfo> properties, int profileId, int fieldId)
        {
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName.Name == null)
            {
                return null;
            }
            properties = type.GetType().GetProperties();
            var attributes = GetAttributesProperties(properties);
            var sb = new StringBuilder();

            sb.Append("SELECT");
            sb.Append(" ");

            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    sb.Append(attribute.ColumnName);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("FROM");
            sb.Append(" ");
            sb.Append(tableName.Name);
            sb.Append(" ");
            sb.Append("WHERE ProfileId = ");
            sb.Append(profileId.ToString(CultureInfo.InvariantCulture));
            sb.Append(" ");
            sb.Append("AND");
            sb.Append(" ");
            sb.Append("Id = ");
            sb.Append(fieldId.ToString(CultureInfo.InvariantCulture));
            sb.Append(";");
            return sb.ToString();
        }

        public string GenerateInsertQuery<T>(T type, ref List<ColumnNameAttribute> attributes)
        {
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName.Name == null)
            {
                return null;
            }
            var properties = type.GetType().GetProperties();
            attributes = GetAttributesProperties(properties);
            var sb = new StringBuilder();

            sb.Append("INSERT INTO");
            sb.Append(" ");
            sb.Append(tableName.Name);
            sb.Append(" ");
            sb.Append("(");
            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    sb.Append(attribute.ColumnName);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            sb.Append(" ");
            sb.Append("VALUES");
            sb.Append(" ");
            sb.Append("(");
            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    sb.Append("@");
                    sb.Append(attribute.ColumnName);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");

            return sb.ToString();
        }


        public string GenerateUpdateQuery<T>(T type, int fieldId)
        {
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName.Name == null)
            {
                return null;
            }
            var properties = type.GetType().GetProperties();
            var attributes = GetAttributesProperties(properties);
            var sb = new StringBuilder();

            sb.Append("UPDATE");
            sb.Append(" ");
            sb.Append(tableName.Name);
            sb.Append(" ");
            sb.Append("SET");
            sb.Append(" ");
            foreach (var attribute in attributes)
            {
                if (attribute != null)
                {
                    sb.Append(attribute.ColumnName);
                    sb.Append(" ");
                    sb.Append("=");
                    sb.Append(" ");
                    sb.Append("@");
                    sb.Append(attribute.ColumnName);
                    sb.Append(", ");
                }
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("WHERE Id = ");
            sb.Append(fieldId.ToString(CultureInfo.InvariantCulture));

            return sb.ToString();
        }


        public string GenerateDeleteQuery<T>(T type, int fieldId)
        {
            var tableName = (TableNameAttribute)type.GetType().GetCustomAttribute(typeof(TableNameAttribute));
            if (tableName.Name == null)
            {
                return null;
            }
            var sb = new StringBuilder();

            sb.Append("DELETE FROM");
            sb.Append(" ");
            sb.Append(tableName.Name);
            sb.Append(" ");
            sb.Append("WHERE");
            sb.Append(" ");
            sb.Append("Id");
            sb.Append(" ");
            sb.Append("=");
            sb.Append(" ");
            sb.Append(fieldId.ToString(CultureInfo.InvariantCulture));

            return sb.ToString();
        }


        private List<ColumnNameAttribute> GetAttributesProperties(IList<PropertyInfo> properties)
        {
            var attributesProperties = new List<ColumnNameAttribute>();
            foreach (var property in properties)
            {
                Attribute attribute = property.GetCustomAttribute(typeof(ColumnNameAttribute));
                var columnNameAttribute = (ColumnNameAttribute)attribute;
                if (columnNameAttribute != null)
                {
                    attributesProperties.Add(columnNameAttribute);
                }
            }
            return attributesProperties;
        }
    }
}
