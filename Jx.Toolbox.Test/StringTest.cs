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
        Assert.False("test1".Contains(Array.Empty<string>()));
        Assert.True("test1".Contains(new []{"test"}));
    }

    [Fact]
    public void ToPascal()
    {
        Assert.Equal("TestAssert", "test_assert".ToPascal());
        Assert.Equal("test_assert", "TestAssert".ToUnderLine());
    }

    [Fact]
    public void FirstLetter()
    {
        Assert.Equal("test", "Test".FirstLetterToLower());
        Assert.Equal("Test", "test".FirstLetterToUpper());
    }
}