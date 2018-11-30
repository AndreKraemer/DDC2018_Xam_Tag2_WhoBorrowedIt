using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhoBorrowedIt.Repositories;
using WhoBorrowedIt.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WhoBorrowedIt.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddLentItemPage : ContentPage
	{
		public AddLentItemPage ()
		{
			InitializeComponent ();
            BindingContext = new AddLentItemPageViewModel(Navigation, new FileLentItemsRepository());
		}
	}
}