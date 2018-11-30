using System.Collections.Generic;
using System.IO;
using SQLite;
using WhoBorrowedIt.Models;
using Xamarin.Essentials;

namespace WhoBorrowedIt.Repositories
{
    public class SqlLiteLentItemsRepository : ILentItemsRepository
    {
        private SQLiteAsyncConnection _database;

        public SqlLiteLentItemsRepository()
        {
            var path = Path.Combine(FileSystem.AppDataDirectory, "wbi.db");
            _database = new SQLiteAsyncConnection(path);
            _database.CreateTableAsync<LentItem>().Wait();
        }

        public void Add(LentItem item)
        {
            _database.InsertAsync(item);
        }

        public void Update(LentItem item)
        {
            _database.UpdateAsync(item);
        }

        public LentItem Get(int id)
        {
            return _database.Table<LentItem>().FirstOrDefaultAsync(x => x.Id == id).Result;
        }

        public IEnumerable<LentItem> GetAll()
        {
            return _database.Table<LentItem>().ToListAsync().Result;
        }

        public void Delete(LentItem item)
        {
            _database.DeleteAsync(item);
        }
    }
}