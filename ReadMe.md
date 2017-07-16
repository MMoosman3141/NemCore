# NemCore

NemCore is a library of various things I've found to be useful, but not things that I can easily classify together into a meaningful unit.

### LogFileListener
LogFileListener is an implementation of a TraceListener designed for writing out a log file.

There isn't much to it.  If you specify a log file name, it will try to use that.  If you don't, it will base the name on the running process.
The only reason it wouldn't use the name you specify is if the file is already in use.  If that's the case it will simply append a number to the filename so you would get things like "log_2.log."

### NemCore.Extensions
This namespace provides extension methods that I've found helpful.

#### IndexesOf
This extension method works on IEnumerable objects returning an IEnumerable of the indexes where a predicate pattern is matched.  The code utilizes defered execution to retrieve the indexes.

**Example:**
```C#
  public void TestIndexesOf() {
    List<string> names = new List<string>() {
      "Abigail",
      "Ava",
      "Benjamin",
      "Charlotte",
      "Elijah",
      "Emily"
    };

    IEnumerable<int> aIndexes = names.IndexesOf(name => name.StartsWith("A"));
    IEnumerable<int> bIndexes = names.IndexesOf(name => name.StartsWith("B"));
    IEnumerable<int> cIndexes = names.IndexesOf(name => name.StartsWith("C"));
    IEnumerable<int> dIndexes = names.IndexesOf(name => name.StartsWith("D"));

    Console.WriteLine($"The number of names starting with 'A':  {aIndexes.Count()}");
    Console.WriteLine($"The number of names starting with 'B':  {bIndexes.Count()}");
    Console.WriteLine($"The number of names starting with 'C':  {cIndexes.Count()}");
    Console.WriteLine($"The number of names starting with 'D':  {dIndexes.Count()}");

    Console.WriteLine();

    Console.WriteLine("'A' Names:");
    foreach(int index in aIndexes) {
      Console.WriteLine($"{names[index]}");
    }

    Console.WriteLine();

    Console.WriteLine("'B' Names:");
    foreach(int index in bIndexes) {
      Console.WriteLine($"{index}");
    }

    Console.WriteLine();

    Console.WriteLine("'C' Names:");
    foreach(int index in cIndexes) {
      Console.WriteLine($"{index}");
    }

    Console.WriteLine();

    Console.WriteLine("'D' Names:");
    foreach(int index in dIndexes) {
      Console.WriteLine($"{index}");
    }
  }
}
```
*Output:*
```
The number of names starting with 'A':  2
The number of names starting with 'B':  1
The number of names starting with 'C':  1
The number of names starting with 'D':  0

'A' Names:
Abigail
Ava

'B' Names:
Benjamin

'C' Names:
Charlotte

'D' Names:
```