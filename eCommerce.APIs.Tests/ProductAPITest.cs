using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using eCommerce.APIs;
using eCommerce.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
namespace Tests
{
    public class Tests
    {
        HttpClient client;
        [SetUp]
        public void Setup()
        {   
            TestServer server=new TestServer(new WebHostBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Test]
        public async Task TestGetProducts()
        {
            var productResponse = await client.GetAsync("/api/product/list");
            string responseContent=await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ProductAddViewModel>>(responseContent);
            Assert.AreEqual(HttpStatusCode.OK,productResponse.StatusCode);
            Assert.Greater(products.Count,0);
        }
    }
}