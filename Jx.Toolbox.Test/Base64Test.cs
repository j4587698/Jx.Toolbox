using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class Base64Test
{
    [Fact]
    public void Encode()
    {
        string str = "Hello World";
        var encode = Base64.Encode(str);
        Assert.Equal(str, Base64.DecodeToString(encode));
    }

    [Fact]
    public void EncodeUrl()
    {
        var str = "What does 2 + 2.1 equal?? ~ 4";
        var encode = Base64.EncodeUrl(str);
        Assert.Equal("V2hhdCBkb2VzIDIgKyAyLjEgZXF1YWw_PyB-IDQ", encode);
        Assert.Equal(str, Base64.DecodeUrlToString(encode));
    }
}