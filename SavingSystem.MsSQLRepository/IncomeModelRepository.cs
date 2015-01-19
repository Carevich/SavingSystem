using System;
using System.Collections.Generic;
using SavingSystem.BaseRepository.Interfaces;
using SavingSystem.Models.Mapping_Model;

namespace SavingSystem.MsSQLRepository
{
    public class IncomeModelRepository : BaseRepository<IncomeModel>, IIncomeModelRepository
    {
        /// <summary>
        /// Get incomes Profile.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <returns>List of incomes profile.</returns>
        public IEnumerable<IncomeModel> GetAll(int profileId)
        {
            return null;
        }


        /// <summary>
        /// Get income by id.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="incomeId">Income id.</param>
        /// <returns>One income.</returns>
        public IncomeModel Get(int profileId, int incomeId)
        {
            return null;
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
        

        /// <summary>
        /// Add item in DB.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="income">Income obj.</param>
        /// <returns>true if succesful added, false if fail.</returns>
        //public bool Add(int profileId, IncomeModel income)
        //{
        //    return true;
        //}


        /// <summary>
        /// Update income by id.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="incomeId">Income id.</param>
        /// <param name="income">Updated income obj.</param>
        /// <returns>true if succesful updated, false if fail.</returns>
        public bool Update(int profileId, int incomeId, IncomeModel income)
        {
            return true;
        }


        /// <summary>
        /// Delete item by id
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="incomeId">Income id.</param>
        /// <returns>true if succesful deleted, false if fail.</returns>
        public bool Delete(int profileId, int incomeId)
        {
            return true;
        }
    }
}
