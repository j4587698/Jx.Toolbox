using Jx.Toolbox.Cryptography;

namespace Jx.Toolbox.Test;

public class DesTest
{
    [Fact]
    public void EncryptTest()
    {
        var key = "2B7E151628AED2A6";
        var iv = "AABB09182736CCDD";
        var data = "test";
        var encrypted = DesEncryption.Encrypt(data, key, iv);
        var decrypted = DesEncryption.Decrypt(encrypted, key, iv);
        Assert.Equal(data, decrypted);
    }
}