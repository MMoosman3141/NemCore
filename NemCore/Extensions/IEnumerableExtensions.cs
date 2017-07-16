using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemCore.Extensions {
  /// <summary>
  /// A number of useful extensions for IEnumerable objects.
  /// </summary>
  public static class IEnumerableExtensions {
    /// <summary>
    /// Extension for IEnumerable objects.
    /// Returns an IEnumerable of all indexes where the predicate conditions are met.
    /// </summary>
    /// <typeparam name="T">The type of object stored in the IEnumerable to be searched</typeparam>
    /// <param name="source">IEnumerable of T which will be searched.</param>
    /// <param name="predicate">A Predicate which defines the parameters which should be searched for.</param>
    /// <returns>An IEnumerable of indexes where the predicate conditions were met.</returns>
    public static IEnumerable<int> IndexesOf<T>(this IEnumerable<T> source, Predicate<T> predicate) {
      int searchPoint = 0;

      int index;
      while((index = source.ToList().FindIndex(searchPoint, predicate)) > -1) {
        yield return index;

        searchPoint = index + 1;
      }
    }
  }
}
