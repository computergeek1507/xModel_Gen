using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xModel_Gen.Tests
{
    [TestFixture]
    public class Node_Test
    {
        [Test]
        public void Node_Create()
        {
            Node newNode = new Node
            {
                GridX = 1,
                GridY = 2
            };
            Assert.AreEqual(1, newNode.GridX);
            Assert.AreEqual(2, newNode.GridY);
            Assert.AreEqual(0, newNode.NodeNumber);
            Assert.IsFalse( newNode.IsWired);
        }

        [Test]
        public void Node_SetWiring()
        {
            Node newNode = new Node();
            newNode.NodeNumber = 8;
            Assert.AreEqual(8, newNode.NodeNumber);
            Assert.IsTrue(newNode.IsWired);
        }

        [Test]
        public void Node_ClearWiring()
        {
            Node newNode = new Node();
            newNode.NodeNumber = 8;
            Assert.IsTrue(newNode.IsWired);
            newNode.ClearWiring();
            Assert.IsFalse(newNode.IsWired);
        }

        [Test]
        public void Node_ToString()
        {
            Node newNode = new Node
            {
                GridX = 1,
                GridY = 2
            };
            newNode.NodeNumber = 8;
            Assert.AreEqual("1,2,8", newNode.ToString());
        }
    }
}
