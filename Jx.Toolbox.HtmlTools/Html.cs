﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

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
        public static async Task<IHtmlCollection<IElement>> GetAllTagByTagName(string html, string tagName)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var doc = await context.OpenAsync(request => request.Content(html));
            return doc.Body.GetElementsByTagName(tagName);
        }
        
        /// <summary>
        /// 获取所有Img标签的Src
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<string>> GetAllImgSrc(string html)
        {
            return (await GetAllTagByTagName(html, "img")).Where(x => x.HasAttribute("src")).Select(x => x.GetAttribute("src"));
        }

        /// <summary>
        /// 移除所有的Html标签
        /// </summary>
        /// <param name="html">要处理的Html</param>
        /// <param name="length">截取长度（0代表不截取）</param>
        /// <returns></returns>
        public static async Task<string> RemoveHtmlTag(string html, int length = 0)
        {
            var context = BrowsingContext.New(Configuration.Default);
            var doc = await context.OpenAsync(req => req.Content(html));
            var strText = doc.Body.TextContent;
            if (length > 0 && length < strText.Length)
            {
                strText = strText.Substring(0, length);
            }

            return strText;
        }
    }
}