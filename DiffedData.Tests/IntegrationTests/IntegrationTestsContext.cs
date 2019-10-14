using DiffedData.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace DiffedData.Tests.IntegrationTests
{
    public class IntegrationTestsContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public IntegrationTestsContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = _server.CreateClient();
        }
    }
}
