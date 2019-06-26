namespace VehicleActivityTracker.Business
{
    using VehicleActivityTracker.Business.Models;

    public interface IVehicleActivityParser
    {
        VehicleActivityXml LoadXml(string xmlFilePath);

        VehicleActivityXml GetVehicleActivity();
    }
}
