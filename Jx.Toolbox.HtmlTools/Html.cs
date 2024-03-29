﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace Jx.Toolbox.HtmlTools
{
    /// <summary>
    /// Html相关处理
    /// </summary>
    public class Html
    {
        /// <summary>
        /// 根据标签名获取所有的标签
        /// </summary>
        /// <param name="html">要分析的Html</param>
        /// <param name="tagName">标签名</param>
        /// <returns></returns>
        public static IHtmlCollection<IElement> GetAllTagByTagName(string html, string tagName)
        {
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            return doc.DocumentElement.GetElementsByTagName(tagName);
        }
        
        /// <summary>
        /// 获取所有Img标签的Src
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetAllImgSrc(string html)
        {
            return GetAllTagByTagName(html, "img").Where(x => x.HasAttribute("src")).Select(x => x.GetAttribute("src"));
        }

        /// <summary>
        /// 移除所有的Html标签
        /// </summary>
        /// <param name="html">要处理的Html</param>
        /// <param name="length">截取长度（0代表不截取）</param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string html, int length = 0)
        {
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            var strText = doc.DocumentElement.TextContent;
            if (length > 0 && length < strText.Length)
            {
                strText = strText.Substring(0, length);
            }

            return strText;
        }

        /// <summary>
        /// 格式化html，尝试将不标准的html格式化为标准html
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string FormatHtml(string html)
        {
            var parser = new HtmlParser();
            var doc = parser.ParseDocument(html);
            return doc.Body?.InnerHtml;
        }
    }
}