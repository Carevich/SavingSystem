using System;

namespace SavingSystem.Comon.Attributes
{
    public class TableNameAttribute : Attribute
    {
        public string Name { get; set; }
        public TableNameAttribute(string tableName)
        {
            Name = tableName;
        }
    }
}
