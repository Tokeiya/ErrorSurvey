using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace ErrorSurvey
{

    public class Survey
    {
		[Params(100,1000,10000,100000)]
		public int Size { get; set; }

	    private int[] _array;

	    [IterationSetup]
	    public void IterationSetup()
	    {
		    _array = new int[Size];

		    for (int i = 0; i < _array.Length; i++)
		    {
			    _array[i] = i + 1;
		    }
	    }

	    [Benchmark]
	    public int Add()
	    {
		    var accum = 0;

		    foreach (var i in _array)
		    {
			    accum += i;
		    }

		    return accum;
	    }
    }
}
