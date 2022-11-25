using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Jx.Toolbox.Utils
{
    
    public static class Properties
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize(object obj)
        {
            var sb = new StringBuilder();
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                sb.AppendLine($"{property.Name} = {property.GetValue(obj)}");
            }
            return sb.ToString();
        }
        
        
        public static T Deserialize<T>(IEnumerable<string> lines) where T : new()
        {
            var obj = new T();
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var line = lines.FirstOrDefault(x => x.StartsWith(property.Name));
                if (line != null)
                {
                    var value = line.Split('=')[1].Trim();
                    property.SetValue(obj, Convert.ChangeType(value, property.PropertyType));
                }
            }
            return obj;
        }
    }
}