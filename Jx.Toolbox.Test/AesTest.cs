using Jx.Toolbox.Cryptography;

namespace Jx.Toolbox.Test;

public class AesTest
{
    [Fact]
    public void EncryptTest()
    {
        var key = "1234567890ABCDEF1234567890ABCDEF";
        var iv = "1234567890ABCDEF1234567890ABCDEF";
        var data = "test";
        var encrypted = AesEncryption.Encrypt(data, key, iv);
        var decrypted = AesEncryption.Decrypt(encrypted, key, iv);
        Assert.Equal(data, decrypted);
    }
}