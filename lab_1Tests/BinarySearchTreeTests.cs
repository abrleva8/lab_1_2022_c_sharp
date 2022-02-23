using Microsoft.VisualStudio.TestTools.UnitTesting;
using lab_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1.Tests {
    [TestClass()]
    public class BinarySearchTreeTests {
        [TestMethod()]
        public void InsertTest() {
            List<int> list = new List<int>() { 2, 4, 5, 3, 1, 6, -1 };
            List<int> exceptedOrder = new List<int>() { -1, 1, 2, 3, 4, 5, 6 };
            BinarySearchTree<int> realBST = new BinarySearchTree<int>(list);
            List<int> orderDetour = realBST.OrderDetour(realBST.Root);
            CollectionAssert.AreEqual(exceptedOrder, orderDetour);
        }

        [TestMethod()]
        public void RemoveTest() {
            List<int> list = new List<int>() { 2, 4, 5, 3, 1, 6, -1 };
            List<int> exceptedOrder = new List<int>() { -1, 1, 3, 4, 5, 6 };
            BinarySearchTree<int> realBST = new BinarySearchTree<int>(list);
            realBST.Remove(2);
            List<int> orderDetour = realBST.OrderDetour(realBST.Root);
            
            CollectionAssert.AreEqual(exceptedOrder, orderDetour);
        }
    }
}