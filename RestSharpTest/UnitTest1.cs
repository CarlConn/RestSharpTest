using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharpTest.Model;

namespace RestSharpTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
       

        }

        [Test]
        public void Test1()
        { 
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 1);
            var response = client.ExecuteGetAsync<Posts>(request).GetAwaiter().GetResult();
            var result = response.Data.author;
            Assert.AreEqual(result, "typicode");
        }
        
        [Test]
        public void Test2()
        {
            
            var client = new RestClient("http://localhost:3000/");
            var request = new RestRequest("posts/{postid}", Method.GET);
            request.AddUrlSegment("postid", 2);
            var response = client.ExecuteGetAsync<Posts>(request).GetAwaiter().GetResult();
            var result = response.Data.author;
            Assert.AreEqual(result, "Carl");
        }

        [Test]
        public void Test3()
        {
            var client = new RestClient("https://reqres.in/api/");
            var request = new RestRequest("root/{page}", Method.GET);
            request.AddUrlSegment("page", 1);
            var response = client.ExecuteGetAsync<List<Root>>(request).GetAwaiter().GetResult();
            JArray jArray = JArray.Parse(response.Content);
            foreach (var content in jArray.Children<JObject>())
            {
                foreach (JProperty property in content.Properties())
                {
                    var x = property.Name;
                }
            }
            
            //Assert.AreEqual(result, "Carl");
        }
    }
}