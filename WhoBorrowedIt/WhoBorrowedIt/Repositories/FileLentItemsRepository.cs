using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WhoBorrowedIt.Models;
using Xamarin.Essentials;

namespace WhoBorrowedIt.Repositories
{
    public class FileLentItemsRepository : ILentItemsRepository
    {
        private readonly List<LentItem> _items;

        public FileLentItemsRepository()
        {
            _items = ReadFile();
        }

        public void Add(LentItem item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            SaveToFile();
        }

        public void Update(LentItem item)
        {
            // TODO;
            SaveToFile();
        }

        public LentItem Get(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<LentItem> GetAll()
        {
            return _items;
        }

        public void Delete(LentItem item)
        {
            var itemToDelete = _items.FirstOrDefault(x => x.Id == item.Id);
            if (itemToDelete != null)
            {
                _items.Remove(itemToDelete);
            }

            SaveToFile();
        }

        private void SaveToFile()
        {
            var json = JsonConvert.SerializeObject(_items);
            var path = Path.Combine(FileSystem.AppDataDirectory, "lentitems.json");

            File.WriteAllText(path, json);
        }

        private List<LentItem> ReadFile()
        {
           
            var path = Path.Combine(FileSystem.AppDataDirectory, "lentitems.json");
            if (!File.Exists(path))
            {
                return new List<LentItem>();
            }
            var json = File.ReadAllText(path);

            var items = JsonConvert.DeserializeObject<List<LentItem>>(json);
            return items;
        }
    }
}