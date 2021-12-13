using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PasswordSafeConsole
{
    internal class PasswordSafeEngine
    {
        private readonly string path;
        private readonly CipherFacility cipherFacility;
        public PasswordSafeEngine(string path, CipherFacility cipherFacility)
        {
            this.path = path;
            this.cipherFacility = cipherFacility;
        }
        internal IEnumerable<string> GetStoredPasswords()
        {
            if (!Directory.Exists(this.path))
            {
                return Enumerable.Empty<string>();
            }
            return Directory.GetFiles(this.path).ToList().Select(f => Path.GetFileName(f)).Where(f => f.EndsWith(".pw")).Select(f => f.Split(".")[0]);
        }
        internal string GetPassword(string passwordName)
        {
            byte[] password = File.ReadAllBytes(Path.Combine(this.path, $"{passwordName}.pw"));
            return this.cipherFacility.Decrypt(password);
        }
        internal string GetPassword2(string passwordName)
        {
            int counter = 1;
            string filename = Tools.GetPathToPasswordFile();
            var lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                if (line == passwordName)
                {
                    //to do
                }
                counter++;
            }
            return null;
        }

        internal void AddNewPassword(PasswordInfo passwordInfo)
        {
            if (!Directory.Exists(this.path))
            {
                Directory.CreateDirectory(this.path);
            }
            File.WriteAllBytes(Path.Combine(this.path, $"{passwordInfo.PasswordName}.pw"), this.cipherFacility.Encrypt(passwordInfo.Password));
        }
        internal void AddNewPassword2(PasswordInfo passwordInfo) //AddPassword for single File 
        {
            string nameToAdd = passwordInfo.PasswordName;
            string pwToAdd = UTF8Encoding.UTF8.GetString(this.cipherFacility.Encrypt2(passwordInfo.Password));
            File.AppendAllText(this.path, nameToAdd + Environment.NewLine + pwToAdd + Environment.NewLine);
        }
        internal void DeletePassword(string passwordName)
        {
            File.Delete(Path.Combine(this.path, $"{passwordName}.pw"));
        }
    }
}