using System;
using NSubstitute;
using WhoBorrowedIt.Repositories;
using WhoBorrowedIt.ViewModels;
using Xamarin.Forms;
using Xunit;

namespace WhoBorrowedIt.Tests
{
    public class AddLentITemPageViewModelTests
    {
        private INavigation _nav;
        private AddLentItemPageViewModel _vm;
        private ILentItemsRepository _repository;

        public AddLentITemPageViewModelTests()
        {
            _repository = Substitute.For<ILentItemsRepository>();
            _nav = NSubstitute.Substitute.For<INavigation>();
            _vm = new AddLentItemPageViewModel(_nav, _repository);
        }

        [Fact]
        public void LentDate_DefaultsTo_Today()
        {
            // arrange

            // act

            // assert

            Assert.Equal(DateTime.Today, _vm.LentDate);
        }
        [Fact]
        public void DueDate_DefaultsTo_FutureDate()
        {
            // arrange


            // act

            // assert

            Assert.Equal(DateTime.Today.AddDays(10), _vm.DueDate);
        }


        [Fact]
        public void Execute_SaveCommand_NavigatesBack()
        {
            // arrange


            // act
            _vm.SaveCommand.Execute(null);

            //Assert
            _nav.Received().PopAsync();

        }
    }
}
