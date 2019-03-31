using System;
using System.IO;

namespace Infrastructure.Helpers
{
    public static class FolderHelper
    {
        /// <summary>
        /// Method to get the folder path
        /// </summary>
        /// <param name="fileName">Not required</param>
        /// <returns>Folder path</returns>
        public static string GetFolderPathIn(string fileName)
        {
            if(String.IsNullOrEmpty(fileName))
                return Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), "data", "in");
            else
                return Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), "data", "in", fileName);
        }

        /// <summary>
        /// Method to get the folder path
        /// </summary>
        /// <param name="fileName">Not required</param>
        /// <returns>Folder path</returns>
        public static string GetFolderPathOut(string fileName)
        {
            if (String.IsNullOrEmpty(fileName))
                return Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), "data", "in");
            else
                return Path.Combine(Environment.ExpandEnvironmentVariables("%HOMEDRIVE%%HOMEPATH%"), "data", "out", fileName);
        }
    }        
}
