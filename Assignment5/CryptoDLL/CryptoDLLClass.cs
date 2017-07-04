using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace CryptoDLL
{
    public class CryptoDLLClass
    {
        /*
         * Create a seed 
         */ 
        static byte[] seed = ASCIIEncoding.ASCII.GetBytes("cse44598"); 

        /*
         * A function to encrypt a string
         */ 
        public static string Encrypt(string plainString)
        { 
            /*
             * check for emptyness
             */ 
            if (String.IsNullOrEmpty(plainString))
            {
                throw new ArgumentNullException("The input cannot be empty or null!");
            }
            /*
             * Create encryptor using symmetric algorithm and get the encrypted string
             */ 
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream,
            saProvider.CreateEncryptor(seed, seed), CryptoStreamMode.Write);
            StreamWriter sWriter = new StreamWriter(cStream);
            sWriter.Write(plainString);
            sWriter.Flush(); 
            cStream.FlushFinalBlock();
            return Convert.ToBase64String(mStream.GetBuffer(), 0, (int)mStream.Length);
        }

        /*
         * A function to decrypt a string
         */
        public static string Decrypt(string encryptedString)
        {
            /*
             * check for emptyness
             */
            if (String.IsNullOrEmpty(encryptedString))
            {
                throw new ArgumentNullException("The string cannot be empty or null!");
            }
            /*
             * Create decryptor using symmetric algorithm and get the decrypted string
             */
            SymmetricAlgorithm saProvider = DES.Create();
            MemoryStream memStream = new MemoryStream
                    (Convert.FromBase64String(encryptedString));
            CryptoStream cStream = new CryptoStream(memStream,
                saProvider.CreateDecryptor(seed, seed), CryptoStreamMode.Read);
            StreamReader reader = new StreamReader(cStream);
            return reader.ReadLine();
        }
    }
}