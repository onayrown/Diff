using DiffedData.Domain.Entities;
using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DiffedData.Tests.IntegrationTests
{
    public class V1ControllerTests
    {
        private readonly IntegrationTestsContext _context;

        public V1ControllerTests()
        {
            _context = new IntegrationTestsContext();
        }              
    }
}
