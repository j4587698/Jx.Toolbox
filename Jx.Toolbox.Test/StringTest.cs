using Jx.Toolbox.Extensions;

namespace Jx.Toolbox.Test;

public class StringTest
{
    [Fact]
    public void WhiteSpace()
    {
        Assert.True("    ".IsNullOrWhiteSpace());
    }
    
    [Fact]
    public void Contains()
    {
        Assert.True("test1".Contains(new []{"test"}));
    }
}