using System;
using NSubstitute;
using WhoBorrowedIt.ViewModels;
using Xamarin.Forms;
using Xunit;

namespace WhoBorrowedIt.Tests
{
    public class AddLentITemPageViewModelTests
    {
        [Fact]
        public void LentDate_DefaultsTo_Today()
        {
            // arrange
            var nav = NSubstitute.Substitute.For<INavigation>();
            var vm = new AddLentItemPageViewModel(nav);

            // act

            // assert

            Assert.Equal(DateTime.Today, vm.LentDate);
        }
        [Fact]
        public void DueDate_DefaultsTo_FutureDate()
        {
            // arrange
            var nav = NSubstitute.Substitute.For<INavigation>();
            var vm = new AddLentItemPageViewModel(nav);

            // act

            // assert

            Assert.Equal(DateTime.Today.AddDays(10), vm.DueDate);
        }


        [Fact]
        public void Execute_SaveCommand_NavigatesBack()
        {
            // arrange
            var nav = NSubstitute.Substitute.For<INavigation>();
            var vm = new AddLentItemPageViewModel(nav);

            // act
            vm.SaveCommand.Execute(null);

            //Assert
            nav.Received().PopAsync();

        }
    }
}
