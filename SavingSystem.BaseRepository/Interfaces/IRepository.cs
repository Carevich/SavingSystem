using System.Collections.Generic;

namespace SavingSystem.BaseRepository.Interfaces
{
    public interface IRepository<T> where T : class
    {
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
        /// <param name="itemId">Item id.</param>
        /// <returns>One item</returns>
        T Get(int profileId, int itemId);

        /// <summary>
        /// Add item in DB.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="item">Item obj</param>
        /// <returns>true if succesful added, false if fail.</returns>
        bool Add(int profileId, T item);

        /// <summary>
        /// Update item by id.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="itemId">Item id.</param>
        /// <param name="item">Updated item.</param>
        /// <returns>true if succesful updated, false if fail.</returns>
        bool Update(int profileId, int itemId, T item);

        /// <summary>
        /// Delete item by id.
        /// </summary>
        /// <param name="profileId">Profile id.</param>
        /// <param name="itemId">Item id</param>
        /// <returns>true if succesful deleted, false if fail.</returns>
        bool Delete(int profileId, int itemId);
    }
}
