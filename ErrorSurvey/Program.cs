using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Jobs;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace ErrorSurvey
{
	[SimpleJob(RunStrategy.Monitoring, launchCount: 1, warmupCount: 2, targetCount: 3)]
	public class SetupAndCleanupExample
	{
		private int setupCounter;
		private int cleanupCounter;

		[IterationSetup]
		public void IterationSetup() => Console.WriteLine("// " + "IterationSetup" + " (" + ++setupCounter + ")");

		[IterationCleanup]
		public void IterationCleanup() => Console.WriteLine("// " + "IterationCleanup" + " (" + ++cleanupCounter + ")");

		[GlobalSetup]
		public void GlobalSetup() => Console.WriteLine("// " + "GlobalSetup");

		[GlobalCleanup]
		public void GlobalCleanup() => Console.WriteLine("// " + "GlobalCleanup");

		[Benchmark]
		public void BenchmarkA() => Console.WriteLine("// " + "BenchmarkA");

		[Benchmark]
		public void BenchmarkB() => Console.WriteLine("// " + "BenchmarkB");

	}

	class Program
    {
        static void Main(string[] args)
        {
	        BenchmarkRunner.Run<SetupAndCleanupExample>();
        }
    }
}
