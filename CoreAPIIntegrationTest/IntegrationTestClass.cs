using CoreApi;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPIIntegrationTest
{
    public class IntegrationTestClass
    {
        public readonly HttpClient testClient;
        public IntegrationTestClass()
        {
            var appFactoy = new WebApplicationFactory<Startup>();
            testClient = appFactoy.CreateClient();
        }
        protected async Task<HttpResponseMessage> CreatePostAsync(string url,object data)
        {
            return await testClient.PostAsJsonAsync(url, data);
        }
    }
}
