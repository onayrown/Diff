using DiffedData.Domain.Entities;
using System.Threading.Tasks;
using Xunit;

namespace DiffedData.Tests.UnitTests.Entities
{
    public class DataEntityTest
    {
        [Fact]
        public async Task ShouldBeInvalidWhenIdIsNull()
        {
            // Arrange
            DataCommand cmd = new DataCommand(null, "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");

            // Act
            var entity = DataEntity.Create(cmd);

            // Assert
            Assert.False(entity.IsValid());
        }

        [Fact]
        public async Task ShouldBeInvalidWhenContentIsNull()
        {
            // Arrange
            DataCommand cmd = new DataCommand("1", null, "left");

            // Act
            var entity = DataEntity.Create(cmd);

            // Assert
            Assert.False(entity.IsValid());
        }
    }
}
