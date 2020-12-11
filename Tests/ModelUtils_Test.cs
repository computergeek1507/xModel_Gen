using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xModel_Gen.Tests
{
    [TestFixture]
    class ModelUtils_Test
    {
        [Test]
        public void ModelUtils_GetDistance()
        {
            double dist = ModelUtils.GetDistance(1, 1, 1, 2);
            Assert.That(dist, Is.EqualTo(1.0).Within(.0005));
        }

        [Test]
        public void ModelUtils_GetDistance2()
        {
            double dist = ModelUtils.GetDistance(1, 1, 2, 1);
            Assert.That(dist, Is.EqualTo(1.0).Within(.0005));
        }

        [Test]
        public void ModelUtils_GetDistance3()
        {
            double dist = ModelUtils.GetDistance(1,1,2,2);
            Assert.That(dist, Is.EqualTo(1.41421).Within(.0005));
        }

        [Test]
        public void ModelUtils_GetDistance4()
        {
            Node node1 = new Node
            {
                GridX = 1,
                GridY = 1
            };

            Node node2 = new Node
            {
                GridX = 2,
                GridY = 2
            };

            double dist = ModelUtils.GetDistance(node1, node2);
            Assert.That(dist, Is.EqualTo(1.41421).Within(.0005));
        }
    }
}
