using NUnit.Framework;
using Task03BinarySearchTreee.Tree;

namespace Task03BinarySearchTreeeTest
{
    public class Tests
    {
        [Test]
        public void BinaryTreeTest_Add_Count_Int()
        {
            BinarySearchTree<int> a = new BinarySearchTree<int>();
            a.Add(1);
            a.Add(4);
            a.Add(0);
            a.Add(15);
            a.Add(65);
            a.Add(11);
            a.Add(76);
            a.Add(8);
            a.Add(64);
            Assert.AreEqual(9, a.Count);
            CollectionAssert.AreEqual(new int[] { 0, 1, 4, 8, 11, 15, 64, 65, 76 }, a.InOrder());
            CollectionAssert.AreEqual(new int[] { 0, 8, 11, 64, 76, 65, 15, 4, 1 }, a.PostOrder());
            CollectionAssert.AreEqual(new int[] { 1, 0, 4, 15, 11, 8, 65, 64, 76 }, a.PreOrder());
        }

        [Test]
        public void BinaryTreeTest_Add_Count_IntComparer()
        {
            BinarySearchTree<int> a = new BinarySearchTree<int>(new IntComparer());
            a.Add(1);
            a.Add(4);
            a.Add(0);
            a.Add(15);
            a.Add(65);
            a.Add(11);
            a.Add(76);
            a.Add(8);
            a.Add(64);
            Assert.AreEqual(9, a.Count);
            CollectionAssert.AreEqual(new int[] { 0, 1, 4, 8, 11, 15, 64, 65, 76 }, a.InOrder());
            CollectionAssert.AreEqual(new int[] { 0, 8, 11, 64, 76, 65, 15, 4, 1 }, a.PostOrder());
            CollectionAssert.AreEqual(new int[] { 1, 0, 4, 15, 11, 8, 65, 64, 76 }, a.PreOrder());
        }

        [Test]
        public void BinaryTreeTest_Add_Count_String()
        {
            BinarySearchTree<string> a = new BinarySearchTree<string>();
            a.Add("asafs");
            a.Add("qweqweq");
            a.Add("qwerty");
            a.Add("123");
            a.Add("a");
            Assert.AreEqual(5, a.Count);
            CollectionAssert.AreEqual(new string[] { "123", "a", "asafs", "qweqweq", "qwerty" }, a.InOrder());
            CollectionAssert.AreEqual(new string[] { "a", "123", "qwerty", "qweqweq", "asafs" }, a.PostOrder());
            CollectionAssert.AreEqual(new string[] { "asafs", "123", "a", "qweqweq", "qwerty" }, a.PreOrder());
        }

        [Test]
        public void BinaryTreeTest_Add_Count_StringComparer()
        {
            BinarySearchTree<string> a = new BinarySearchTree<string>(new StringComparer());
            a.Add("asafs");
            a.Add("qweqweq");
            a.Add("qwerty");
            a.Add("123");
            a.Add("a");
            Assert.AreEqual(5, a.Count);
            CollectionAssert.AreEqual(new string[] { "a", "123", "asafs", "qwerty", "qweqweq" }, a.InOrder());
        }

        [Test]
        public void BinaryTreeTest_Add_Count_PointStructComparer()
        {
            BinarySearchTree<PointStruct> a = new BinarySearchTree<PointStruct>(new PointStructComparer());
            a.Add(new PointStruct(1, 2));
            a.Add(new PointStruct(0, 0));
            a.Add(new PointStruct(3, 4));
            a.Add(new PointStruct(4, 5));
            a.Add(new PointStruct(2, 3));
            Assert.AreEqual(5, a.Count);
            CollectionAssert.AreEqual(new PointStruct[] { new PointStruct(0, 0), new PointStruct(1, 2), new PointStruct(2, 3), new PointStruct(3, 4), new PointStruct(4, 5) }, a.InOrder());
        }

        [Test]
        public void BinaryTreeTest_Add_Count_Book()
        {
            BinarySearchTree<Book> a = new BinarySearchTree<Book>();
            a.Add(new Book("1", 1));
            a.Add(new Book("2", 2));
            a.Add(new Book("11", 4));
            a.Add(new Book("123", 5));
            a.Add(new Book("321", 3));
            Assert.AreEqual(5, a.Count);
            CollectionAssert.AreEqual(new Book[] { new Book("1", 1), new Book("2", 2), new Book("321", 3), new Book("11", 4), new Book("123", 5) }, a.InOrder());
        }

        [Test]
        public void BinaryTreeTest_Add_Count_BookComparer()
        {
            BinarySearchTree<Book> a = new BinarySearchTree<Book>(new BookComparer());
            a.Add(new Book("1123", 1));
            a.Add(new Book("2", 2));
            a.Add(new Book("11", 4));
            a.Add(new Book("1235555", 5));
            a.Add(new Book("", 3));
            Assert.AreEqual(5, a.Count);
            CollectionAssert.AreEqual(new Book[] { new Book("", 3), new Book("2", 2), new Book("11", 4), new Book("1123", 1), new Book("1235555", 5) }, a.InOrder());
        }
    }
}