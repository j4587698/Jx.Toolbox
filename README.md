# Jx.Toolbox
常用工具集

## 工具库

AvatarUtil
```
await AvatarUtil.GetAvatarUrl("你要获取的Email地址"); // 使用cnavatar来获取此Email对应的头像地址

await AvatarUtil.GetAvatarBytesAsync("你要获取的Email地址"); // 使用cnavatar来获取此Email对应的头像byte数组
```

MimeUtil
```
MimeUtil.GetMimeFromExtension("扩展名"); // 根据扩展名获取Mime

MimeUtil.GetTypeFormExtension("扩展名"); // 根据扩展名获取大类

MimeUtil.GetExtensionFromMime("Mime"); // 根据Mime获取扩展名
```

NumberFormatUtil
```
NumberFormatUtil.ToDecimalString(数字, 要转换的进制); // 将long转换为对应进制字符串

NumberFormatUtil.ToLong(对应进制字符串, 原进制); // 将字符串按原进制转换为long
```

## 扩展库

StringExtension
```
"字符串".IsNullOrEmpty(); // 判断字符串是否为空
```

ObjectExtension
```
object.SetProperty("属性名", 属性值); // 使用反射给实例赋值
```

## 加密库

```
MD5.MD5String("要加密的字符串"); // 获取32位小写的MD5串

MD5.MD5StringWithSalt("要加密的字符串", "盐"); // 获取加盐后的32位小写MD5串

MD5.MD5String2("要加密的字符串"); // 获取2次MD5加密的32位小写MD5串

MD5.MD5String2WithSalt("要加密的字符串", "盐"); // 获取加盐后的2次MD5加密的32位小写MD5串
```

