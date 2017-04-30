namespace GoogleCodeJam.Problem
{
	public class Program : ProgramBase
	{
		private static int Main(string[] args)
		{
			return Execute(args, input => new Solver().Solve(input));
		}
	}
}