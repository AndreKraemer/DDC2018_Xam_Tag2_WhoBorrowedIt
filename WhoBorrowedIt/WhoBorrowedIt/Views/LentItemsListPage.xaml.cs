using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WhoBorrowedIt.Models;
using WhoBorrowedIt.Repositories;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoBorrowedIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LentItemsListPage : ContentPage
    {
        public ObservableCollection<LentItem> Items { get; set; }

        public LentItemsListPage()
        {
            InitializeComponent();

            var repository = new FileLentItemsRepository();
            Items = new ObservableCollection<LentItem>(repository.GetAll());
			MyListView.ItemsSource = Items;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }
    }
}
