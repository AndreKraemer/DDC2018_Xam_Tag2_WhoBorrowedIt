using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoBorrowedIt.Repositories;
using WhoBorrowedIt.ViewModels;
using Xamarin.Forms;

namespace WhoBorrowedIt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
           
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new MainPageViewModel(Navigation, new SqlLiteLentItemsRepository());
        }
    }
}
