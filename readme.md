# Code performance & benchmarking
Project with exercises on code optimization and BenchmarkDotNet.

## Sources
- BenchmarkDotNet git repo https://github.com/dotnet/BenchmarkDotNet
- BenchmarkDotNet home https://benchmarkdotnet.org/
- .NET blog performance articles https://devblogs.microsoft.com/dotnet/?s=performance&submit=%EE%9C%A1

## Notes for the lecture
1. `Program.cs`, benchmark runner, Release, without debug (CTRL+F5), HashBenchmark
2. `StringBenchmark` What is faster? String concatenation or string builder?
3. `SubBufferBenchmarks` Keep performace in mind when dealing with large arrays. 
	- Performace of some implementations may vary.
	- The fixed statement prevents the garbage collector from relocating a movable variable.
4. `SearchingStringBenchmark` - Regular expression is generally slower because its overhead (regex engine, expression parsing and compilation if set)
	- However, Regex uses caching so it is faster in this example.
	- We can make it even faster by using `RegexOption.Compile`
	- More here https://docs.microsoft.com/en-us/dotnet/standard/base-types/details-of-regular-expression-behavior
	- What is complexity of searching? O(m+n) https://en.wikipedia.org/wiki/Knuth%E2%80%93Morris%E2%80%93Pratt_algorithm
5. `StructVsClasses` - value types are stored on stack, reference types on heap. 
	- Reference types bring us fetures like inheritance, polymorphysm, garbage collection,...
	- To do that, they heave special headers on heap (to enable those features).
	- In array, reference types are stored as pointers, value types are directly on that place in memory.
6. `ToStringBenchmark` - string interpolation is just syntactic sugar for `string.Format()`.
	- If you look at `string.Format()` it takes string and array of objects https://docs.microsoft.com/en-us/dotnet/api/system.string.format?view=netframework-4.8
	- But `a` and `b` are value types on stack, so they need to be boxed `(object)a`
7. `MatrixBenchmark` - the trick is in processor cache. In case of j,i it has lot of cache miss making prefetching useless.
	- Small array fit to the L2 cache sot it doesn't have this problem.
8. `LinqBenchmark` - lambda is in fact delegate and we call this delegate on each item in collection. To make all of this happen, we need lot of allocations.
	- Foreach - Current, MoveNextNext, Dispose.