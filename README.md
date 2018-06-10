# High Performance Computing in C# (HPC#)

High performance C#/.NET generic algorithms. Community driven to move C# toward high performance computing.
Includes linear and stable Radix Sort algorithm, as well as Merge Sort and Merge of arrays and lists.
Provides a trade-off between performance and level of abstraction: Array, List, IList, IEnumerable.
Lowering the level of abstraction results in higher performance. Some algorithms are parallel for additional performance.
Open source.

Version 1.0 includes the following Linq style algorithms:

*Algorithm*|*Collection*|*vs Linq*|*Parallel vs Linq*
--- | --- | --- | ---
SequenceEqual|Array, List|4X faster|up to 11X faster
Min|Array, List|1.5-3X faster
Max|Array, List|1.5X faster

Sorting and Merging Algorithms:

*Algorithm*|*Collection*|*Distribution*|*vs .Sort*|*vs Linq*|*vs Linq.AsParallel*|*Description*
--- | --- | --- | --- | --- | --- | ---
Radix Sort|Array|Random|5X-7X|18X-35X|5X-9X|Stable, Generic
Radix Sort|List||Random|4X-7X|14X-27X|4X-8X|Stable, Generic
Radix Sort|Array|Presorted|0.3X-0.5X|3X-5X|1X-2X|Stable, Generic
Radix Sort|List||Presorted|0.3X-0.5X|3X-5X|1X-3X|Stable, Generic
Radix Sort|Array|Constant|1.2X-1.5X|6X-8X|2X-3X|Stable, Generic
Radix Sort|List||Constant|1X-1.4X|5X-6X|2X-3X|Stable, Generic

*Algorithm*|*Collection*|*vs Array Sort*|*Description*
--- | --- | --- | ---
Insertion Sort|Array, List||For fast in-place sorting of very small collections
Merge|Array, List||merges two pre-sorted collections
Radix Sort|Array, List|5X faster|Stable, O(N) Linear Time Sort
Merge Sort|Array, List|1.7X slower|Stable, O(NlgN), never O(N<sup>2</sup>), Generic


See HPCsharpExample folder in this repo for usage examples - a complete VisualStudio 2017 solution provided.

For details on the motivation see blog:
https://duvanenko.tech.blog/2018/03/03/high-performance-c/

# More High Performance Algorithms
Soon to be available at https://foostate.com/

*Algorithm*|*Collection*|*Distribution*|*vs .Sort*|*vs Linq*|*vs Linq.AsParallel*|*Description*
--- | --- | --- | --- | --- | --- | ---
Radix Sort|Array|Random|5X-7X|18X-35X|5X-9X|Stable, Generic
Radix Sort|List||Random|4X-7X|14X-27X|4X-8X|Stable, Generic
Radix Sort|Array|Presorted|0.3X-0.5X|3X-5X|1X-2X|Stable, Generic
Radix Sort|List||Presorted|0.3X-0.5X|3X-5X|1X-3X|Stable, Generic
Radix Sort|Array|Constant|1.2X-1.5X|6X-8X|2X-3X|Stable, Generic
Radix Sort|List||Constant|1X-1.4X|5X-6X|2X-3X|Stable, Generic

Merge Sort|Array|Random|0.6X-0.7X|2X-4X|1X-3X||Stable
Merge Sort|List|Random||2X-3X faster|||Stable
Parallel Merge Sort|Random|Array|2X-3X faster||||Stable
Parallel Merge Sort|Random|List|2X-3X faster||||Stable

Parallel Copying:

*Method*|*Collection*|*Parallel*
--- | --- | ---
Parallel CopyTo|List to Array|1.7X-2.5X faster



[![paypal](https://www.paypalobjects.com/en_US/i/btn/btn_donateCC_LG.gif)](https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=LDD8L7UPAC7QL)
