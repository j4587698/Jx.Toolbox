using System;

namespace Jx.Toolbox.Extensions
{
    public static class ObjectExtension
    {
        public static void SetProperty(this object obj, string name, object value)
        {
            var t = obj.GetType();
            var p = t.GetProperty(name);

            if (p == null)
            {
                throw new InvalidOperationException($"未找到 {name} 属性");
            }

            if (!p.PropertyType.IsGenericType)
            {
                p.SetValue(obj, Convert.ChangeType(value, p.PropertyType));
            }
            else
            {
                var genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(Nullable<>))
                {
                    p.SetValue(obj,
                        Convert.ChangeType(value,
                            Nullable.GetUnderlyingType(p.PropertyType) ??
                            throw new InvalidOperationException("获取类型失败")));
                }
                else
                {
                    throw new InvalidOperationException("只能对基础类型进行赋值");
                }
            }
        }
    }
}