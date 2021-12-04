using System;
using System.Reflection;
using System.Linq;
using System.Runtime.Serialization;

namespace DeepCopy.Naive
{
    public static class Copier
    {

        public static T Copy<T>(this T t)
        {
            Type type = t.GetType();
            
            if(type.IsPrimitiveOrString())
            {
                return t;
            }

            if (!type.IsValueType && t == null)
            {
                return default;
            }

            if (t is Array a)
            {
                return (T)a.ArrayCopy();
            }

            T newT;

            try
            {
                newT = (T)Activator.CreateInstance(type);
            }
            catch(Exception)
            {
                newT = (T)FormatterServices.GetUninitializedObject(type);
            }

            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var field in fields)
            {
                field.SetValue(newT, field.GetValue(t).Copy());
            }           
            
            return newT;
        }

        private static bool IsPrimitiveOrString(this Type t)
        {
            return (t.IsPrimitive || t.IsEnum || t == typeof(string));
        }

        private static object ArrayCopy(this Array a)
        {
            if (a.GetType().GetElementType().IsPrimitiveOrString())
            {
                return a.Clone();
            }
            else
            {
                var newA = (Array)a.Clone();

                for (int i = 0; i < a.Length; i++)
                {
                    newA.SetValue(a.GetValue(i).Copy(), i);
                }

                return newA;
            }
        }
    }
}
