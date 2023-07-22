namespace UnitTest
{
    [TestClass]
    public class CombinationsPermutationsTest
    {
        static readonly int[] sources = new int[] { 0, 1, 2, 3 };

        [TestMethod]
        public void TestCombinations()
        {
            int k = 3;
            int count = MyMath.Factorial(sources.Length) / (MyMath.Factorial(k) * MyMath.Factorial(sources.Length - k));// 4! / (3! * (4-3)!)

            var result = sources.Combinations(k);
            Assert.AreEqual(result.Count(), count);
            foreach (var line in result)
            {
                Console.WriteLine(string.Join(", ", line));
                Assert.AreEqual(line.Count(), k);
                Assert.IsTrue(result.Except(line).Any(x => x.Except(line).Count() > 0));
            }
        }



        [TestMethod]
        public void TestPermutations()
        {
            int k = 3;
            int count = MyMath.Factorial(sources.Length) / MyMath.Factorial(sources.Length - k);// 4! / (4-3)! = 24 / 1 = 24

            var result = sources.Permutations(k);
            Assert.AreEqual(result.Count(), count);
            foreach (var line in result)
            {
                Console.WriteLine(string.Join(", ", line));
                Assert.AreEqual(line.Count(), k);

                Assert.IsTrue(result.Except(line).Any(x => x.Intersect(line).Count() < k));
            }
        }
    }
}