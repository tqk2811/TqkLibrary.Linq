using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class RandomTest
    {
        [TestMethod]
        public async Task GetRandomItemTestAsync()
        {
            var items = Enumerable.Range(0, 10).ToList();

            var item0 = items.GetRandomItem();
            var item1 = items.GetRandomItem();

            Assert.AreNotEqual(item0, item1);
            await Task.Delay(100);
            var item2 = items.GetRandomItem();

            Assert.AreNotEqual(item2, item1);

        }
    }
}
