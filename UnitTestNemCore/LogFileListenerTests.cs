using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using NemCore;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestNemCore {
  [TestClass]
  public class LogFileListenerTests {
    [TestMethod]
    public void UnitTest_LogFileListenerOneLineNoDate() {
      LogFileListener logListener = new LogFileListener(@"C:\Temp\TestLog.log", false);

      Trace.Listeners.Add(logListener);
      Trace.IndentLevel = 0;

      Trace.WriteLine("This is a test.");

      Trace.Listeners.Clear();
      logListener.Dispose();

      List<string> lines = File.ReadAllLines(@"C:\Temp\TestLog.log").ToList();

      Assert.IsTrue(lines.Count == 1);
      Assert.IsTrue(lines.Contains("This is a test."));
    }

    [TestMethod]
    public void UnitTest_LogFileListenerOneLineWithDate() {
      LogFileListener logListener = new LogFileListener(@"C:\Temp\TestLog.log");

      Trace.Listeners.Add(logListener);
      Trace.IndentLevel = 0;

      Trace.WriteLine("This is a test.");

      Trace.Listeners.Clear();
      logListener.Dispose();

      List<string> lines = File.ReadAllLines(@"C:\Temp\TestLog.log").ToList();

      Assert.IsTrue(lines.Count == 1);

      string firstLine = lines.FirstOrDefault();
      string datePart = firstLine.Split('-').First().Trim();
      string msgPart = firstLine.Split('-').Last().Trim();

      DateTime dateTime;
      bool isDate = DateTime.TryParse(datePart, out dateTime);

      Assert.IsTrue(isDate);

      Assert.IsTrue(msgPart == "This is a test.");
    }

    [TestMethod]
    public void UnitTest_LogFileListenerMultiLineNoDateIndents() {
      LogFileListener logListener = new LogFileListener(@"C:\Temp\TestLog.log", false);

      Trace.Listeners.Add(logListener);
      Trace.IndentLevel = 1;

      Trace.WriteLine("This is a test.");
      Trace.WriteLine("This is another test.");

      Trace.Listeners.Clear();
      logListener.Dispose();

      List<string> lines = File.ReadAllLines(@"C:\Temp\TestLog.log").ToList();

      Assert.IsTrue(lines.Count == 2);
      Assert.IsTrue(lines.Contains("    This is a test."));
      Assert.IsTrue(lines.Contains("    This is another test."));
    }

    [TestMethod]
    public void UnitTest_LogFileListenerMultiWriteSingleLineNoDate() {
      LogFileListener logListener = new LogFileListener(@"C:\Temp\TestLog.log", false);

      Trace.Listeners.Add(logListener);
      Trace.IndentLevel = 0;

      Trace.Write("1 ");
      Trace.Write("2");

      Trace.Listeners.Clear();
      logListener.Dispose();

      List<string> lines = File.ReadAllLines(@"C:\Temp\TestLog.log").ToList();

      Assert.IsTrue(lines.Count == 1, $"line count: {lines.Count}");
      Assert.IsTrue(lines.Contains("1 2"), $"line: {lines.First().Replace(" ", "|")}");
    }

    [TestMethod]
    public void UnitTest_LogFileWhenLocked() {
      FileStream fileStream1 = new FileStream(@"C:\Temp\TestLog.log", FileMode.Create);
      fileStream1.Lock(0, 0);
      FileStream fileStream2 = new FileStream(@"C:\Temp\TestLog_2.log", FileMode.Create);
      fileStream2.Lock(0, 0);

      LogFileListener logListener = new LogFileListener(@"C:\Temp\TestLog.log", false);

      logListener.WriteLine("This is a test.");
      logListener.Dispose();

      fileStream1.Unlock(0, 0);
      fileStream2.Unlock(0, 0);

      List<string> lines = File.ReadAllLines(@"C:\Temp\TestLog_3.log").ToList();

      Assert.IsTrue(lines.Count == 1, $"line count: {lines.Count}");
      Assert.IsTrue(lines.Contains("This is a test."), $"line: {lines.First()}");
    }

    [TestMethod]
    public void UnitTest_LogFileListenerOneLineNoDateDefaultLocation() {
      LogFileListener logListener = new LogFileListener(includeDateTime: false);
      string logFilename = logListener.LogFilename;

      Trace.Listeners.Add(logListener);
      Trace.IndentLevel = 0;

      Trace.WriteLine("This is a test.");

      Trace.Listeners.Clear();
      logListener.Dispose();

      List<string> lines = File.ReadAllLines(logFilename).ToList();

      Assert.IsTrue(lines.Count == 1);
      Assert.IsTrue(lines.Contains("This is a test."));
    }
  }
}
