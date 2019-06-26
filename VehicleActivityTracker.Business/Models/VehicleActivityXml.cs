namespace VehicleActivityTracker.Business.Models
{
    using System;
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "VehicleActivity")]
    public class VehicleActivityXml
    {
        [XmlElement(ElementName = "ActivityDateTime")]
        public DateTime ActivityDateTime { get; set; }

        [XmlElement(ElementName = "Latitude")]
        public double Latitude { get; set; }

        [XmlElement(ElementName = "Longitude")]
        public double Longitude { get; set; }

        [XmlElement(ElementName = "GPSValid")]
        public bool GPSValid { get; set; }

        [XmlElement(ElementName = "Location")]
        public string Location { get; set; }

        [XmlElement(ElementName = "IgnitionOn")]
        public bool IgnitionOn { get; set; }

        [XmlElement(ElementName = "HDG")]
        public int HDG { get; set; }

        [XmlElement(ElementName = "Speed")]
        public int Speed { get; set; }

        [XmlElement(ElementName = "EventSubType")]
        public string EventSubType { get; set; }

        [XmlElement(ElementName = "ODOMeter")]
        public double ODOMeter { get; set; }

        [XmlElement(ElementName = "VehicleID")]
        public Guid VehicleID { get; set; }
    }
}
