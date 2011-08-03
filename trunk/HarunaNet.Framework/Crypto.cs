using System;
using System.Collections.Generic;
using System.Text;
using System.Security;
using System.Security.Cryptography;

using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Classe de criptografia.
    /// </summary>
    public class Crypto
    {
        /// <summary>
        /// Cria o hash SHA1Managed.
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        public static string CreateHash(string plaintext)
        {
            return Cryptographer.CreateHash("SHA1Managed", plaintext.ToLower());
        }

        /// <summary>
        /// Compara o hash informado.
        /// </summary>
        /// <param name="plaintext">Texto informado pela interface.</param>
        /// <param name="hash">Hash salvo.</param>
        /// <returns>True ou False para a comparação.</returns>
        public static bool CompareHash(string plaintext, string hash)
        {
            return Cryptographer.CompareHash("SHA1Managed", plaintext.ToLower(), hash);
        }

        /// <summary>
        /// Cria uma senha aleatória.
        /// </summary>
        /// <param name="PasswordLength">Tamaho da senha.</param>
        /// <returns>Senha criada.</returns>
        public static string CreateRandomPassword(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@#$%?&*()";
            Random rnd = new Random();
            Byte[] randomBytes = new Byte[PasswordLength];
            rnd.NextBytes(randomBytes);
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
        }

        #region Gera HashCode
        private static HashAlgorithm mhash;

        private static void setEncryptor()
        {

            /*case PDSAHashType.MD5:
            mhash = new MD5CryptoServiceProvider();
             break;
             case PDSAHashType.SHA1:
              mhash = new SHA1CryptoServiceProvider();
              break;
             case PDSAHashType.SHA256:
              mhash = new SHA256Managed();
              break;
             case PDSAHashType.SHA384:
              mhash = new SHA384Managed();
              break;
             case PDSAHashType.SHA512:*/
            mhash = new SHA512Managed();
            //break;

        }

        /// <summary>
        /// Constrói um hash para a string informada.
        /// </summary>
        /// <param name="mstrOriginalString">String.</param>
        /// <returns>Hash.</returns>
        public static string getHash(string mstrOriginalString)
        {
            byte[] bytValue;
            byte[] bytHash;

            // Create New Crypto Service Provider Object
            setEncryptor();

            // Convert the original string to array of Bytes
            bytValue =
             System.Text.Encoding.UTF8.GetBytes(mstrOriginalString);

            // Compute the Hash, returns an array of Bytes  
            bytHash = mhash.ComputeHash(bytValue);

            // Return a base 64 encoded string of the Hash value
            return Convert.ToBase64String(bytHash);
        }
        #endregion
    }
}
