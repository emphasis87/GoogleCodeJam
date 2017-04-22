using JetBrains.Annotations;
using MoreLinq;
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
	}
}