using System.ComponentModel;
using AngleSharp.Text;
using Jx.Toolbox.Extensions;

namespace Jx.Toolbox.Test;

public class EnumTest
{
    enum TestEnum
    {
        [Description("测试")]
        test,
        test1,
        test2
    }
    
    [Fact]
    public void ToEnum()
    {
        Assert.Equal(TestEnum.test1, "test1".ToEnum<TestEnum>(false));
        Assert.Equal(TestEnum.test2, typeof(TestEnum).ToEnum("Test2"));
        Assert.Equal(TestEnum.test1, "test1".ToEnum(TestEnum.test));
        Assert.Equal(TestEnum.test, "Test1".ToEnum(TestEnum.test, false));
        Assert.Throws<ArgumentException>(() =>
        {
            "Test".ToEnum<TestEnum>(false);
        });
        Assert.Throws<ArgumentException>(() =>
        {
            typeof(string).ToEnum("test1");
        });
    }

    [Fact]
    public void GetDescription()
    {
        Assert.Equal("测试", TestEnum.test.GetDescription());
        Assert.Equal("test1", TestEnum.test1.GetDescription());
    }
}