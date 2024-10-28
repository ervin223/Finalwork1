using System;
using System.IO;
using Environment = System.Environment;

namespace Finalwork1
{
    public static class FileAccessHelper
    {
        public static string GetLocalFilePath(string filename)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), filename);
            return path;
        }
    }
}
