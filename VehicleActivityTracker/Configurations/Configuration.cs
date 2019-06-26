namespace VehicleActivityTracker.Configurations
{
    using System;
    using System.Configuration;
    using System.IO;

    public class Configuration : IConfiguration
    {
        public string XmlDataPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ConfigurationManager.AppSettings["vehicleActivityStore"]);
    }
}