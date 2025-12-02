using System.Diagnostics.Metrics;

namespace q_7
{
    struct PointStruct
    {
        public int X;
        public int Y;
    }
    static class Overflow
    {
        static int counter = 0;
       public static void Recursion()
        {
            int[] arr = new int[50];
            PointStruct p1, p2, p3, p9;
            PointStruct p5, p6, p4, p0; 
            counter++;
            if (counter % 100 == 0)
                Console.WriteLine($"counter={counter}");
            Console.WriteLine($"counter={counter}");
            Recursion();
        }
    }
    class Program
    {
        static void Main()
        {
            Overflow.Recursion();
        }
    }
}