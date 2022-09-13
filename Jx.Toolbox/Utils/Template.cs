using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Jx.Toolbox.Utils
{
    /// <summary>
    /// 模板
    /// </summary>
    public class Template
    {
        /// <summary>
        /// 模板内容
        /// </summary>
        private string _content;

        /// <summary>
        /// 变量开始标志
        /// </summary>
        private string _startKey = "{{";

        /// <summary>
        /// 变量结束标志
        /// </summary>
        private string _endKey = "}}";
        
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="content"></param>
        public Template(string content)
        {
            _content = content;
        }

        /// <summary>
        /// 设置内容
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Template SetValue(string key, string value)
        {
            _content = _content.Replace($"{_startKey}{key}{_endKey}", value);
            return this;
        }

        /// <summary>
        /// 设置变量开始标志
        /// </summary>
        /// <param name="startKey"></param>
        /// <returns></returns>
        public Template SetStartKey(string startKey)
        {
            _startKey = startKey;
            return this;
        }

        /// <summary>
        /// 设置变量结束标志
        /// </summary>
        /// <param name="endKey"></param>
        /// <returns></returns>
        public Template SetEndKey(string endKey)
        {
            _endKey = endKey;
            return this;
        }

        /// <summary>
        /// 渲染模板
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string Render(bool check = false)
        {
            if (check)
            {
                var mc = Regex.Matches(_content, $"{_startKey}.+?{_endKey}");
                if (mc.Count > 0)
                {
                    throw new ArgumentException($"存在未赋值的变量{string.Join(",", mc.Cast<Match>().Select(x => x.Value))}");
                }
            }

            return _content;
        }

        public static Template Create(string content)
        {
            return new Template(content);
        }
        
    }
}