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
        public static void SetProperty(this object obj, string name, object value, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance)
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
        
        /// <summary>
        /// 将源属性拷贝到目标
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        public static void CopyTo<TSource, TTarget>(this TSource source, TTarget target)
        {
            PropertyInfo[] propertyInfos = GetProperties(source, BindingFlags.Public | BindingFlags.Instance);
            Type targetType = target.GetType();
            foreach (var propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(source, null);
                if (value != null)
                {
                    targetType.GetProperty(propertyInfo.Name)?.SetValue(target, value, null);
                }
            }
        }

        /// <summary>
        /// 将目标属性拷贝到源
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        public static void CopyFrom<TSource, TTarget>(this TSource source, TTarget target)
        {
            CopyTo(target, source);
        }
        
        /// <summary>
        /// 将源属性拷贝到目标
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TTarget"></typeparam>
        /// <returns></returns>
        public static TTarget CopyTo<TTarget>(this object source)
        {
            var target = Activator.CreateInstance<TTarget>();
            CopyTo(source, target);
            return target;
        }
    }
}