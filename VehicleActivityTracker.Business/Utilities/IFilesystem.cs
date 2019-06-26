namespace VehicleActivityTracker.Business.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public interface IFileSystem
    {
        Stream ReadStream(string filepath, FileMode mode);
    }
}
