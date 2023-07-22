namespace UnitTest
{
    static class MyMath
    {
        public static int Factorial(int num)
        {
            if (num <= 0) throw new InvalidOperationException();
            if (num == 1) return num;
            return Enumerable.Range(2, num - 1).Multiplication();
        }
    }
}