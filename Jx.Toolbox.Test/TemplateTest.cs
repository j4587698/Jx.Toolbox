using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class TemplateTest
{
    [Fact]
    public void RenderTemplate()
    {
        var str = "<test1>testtest<test2>";
        var template = Template.Create(str).SetStartKey("<").SetEndKey(">");
        Assert.Equal("abctesttest<test2>", template.SetValue("test1", "abc").Render());
        Assert.Throws<ArgumentException>(() =>
        {
            template.Render(true);
        });
        Assert.Equal("abctesttestbcd", template.SetValue("test2", "bcd").Render(true));
    }
    
}