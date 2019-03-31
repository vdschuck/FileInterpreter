using Infrastructure.Helpers;
using System;
using System.IO;

namespace Application.Interpreter
{
    public class FileObserver
    {
        #region ctor
        private readonly FileSystemWatcher fileWatcher;
        private readonly FileReceive fileReceive;

        public FileObserver()
        {
            fileWatcher = new FileSystemWatcher();
            fileReceive = new FileReceive();
        }
        #endregion       

        /// <summary>
        /// Method to identify changes in the folder
        /// </summary>       
        public void HandlerEvents()
        {
            // Associate event handlers with the events
            fileWatcher.Created += fileReceive.ProcessFile;

            // Configurations
            fileWatcher.Path = FolderHelper.GetFolderPathIn(null);
            fileWatcher.Filter = "*.dat";
            fileWatcher.EnableRaisingEvents = true;           

            Console.WriteLine("[AWAITING] Waiting for new file");           

            // Wait for the user to quit the program.
            Console.WriteLine("Press 'q' to quit the sample.");
            while (Console.Read() != 'q') ;                     
        }
    }
}
