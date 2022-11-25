using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class PropertiesTest
{
    public class TestClass
    {
        public string? Url { get; set; }

        public string? UserName { get; set; }
    }

    [Fact]
    public void Test()
    {
        var test = new TestClass();
        test.Url = "https://www.google.com";
        test.UserName = "test";
        var str = Properties.Serialize(test);
        test = Properties.Deserialize<TestClass>(str.Split(Environment.NewLine));
        Assert.Equal("https://www.google.com", test.Url);
        Assert.Equal("test", test.UserName);
    }
}