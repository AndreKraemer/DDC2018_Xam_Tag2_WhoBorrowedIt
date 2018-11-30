using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhoBorrowedIt.ViewModels
{
    public class AddLentItemPageViewModel: INotifyPropertyChanged
    {
        private readonly INavigation _navigation;
        private DateTime _lentDate = DateTime.Today;
        private DateTime _dueDate = DateTime.Today.AddDays(10);
        private string _person;
        private string _item;

        public AddLentItemPageViewModel(INavigation navigation)
        {
            _navigation = navigation;
            SaveCommand = new Command(Save);
        }

        public ICommand SaveCommand { get; set; }

        public string Item
        {
            get => _item;
            set { _item = value; OnPropertyChanged();}
        }

        public string Person
        {
            get => _person;
            set { _person = value; OnPropertyChanged(); }
        }

        public DateTime LentDate
        {
            get => _lentDate;
            set { _lentDate = value; OnPropertyChanged(); }
        }

        public DateTime DueDate
        {
            get => _dueDate;
            set { _dueDate = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Save()
        {
            _navigation.PopAsync(); 
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
