using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class AvatarTest
{
    [Fact]
    public void AvatarUrlTest()
    {
        Assert.Equal("https://cravatar.cn/avatar/d359e0ed709392be140e2bcb454f0500", AvatarUtil.GetAvatarUrl("jx@jvxiang.com"));
    }

    [Fact]
    public async Task AvatarBytesTest()
    {
        Assert.Null(await AvatarUtil.GetAvatarBytesAsync(null));
        var bytes = await AvatarUtil.GetAvatarBytesAsync("jx@jvxiang.com");
        Assert.NotEmpty(bytes);
    }
}