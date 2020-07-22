using Moq;
using NUnit.Framework;
using CloudStorageDistribution.Services;
using CloudStorageDistribution.Controllers;
using System.Collections.Generic;

namespace CloudStorageDistributionTesting
{
    public class Tests
    {
        Mock<IService> serviceMock;
        [SetUp]
        public void Setup()
        {
            serviceMock = new Mock<IService>();
        }

        [Test]
        public void UnitTestExample()
        {
            serviceMock.Setup(p => p.Return0()).Returns(0);
            var controller = new GDriveController(serviceMock.Object);

            // act
            var result = controller.Test0(3);

            // assert

            Assert.AreEqual(0, result);
        }

        [Test]
        public void ListAllFilesTest()
        {
            var gDriveService = new GDriveService();

            // act
            var result = gDriveService.ListAllFiles();

            // assert

            Assert.IsInstanceOf<List<Google.Apis.Drive.v3.Data.File>>(result);
        }
    }
}
