using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NemCore.Extensions;

namespace UnitTestNemCore {
  [TestClass]
  public class IEnumerableExtensionTests {
    [TestMethod]
    public void TestIndexesOf() {
      List<string> names = new List<string>() {
        "Abigail",  //0
        "Ava",      //1
        "Benjamin", //2
        "Charlotte",//3
        "Elijah",   //4
        "Emily",    //5
        "Emma",     //6
        "Ethan",    //7
        "Harper",   //8
        "Isabella", //9
        "Jacob",    //10
        "James",    //11
        "Liam",     //12
        "Mason",    //13
        "Mia",      //14
        "Michael",  //15
        "Noah",     //16
        "Olivia",   //17
        "Sophia",   //18
        "William"   //19
      };

      IEnumerable<int> aIndexes = names.IndexesOf(name => name.StartsWith("A"));
      IEnumerable<int> bIndexes = names.IndexesOf(name => name.StartsWith("B"));
      IEnumerable<int> cIndexes = names.IndexesOf(name => name.StartsWith("C"));
      IEnumerable<int> dIndexes = names.IndexesOf(name => name.StartsWith("D"));
      IEnumerable<int> eIndexes = names.IndexesOf(name => name.StartsWith("E"));
      IEnumerable<int> hIndexes = names.IndexesOf(name => name.StartsWith("H"));
      IEnumerable<int> iIndexes = names.IndexesOf(name => name.StartsWith("I"));
      IEnumerable<int> jIndexes = names.IndexesOf(name => name.StartsWith("J"));
      IEnumerable<int> lIndexes = names.IndexesOf(name => name.StartsWith("L"));
      IEnumerable<int> mIndexes = names.IndexesOf(name => name.StartsWith("M"));
      IEnumerable<int> nIndexes = names.IndexesOf(name => name.StartsWith("N"));
      IEnumerable<int> oIndexes = names.IndexesOf(name => name.StartsWith("O"));
      IEnumerable<int> sIndexes = names.IndexesOf(name => name.StartsWith("S"));
      IEnumerable<int> wIndexes = names.IndexesOf(name => name.StartsWith("W"));

      Assert.IsTrue(aIndexes.Count() == 2 && aIndexes.Contains(0) && aIndexes.Contains(1));
      Assert.IsTrue(bIndexes.Count() == 1 && bIndexes.Contains(2));
      Assert.IsTrue(cIndexes.Count() == 1 && cIndexes.Contains(3));
      Assert.IsTrue(dIndexes.Count() == 0);
      Assert.IsTrue(eIndexes.Count() == 4 && eIndexes.Contains(4) && eIndexes.Contains(5) && eIndexes.Contains(6) && eIndexes.Contains(7));
      Assert.IsTrue(hIndexes.Count() == 1 && hIndexes.Contains(8));
      Assert.IsTrue(iIndexes.Count() == 1 && iIndexes.Contains(9));
      Assert.IsTrue(jIndexes.Count() == 2 && jIndexes.Contains(10) && jIndexes.Contains(11));
      Assert.IsTrue(lIndexes.Count() == 1 && lIndexes.Contains(12));
      Assert.IsTrue(mIndexes.Count() == 3 && mIndexes.Contains(13) && mIndexes.Contains(14) && mIndexes.Contains(15));
      Assert.IsTrue(nIndexes.Count() == 1 && nIndexes.Contains(16));
      Assert.IsTrue(oIndexes.Count() == 1 && oIndexes.Contains(17));
      Assert.IsTrue(sIndexes.Count() == 1 && sIndexes.Contains(18));
      Assert.IsTrue(wIndexes.Count() == 1 && wIndexes.Contains(19));
    }
  }
}
