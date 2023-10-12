using NUnit.Framework;
using WebLab.Entities;
using WebLab.Models;
using WebLab.Tests;
using Xunit;
namespace WebLab.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act
            var model = ListViewModel<Dish>
            .GetModel(TestData.GetDishesList(), 1, 3);
            // Assert
            Assert.Equals(2, model.TotalPages);
        }
        [NUnit.Framework.Theory]
        [MemberData(memberName: nameof(TestData.Params),
        MemberType = typeof(TestData))]
        
        
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Dish>
            .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equals(qty, model.Count);
        }
        [NUnit.Framework.Theory]
        [MemberData(memberName: nameof(TestData.Params),
        MemberType = typeof(TestData))]
        
        
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act
            var model = ListViewModel<Dish>
            .GetModel(TestData.GetDishesList(), page, 3);
            // Assert
            Assert.Equals(id, model[0].DishId);
        }
    }
}