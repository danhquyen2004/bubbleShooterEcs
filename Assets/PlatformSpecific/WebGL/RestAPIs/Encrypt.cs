using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto;
using System;
using System.IO;
using System.Text;
using Org.BouncyCastle.OpenSsl;

public static class EncryptCustom
{
    // Example private key in PEM format (replace with your actual private key)
    public static string Encrypt(string data, string publicKey)
    {
        var bytesToEncrypt = Encoding.UTF8.GetBytes(data);

        // Convert the public key to an AsymmetricKeyParameter
        var keyParameter = (AsymmetricKeyParameter)new PemReader(new StringReader(publicKey)).ReadObject();

        // Set up the RSA encryption engine with PKCS1 padding
        var rsaEngine = new Pkcs1Encoding(new RsaEngine());
        rsaEngine.Init(true, keyParameter);

        // Encrypt the data
        var encryptedBytes = rsaEngine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);

        // Convert the encrypted bytes to a base64 string
        return Convert.ToBase64String(encryptedBytes);
    }

    public static string Decrypt(string encryptedData, string privateKey)
    {
        var bytesToDecrypt = Convert.FromBase64String(encryptedData);

        // Convert the private key to an AsymmetricKeyParameter
        AsymmetricKeyParameter keyParameter = null;
        using (var reader = new StringReader(privateKey))
        {
            var pemReader = new PemReader(reader);
            keyParameter = (AsymmetricKeyParameter)pemReader.ReadObject();
        }

        // Set up the RSA decryption engine with PKCS1 padding
        var rsaEngine = new Pkcs1Encoding(new RsaEngine());
        rsaEngine.Init(false, keyParameter);

        // Decrypt the data
        var decryptedBytes = rsaEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length);

        // Convert the decrypted bytes to a string
        return Encoding.UTF8.GetString(decryptedBytes);
    }
}
