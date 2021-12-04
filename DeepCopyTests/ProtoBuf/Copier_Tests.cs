using NUnit.Framework;
using DeepCopy.ProtoBuf;
using DeepCopy.ProtoBuf.ProtoBufClasses;

namespace DeepCopyTests.ProtoBuf
{
    [TestFixture]
    public class Tests
    {        
        [Test]
        public void Clone_Person()
        {
            var address = new Address("Flat 1", "The Meadows");
            var person = new Person(12345, "Fred", address);
            var personCopy = person.Copy();

            Assert.That(!ReferenceEquals(person, personCopy));
            Assert.That(personCopy, Is.EqualTo(person));
        }
    }
}