using System;

namespace SavingSystem.Comon.Attributes
{
    public class ColumnNameAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public string PropertyName { get; set; }

        /// <summary>
        /// If the column name is equal to the property name.
        /// </summary>
        /// <param name="columnName">Column name.</param>
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
            PropertyName = columnName;
        }

        /// <summary>
        /// If the column name is NOT equal to the property name.
        /// </summary>
        /// <param name="columnName">Column name.</param>
        /// <param name="propertyName">Property name.</param>
        public ColumnNameAttribute(string columnName, string propertyName)
        {
            ColumnName = columnName;
            PropertyName = propertyName;
        }
    }
}
