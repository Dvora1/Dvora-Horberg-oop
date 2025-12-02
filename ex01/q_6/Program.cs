using System;

namespace q_6
{
    public static class MemoryTools
    {
        public static long MeasureAllocation(Func<object> allocate)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            long before = GC.GetAllocatedBytesForCurrentThread();

            object result = allocate();

            long after = GC.GetAllocatedBytesForCurrentThread();

            return after - before;
        }
    }
    struct MyStruct
    {
        public int X;
        public long Y;
    }
    class MyClass
    {
        public long A; // 8 bytes
        public int B;  // 4 bytes
    }
    class Program
    {
        static void Main()
        {
            int N = 1000;
            long intArrayMemory = MemoryTools.MeasureAllocation(() => new int[N]);
            Console.WriteLine($"Memory for int[{N}] = {intArrayMemory} bytes");

            long doubleArrayMemory = MemoryTools.MeasureAllocation(() => new double[N]);
            Console.WriteLine($"Memory for double[{N}] = {doubleArrayMemory} bytes");

            long stringArrayMemory = MemoryTools.MeasureAllocation(() => new string[N]);
            Console.WriteLine($"Memory for string[{N}] = {stringArrayMemory} bytes");

            long structArrayMemory = MemoryTools.MeasureAllocation(() => new MyStruct[N]);
            Console.WriteLine($"Memory for MyStruct[{N}] = {structArrayMemory} bytes");

            long MyClass = MemoryTools.MeasureAllocation(() => {
                var arr = new MyClass[N];
                for (int i = 0; i < N; i++) arr[i] = new MyClass();
                return arr; });
                Console.WriteLine($"Memory for MyClass[{N}] = {MyClass} bytes");
           
        }
    }
}
