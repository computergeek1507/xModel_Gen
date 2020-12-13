using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xModel_Gen;
using System.Windows.Forms;

namespace xModel_Gen.Tests
{
    [TestFixture]
    public class Model_Test
    {
        [Test]
        public void Model_Create()
        {
            Model test = new Model();
            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            Assert.AreEqual(1,test.GetNodeCount());
        }

        [Test]
        public void Model_AddedDup()
        {
            Model test = new Model();
            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            test.AddNode(newNode);
            Assert.AreEqual(1, test.GetNodeCount());
        }

        [Test]
        public void Model_AddTwo()
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
                GridX = 2,
                GridY = 2
            };
            test.AddNode(newNode2);
            Assert.AreEqual(2, test.GetNodeCount());
        }

        [Test]
        public void Model_Count()
        {
            Model test = new Model();
            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            Assert.AreEqual(test.GetNodes().Count(), test.GetNodeCount());
        }

        [Test]
        public void Model_Name()
        {
            Model test = new Model();
            test.Name = "TEST";
            Assert.AreEqual("TEST", test.Name);
        }

        [Test]
        public void Model_SizeX()
        {
            Model test = new Model();
            test.SizeX = 10;
            Assert.AreEqual(10, test.SizeX);
        }

        [Test]
        public void Model_SizeY()
        {
            Model test = new Model();
            test.SizeY = 10;
            Assert.AreEqual(10, test.SizeY);
        }


        [Test]
        public void Model_GetNode()
        {
            Model test = new Model();
            Assert.That(test.GetNode(1), Is.Null);

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            Assert.That(test.GetNode(0), Is.Not.Null);
        }

        [Test]
        public void Model_FindNode()
        {
            Model test = new Model();
            Assert.That(test.FindNode(1,1), Is.Null);

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            Assert.That(test.FindNode(1, 1), Is.Not.Null);
        }
        [Test]
        public void Model_FindNodeIndex()
        {
            Model test = new Model();
            Assert.AreEqual(-1, test.FindNodeIndex(1, 1));

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            Assert.AreEqual(0, test.FindNodeIndex(1, 1));
        }

        [Test]
        public void Model_DeleteNode()
        {
            Model test = new Model();

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            test.DeleteNode(0, 0);
            Assert.AreEqual(1, test.GetNodeCount());
            test.DeleteNode(1, 1);
            Assert.AreEqual(0, test.GetNodeCount());
        }

        [Test]
        public void Model_SetNodeNumber()
        {
            Model test = new Model();

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1
            };
            test.AddNode(newNode);
            test.SetNodeNumber(1, 1, 10);

            Assert.AreEqual(10, test.GetNode(0).NodeNumber);
            test.SetNodeNumber(0, 0, 1);
            Assert.AreEqual(10, test.GetNode(0).NodeNumber);
        }

        [Test]
        public void Model_SetNodeNumber2()
        {
            Model test = new Model();

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1,
                NodeNumber = 0
            };
            test.AddNode(newNode);
            test.SetNodeNumber(0, 10);

            Assert.AreEqual(10, test.GetNode(0).NodeNumber);
            test.SetNodeNumber(10, 1);
            Assert.AreEqual(10, test.GetNode(0).NodeNumber);
        }

        [Test]
        public void Model_ClearWiring()
        {
            Model test = new Model();

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1,
                NodeNumber = 10
            };
            test.AddNode(newNode);
            Assert.AreEqual(10, test.GetNode(0).NodeNumber);
            test.ClearWiring();
            Assert.AreEqual(0, test.GetNode(0).NodeNumber);
        }

        [Test]
        public void Model_Sort()
        {
            Model test = new Model();

            var newNode = new Node
            {
                GridX = 1,
                GridY = 1,
                NodeNumber = 10
            };
            test.AddNode(newNode);
            var newNode2 = new Node
            {
                GridX = 2,
                GridY = 2,
                NodeNumber = 2
            };
            test.AddNode(newNode2);
            Assert.AreEqual(10, test.GetNode(0).NodeNumber);
            test.SortNodes();
            Assert.AreEqual(2, test.GetNode(0).NodeNumber);
        }
    }
}
