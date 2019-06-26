namespace VehicleActivityTracker.Business.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FileSystem : IFileSystem
    {
        public Stream ReadStream(string filepath, FileMode mode)
        {
            return new FileStream(filepath, mode);
        }
    }
}
