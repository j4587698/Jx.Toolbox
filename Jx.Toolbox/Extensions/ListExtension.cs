using System;
using System.Collections.Generic;

namespace Jx.Toolbox.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// 简易洗牌算法，支持IList
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
    }
}