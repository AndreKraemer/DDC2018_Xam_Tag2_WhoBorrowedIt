using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using WhoBorrowedIt.Models;
using WhoBorrowedIt.Repositories;
using WhoBorrowedIt.Views;
using Xamarin.Forms;

namespace WhoBorrowedIt.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly INavigation _navigation;
        private readonly ILentItemsRepository _repository;
        private IEnumerable<LentItem> _items;
        private int _lentCount = 5;
        private int _lentOverDueCount = 0;
        private int _borrowedCount = 3;
        private int _borrowedOverDueCount = 1;

        public MainPageViewModel(INavigation navigation, ILentItemsRepository repository)
        {
            _navigation = navigation;
            _repository = repository;
            NavigateToAddLentItemCommand = new Command(NavigateToAddLentItem);
            NavigateToLentItemsCommand = new Command(NavigateToLentItems);
            NavigateToPersonsCommand = new Command(NavigateToPersons);

            _items = _repository.GetAll();
            LentCount = _items.Count();
            LentOverDueCount = _items.Count(x => x.DueDate < DateTime.Today);
        }

        private void NavigateToPersons()
        {
            _navigation.PushAsync(new PersonsPage());
        }

        public Command NavigateToPersonsCommand { get; set; }

        public ICommand NavigateToAddLentItemCommand { get; set; }
        public ICommand NavigateToLentItemsCommand { get; set; }

        public int LentCount
        {
            get => _lentCount;
            set { _lentCount = value; OnPropertyChanged();}
        }

        public int LentOverDueCount
        {
            get => _lentOverDueCount;
            set { _lentOverDueCount = value; OnPropertyChanged(); }
        }

        public int BorrowedCount
        {
            get => _borrowedCount;
            set { _borrowedCount = value; OnPropertyChanged(); }
        }

        public int BorrowedOverDueCount
        {
            get => _borrowedOverDueCount;
            set { _borrowedOverDueCount = value; OnPropertyChanged(); }
        }


        private void NavigateToAddLentItem()
        {
            _navigation.PushAsync(new AddLentItemPage());
        }

        private void NavigateToLentItems()
        {
            _navigation.PushAsync(new LentItemsListPage());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
