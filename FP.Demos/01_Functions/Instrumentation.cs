using System;
using System.Diagnostics;

namespace FP.Demos._01_Functions
{
    public static class Instrumentation
    {
        public static T Time<T>(string operation, Func<T> f)
        {
            var sw = new Stopwatch();
            sw.Start();

            T result = f();

            sw.Stop();

            LogTime(operation, sw);

            return result;
        }

        public static void Time(string operation, Action f)
        {
            var sw = new Stopwatch();
            sw.Start();

            f();

            sw.Stop();

            LogTime(operation, sw);
        }

        private static void LogTime(string operation, Stopwatch sw) 
            => Console.WriteLine($"\n{operation} took {sw.Elapsed}");
    }
}
