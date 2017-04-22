using System;
using System.Collections.Generic;

namespace GoogleCodeJam.Helpers
{
	public static class DictionaryHelpers
	{
		public static void Update<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue, TValue> selector, TValue defaultValue = default(TValue))
		{
			var value = dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
			dictionary[key] = selector(value);
		}
	}
}