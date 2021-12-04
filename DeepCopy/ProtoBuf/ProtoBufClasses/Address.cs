using ProtoBuf;

namespace DeepCopy.ProtoBuf.ProtoBufClasses
{
    [ProtoContract]
    public class Address
    {
        [ProtoMember(1)]
        public string Line1 { get; }
        [ProtoMember(2)]
        public string Line2 { get; }

        public Address()
        {
            Line1 = string.Empty;
            Line2 = string.Empty;
        }

        public Address(string line1 = "", string line2 ="")
        {
            Line1 = line1;
            Line2 = line2;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Address a) return false;

            if (ReferenceEquals(a, this)) return true;

            return (Line1 == a.Line1 && Line2 == a.Line2);

        }

        public override int GetHashCode()
        {
            return Line1.GetHashCode() ^ Line2.GetHashCode();
        }
    }
}
