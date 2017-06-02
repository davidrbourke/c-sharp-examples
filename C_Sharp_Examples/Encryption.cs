using System.IO;
using System.Security.Cryptography;

namespace C_Sharp_Examples
{
    public class Encryption
    {
        public byte[] EncryptAes(string subjectToEncrypt, byte[] key, byte[] IV)
        {
            byte[] encryptedSubject;
            using (Aes aes = Aes.Create())
            {
                // aes.Key & aes.IV set but create another object to get new ones

                ICryptoTransform encryptor = aes.CreateEncryptor(key, IV);

                using (MemoryStream encyptionMemoryStream = new MemoryStream())
                {
                    using (CryptoStream encryptionCryptoStream = new CryptoStream(encyptionMemoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(encryptionCryptoStream))
                        {
                            writer.Write(subjectToEncrypt);
                        }
                        encryptedSubject = encyptionMemoryStream.ToArray();
                    }
                }

            }

            return encryptedSubject;
        }

        public string DecryptAes(byte[] subjectToDecrypt, byte[] key, byte[] IV)
        {
            string decryptedSubject;
            using (Aes aes = Aes.Create())
            {
                // aes.Key & aes.IV set but create another object to get new ones

                ICryptoTransform decryptor = aes.CreateDecryptor(key, IV);

                using (MemoryStream decryptionMemoryStream = new MemoryStream(subjectToDecrypt))
                {
                    using (CryptoStream decryptionCryptoStream = new CryptoStream(decryptionMemoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(decryptionCryptoStream))
                        {
                            decryptedSubject = reader.ReadToEnd();
                        }
                    }
                }

            }

            return decryptedSubject;
        }
    }
}
