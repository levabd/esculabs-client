namespace Client.Helpers
{
    using System.Text;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Storage.Streams;

    public class Encryption
    {
        private const string Salt = "v~ry*R%fPOG%Qbzq";

        /// <summary>
        /// Encrypt a string
        /// </summary>
        /// <param name="value">Value to be encrypted</param>
        /// <returns>Base64 encoded string</returns>
        public static string Encrypt(string value)
        {
            // We'll be using AES, CBC mode with PKCS#7 padding to encrypt
            SymmetricKeyAlgorithmProvider aesCbcPkcs7 = SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbcPkcs7);

            // Convert the private key to binary
            IBuffer keymaterial = CryptographicBuffer.ConvertStringToBinary(Salt, BinaryStringEncoding.Utf8);

            // Create the private key
            CryptographicKey k = aesCbcPkcs7.CreateSymmetricKey(keymaterial);

            // Creata a 16 byte initialization vector
            IBuffer iv = keymaterial;

            // Encrypt the data
            byte[] plainText = Encoding.UTF8.GetBytes(value); // Data to encrypt

            IBuffer buff = CryptographicEngine.Encrypt(k, CryptographicBuffer.CreateFromByteArray(plainText), iv);


            return CryptographicBuffer.EncodeToBase64String(buff);
        }

        ///// <summary>
        ///// Decrypt a string
        ///// </summary>
        ///// <param name="value">Encrypted string in Base64 format</param>
        ///// <returns>Original value</returns>
        //public static string Decrypt(string value)
        //{
        //    IBuffer val = CryptographicBuffer.DecodeFromBase64String(value);

        //    // Use AES, CBC mode with PKCS#7 padding (good default choice)
        //    SymmetricKeyAlgorithmProvider aesCbcPkcs7 =
        //        SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithmNames.AesCbcPkcs7);

        //    IBuffer keymaterial = CryptographicBuffer.ConvertStringToBinary(Salt, BinaryStringEncoding.Utf8);

        //    // Create an AES 128-bit (16 byte) key
        //    CryptographicKey k = aesCbcPkcs7.CreateSymmetricKey(keymaterial);

        //    // Creata a 16 byte initialization vector
        //    IBuffer iv = keymaterial;// CryptographicBuffer.GenerateRandom(aesCbcPkcs7.BlockLength);

        //    //IBuffer val = CryptographicBuffer.DecodeFromBase64String(value);

        //    IBuffer buff = CryptographicEngine.Decrypt(k, val, iv);

        //    return CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8, buff);

        //}
    }
}

