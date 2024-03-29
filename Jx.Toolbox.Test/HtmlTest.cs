﻿using Jx.Toolbox.HtmlTools;

namespace Jx.Toolbox.Test;

public class HtmlTest
{
    [Fact]
    public void GetAllImgSrc()
    {
        string str = "<html><body><img src='/test.jpg'><img src='/test1.jpg' /><img /></body></html>";
        Assert.Collection(Html.GetAllImgSrc(str), x => Assert.Equal("/test.jpg", x)
        , x => Assert.Equal("/test1.jpg", x));
    }

    [Fact]
    public void RemoveHtmlTag()
    {
        string str = "<html><body><span>test</span><br /><a>test1</a></body></html>";
        Assert.Equal("testtest1", Html.RemoveHtmlTag(str));
    }

    [Fact]
    public void FormatHtml()
    {
        var html = "<span>test";
        Assert.Equal("<span>test</span>", Html.FormatHtml(html));
    }
}