namespace AcademyScheduleAnalyzer.Benchmarks;
using System.Text;
using BenchmarkDotNet.Attributes;

[MemoryDiagnoser]
public class StringBenchmark
{
    [Params(100, 1000, 10000, 100000)]
    public int Iterations;

    [Benchmark]
    public string StringConcatenation()
    {
        string result = "";
        for(int i = 0; i < Iterations; i++)
        {
            result += "Hello, World!";
        }

        return result;
    }

    [Benchmark]
    public string StringBuilderConcatenation()
    {
        StringBuilder result = new StringBuilder();
        for(int i = 0; i < Iterations; i++)
        {
            result.Append("Hello, World!");
        }

        return result.ToString();
    }
}