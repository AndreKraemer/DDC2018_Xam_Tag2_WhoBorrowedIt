using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WhoBorrowedIt.Views;
using Xamarin.Forms;

namespace WhoBorrowedIt.ViewModels
{
    public class MainPageViewModel
    {
        private readonly INavigation _navigation;

        public MainPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NavigateToAddLentItemCommand = new Command(NavigateToAddLentItem);
        }

        public ICommand NavigateToAddLentItemCommand { get; set; }

        public int LentCount { get; set; } = 5;
        public int LentOverDueCount { get; set; } = 0;
        public int BorrowedCount { get; set; } = 3;
        public int BorrowedOverDueCount { get; set; } = 1;


        private void NavigateToAddLentItem()
        {
            _navigation.PushAsync(new AddLentItemPage());
        }
    }
}
