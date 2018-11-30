using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoBorrowedIt.ViewModels;
using Xamarin.Forms;

namespace WhoBorrowedIt
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
        }
    }
}
