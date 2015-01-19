using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SavingSystem.Comon;

namespace SavingSystem.CustomDAL
{
    //public class IncomeDAL
    //{
    //    public IEnumerable<T> GetIncomes<T>(int profileId) where T : new()
    //    {
    //        IEnumerable<T> incomes;
    //        T income = default(T);
    //        using (SqlConnection connection = new SqlConnection(cnStr))
    //        {
    //            query = string.Format("SELECT * FROM Incomes WHERE ProfileId = {0}", profileId);
    //            using (SqlCommand command = new SqlCommand(query, connection))
    //            {
    //                connection.Open();
    //                SqlDataReader reader = command.ExecuteReader();
    //                List<string> columns = GetColumnsTable(reader);
    //                incomes = ReadData(reader, columns, income);
    //                connection.Close();
    //            }
    //        }

    //        foreach (var i in incomes)
    //        {
    //            using (SqlConnection connection = new SqlConnection(cnStr))
    //            {
    //                query = string.Format("SELECT * FROM IncomeCategories WHERE Id = {0}", i.IncomeCategoryId);
    //                using (SqlCommand command = new SqlCommand(query, connection))
    //                {
    //                    connection.Open();
    //                    SqlDataReader reader = command.ExecuteReader();
    //                    var incomeCategory = new IncomeCategory();
    //                    while (reader.Read())
    //                    {
    //                        incomeCategory.Title = (string)reader["Title"];
    //                        i.IncomeCategory = incomeCategory;
    //                    }
    //                    connection.Close();
    //                }
    //            }
    //        }
    //        return incomes;
    //    }


    //    public T GetIncome<T>(int profileId, int incomeId)
    //    {

    //        throw new NotImplementedException();
    //    }


    //    public IEnumerable<T> GetByDate<T>(int profileId, DateTime dateFrom, DateTime dateTo)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public IEnumerable<T> GetByDateAndCategory<T>(int profileId, DateTime dateFrom, DateTime dateTo, int incomeCategoryId) where T : class, new()
    //    {
    //        List<T> incomes;
    //        T income = default(T);
    //        using (SqlConnection connection = new SqlConnection(cnStr))
    //        {
    //            query = string.Format("SELECT Incomes.Summ, IncomeCategories.Title, Incomes.DateCreation, Incomes.Comment " +
    //                                  "FROM Incomes, IncomeCategories " +
    //                                  "WHERE Incomes.ProfileId = 1 " +
    //                                  "AND Incomes.IncomeCategoryId = IncomeCategories.Id " +
    //                                  "AND DateCreation BETWEEN '2014-07-16' AND '2014-07-18' " +
    //                                  "AND IncomeCategoryId = 2;");
    //            using (SqlCommand command = new SqlCommand(query, connection))
    //            {
    //                connection.Open();
    //                SqlDataReader reader = command.ExecuteReader();
    //                List<string> columns = GetColumnsTable(reader);
    //                incomes = ReadData(reader, columns, income);
    //                connection.Close();
    //            }
    //        }
    //        return null;
    //    }


    //    public IEnumerable<T> GetByCategory<T>(int profileId, int incomeCategoryId)
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public void Insert(int profileId, Income income)
    //    {
    //        using (SqlConnection connection = new SqlConnection(cnStr))
    //        {
    //            query = string.Format("INSERT INTO Incomes" +
    //                                         "(ProfileId, Summ, IncomeCategoryId, DateCreation, Comment) Values " +
    //                                         "(@ProfileId, @Summ, @IncomeCategoryId, @DateCreation, @Comment)");

    //            SqlCommand command = new SqlCommand(query, connection);
    //            command.Parameters.AddWithValue("@ProfileId", income.ProfileId);
    //            command.Parameters.AddWithValue("@Summ", income.Summ);
    //            if (income.IncomeCategoryId != 0)
    //            { command.Parameters.AddWithValue("@IncomeCategoryId", income.IncomeCategoryId); }
    //            else { command.Parameters.AddWithValue("@IncomeCategoryId", DBNull.Value); }
    //            command.Parameters.AddWithValue("@DateCreation", income.DateCreation);
    //            if (income.Comment != null)
    //            { command.Parameters.AddWithValue("@Comment", income.Comment); }
    //            else
    //            { command.Parameters.AddWithValue("@Comment", DBNull.Value); }

    //            connection.Open();
    //            command.ExecuteNonQuery();
    //            connection.Close();
    //        }
    //    }


    //    public void Update(int profileId, int incomeId, Income income)
    //    {
    //        using (SqlConnection connection = new SqlConnection(cnStr))
    //        {
    //            query = string.Format("UPDATE Incomes SET " +
    //                                         "Summ = @Summ, IncomeCategoryId = @IncomeCategoryId, " +
    //                                         "DateCreation = @DateCreation, Comment = @Comment WHERE Id = {0}", income.Id);

    //            SqlCommand command = new SqlCommand(query, connection);
    //            command.Parameters.AddWithValue("@Summ", income.Summ);
    //            if (income.IncomeCategoryId != 0)
    //            { command.Parameters.AddWithValue("@IncomeCategoryId", income.IncomeCategoryId); }
    //            else { command.Parameters.AddWithValue("@IncomeCategoryId", DBNull.Value); }
    //            command.Parameters.AddWithValue("@DateCreation", income.DateCreation);
    //            if (income.Comment != null)
    //            { command.Parameters.AddWithValue("@Comment", income.Comment); }
    //            else
    //            { command.Parameters.AddWithValue("@Comment", DBNull.Value); }

    //            connection.Open();
    //            command.ExecuteNonQuery();
    //            connection.Close();
    //        }
    //    }


    //    public void DeleteIncome(int profileId, int incomeId)
    //    {
    //        string tableName = "Incomes";
    //        DeleteItemInTableById(tableName, incomeId);
    //    }
    //}
}
