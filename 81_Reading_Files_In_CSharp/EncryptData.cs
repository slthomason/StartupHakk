string Decrypt(string encryptedData)
{
    byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

    using Aes aesAlg = Aes.Create();
    aesAlg.Key = key;
    aesAlg.IV = iv;

    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

    using MemoryStream msDecrypt = new(encryptedBytes);
    using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
    using StreamReader srDecrypt = new(csDecrypt);
    return srDecrypt.ReadToEnd();
}