using Jx.Toolbox.Extensions;

namespace Jx.Toolbox.Test;

public class LongTest
{
    [Fact]
    public void ToSizeString_Ok()
    {
        int fileSizeInBytes = 12345678;
        Assert.Equal("11.77 MB", fileSizeInBytes.ToSizeString());
    }

    [Fact]
    public void ToTimeString_Ok()
    {
        int totalSeconds = 3661;
        Assert.Equal("01:01:01", totalSeconds.ToTimeString());
    }
}