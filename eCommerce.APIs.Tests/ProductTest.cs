using Microsoft.AspNetCore.TestHost;
using NUnit.Framework;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using eCommerce.ViewModels;
using System.Collections.Generic;
namespace eCommerce.APIs.Tests
{
    public class ProductTests
    {
        HttpClient _client;
        int productAddedId = 0;
        [SetUp]
        public void Setup()
        {
            TestServer server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Test]
        //[MaxTime(200)]
        public async Task TestList_StatusCode()
        {

            var productResponse  = await  _client.GetAsync("/api/product/list");
            Assert.AreEqual(HttpStatusCode.OK, productResponse.StatusCode);
        }

        [Test]
        //[MaxTime(200)]
        public async Task TestList_ResultsCount_greater_1()
        {

            var productResponse = await _client.GetAsync("/api/product/list");
            string productcontent = await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductViewModel>>(productcontent);
            Assert.GreaterOrEqual(products.Count, 1);
           
        }

        [Test]
        //[Order(1)]
        //[MaxTime(200)]
        public async Task PostProduct_OK()
        {
            //arrange
            ProductAddViewModel newProduct = new ProductAddViewModel();
            newProduct.CategoryId = 1;
            newProduct.Name = "product test";
            newProduct.Price = 200;
            var productResponse = await _client.PostAsJsonAsync("/api/product/",newProduct);
            
            Assert.AreEqual(HttpStatusCode.OK, productResponse.StatusCode);

        }
    }
}