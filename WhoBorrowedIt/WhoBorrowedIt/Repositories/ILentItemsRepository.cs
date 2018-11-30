using System.Collections;
using System.Collections.Generic;
using WhoBorrowedIt.Models;

namespace WhoBorrowedIt.Repositories
{
    public interface ILentItemsRepository
    {
        void Add(LentItem item);
        void Update(LentItem item);
        LentItem Get(int id);

        IEnumerable<LentItem> GetAll();

        void Delete(LentItem item);
    }
}