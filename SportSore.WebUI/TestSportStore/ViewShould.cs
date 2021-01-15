using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Domain.Entity;
using SportSore.WebUI.Controllers;
using SportSore.WebUI.Models;
using SportSore.WebUI.HtmlHelpers;
using System.Web.Mvc;

namespace TestSportStore
{
    public class ViewShould
    {
        [Fact]
        public void PaginationSHould()
        {
            Mock<Domain.Abstract.IProductRepository> mock = new Mock<Domain.Abstract.IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] { 
                new Product { ProductID = 1, Name = "P1" },
                new Product { ProductID = 1, Name = "P2" },
                new Product { ProductID = 1, Name = "P3" },
                new Product { ProductID = 1, Name = "P4" }
            });

            ProductController sut = new ProductController(mock.Object);

            ProductsListViewModel model = (ProductsListViewModel) sut.List(2).Model;

            IEnumerable<Product> products = model.Products;

            //Assert
            Product[] prodArray = products.ToArray();

            Assert.True(prodArray.Length == 1);
            Assert.Equal("P4", prodArray[0].Name);

        }
        [Fact]
        public void GenerateLinkSHould()
        {
            //Arrange - define an HTMLHelper for apply the estension method
            HtmlHelper sut = null;

            //create info page 
            PageInfo pageInfo = new PageInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemPerPage = 10
            };

            //define a delegate
            Func<int, string> pageUrlDelegate = (i) => "Page" + i;

            //Act 
            MvcHtmlString resultTest = sut.PageLinks(pageInfo, pageUrlDelegate);
            string expValue = @"<a class=""btn btn-default"" href=""Page1"">1</a>"
                            + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                            + @"<a class=""btn btn-default"" href=""Page3"">3</a>";

            Assert.Equal(expValue, resultTest.ToString());
        }
    }
}
