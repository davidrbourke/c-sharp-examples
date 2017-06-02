using System.Security.Cryptography;
using C_Sharp_Examples;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace C_Sharp_Examples_Tests
{
    [TestClass]
    public class EncryptionTests
    {
        [TestMethod]
        public void EncryptAes_StringProvided_ByteArrayReturned()
        {
            // ARRANGE
            Encryption c = new Encryption();
            Aes aes = Aes.Create();

            // ACT
            var encryptedByteArray = c.EncryptAes("Hello world!", aes.Key, aes.IV);

            // ASSERT
            Assert.IsInstanceOfType(encryptedByteArray, typeof(byte[]));
        }

        [TestMethod]
        public void EncryptAes_StringProvided_StringEncrypted()
        {
            // ARRANGE
            Encryption c = new Encryption();
            Aes aes = Aes.Create();
            var encryptedByteArray = c.EncryptAes("Hello world!", aes.Key, aes.IV);

            // ACT
            string decryptedSubject = c.DecryptAes(encryptedByteArray, aes.Key, aes.IV);

            // ASSERT
            Assert.AreEqual("Hello world!", decryptedSubject);
        }

        [TestMethod]
        public void EncryptAes_SameKeySameIV_SameByteEncription()
        {
            // ARRANGE
            Encryption c = new Encryption();
            Aes aes = Aes.Create();

            // ACT
            var encryptedByteArrayA = c.EncryptAes("Hello world!", aes.Key, aes.IV);
            var encryptedByteArrayB = c.EncryptAes("Hello world!", aes.Key, aes.IV);

            // ASSERT
            Assert.AreEqual(encryptedByteArrayA[0], encryptedByteArrayB[0]);
            Assert.AreEqual(encryptedByteArrayA[encryptedByteArrayA.Length - 1], encryptedByteArrayB[encryptedByteArrayB.Length - 1]);
        }

        [TestMethod]
        public void EncryptAes_SameKeyDifferentIV_DifferentByteEncription()
        {
            // ARRANGE
            Encryption c = new Encryption();
            Aes aes = Aes.Create();
            Aes aesB = Aes.Create();

            // ACT
            var encryptedByteArrayA = c.EncryptAes("Hello world!", aes.Key, aes.IV);
            var encryptedByteArrayB = c.EncryptAes("Hello world!", aes.Key, aesB.IV);

            // ASSERT
            Assert.AreNotEqual(encryptedByteArrayA[0], encryptedByteArrayB[0]);
            Assert.AreNotEqual(encryptedByteArrayA[encryptedByteArrayA.Length - 1], encryptedByteArrayB[encryptedByteArrayB.Length - 1]);
        }

        [TestMethod]
        public void DecryptAes_SameKeyDifferentIV_SameKeyDecryptsToSameData()
        {
            // This test is to demonstrate that the same key can be used with a different Initialization Vector

            // ARRANGE
            Encryption c = new Encryption();
            Aes aes = Aes.Create();
            Aes aesB = Aes.Create();

            // ACT
            var encryptedByteArrayA = c.EncryptAes("Hello world!", aes.Key, aes.IV);
            var decryptedSubjectA = c.DecryptAes(encryptedByteArrayA, aes.Key, aes.IV);
            var encryptedByteArrayB = c.EncryptAes("Hello world!", aes.Key, aesB.IV);
            var decryptedSubjectB = c.DecryptAes(encryptedByteArrayB, aes.Key, aesB.IV);

            // ASSERT
            Assert.AreEqual("Hello world!", decryptedSubjectA);
            Assert.AreEqual("Hello world!", decryptedSubjectB);
        }
    }
}
