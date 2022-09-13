using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class MimeTest
{
    [Fact]
    public void GetMimeFromExtension()
    {
        Assert.Equal("application/pdf", Mime.GetMimeFromExtension("pdf"));
        Assert.Equal("application/pdf", Mime.GetMimeFromExtension(".pdf"));
    }

    [Fact]
    public void GetTypeFormExtension()
    {
        Assert.Equal("image", Mime.GetTypeFormExtension("bmp"));
        Assert.Equal("image", Mime.GetTypeFormExtension(".bmp"));
    }

    [Fact]
    public void GetExtensionFromMime()
    {
        Assert.Equal(".pdf", Mime.GetExtensionFromMime("application/pdf"));
    }
}