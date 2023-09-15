using (StreamWriter file = new("YourFileHere.klc"))
{

}

using (StreamWriter file = new(@"c:\path\to\YourFileHere.klc"))
{

}

//Using Folders
string fileName = @"d:\my_folder\data.klc";

using (StreamWriter file = new(fileName))
{    
    file.Write("hello ");
    file.WriteLine("world");

    file.WriteLine("another line here");
}

string folder = @"d:\my_folder\";
string filename = "data.txt";
string path = Path.Combine(folder, filename);

if(!Directory.Exists(folder))
    Directory.CreateDirectory(folder);

using (StreamWriter file = new(path))
{    
    file.Write("hello ");
    file.WriteLine("world");

    file.WriteLine("another line here");
}

//Special Folders
string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YourFileHere.klc");

using (StreamWriter file = new(path))
{    
    file.Write("hello ");
    file.WriteLine("world");

    file.WriteLine("another line here");
}

//Encryption & Decryption
string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "YourFileHere.txt");

byte[] key;
byte[] iv;

using (StreamWriter file = new(path))
{
    string toWrite = "Hello world! This is an encrypted text!";

    file.Write(Encrypt(toWrite));
}

string Encrypt(string plainText)
{
    using Aes aesAlg = Aes.Create();

    aesAlg.GenerateKey();
    aesAlg.GenerateIV();

    key = aesAlg.Key;
    iv = aesAlg.IV;

    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

    using MemoryStream msEncrypt = new();
    using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
    using (StreamWriter swEncrypt = new(csEncrypt))
    {
        swEncrypt.Write(plainText);
    }
    byte[] encryptedBytes = msEncrypt.ToArray();
    return Convert.ToBase64String(encryptedBytes);
}
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