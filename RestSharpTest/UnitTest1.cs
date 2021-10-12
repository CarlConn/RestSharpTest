using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpTest.Model;

namespace RestSharpTest
{
    public class Tests
    {
        private string _url = "https://reqres.in/api/";
        
        /// <summary>
        /// Imagine this to be the number
        /// of associates in the json file
        /// </summary>
        [Test]
        public void Test1()
        {
            int expectedNumberOfDataArray = 6;
            int actualNumberOfDataArray = 0;
            
            var client = new RestClient(_url);
            var request = new RestRequest("root/", Method.GET);
            var response = client.ExecuteGetAsync<Root>(request).GetAwaiter().GetResult();
            actualNumberOfDataArray = response.Data.data.Count;
            
            Assert.AreEqual(expectedNumberOfDataArray, actualNumberOfDataArray);
        }
        
/// <summary>
/// Imagine this to recall the
/// members data from the json file
/// </summary>
        [Test]
        public void Test2()
        {
            int expectedPerPage = 6;
            int actualPerPage = 0;
            
            var client = new RestClient(_url);
            var request = new RestRequest("/root", Method.GET);
            var response = client.ExecuteGetAsync<Root>(request).GetAwaiter().GetResult();
            actualPerPage = response.Data.per_page;
            
            Assert.AreEqual(expectedPerPage, actualPerPage);
        }

/// <summary>
/// Access data in a given
/// data object
/// </summary>
        [Test]
        public void Test3()
        {
            string expectedColor = "#98B2D1";
            string actualColor = null;
            
            var client = new RestClient(_url);
            var request = new RestRequest("root/{page}", Method.GET);
            request.AddUrlSegment("page", 1);
            var response = client.ExecuteGetAsync<Root>(request).GetAwaiter().GetResult();
            foreach (var content in response.Data.data)
            {
                actualColor = content.color;
            }
            
            Assert.AreEqual(expectedColor, actualColor);
        }
    }
}