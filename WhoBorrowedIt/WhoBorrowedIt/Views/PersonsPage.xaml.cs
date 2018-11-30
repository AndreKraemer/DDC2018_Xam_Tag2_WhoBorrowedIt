using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WhoBorrowedIt.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoBorrowedIt.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PersonsPage : ContentPage
    {
        public ObservableCollection<Person> Items { get; set; }

        public PersonsPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<Person>();
            MyListView.ItemsSource = Items;
        }

        protected override async void OnAppearing()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");

            var result = await client.GetAsync("api/persons");

            var json = await result.Content.ReadAsStringAsync();

            var persons = JsonConvert.DeserializeObject<List<Person>>(json);

            Items.Clear();
            foreach (var person in persons)
            {
                Items.Add(person);
            }
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
