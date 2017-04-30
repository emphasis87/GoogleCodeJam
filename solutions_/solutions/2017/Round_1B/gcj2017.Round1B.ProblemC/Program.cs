using GoogleCodeJam;

namespace gcj2017.Round1B.ProblemC
{
	internal class Program : ProgramBase
	{
		private static int Main(string[] args)
		{
			var solver = new Solver();
			return Execute(args, x => solver.Resolve(x));
		}
	}
}