using JetBrains.Annotations;
using System;
using System.IO;
using System.Text;

namespace GoogleCodeJam
{
	public class ProgramBase
	{
		protected static int Execute(string[] args, [NotNull] Func<string, string> process)
		{
			if (args.Length > 1)
			{
				Console.Error.WriteLine("This program accepts either a single parameter with a path to an input file or a text through standard input.");
				return 1;
			}

			string content;
			if (args.Length == 1)
			{
				if (!File.Exists(args[0]))
				{
					Console.Error.WriteLine($"The file specified by the path: '{args[0]}' can not be found.");
					return 2;
				}
				content = File.ReadAllText(args[0]);
			}
			else
			{
				Console.InputEncoding = Encoding.UTF8;
				content = Console.In.ReadToEnd();
			}

			var result = process(content);
			Console.Write(result);

			return 0;
		}
	}
}