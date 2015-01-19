using System;
using SavingSystem.Comon;

namespace SavingSystem.MsSQLRepository
{
    public class IncomeRepository : BaseRepository<Income>
    {
        public override bool Update(int profileId, int itemId, Income item)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int profileId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
