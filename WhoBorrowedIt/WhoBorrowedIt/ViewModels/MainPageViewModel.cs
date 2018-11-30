using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WhoBorrowedIt.Models;
using WhoBorrowedIt.Repositories;
using WhoBorrowedIt.Views;
using Xamarin.Forms;

namespace WhoBorrowedIt.ViewModels
{
    public class MainPageViewModel
    {
        private readonly INavigation _navigation;
        private readonly ILentItemsRepository _repository;
        private IEnumerable<LentItem> _items;

        public MainPageViewModel(INavigation navigation, ILentItemsRepository repository)
        {
            _navigation = navigation;
            _repository = repository;
            NavigateToAddLentItemCommand = new Command(NavigateToAddLentItem);
            NavigateToLentItemsCommand = new Command(NavigateToLentItems);

            _items = _repository.GetAll();
            LentCount = _items.Count();
            LentOverDueCount = _items.Count(x => x.DueDate < DateTime.Today);
        }

        public ICommand NavigateToAddLentItemCommand { get; set; }
        public ICommand NavigateToLentItemsCommand { get; set; }

        public int LentCount { get; set; } = 5;
        public int LentOverDueCount { get; set; } = 0;
        public int BorrowedCount { get; set; } = 3;
        public int BorrowedOverDueCount { get; set; } = 1;


        private void NavigateToAddLentItem()
        {
            _navigation.PushAsync(new AddLentItemPage());
        }

        private void NavigateToLentItems()
        {
            _navigation.PushAsync(new LentItemsListPage());
        }
    }
}
