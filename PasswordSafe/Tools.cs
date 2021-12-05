using System.IO;

namespace PasswordSafeConsole
{
    public static class Tools
    {
        public static string GetPath()
        {
            string folderName = "\\Master";
            string fileName = "/master.pw";
            string myPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + folderName + fileName;
            return myPath;
            //As the solution was specifically developed for the very first customer, it cannot be installed on other machines.
            //Seems that a more flexible configuration for locations of “master.pw” file and password.pw folder is required.
            //I have chosen to save it in a Folder "Master" which is automatically created
            //here the master.pw will be stored, this should run on every machine!
        }
    }
}