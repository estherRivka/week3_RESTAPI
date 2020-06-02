using CoronaApp.Dal;
using CoronaApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Xunit;

namespace CoronaApp.Tests
{
    public class PathControllerTests : IClassFixture<WebApplicationFactory<Api.Startup>>
    {
        private readonly WebApplicationFactory<Api.Startup> _factory;
        public PathControllerTests(WebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void GetPaths_ByCity_ReturnPaths()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act 
            var response = await client.GetAsync("/api/path/GetPathSearchBy?pathSearch.City=Jerusalem");

            // Assert
            response.EnsureSuccessStatusCode();
        }
        [Fact]
        public async Task GetPaths_ReturnPaths_mock()
        {
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.AddScoped<IPathRepository, TestPathRepository>();
                });
            })
       .CreateClient();

            //Act
            var response = await client.GetAsync("/api/path/getallpaths");
            //var content = await HtmlHelpers.GetDocumentAsync(defaultPage);
            // var quoteElement = content.QuerySelector("#quote");
            //response.EnsureSuccessStatusCode();
            // Assert
            //  Assert.Equal("Something's interfering with time, Mr. Scarman, " +
            //   "and time is my business.", quoteEle>ment.Attributes["value"].Value);
            //  HttpStatusCode d = new HttpStatusCode();
            // Assert.IsType <d>(response.StatusCode);
            // Assert.IsType<StatusCodes.Status200OK>(response);
            response.EnsureSuccessStatusCode();

          //  Assert.True((int)response.StatusCode==200, $"The returnd status is:{(int)response.StatusCode}");
        }
    }
}
