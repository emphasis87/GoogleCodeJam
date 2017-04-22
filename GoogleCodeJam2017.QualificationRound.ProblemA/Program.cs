using GoogleCodeJam;

namespace GoogleCodeJam2017.QualificationRound.ProblemA
{
	public class Program : ProgramBase
	{
		private static int Main(string[] args)
		{
			return Execute(args, x =>
			{
				var flipper = new OversizedPancakeFlipper();
				return flipper.Resolve(x);
			});
		}
	}
}