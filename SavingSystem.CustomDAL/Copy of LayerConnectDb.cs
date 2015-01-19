using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using SavingSystem.Comon;
using SavingSystem.Models;

namespace SavingSystem.CustomDAL
{
    public class LayerConnectDbNotUse
    {
        protected string cnStr;
        protected string query;

        public LayerConnectDbNotUse()
        {
            cnStr = ConfigurationManager.ConnectionStrings["SavSysEntities"].ConnectionString;
        }

        public List<Balance> ViewBalances(int idProfile)
        {
            List<Balance> balances;
            Balance balance = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from Balances where ProfileId = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    balances = ReadData(reader, columns, balance);
                    connection.Close();
                }
            }
            return balances;
        }
        public void InsertBalance(Balance balance)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into Balances"
                                             + "(ProfileId, Summ, DateCreation) Values "
                                             + "(@ProfileId, @Summ, @DateCreation)");

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@ProfileId", balance.ProfileId);
                command.Parameters.AddWithValue("@Summ", balance.Summ);
                command.Parameters.AddWithValue("@DateCreation", balance.DateCreation);

                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateBalance(Balance balance)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update Balances Set Summ = @Summ, DateCreation = '@DateCreation'" +
                                             " Where Id = {0}", balance.Id);
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Summ", balance.Summ);
                command.Parameters.AddWithValue("@DateCreation", balance.DateCreation);

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteBalance(int id)
        {
            string tableName = "Balances";
            DeleteItemInTable(tableName, id);
        }

        public List<Borrover> ViewBorrovers(int idProfile)
        {
            List<Borrover> borrovers;
            Borrover borrover = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from Borrovers where ProfileId = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    borrovers = ReadData(reader, columns, borrover);
                    connection.Close();
                }
            }
            return borrovers;
        }
        public void InsertBorrover(Borrover borrover)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into Borrovers"
                                             + "(ProfileId, Summ, BorroverName, DateIssue, DateExpiration, Comment) Values "
                                             + "(@ProfileId, @Summ, @BorroverName, @DateIssue, @DateExpiration, @Comment)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProfileId", borrover.ProfileId);
                command.Parameters.AddWithValue("@Summ", borrover.Summ);
                command.Parameters.AddWithValue("@BorroverName", borrover.BorroverName);
                command.Parameters.AddWithValue("@DateIssue", borrover.DateIssue);
                command.Parameters.AddWithValue("@DateExpiration", borrover.DateExpiration);
                if (borrover.Comment != null)
                { command.Parameters.AddWithValue("@Comment", borrover.Comment); }
                else
                { command.Parameters.AddWithValue("@Comment", DBNull.Value); }
                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateBorrover(Borrover borrover)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update Borrovers Set " +
                                             "Summ = @Summ, BorroverName = @BorroverName, " +
                                             "DateIssue = @DateIssue, DateExpiration = @DateExpiration, Comment = @Comment" +
                                             "Where Id = {0}", borrover.Id);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Summ", borrover.Summ);
                command.Parameters.AddWithValue("@BorroverName", borrover.BorroverName);
                command.Parameters.AddWithValue("@DateIssue", borrover.DateIssue);
                command.Parameters.AddWithValue("@DateExpiration", borrover.DateExpiration);
                if (borrover.Comment != null)
                { command.Parameters.AddWithValue("@Comment", borrover.Comment); }
                else
                { command.Parameters.AddWithValue("@Comment", DBNull.Value); }

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteBorrover(int id)
        {
            string tableName = "Borrovers";
            DeleteItemInTable(tableName, id);
        }

        public List<Creditor> ViewCreditors(int idProfile)
        {
            List<Creditor> creditors;
            Creditor creditor = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from Creditors where ProfileId = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    creditors = ReadData(reader, columns, creditor);
                    connection.Close();
                }
            }
            return creditors;
        }
        public void InsertCreditor(Creditor creditor)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into Creditors"
                                             + "(ProfileId, Summ, CreditorName, DateIssue, DateExpiration, Comment) Values "
                                             + "(@ProfileId, @Summ, @CreditorName, @DateIssue, @DateExpiration, @Comment)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProfileId", creditor.ProfileId);
                command.Parameters.AddWithValue("@Summ", creditor.Summ);
                command.Parameters.AddWithValue("@BorroverName", creditor.CreditorName);
                command.Parameters.AddWithValue("@DateIssue", creditor.DateIssue);
                command.Parameters.AddWithValue("@DateExpiration", creditor.DateExpiration);
                if (creditor.Comment != null)
                { command.Parameters.AddWithValue("@Comment", creditor.Comment); }
                else
                { command.Parameters.AddWithValue("@Comment", DBNull.Value); }

                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateCreditor(Creditor creditor)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update Creditors Set " +
                                             "Summ = @Summ, CreditorName = @CreditorName, " +
                                             "DateIssue = @DateIssue, DateExpiration = @DateExpiration, Comment = @Comment" +
                                             "Where Id = {0}", creditor.Id);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Summ", creditor.Summ);
                command.Parameters.AddWithValue("@CreditorName", creditor.CreditorName);
                command.Parameters.AddWithValue("@DateIssue", creditor.DateIssue);
                command.Parameters.AddWithValue("@DateExpiration", creditor.DateExpiration);
                if (creditor.Comment != null)
                { command.Parameters.AddWithValue("@Comment", creditor.Comment); }
                else
                { command.Parameters.AddWithValue("@Comment", DBNull.Value); }

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteCreditor(int id)
        {
            string tableName = "Creditors";
            DeleteItemInTable(tableName, id);
        }

        public List<Expense> ViewExpenses(int idProfile)
        {
            List<Expense> expenses;
            Expense expense = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from Expenses where ProfileId = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    expenses = ReadData(reader, columns, expense);
                    connection.Close();
                }
            }

            foreach (var e in expenses)
            {
                using (SqlConnection connection = new SqlConnection(cnStr))
                {
                    query = string.Format("Select * from ExpenseCategories where Id = {0}", e.ExpenseCategoryId);
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        var exCategory = new ExpenseCategory();
                        while (reader.Read())
                        {
                            exCategory.Title = (string)reader["Title"];
                            e.ExpenseCategory = exCategory;
                        }
                        connection.Close();
                    }
                }
            }
            return expenses;
        }
        public void InsertExpense(Expense expense)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into Expenses " +
                                             "(ProfileId, Summ, ExpenseCategoryId, DateCreation, Comment) Values " +
                                             "(@ProfileId, @Summ, @ExpenseCategoryId, @DateCreation, @Comment)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProfileId", expense.ProfileId);
                command.Parameters.AddWithValue("@Summ", expense.Summ);
                if (expense.ExpenseCategoryId != 0)
                { command.Parameters.AddWithValue("@ExpenseCategoryId", expense.ExpenseCategoryId); }
                else { command.Parameters.AddWithValue("@ExpenseCategoryId", DBNull.Value); }
                command.Parameters.AddWithValue("@DateCreation", expense.DateCreation);
                if (expense.Comment != null)
                { command.Parameters.AddWithValue("@Comment", expense.Comment); }
                else
                { command.Parameters.AddWithValue("@Comment", DBNull.Value); }

                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateExpense(Expense expense)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update Expenses Set " +
                                             "Summ = @Summ, ExpenseCategoryId = @ExpenseCategoryId, " +
                                             "DateCreation = @DateCreation, Comment = @Comment where Id = {0}", expense.Id);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Summ", expense.Summ);
                if (expense.ExpenseCategoryId != 0)
                { command.Parameters.AddWithValue("@ExpenseCategoryId", expense.ExpenseCategoryId); }
                else { command.Parameters.AddWithValue("@ExpenseCategoryId", DBNull.Value); }
                command.Parameters.AddWithValue("@DateCreation", expense.DateCreation);
                if (expense.Comment != null)
                { command.Parameters.AddWithValue("@Comment", expense.Comment); }
                else
                { command.Parameters.AddWithValue("@Comment", DBNull.Value); }

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteExpense(int id)
        {
            string tableName = "Expenses";
            DeleteItemInTable(tableName, id);
        }

        

        public List<ExpenseCategory> ViewExpenseCategories(int idProfile)
        {
            List<ExpenseCategory> expenseCategories;
            ExpenseCategory expenseCategory = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from ExpenseCategories where ProfileId = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    expenseCategories = ReadData(reader, columns, expenseCategory);
                    connection.Close();
                }
            }
            return expenseCategories;
        }
        public void InsertExpenseCategory(ExpenseCategory expenseCategory)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into ExpenseCategories (Title, ProfileId) Values (@Title, @ProfileId)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", expenseCategory.Id);
                command.Parameters.AddWithValue("@ProfileId", expenseCategory.ProfileId);

                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateExpenseCategory(ExpenseCategory expenseCategory)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update ExpenseCategories Set Title = '@Title' where Id = {0}", expenseCategory.Id);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", expenseCategory.Title);

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteExpenseCategory(int id)
        {
            string tableName = "ExpenseCategories";
            DeleteItemInTable(tableName, id);
        }

        public List<IncomeCategory> ViewIncomeCategories(int idProfile)
        {
            List<IncomeCategory> incomeCategories;
            IncomeCategory incomeCategory = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from IncomeCategories where ProfileId = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    incomeCategories = ReadData(reader, columns, incomeCategory);
                    connection.Close();
                }
            }
            return incomeCategories;
        }
        public void InsertIncomeCategory(IncomeCategory incomeCategory)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into IncomeCategories (Title, ProfileId) Values (@Title, @ProfileId)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", incomeCategory.Id);
                command.Parameters.AddWithValue("@ProfileId", incomeCategory.ProfileId);

                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateIncomeCategory(IncomeCategory incomeCategory)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update IncomeCategories Set Title = '@Title' where Id = {0}", incomeCategory.Id);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Title", incomeCategory.Title);

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteIncomeCategory(int id)
        {
            string tableName = "IncomeCategories";
            DeleteItemInTable(tableName, id);
        }

        public List<Profile> ViewProfiles(int idProfile)
        {
            List<Profile> profiles;
            Profile profile = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from Profiles where Id = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    profiles = ReadData(reader, columns, profile);
                    connection.Close();
                }
            }

            foreach (var p in profiles)
            {
                using (SqlConnection connection = new SqlConnection(cnStr))
                {
                    query = string.Format("Select * from Roles where Id = {0}", p.RoleId);
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        var role = new Role();
                        while (reader.Read())
                        {
                            role.Name= (string)reader["Name"];
                            p.Role = role;
                        }
                        connection.Close();
                    }
                }
            }

            return profiles;
        }
        public List<string> ViewEmaiListProfiles()
        {
            var emails = new List<string>();
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("select Email from Profiles");
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        emails.Add((string)reader["Email"]);
                    }
                    connection.Close();
                }
            }
            return emails;
        }
        public void InsertProfile(Profile profile)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into Profiles (Email, FirstName, Birthday, Password, DateCreation, RoleId)" +
                                             " Values (@Email, @FirstName, @Birthday, @Password, @DateCreation, @RoleId)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", profile.Email);
                command.Parameters.AddWithValue("@FirstName", profile.FirstName);
                if (profile.Birthday != DateTime.Parse("01.01.0001 0:00:00") && profile.Birthday != null)
                { command.Parameters.AddWithValue("@Birthday", profile.Birthday); }
                else
                { command.Parameters.AddWithValue("@Birthday", DBNull.Value); }
                command.Parameters.AddWithValue("@Password", profile.Password);
                command.Parameters.AddWithValue("@DateCreation", profile.DateCreation);
                command.Parameters.AddWithValue("@RoleId", profile.RoleId);

                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateProfile(Profile profile)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update Profiles Set (Email = @Email, FirstName = @FirstName, " +
                                             "Birthday = '@Birthday', Password = '@Password', DateCreation = '@DateCreation', " +
                                             "RoleId = @RoleId where Id = {0}", profile.Id);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", profile.Email);
                command.Parameters.AddWithValue("@FirstName", profile.FirstName);
                if (profile.Birthday != DateTime.Parse("01.01.0001 0:00:00"))
                { command.Parameters.AddWithValue("@Birthday", profile.Birthday); }
                else
                { command.Parameters.AddWithValue("@Birthday", DBNull.Value); }
                command.Parameters.AddWithValue("@Password", profile.Password);
                command.Parameters.AddWithValue("@DateCreation", profile.DateCreation);
                command.Parameters.AddWithValue("@RoleId", profile.RoleId);

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteProfile(int id)
        {
            string tableName = "Profiles";
            DeleteItemInTable(tableName, id);
        }

        public List<Role> ViewRoles(int idProfile)
        {
            List<Role> roles;
            Role role = null;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from Roles where Id = {0}", idProfile);
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    List<string> columns = GetColumnsFromTable(reader);
                    roles = ReadData(reader, columns, role);
                    connection.Close();
                }
            }
            return roles;
        }
        public void InsertRole(Role role)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Insert Into Roles (Name, ProfileId" +
                                             " Values ('@Name', @ProfileId)");

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", role.Name);
                command.Parameters.AddWithValue("@ProfileId", role.ProfileId);

                OpenExecCloseConn(connection, command);
            }
        }
        public void UpdateRole(Role role)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Update Roles Set (Name = @Name, ProfileId = @ProfileId) " +
                                             "where Id = {0}", role.Id);

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", role.Name);

                OpenExecCloseConn(connection, command);
            }
        }
        public void DeleteRole(int id)
        {
            string tableName = "Roles";
            DeleteItemInTable(tableName, id);
        }


        public List<T> ViewDataTable<T>(T userType, string tableName) where T : new()
        {
            List<T> results;
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Select * from {0}", tableName);
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<string> columns = GetColumnsFromTable(reader);
                results = ReadData(reader, columns, userType);
                connection.Close();
            }
            return results;
        }

        protected List<T> ReadData<T>(SqlDataReader reader, List<string> columns, T type) where T : new()
        {
            var results = new List<T>();
            type = new T();
            PropertyInfo[] props = type.GetType().GetProperties();
            while (reader.Read())
            {
                var tempType = new T();
                foreach (string column in columns)
                {
                    foreach (PropertyInfo property in props)
                    {
                        if (property.Name == column)
                        {
                            if (!(reader[column] is DBNull))
                            {
                                property.SetValue(tempType, reader[column]);
                            }
                        }
                    }
                }
                results.Add(tempType);
            }
            return results;
        }

        protected List<string> GetColumnsFromTable(SqlDataReader reader)
        {
            var columns = new List<string>();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                columns.Add(reader.GetName(i));
            }
            return columns;
        }

        protected void DeleteItemInTable(string tableName, int id)
        {
            using (SqlConnection connection = new SqlConnection(cnStr))
            {
                query = string.Format("Delete from {0} where Id = {1}", tableName, id);
                SqlCommand command = new SqlCommand(query, connection);
                OpenExecCloseConn(connection, command);
            }
        }

        protected void OpenExecCloseConn(SqlConnection connection, SqlCommand command)
        {
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}