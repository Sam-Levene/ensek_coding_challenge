using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;

namespace ensek_coding_challenge.Base
{
    public class ApiTestBase
    {
        protected RestClient client;
        protected ExtentTest extentTest;


        [SetUp]
        public void Setup()
        {
            var extent = ExtentReportManager.GetExtentReport();
            extentTest = extent.CreateTest("Sample Test");
        }

        [TearDown]
        public void TearDown()
        {
            ExtentReportManager.FlushReport();
        }

        public ApiTestBase()
        {
            client = new RestClient("https://qacandidatetest.ensek.io");
        }

        // Helper method for GET requests
        public async Task<RestResponse> GetAsync(string endpoint)
        {
            var request = new RestRequest(endpoint, Method.Get);
            return await client.ExecuteAsync(request);
        }

        // Helper method for POST requests
        public async Task<RestResponse> PostAsync<T>(string endpoint, T? body) where T : class  // Add the 'where T : class' constraint
        {
            var request = new RestRequest(endpoint, Method.Post);
            if (body != null)
                request.AddJsonBody(body);  // Now T is guaranteed to be a reference type
            return await client.ExecuteAsync(request);
        }

        // Helper method for PUT requests
        public async Task<RestResponse> PutAsync<T>(string endpoint, T? body) where T : class  // Add the 'where T : class' constraint
        {
            var request = new RestRequest(endpoint, Method.Put);
            if (body != null)
                request.AddJsonBody(body);  // Now T is guaranteed to be a reference type
            return await client.ExecuteAsync(request);
        }

        // Helper method for DELETE requests
        public async Task<RestResponse> DeleteAsync<T>(string endpoint, T? body) where T : class  // Add the 'where T : class' constraint
        {
            var request = new RestRequest(endpoint, Method.Delete);
            if (body != null)
                request.AddJsonBody(body);  // Now T is guaranteed to be a reference type
            return await client.ExecuteAsync(request);
        }
    }
}