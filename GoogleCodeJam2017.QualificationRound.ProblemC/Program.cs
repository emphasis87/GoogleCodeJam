using GoogleCodeJam;

namespace GoogleCodeJam2017.QualificationRound.ProblemC
{
	public class Program : ProgramBase
	{
		private static int Main(string[] args)
		{
			var solver = new Solver();
			return Execute(args, x => solver.Resolve(x));
		}
	}
}