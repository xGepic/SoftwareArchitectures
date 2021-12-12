using System.IO;

namespace PasswordSafeConsole
{
    public static class Tools
    {
        //As the solution was specifically developed for the very first customer, it cannot be installed on other machines.
        //Seems that a more flexible configuration for locations of “master.pw” file and password.pw folder is required.
        
        //I have chosen to save it in a Folder "Passwords" which is automatically created
        //in there, there is a folder "Master for the master password.
        //All other passwords will be stored in the "Passwords" folder outside of the "Master" folder.
        public static string GetMasterPath() //Method to get the Path to the Master Folder
        {
            string folderName = "\\Passwords";
            string masterFolder = "\\Master";
            string fileName = "/master.pw";
            string myPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderName + masterFolder + fileName;
            string tempPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderName + masterFolder;
            if (!Directory.Exists(myPath))
            {
                Directory.CreateDirectory(tempPath);
                return myPath;
            }
            return myPath;
        }
        public static string GetPasswordPath() //Method to get the Path to the Passwords Folder
        {
            string folderName = "\\Passwords";
            string myPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderName;
            if (!Directory.Exists(myPath))
            {
                Directory.CreateDirectory(myPath);
            }
            return myPath;
        }
        public static void DeleteAll() //Method to delete all old passwords when a new Master Password is created
        {
            DirectoryInfo di = new(GetPasswordPath());
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
        }
    }
}