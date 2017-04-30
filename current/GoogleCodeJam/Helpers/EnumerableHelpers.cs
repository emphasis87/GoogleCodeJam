using JetBrains.Annotations;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam.Helpers
{
	public static class EnumerableHelpers
	{
		public static IEnumerable<T> NotNulls<T>(this IEnumerable<T> items)
		{
			return items.Where(x => x != null);
		}

		[ContractAnnotation("=> notnull")]
		public static IEnumerable<T> Iterable<T>(this IEnumerable<T> items)
		{
			return (items ?? Enumerable.Empty<T>()).NotNulls();
		}

		public static IEnumerable<T> Append<T>(this IEnumerable<T> items, params T[] tail)
		{
			return items.Concat(tail);
		}

		public static int GetSequenceHashCode<T>(this IEnumerable<T> items)
		{
			unchecked
			{
				var hash = 19;
				items.Iterable().ForEach(x => hash = hash * 31 + x.GetHashCode());
				return hash;
			}
		}

		public static T[] Collect<T>(this IEnumerable<T> items)
		{
			return items.Iterable().ToArray();
		}

		public static TResult[] Collect<T, TResult>(this IEnumerable<T> items, Func<T, TResult> selector)
		{
			return items.Iterable().Select(selector).NotNulls().ToArray();
		}

		public static void Shuffle<T>(this IList<T> list)
		{
			var rng = new Random();
			var n = list.Count;
			while (n > 1)
			{
				n--;
				var k = rng.Next(n + 1);
				var value = list[k];
				list[k] = list[n];
				list[n] = value;
			}
		}
	}
}