using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SavingSystem.QueryBuilder
{
    public class QueryManager
    {
        public string GenerateSelectAllQuery(string tableName, IList<string> columnsStrings)
        {
            var sb = new StringBuilder();

            sb.Append("SELECT");
            sb.Append(" ");
            foreach (var column in columnsStrings)
            {
                sb.Append(column);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("FROM");
            sb.Append(" ");
            sb.Append(tableName);

            return sb.ToString();
        }


        public string GenerateSelectAllQuery(string tableName, IList<string> columnsStrings, int profileId)
        {
            var sb = new StringBuilder();

            sb.Append("SELECT");
            sb.Append(" ");
            foreach (var column in columnsStrings)
            {
                sb.Append(column);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("FROM");
            sb.Append(" ");
            sb.Append(tableName);
            sb.Append(" ");
            sb.Append("WHERE ProfileId = ");
            sb.Append(profileId.ToString(CultureInfo.InvariantCulture));
            sb.Append(";");

            return sb.ToString();
        }


        public string GenerateSelectOneFild(string tableName, IList<string> columnsStrings, int profileId, int fieldId)
        {
            var sb = new StringBuilder();

            sb.Append("SELECT");
            sb.Append(" ");

            foreach (var column in columnsStrings)
            {
                sb.Append(column);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("FROM");
            sb.Append(" ");
            sb.Append(tableName);
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


        public string GenerateInsertQuery(string tableName, IList<string> columnsStrings)
        {
            var sb = new StringBuilder();

            sb.Append("INSERT INTO");
            sb.Append(" ");
            sb.Append(tableName);
            sb.Append(" ");
            sb.Append("(");
            foreach (var column in columnsStrings)
            {
                sb.Append(column);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");
            sb.Append(" ");
            sb.Append("VALUES");
            sb.Append(" ");
            sb.Append("(");
            foreach (var column in columnsStrings)
            {
                sb.Append("@");
                sb.Append(column);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(")");

            return sb.ToString();
        }


        public string GenerateUpdateQuery(string tableName, IList<string> columnsStrings, int fieldId)
        {
            var sb = new StringBuilder();

            sb.Append("UPDATE");
            sb.Append(" ");
            sb.Append(tableName);
            sb.Append(" ");
            sb.Append("SET");
            sb.Append(" ");
            foreach (var column in columnsStrings)
            {
                sb.Append(column);
                sb.Append(" ");
                sb.Append("=");
                sb.Append(" ");
                sb.Append("@");
                sb.Append(column);
                sb.Append(", ");
            }
            sb.Remove(sb.Length - 2, 1);
            sb.Append("WHERE Id = ");
            sb.Append(fieldId.ToString(CultureInfo.InvariantCulture));

            return sb.ToString();
        }


        public string GenerateDeleteQuery(string tableName, int fieldId)
        {
            var sb = new StringBuilder();

            sb.Append("DELETE FROM");
            sb.Append(" ");
            sb.Append(tableName);
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
    }
}
