using Jx.Toolbox.HtmlTools;

namespace Jx.Toolbox.Test;

public class HtmlTest
{
    [Fact]
    public async Task GetAllImgSrc()
    {
        string str = "<html><body><img src='/test.jpg'><img src='/test1.jpg' /><img /></body></html>";
        Assert.Collection(await Html.GetAllImgSrc(str), x => Assert.Equal("/test.jpg", x)
        , x => Assert.Equal("/test1.jpg", x));
    }
    
}