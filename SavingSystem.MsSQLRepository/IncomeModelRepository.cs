using System;
using System.Collections.Generic;
using SavingSystem.BaseRepository.Interfaces;
using SavingSystem.Comon.Mapping_Model;

namespace SavingSystem.MsSQLRepository
{
    public class IncomeModelRepository : BaseRepository<IncomeModel>, IIncomeModelRepository
    {
        /// <summary>
        /// Get all incomes by date.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="dateFrom">Date from.</param>
        /// <param name="dateTo">Date to.</param>
        /// <returns>List incomes by date.</returns>
        public IEnumerable<IncomeModel> GetByDate(int profileId, DateTime dateFrom, DateTime dateTo)
        {
            return null;
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
        /// Get all incomes by category.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="incomeCategoryId">Income category id.</param>
        /// <returns>All incomes by one category</returns>
        public IEnumerable<IncomeModel> GetByCategory(int profileId, int incomeCategoryId)
        {
            return null;
        }
    }
}
