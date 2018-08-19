using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Linq;

namespace PerformanceTalkDemo
{
    [MemoryDiagnoser]
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<Program>();
        }

        private string[] _data = new string[] { "the", "quick", "brown", "fox", "jumped", "over", "the", "lazy", "dog" };

        [Benchmark(Baseline = true)]
        public string Aggregate()
        {
            return _data.Aggregate(string.Empty, (c, n) => c + n + ",");
        }

        [Benchmark]
        public string Join()
        {
            return string.Join(",", _data);
        }
    }
}
