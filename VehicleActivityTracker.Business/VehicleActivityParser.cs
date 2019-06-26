namespace VehicleActivityTracker.Business
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using VehicleActivityTracker.Business.Models;
    using VehicleActivityTracker.Business.Utilities;

    public class VehicleActivityParser : IVehicleActivityParser
    {
        private readonly XmlSerializer serializer;
        private readonly VehicleActivityXml vehicleActivityXml;
        private readonly IFileSystem fileSystem;

        public VehicleActivityParser(string xmlFilePath)
        {
            this.serializer = new XmlSerializer(typeof(VehicleActivityXml));
            this.vehicleActivityXml = this.LoadXml(xmlFilePath);
        }

        public VehicleActivityXml LoadXml(string xmlFilePath)
        {
            var vehicleActivityXml = new VehicleActivityXml();
            using (var fileStream = new FileStream(xmlFilePath, FileMode.Open))
            {
                vehicleActivityXml = (VehicleActivityXml)this.serializer.Deserialize(fileStream);
            }

            return vehicleActivityXml;
        }

        public VehicleActivityXml GetVehicleActivity()
        {
            var vehicleActivity = this.vehicleActivityXml;
            vehicleActivity.ActivityDateTime = this.GetPacificStandardTime(vehicleActivity.ActivityDateTime);
            vehicleActivity.HDG = this.GetVehicleHeading(0, 359);

            return vehicleActivity;
        }

        private DateTime GetPacificStandardTime(DateTime date)
        {
            TimeZoneInfo pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            var pacificTime = TimeZoneInfo.ConvertTimeFromUtc(date, pacificZone);
            return pacificTime;
        }

        private int GetVehicleHeading(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
