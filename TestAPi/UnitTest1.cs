using ApiNasaRovers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Xunit;
using Xunit.Abstractions;

namespace TestAPi
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper _testOutputHelper;
        public UnitTest1(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public async void Testbase200()
        {
            var controller = new BaseController();
            var response =  controller.Get();
            _testOutputHelper.WriteLine(response);
            response.ToString().Equals(HttpStatusCode.NotFound);
        }



        [Fact]
        public async void TestapiRovers200()
        {
            var controller = new RoverController();
            var response = await controller.Get();
            _testOutputHelper.WriteLine(response);
            response.ToString().Equals(HttpStatusCode.NotFound);
        }


        [Fact]
        public async void TestapiRoverJson()
        {
            var controller = new RoverController();
            var response = await controller.Get();
            _testOutputHelper.WriteLine(response);
            JArray json = JArray.Parse(response);
            Assert.IsType<JArray>(json);

        }

    }
}