using NUnit.Framework;
using DeepCopy;

namespace DeepCopyTests
{
    [TestFixture]
    public class Tests
    {

        public class ValueContainer<T>
        {
            public T Value { get; set; }
        }

        [Test]
        public void Clone_int()
        {
            int i = 1.Copy();

            Assert.That(i, Is.EqualTo(1));
        }

        [Test]
        public void Clone_string()
        {
            string test = "test";
            string s = test.Copy();

            Assert.That(s, Is.EqualTo("test"));
        }

        [Test]
        public void Clone_string_array()
        {
            string[] test = { "apple", "banana", "pear" };
            string[] a = test.Copy();

            CollectionAssert.AreEqual(a, test);
            Assert.That(!ReferenceEquals(a, test));
        }

        [Test]
        public void Clone_ValueContainer()
        {
            var vci = new ValueContainer<int>() { Value = 1 };
            var vciCopy = vci.Copy();

            Assert.That(!ReferenceEquals(vci, vciCopy));
            Assert.That(vciCopy, Has.Property("Value").EqualTo(vci.Value));
        }
    }
}