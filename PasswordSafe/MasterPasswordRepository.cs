﻿using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PasswordSafeConsole
{
    internal class MasterPasswordRepository
    {
        private readonly string masterPasswordPath;
        public MasterPasswordRepository(string masterPasswordPath)
        {
            this.masterPasswordPath = masterPasswordPath;
        }
        internal bool MasterPasswordIsEqualTo(string masterPwToCompare)
        {
            return File.Exists(this.masterPasswordPath) && GetMasterHashString(masterPwToCompare) == File.ReadAllText(this.masterPasswordPath);
        }
        internal void SetMasterPassword(string masterPw)
        {
            File.WriteAllText(this.masterPasswordPath, GetMasterHashString(masterPw));
        }
        //Users with access to the file system on the installation should not be able to read the master password.
        public byte[] GetMasterHash(string plain)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(plain));
        }
        public string GetMasterHashString(string input)
        {
            StringBuilder sb = new();
            foreach (byte b in GetMasterHash(input))
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}