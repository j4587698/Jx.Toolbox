using Jx.Toolbox.Extensions;

namespace Jx.Toolbox.Test;

public class ObjectTest
{
    public string? Test { get; set; }
    public List<string>? ListTest { get; set; }
    public int? IntTest { get; set; }

    [Fact]
    public void SetPropertyTest()
    {
        this.SetProperty(nameof(Test), "test");
        Assert.Equal("test", Test);
        this.SetProperty(nameof(IntTest), 1);
        Assert.Equal(1, IntTest);
        Assert.Throws<InvalidOperationException>(() => { this.SetProperty("abc", 1);});
        Assert.Throws<InvalidOperationException>(() => { this.SetProperty("ListTest", 1);});
    }
}