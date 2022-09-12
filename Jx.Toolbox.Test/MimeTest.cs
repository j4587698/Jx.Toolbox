using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class MimeTest
{
    [Fact]
    public void GetMimeFromExtension()
    {
        Assert.Equal("application/pdf", MimeUtil.GetMimeFromExtension("pdf"));
        Assert.Equal("application/pdf", MimeUtil.GetMimeFromExtension(".pdf"));
    }

    [Fact]
    public void GetTypeFormExtension()
    {
        Assert.Equal("image", MimeUtil.GetTypeFormExtension("bmp"));
        Assert.Equal("image", MimeUtil.GetTypeFormExtension(".bmp"));
    }

    [Fact]
    public void GetExtensionFromMime()
    {
        Assert.Equal(".pdf", MimeUtil.GetExtensionFromMime("application/pdf"));
    }
}