using ProtoBuf;

namespace DeepCopy.ProtoBuf.ProtoBufClasses
{
    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public int Id { get; }
        [ProtoMember(2)]
        public string Name { get; }
        [ProtoMember(3)]
        public Address Address { get; }

        public Person()
        {
            Name = string.Empty;
            Address = new Address();
        }

        public Person(int id, string name, Address address)
        {
            Id = id;
            Name = name ?? string.Empty;
            Address = address ?? new Address();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Person p) return false;

            if (ReferenceEquals(p, this)) return true;

            return (Id == p.Id && Name == p.Name && Address.Equals(p.Address));

        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
