using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using WhoBorrowedIt.Models;

namespace WhoBorrowedIt.Repositories
{
    public class FileLentItemsRepository : ILentItemsRepository
    {
        private List<LentItem> _items = new List<LentItem>();

        public FileLentItemsRepository()
        {
            // TODO: Datei lesen ....
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
            var path = "";

            File.WriteAllText(path, json);
        }
    }
}