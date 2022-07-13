using BenchmarkDotNet.Running;
using TechTalks.Castle.Benchmark;

var summary = BenchmarkRunner.Run<DecoratorBenchmarker>();