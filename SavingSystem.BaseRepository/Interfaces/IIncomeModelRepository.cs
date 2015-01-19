using System;
using System.Collections.Generic;
using SavingSystem.Models.Mapping_Model;

namespace SavingSystem.BaseRepository.Interfaces
{
    public interface IIncomeModelRepository : IRepository<IncomeModel> 
    {
        /// <summary>
        /// Get all incomes Profile by date.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="dateFrom">Date from.</param>
        /// <param name="dateTo">Date to.</param>
        /// <returns>All incomes by date.</returns>
        IEnumerable<IncomeModel> GetByDate(int profileId, DateTime dateFrom, DateTime dateTo);

        /// <summary>
        /// Get all incomes Profile by date and category.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="dateFrom">Date from.</param>
        /// <param name="dateTo">Date to.</param>
        /// <param name="incomeCategoryId">Income Category id</param>
        /// <returns>All incomes by date and category.</returns>
        IEnumerable<IncomeModel> GetByDateAndCategory(int profileId, DateTime dateFrom, DateTime dateTo, int incomeCategoryId);

        /// <summary>
        /// Get all incomes by category.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="incomeCategoryId">Income category id.</param>
        /// <returns>All incomes by one category</returns>
        IEnumerable<IncomeModel> GetByCategory(int profileId, int incomeCategoryId);
    }
}
