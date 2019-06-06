﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CDS.Update.Helper
{
    /// <summary>
    /// The type of hash to create
    /// </summary>
    internal enum HashType
    {
        MD5,
        SHA1,
        SHA512
    }

    /// <summary>
    /// Class used to generate hash sums of files
    /// </summary>
    internal static class Hasher
    {
        /// <summary>
        /// Generate a hash sum of a file
        /// </summary>
        /// <param name="filePath">The file to hash</param>
        /// <param name="algo">The Type of hash</param>
        /// <returns>The computed hash</returns>
        internal static string HashFile(string filePath, HashType algo)
        {
            string hash = "";
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                switch (algo)
                {
                    case HashType.MD5:
                        hash = MakeHashString(MD5.Create().ComputeHash(fs));
                        break;
                    case HashType.SHA1:
                        hash = MakeHashString(SHA1.Create().ComputeHash(fs));
                        break;
                    case HashType.SHA512:
                        hash = MakeHashString(SHA512.Create().ComputeHash(fs));
                        break;
                }
            }
            return hash;
        }

        /// <summary>
        /// Converts byte[] to string
        /// </summary>
        /// <param name="hash">The hash to convert</param>
        /// <returns>Hash as string</returns>
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder();

            foreach (byte b in hash)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();
        }
    }
}
