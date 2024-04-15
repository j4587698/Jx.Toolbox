using Jx.Toolbox.Cryptography;
using Jx.Toolbox.Hash;

namespace Jx.Toolbox.Test;

public class MD5Test
{
    [Fact]
    public void TestMD5()
    {
        Assert.Equal("098f6bcd4621d373cade4e832627b4f6", MD5.MD5String("test"));
        Assert.Equal("fb469d7ef430b0baf0cab6c436e70375", MD5.MD5String2("test"));
        Assert.Equal("315240c61218a4a861ec949166a85ef0", MD5.MD5StringWithSalt("test", "salt"));
        Assert.Equal("1b916c65ca424d1566b9f6e53e8edace", MD5.MD5String2WithSalt("test", "salt"));
    }
}