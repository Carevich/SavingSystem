using System.Collections.Generic;

namespace SavingSystem.BaseRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get all items table. Only Admin.
        /// </summary>
        /// <returns>All itms table.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get all items Profile.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <returns>List items.</returns>
        IEnumerable<T> GetAll(int profileId);
        
        /// <summary>
        /// Get one item by id.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="fieldId">Field id.</param>
        /// <returns>One item</returns>
        T Get(int profileId, int fieldId);

        /// <summary>
        /// Add item in DB.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="type">T type.</param>
        /// <returns>true if succesful added, false if fail.</returns>
        bool Add(int profileId, T type);

        /// <summary>
        /// Update item by id.
        /// </summary>
        /// <param name="fieldId">Field id.</param>
        /// <param name="type">Updated T type obj.</param>
        /// <returns>true if succesful updated, false if fail.</returns>
        bool Update(int fieldId, T type);

        /// <summary>
        /// Delete item by id.
        /// </summary>
        /// <param name="fieldId">Field id.</param>
        /// <param name="type">T type.</param>
        /// <returns>true if succesful deleted, false if fail.</returns>
        bool Delete(int fieldId, T type);
    }
}
