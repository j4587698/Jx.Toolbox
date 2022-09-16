using System;
using System.Reflection;

namespace Jx.Toolbox.Extensions
{
    public static class ObjectExtension
    {

        /// <summary>
        /// 获取属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bindingFlags"></param>
        /// <returns></returns>
        public static PropertyInfo[] GetProperties(this object obj, BindingFlags bindingFlags = BindingFlags.Public)
        {
            return obj.GetType().GetProperties(bindingFlags);
        }
        
        /// <summary>
        /// 设置属性
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="bindingFlags"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void SetProperty(this object obj, string name, object value, BindingFlags bindingFlags = BindingFlags.Public)
        {
            var t = obj.GetType();
            var p = t.GetProperty(name, bindingFlags);

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