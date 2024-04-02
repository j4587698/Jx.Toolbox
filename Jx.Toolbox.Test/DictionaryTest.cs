using Jx.Toolbox.Extensions;

namespace Jx.Toolbox.Test;

public class DictionaryTest
{
    [Fact]
    public void TryRemoveTest()
    {
        var dict = new Dictionary<string, string>
        {
            {"a", "1"},
            {"b", "2"},
            {"c", "3"}
        };
        Assert.True(dict.TryRemove("a", out var result));
        Assert.Equal("1", result);
        Assert.False(dict.TryRemove("d", out result));
        Assert.Null(result);
    }
}