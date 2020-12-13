using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xModel_Gen.Tests
{
    [TestFixture]
    class AutoSort_Test
    {
        private void ProgressSizeUpdated(object sender, int e)
        {
        }

        private void ProgressUpdated(object sender, ProgressEventArgs e)
        {
        }

        [Test]
        public void AutoSort_Run()
        {
            Model test = new Model();
            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            var newNode2 = new Node
            {
                GridX = 4,
                GridY = 4
            };
            test.AddNode(newNode2);
            AutoSort sort = new AutoSort(test, 5);
            sort.ListSizeSent += ProgressSizeUpdated;
            sort.ProgressSent += ProgressUpdated;

            //get starting position
            var x = 1;
            var y = 1;

            sort.WireModel(x, y);
            bool worked = sort.GetWorked();

            Assert.IsTrue(worked);
            Assert.AreEqual(2, sort.GetIndexes().Count());
        }
    }
}
