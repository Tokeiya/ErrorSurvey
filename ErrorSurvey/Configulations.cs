using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Exporters.Csv;
using BenchmarkDotNet.Jobs;

namespace ErrorSurvey
{
    public static class Configulations
    {
	    public static IConfig CreateNormal(int count)
	    {
		    var job = Job.Core
			    .WithTargetCount(count);

		    return ManualConfig.Create(DefaultConfig.Instance)
			    .With(job)
			    .With(new CsvExporter(CsvSeparator.Comma))
			    .With(new CsvMeasurementsExporter(CsvSeparator.Comma));
	    }
    }
}
