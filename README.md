# Jx.Toolbox
常用工具集

## 工具库

Avatar
```
await Avatar.GetAvatarUrl("你要获取的Email地址"); // 使用cnavatar来获取此Email对应的头像地址
await Avatar.GetAvatarBytesAsync("你要获取的Email地址"); // 使用cnavatar来获取此Email对应的头像byte数组
```

Mime
```
Mime.GetMimeFromExtension("扩展名"); // 根据扩展名获取Mime
Mime.GetTypeFormExtension("扩展名"); // 根据扩展名获取大类
Mime.GetExtensionFromMime("Mime"); // 根据Mime获取扩展名
```

NumberFormat
```
NumberFormat.ToDecimalString(数字, 要转换的进制); // 将long转换为对应进制字符串
NumberFormat.ToLong(对应进制字符串, 原进制); // 将字符串按原进制转换为long
```

Template
```
var template = Template.Create(要渲染的字符串); // 创建Template实例
template.SetStartKey(开始标志); // 设置变量开始标志，默认为{{
template.SetEndKey(结束标志); // 设置变量结束标志，默认为}}
template.SetValue(变量名, 变量值); // 给变量赋值
var str = template.Render(是否所有变量都必须赋值); // 渲染字符串，如果设置了需要检查变量，则如果有变量未赋值，抛出ArgumentException异常

// 可以使用链式表达式直接完成所有的操作。
var str = Template.Create(要渲染的字符串).SetStartKey(开始标志).SetEndKey(结束标志).SetValue(变量名, 变量值).Render(是否所有变量都必须赋值);
```

## 扩展库

StringExtension
```
"字符串".IsNullOrEmpty(); // 判断字符串是否为空
"字符串".IsNullOrWhiteSpace(); // 判断字符串是否为空或者空格
"字符串".Contains(数组); // 判断字符串中是否包含指定数组
"字符串".ToPascal(); // 将字符串转换为驼峰形式
"字符串".ToUnderLine(); // 驼峰转下划线
"字符串".FirstLetterToLower(); // 字符串首字母小写
"字符串".FirstLetterToUpper(); // 字符串首字母大写
```

ObjectExtension
```
任意类型.GetProperties(属性类型); // 获取所有属性，默认获取public的属性
任意类型.SetProperty("属性名", 属性值, 属性类型); // 使用反射给实例赋值，默认只查找public的属性
```

EnumExtension
```
"字符串".ToEnum<枚举类型>(是否区分大小写); // 字符串转换为枚举类型
"字符串".ToEnum(转换失败返回枚举类型, 是否区分大小写); // 字符串转换为枚举类型，如果转换失败，则返回默认类型
枚举类型.ToEnum(枚举字符串, 是否区分大小写); // 字符串转换为枚举类型
枚举值.GetDescription(); // 获取枚举的Description，如果没有，则返回内容
```

StringArrayExtension
```
字符数组.Join(分隔符); // 字符数组合并为字符串，默认分隔符为逗号
```

## 加密库

```
MD5.MD5String("要加密的字符串"); // 获取32位小写的MD5串
MD5.MD5StringWithSalt("要加密的字符串", "盐"); // 获取加盐后的32位小写MD5串
MD5.MD5String2("要加密的字符串"); // 获取2次MD5加密的32位小写MD5串
MD5.MD5String2WithSalt("要加密的字符串", "盐"); // 获取加盐后的2次MD5加密的32位小写MD5串
```

# Jx.Toolbox.HtmlTools
Html相关

## html处理
```
Html.GetAllTagByTagName(要解析的html, 标签名); // 获取html中所有的指定标签节点
Html.GetAllImgSrc(要解析的html); // 获取Html中所有的img的src
Html.RemoveHtmlTag(要解析的html); // 移除所有Html标签
```