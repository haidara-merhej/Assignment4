# Benchmark Results

## Execution Environment

These benchmarks compare regular C# string concatenation with StringBuilder at different iteration counts.

## Performance Results

| Method                     | Iterations | Mean                | Error             | StdDev            | Allocated       |
|--------------------------- |----------- |--------------------:|------------------:|------------------:|----------------:|
| StringConcatenation        | 100        |         10,877.4 ns |         130.32 ns |         127.99 ns |       130.62 KB |
| StringBuilderConcatenation | 100        |            997.9 ns |          19.60 ns |          33.28 ns |         7.13 KB |
| StringConcatenation        | 1000       |        924,602.1 ns |      15,556.38 ns |      22,310.49 ns |     12732.38 KB |
| StringBuilderConcatenation | 1000       |          6,770.7 ns |          72.61 ns |          56.69 ns |        57.81 KB |
| StringConcatenation        | 10000      |    155,501,860.7 ns |   1,910,441.88 ns |   1,693,556.97 ns |   1270019.85 KB |
| StringBuilderConcatenation | 10000      |        221,895.6 ns |       1,527.38 ns |       1,275.43 ns |       521.78 KB |
| StringConcatenation        | 100000     | 51,259,716,553.3 ns | 356,698,520.12 ns | 333,656,017.18 ns | 126963827.37 KB |
| StringBuilderConcatenation | 100000     |      3,517,691.5 ns |      70,297.79 ns |     161,520.88 ns |      5100.83 KB |

## Benchmark Analysis

### 1. Which approach was faster with 100 iterations?

`StringBuilder` was faster than `StringConcatenation` with 100 iterations.

### 2. Which approach was faster with 100,000 iterations?

`StringBuilder` was much faster than `StringConcatenation`.

### 3. Which approach allocated more memory?

`StringConcatenation` allocated more memory than `StringBuilder` especially with 100000 iterations.

### 4. What happened to string concatenation performance as the loop size increased?

`StringConcatenation` became sigificantly slower as the number of iterations increased.
The performance difference between the two approaches became much larger for larger loops.

### 5. Why does repeated string concatenation create additional allocations?

Strings in C# are immutable, which means their contents cannot be changed after creation.
Repeated concatenation creates new string objects to hold he updated results. 

### 6. Why does StringBuilder usually perform better when text is repeatedly appended?

`StringBuilder` uses a mutable buffer that can be modified as text is appended.
This reduces the need to create a new string object for every append operatio, making it
generally more efficient for repeated concatenations.

### 7. Is StringBuilder always better than normal string operations? Explain.

No. For simple concatenations or a small number if strings, normal string may be sufficient and more readable.
`StringBuilder` is usually more beneficial when repeatedly appending text in loops or building large strings.
So the best choice depends on the situation.

## Understanding the Benchmark Columns

- **Mean:** Average measured execution time.
- **Error:** Reported uncertainty around the mean.
- **Allocated:** Total managed memory allocated during the benchmark.