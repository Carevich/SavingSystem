using System;

namespace SavingSystem.Comon.Attributes
{
    public class ColumnNameAttribute : Attribute
    {
        public string ColumnName { get; set; }
        public string PropertyName { get; set; }

        public ColumnNameAttribute(string columnName, string propertyName)
        {
            ColumnName = columnName;
            PropertyName = propertyName;
        }
    }
}
