using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebLab.Controllers;
using WebLab.Entities;
using NUnit;
using NUnit.Framework;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Http;
using WebLab.Data;
using Microsoft.EntityFrameworkCore;

namespace WebLab.Tests
{
    public class ProductControllerTests
    {
        DbContextOptions<ApplicationDbContext> _options;
        public ProductControllerTests()
        {
            _options =
            new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "testDb")
            .Options;
        }
        [NUnit.Framework.Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                // создать объект класса контроллера
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };
                // Act
                var result = controller.Index(group: null, pageNo: page) as ViewResult;
                var model = result?.Model as List<Dish>;
                // Assert
                Assert.NotNull(model);
                Assert.Equals(qty, model.Count);
                Assert.Equals(id, model[0].DishId);
            }
            // удалить базу данных из памяти
            using (var context = new ApplicationDbContext(_options))
            {
                context.Database.EnsureDeleted();
            }
        }
        [Fact]
        public void ControllerSelectsGroup()
        {
            // arrange
            // Контекст контроллера
            var controllerContext = new ControllerContext();
            // Макет HttpContext
            var moqHttpContext = new Mock<HttpContext>();
            moqHttpContext.Setup(c => c.Request.Headers)
            .Returns(new HeaderDictionary());
            controllerContext.HttpContext = moqHttpContext.Object;
            //заполнить DB данными
            using (var context = new ApplicationDbContext(_options))
            {
                TestData.FillContext(context);
            }
            using (var context = new ApplicationDbContext(_options))
            {
                var controller = new ProductController(context)
                { ControllerContext = controllerContext };
                var comparer = Comparer<Dish>.GetComparer((d1, d2) => d1.DishId.Equals(d2.DishId));
                // act
                var result = controller.Index(2) as ViewResult;
                var model = result.Model as List<Dish>;
                // assert
                Assert.Equals(2, model.Count);
                Assert.Equals(context.Dishes
                .ToArrayAsync()
                .GetAwaiter()
                .GetResult()[2], model[0], comparer);
            }
        }
    }
}
