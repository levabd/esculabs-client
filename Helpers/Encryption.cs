namespace Client.Helpers
{
    using System;
    using Windows.Security.Cryptography;
    using Windows.Security.Cryptography.Core;
    using Windows.Storage.Streams;

    public class Encryption
    {
        public static string HashString(string input)
        {
            // Конвертируем строку в буффер 
            var buffUtf8Msg = CryptographicBuffer.ConvertStringToBinary(input, BinaryStringEncoding.Utf8);

            // Создаём провайдер алгоритма хеширования
            var objAlgProv = HashAlgorithmProvider.OpenAlgorithm(HashAlgorithmNames.Sha512);

            // Хешируем строку
            var buffHash = objAlgProv.HashData(buffUtf8Msg);

            // Проверяем, что длина полученного хеша равна ожидаемой длине хеша алгоритма (в SHA512 - 64 байта)
            if (buffHash.Length != objAlgProv.HashLength)
            {
                throw new Exception("Ошибка создания хеша");
            }

            // Возвращаем захешированную строку
            return CryptographicBuffer.EncodeToBase64String(buffHash);
        }
    }
}

