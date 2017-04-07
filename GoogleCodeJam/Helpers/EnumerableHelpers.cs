using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCodeJam.Helpers
{
	public static class EnumerableHelpers
	{
		public static IEnumerable<T> NotNulls<T>(this IEnumerable<T> items)
		{
			return items.Iterable().Where(x => x != null);
		}

		public static IEnumerable<T> Iterable<T>(this IEnumerable<T> items)
		{
			return items ?? Enumerable.Empty<T>();
		}
	}
}
