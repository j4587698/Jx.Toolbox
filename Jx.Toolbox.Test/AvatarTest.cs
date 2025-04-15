using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class AvatarTest
{
    [Fact]
    public void AvatarUrlTest()
    {
        Assert.Equal("https://cravatar.com/avatar/d359e0ed709392be140e2bcb454f0500", Avatar.GetAvatarUrl("jx@jvxiang.com"));
    }

    [Fact]
    public async Task AvatarBytesTest()
    {
        Assert.Null(await Avatar.GetAvatarBytesAsync(null));
        var bytes = await Avatar.GetAvatarBytesAsync("jx@jvxiang.com");
        Assert.NotEmpty(bytes);
    }
}