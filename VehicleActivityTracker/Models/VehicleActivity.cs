namespace VehicleActivityTracker.Models
{
    using System;

    public class VehicleActivity
    {
        public DateTime ActivityDateTime { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public bool GPSValid { get; set; }

        public string Location { get; set; }

        public bool IgnitionOn { get; set; }

        public int HDG { get; set; }

        public int Speed { get; set; }

        public string EventSubType { get; set; }

        public double ODOMeter { get; set; }

        public Guid VehicleID { get; set; }
    }
}