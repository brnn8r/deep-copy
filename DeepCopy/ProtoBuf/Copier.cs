using ProtoBuf;
using System.IO;

namespace DeepCopy.ProtoBuf
{
    public static class Copier
    {
        public static T Copy<T>(this T t)
        {
            

            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, t);

                stream.Seek(0,SeekOrigin.Begin);

                return Serializer.Deserialize<T>(stream);
            }
        }
    }
}
