using Jx.Toolbox.Utils;

namespace Jx.Toolbox.Test;

public class NumberFormatTest
{
    [Fact]
    public void ToDecimalString()
    {
        long number = 123456789;
        Assert.Equal("111010110111100110100010101", NumberFormat.ToDecimalString(number, 2));
        Assert.Equal("726746425", NumberFormat.ToDecimalString(number, 8));
        Assert.Equal("75BCD15", NumberFormat.ToDecimalString(number, 16));
        Assert.Equal("21I3V9", NumberFormat.ToDecimalString(number, 36));
    }

    [Fact]
    public void ToLong()
    {
        Assert.Equal(123456789, NumberFormat.ToLong("111010110111100110100010101", 2));
        Assert.Equal(123456789, NumberFormat.ToLong("726746425", 8));
        Assert.Equal(123456789, NumberFormat.ToLong("75BCD15", 16));
        Assert.Equal(123456789, NumberFormat.ToLong("21I3V9", 36));
    }
}