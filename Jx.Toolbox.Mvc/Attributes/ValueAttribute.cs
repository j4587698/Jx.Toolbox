namespace Jx.Toolbox.Mvc.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ValueAttribute : Attribute
{
    public ValueAttribute(string configPath)
    {
        ConfigPath = configPath;
    }
        
    /// <summary>
    /// config文件中的路径，多层用:分隔，如：AppConfig:AppConfigOption:ConfigSearchFolder
    /// </summary>
    public string ConfigPath { get; set; }
}