using System.Collections.Generic;

namespace ChaosLib.Extensions
{
    public static class DictionaryExt
    {
        /// <summary>
        /// Gets the value of a key, or adds the key to the dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="value"></param>
        /// <returns><see langword="true"/> if the value was found, or <see langword="false"/> if it was added.</returns>
        public static bool GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey keyToCheck, TValue valueToAdd, out TValue value)
        {
            if (!dictionary.TryGetValue(keyToCheck, out value))
            {
                value = valueToAdd;
                dictionary.Add(keyToCheck, value);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the value of a key, or adds the key to the dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="value"></param>
        /// <returns><see langword="true"/> if the value was found, or <see langword="false"/> if it was added.</returns>
        public static bool GetOrAddDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey keyToCheck, out TValue value)
        {
            if (!dictionary.TryGetValue(keyToCheck, out value))
            {
                value = default;
                dictionary.Add(keyToCheck, value);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the value of a key, or adds the key to the dictionary.
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dictionary"></param>
        /// <param name="value"></param>
        /// <returns><see langword="true"/> if the value was found, or <see langword="false"/> if it was added.</returns>
        public static bool GetOrAddNew<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey keyToCheck, out TValue value) where TValue : new()
        {
            if (!dictionary.TryGetValue(keyToCheck, out value))
            {
                value = new TValue();
                dictionary.Add(keyToCheck, value);
                return false;
            }

            return true;
        }
    }
}