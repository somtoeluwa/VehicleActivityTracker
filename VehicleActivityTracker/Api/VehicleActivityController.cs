namespace VehicleActivityTracker.Api
{
    using System.Web.Http;
    using Newtonsoft.Json;
    using VehicleActivityTracker.Business;
    using VehicleActivityTracker.Business.Models;
    using VehicleActivityTracker.Business.Utilities;
    using VehicleActivityTracker.Configurations;
    using VehicleActivityTracker.Models;

    public class VehicleActivityController : ApiController
    {
        private readonly IVehicleActivityParser vehicleActivityParser;

        public VehicleActivityController(IConfiguration configuration)
        {
            this.vehicleActivityParser = new VehicleActivityParser(configuration.XmlDataPath);
        }

        // GET api/vehicleActivity
        public VehicleActivity Get()
        {
            var vehicleActivityXmlParsed = this.DataToVehicleActivity(this.vehicleActivityParser.GetVehicleActivity());

            return vehicleActivityXmlParsed;
        }

        private VehicleActivity DataToVehicleActivity(VehicleActivityXml data)
        {
            var vehicleActivity = new VehicleActivity()
            {
                ActivityDateTime = data.ActivityDateTime,
                Latitude = data.Latitude.ToString("F"),
                Longitude = data.Longitude.ToString("F"),
                GPSValid = data.GPSValid,
                Location = data.Location,
                HDG = data.HDG,
                Speed = data.Speed,
                EventSubType = data.EventSubType,
                ODOMeter = data.ODOMeter,
                VehicleID = data.VehicleID,
            };

            return vehicleActivity;
        }
    }
}