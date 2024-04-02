using System.Collections.Generic;

namespace Jx.Toolbox.Extensions
{
    public static class DictionaryExtension
    {
        public static bool TryRemove<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, out TValue result)
        {
            result = default;
            if (dictionary.TryGetValue(key, out result))
            {
                return dictionary.Remove(key);
            }

            return false;
        }
    }
}