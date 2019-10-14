using DiffedData.Domain.Entities;
using DiffedData.Domain.Services;
using DiffedData.Tests.UnitTests.Mocks;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DiffedData.Tests.UnitTests.Services
{
    public class DataServicesTest
    {
        [Fact]
        public async Task TestMethodAdd_ShouldBeInvalidWhenLeftIdIAlreadyExist()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");
            DataCommand cmd2 = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            var result = await dataServices.AddData(cmd2);
            
            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestMethodAdd_ShouldBeInvalidWhenRightIdIAlreadyExist()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");
            DataCommand cmd2 = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            var result = await dataServices.AddData(cmd2);

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestMethodAdd_ShouldBeValidWhenLeftIdINotExist()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");
            DataCommand cmd2 = new DataCommand("2", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            var result = await dataServices.AddData(cmd2);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task TestMethodAdd_ShouldBeValidWhenRightIdINotExist()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");
            DataCommand cmd2 = new DataCommand("2", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            var result = await dataServices.AddData(cmd2);

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task TestMethodAdd_ShouldBeValidWhenSameIdExistsOnAnotherDataList()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");
            DataCommand cmd2 = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            var result = await dataServices.AddData(cmd2);

            // Assert
            Assert.True(result.IsValid);
        }        

        [Fact]
        public async Task TestMethodCompare_ShouldBeValidWhenLeftDataAndRightDataAreEquals()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "left");
            DataCommand cmd2 = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            await dataServices.AddData(cmd2);

            var result = await dataServices.Compare("1");

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact]
        public async Task TestMethodCompare_ShouldBeInvalidWhenLeftDataAndRightDataAreNotEqualsOnLenght()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfvxyz", "left");
            DataCommand cmd2 = new DataCommand("1", "fsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfv", "right");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            await dataServices.AddData(cmd2);

            var result = await dataServices.Compare("1");

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestMethodCompare_ShouldBeInvalidWhenLeftDataAndRightDataAreNotEquals()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "afsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfvx", "left");
            DataCommand cmd2 = new DataCommand("1", "bfsjbkjsbdkjdfbjvdfjvbdjkfdfjnvxfvlsfnvjdfnvjdfvy", "right");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            await dataServices.AddData(cmd2);

            var result = await dataServices.Compare("1");

            // Assert
            Assert.False(result.IsValid);
        }

        [Fact]
        public async Task TestMethodOffSetDiff_ShouldBeValidWhenReturnsTheDiferencesOnLeftDataAndRightData()
        {
            // Arrange
            FakeDataRepository fakeData = new FakeDataRepository();
            DataCommand cmd = new DataCommand("1", "ajdfvx", "left");
            DataCommand cmd2 = new DataCommand("1", "bjdfvy", "right");
            DataServices dataServices = new DataServices(fakeData);

            // Act
            await dataServices.AddData(cmd);
            await dataServices.AddData(cmd2);

            var result = dataServices.OffSetDiff("1", cmd.BodyData, cmd2.BodyData);

            // Assert
            Assert.Equal("Left Data Diff: a\0\0\0\0x and Right Data Diff: b\0\0\0\0y", result);
        }
    }
}
