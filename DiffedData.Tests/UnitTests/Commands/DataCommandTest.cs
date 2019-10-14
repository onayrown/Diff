using DiffedData.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DiffedData.Tests.UnitTests.Commands
{
    public class DataCommandTest
    {
        [Fact]
        public async Task ShouldBeInvalidWhenActionIsNotLeftOrRight()
        {
            // Arrange            
            // Act
            Exception ex = Assert.Throws<ArgumentException>(() => new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "midle"));

            // Assert
            Assert.Equal("Parameter Invalid: must be left or right", ex.Message);
        }

        [Fact]
        public async Task IsLeftShouldBeReturnsFalseIfActionEqualsRight()
        {
            // Arrange  
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");

            // Act
            // Assert
            Assert.False(cmd.IsLeft);
        }

        [Fact]
        public async Task IsLeftShouldBeReturnsTruefActionEqualsLeft()
        {
            // Arrange  
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");

            // Act
            // Assert
            Assert.True(cmd.IsLeft);
        }
    }
}
