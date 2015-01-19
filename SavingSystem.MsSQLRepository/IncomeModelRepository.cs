using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using SavingSystem.BaseRepository.Interfaces;
using SavingSystem.Comon.Mapping_Model;

namespace SavingSystem.MsSQLRepository
{
    public class IncomeModelRepository : BaseRepository<IncomeModel>, IIncomeModelRepository
    {
        /// <summary>
        /// Get all the income profile of all time.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <returns>All incomes.</returns>
        public override IEnumerable<IncomeModel> GetAll(int profileId)
        {
            var result = base.GetAll(profileId);
            return result;
        }


        /// <summary>
        /// Get all incomes by date.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="dateFrom">Date from.</param>
        /// <param name="dateTo">Date to.</param>
        /// <returns>List incomes by date.</returns>
        public IEnumerable<IncomeModel> GetByDate(int profileId, DateTime dateFrom, DateTime dateTo)
        {
            IList<IncomeModel> items;
            IList<PropertyInfo> properties = new IncomeModel().GetType().GetProperties();

            var query = String.Format("SELECT Incomes.Id, Incomes.Summ, IncomeCategories.Title, Incomes.DateCreation, Incomes.Comment " +
                                      "FROM Incomes, IncomeCategories " +
                                      "WHERE Incomes.ProfileId = {0} " +
                                      "AND Incomes.IncomeCategoryId = IncomeCategories.Id " +
                                      "AND Incomes.DateCreation BETWEEN '{1}' AND '{2}'",
                                      profileId, dateFrom.ToString(CultureInfo.InvariantCulture), dateTo.ToString(CultureInfo.InvariantCulture));
            using (var connection = new SqlConnection(CnStr))
            {
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        IList<string> columns = GetColumnsTable(reader);
                        items = ReadData<IncomeModel>(reader, columns, properties);
                        reader.Close();
                    }
                }
                connection.Close();
            }
            return items;
        }


        /// <summary>
        /// Get all incomes by date and category.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="dateFrom">Date from.</param>
        /// <param name="dateTo">Date to.</param>
        /// <param name="incomeCategoryId">Income category id</param>
        /// <returns></returns>
        public IEnumerable<IncomeModel> GetByDateAndCategory(int profileId, DateTime dateFrom, DateTime dateTo, int incomeCategoryId)
        {
            return null;
        }


        /// <summary>
        /// Get all incomes by category of all time.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <returns>Incomes b category.</returns>
        public IEnumerable<IncomeModel> GetByCategory(int profileId)
        {
            return null;
        }


        #region Not Implement
        public override bool Add(int profileId, IncomeModel type)
        {
            throw new NotSupportedException();
        }

        public override bool Update(int fieldId, IncomeModel type)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int fieldId, IncomeModel type)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<IncomeModel> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
