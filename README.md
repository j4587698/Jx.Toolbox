# Jx.Toolbox
常用工具集

## 获取头像

```
await AvatarUtil.GetAvatarUrl("你要获取的Email地址");
```
使用cnavatar来获取此Email对应的头像地址

```
await AvatarUtil.GetAvatarBytesAsync("你要获取的Email地址");
```
使用cnavatar来获取此Email对应的头像byte数组

## 扩展库

StringExtension
```
"字符串".IsNullOrEmpty();
```

ObjectExtension
```
object.SetProperty(propertyName, value);
```
使用反射给实例赋值

## 加密库

```
MD5.MD5String("要加密的字符串");
```
获取32位小写的MD5串
