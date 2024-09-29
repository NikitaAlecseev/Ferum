using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FerumServerWPF.Core
{
    internal class CryptoRSA
    {
        private static readonly string _publicKeyFile = "publicKey.xml";
        private static readonly string _privateKeyFile = "privateKey.xml";

        /// <summary>
        /// Создаеие пары ключей
        /// </summary>
        private void createKey()
        {
            // Создание ключей, если их еще нет
            if (!File.Exists(_publicKeyFile) || !File.Exists(_privateKeyFile))
            {
                GenerateKeyPair();
            }
        }

        /// <summary>
        /// Генерация открытого и закрытого ключа
        /// </summary>
        private static void GenerateKeyPair()
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
            {
                // Создание XML-файлов с открытым и закрытым ключами
                File.WriteAllText(_publicKeyFile, rsa.ToXmlString(false));
                File.WriteAllText(_privateKeyFile, rsa.ToXmlString(true));
            }
        }


        /// <summary>
        /// Шифрование текста
        /// </summary>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        private static string Encrypt(string plaintext)
        {
            // Загрузка открытого ключа из файла
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKeyXml = File.ReadAllText(_publicKeyFile);
                rsa.FromXmlString(publicKeyXml);

                // Шифрование текста
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] ciphertextBytes = rsa.Encrypt(plaintextBytes, RSAEncryptionPadding.Pkcs1);

                // Преобразование зашифрованного текста в строку
                return Convert.ToBase64String(ciphertextBytes);
            }
        }

        /// <summary>
        /// Дешифрование текста
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        private static string Decrypt(string ciphertext)
        {
            // Загрузка закрытого ключа из файла
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string privateKeyXml = File.ReadAllText(_privateKeyFile);
                rsa.FromXmlString(privateKeyXml);

                // Дешифрование текста
                byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);
                byte[] plaintextBytes = rsa.Decrypt(ciphertextBytes, RSAEncryptionPadding.Pkcs1);

                // Преобразование дешифрованного текста в строку
                return Encoding.UTF8.GetString(plaintextBytes);
            }
        }
    }
}
