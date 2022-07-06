using BenchmarkDotNet.Running;
using TechTalks.PostSharp.Benchmark;

var summary = BenchmarkRunner.Run<TransactionBenchmarker>();