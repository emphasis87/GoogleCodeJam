using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;

namespace GoogleCodeJam.Helpers
{
	public static class StringHelpers
	{
		public static IEnumerable<string> ToLines(this string str)
		{
			if (str == null)
				yield break;

			using (var reader = new StringReader(str))
			{
				string line;
				while ((line = reader.ReadLine()) != null)
					yield return line;
			}
		}

		public static string[] ToChunks(this string str)
		{
			return str?.Split(null) ?? new string[0];
		}

		public static string Join(this IEnumerable<string> items, string delimiter = "")
		{
			return items?.ToDelimitedString(delimiter) ?? "";
		}

		public static string JoinLines(this IEnumerable<string> items)
		{
			return items?.ToDelimitedString(Environment.NewLine) ?? "";
		}
	}
}