using Moq;
using NUnit.Framework;
using VehicleActivityTracker.Business;
using VehicleActivityTracker.Business.Models;
using VehicleActivityTracker.Configurations;

namespace VehicleActivityTracker.UnitTests
{
    [TestFixture]
    public class VehicleActivityParserTests
    {
        [Test]
        public void Test_GetVehicleActivity_ReturnsVehicleActivity()
        {
            //Setup
            var xmlFilePath = "some.xml";
            var mockConfiguration = new Mock<IConfiguration>();
            var expextedActivityXml = new VehicleActivityXml()
            {
                Location = "myLocation",
            };
            mockConfiguration
                .Setup(fp => fp.XmlDataPath)
                .Returns(xmlFilePath);
            var mockVehicleParser = new Mock<IVehicleActivityParser>();
              mockVehicleParser
                .Setup(lx => lx.LoadXml(xmlFilePath))
                .Returns(expextedActivityXml);
            mockVehicleParser
                .Setup(gv => gv.GetVehicleActivity())
                .Returns(expextedActivityXml);   
    
            var vehicleActivityParser = mockVehicleParser.Object;

            //Check
            var result = vehicleActivityParser.GetVehicleActivity();

            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Location, Is.EqualTo(result.Location));

        }

        [Test]
        public void Test_GetVehicleActivity_TwoVehicleHeadingAreDifferent()
        {
            //Setup
            var xmlFilePath = "some.xml";
            var mockConfiguration = new Mock<IConfiguration>();
            var expextedActivityXml1 = new VehicleActivityXml()
            {
                HDG = 123
            };
            var expextedActivityXml2 = new VehicleActivityXml()
            {
                HDG = 456
            };
            mockConfiguration
                .Setup(fp => fp.XmlDataPath)
                .Returns(xmlFilePath);
            var mockVehicleParser = new Mock<IVehicleActivityParser>();
            var mockVehicleParser2 = new Mock<IVehicleActivityParser>();
            mockVehicleParser
              .Setup(lx => lx.LoadXml(xmlFilePath))
              .Returns(expextedActivityXml1);
            mockVehicleParser
                .Setup(gv => gv.GetVehicleActivity())
                .Returns(expextedActivityXml1);
            mockVehicleParser2
                .Setup(lx => lx.LoadXml(xmlFilePath))
                .Returns(expextedActivityXml2);
            mockVehicleParser2
                .Setup(gv => gv.GetVehicleActivity())
                .Returns(expextedActivityXml2);

            var vehicleActivityParser = mockVehicleParser.Object;

            var vehicleActivityParser2 = mockVehicleParser2.Object;

            //Check
            var result1 = vehicleActivityParser.GetVehicleActivity();
            var result2 = vehicleActivityParser2.GetVehicleActivity();

            //Assert
            Assert.That(result1.HDG, Is.Not.EqualTo(result2.HDG));
        }
    }
}
