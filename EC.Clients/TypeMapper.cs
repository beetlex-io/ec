using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC.Implement
{
    class TypeMapper
    {
        Dictionary<short, Type> mTypes = new Dictionary<short, Type>(2048);

        Dictionary<Type, short> mValues = new Dictionary<Type, short>(2048);

        public TypeMapper()
        {
            Register<byte>(-0x7f01);
            Register<byte[]>(-0x7f02);
            Register<List<byte>>(-0x7f03);

            Register<short>(-0x7f04);
            Register<short[]>(-0x7f05);
            Register<List<short>>(-0x7f06);

            Register<int>(-0x7f07);
            Register<int[]>(-0x7f08);
            Register<List<int>>(-0x7f09);

            Register<long>(-0x7f0a);
            Register<long[]>(-0x7f0b);
            Register<List<long>>(-0x7f0c);

            Register<float>(-0x7f0d);
            Register<float[]>(-0x7f0e);
            Register<List<float>>(-0x7f0f);

            Register<double>(-0x7f11);
            Register<double[]>(-0x7f12);
            Register<List<double>>(-0x7f13);

            Register<string>(-0x7f14);
            Register<string[]>(-0x7f15);
            Register<List<string>>(-0x7f16);

            Register<char>(-0x7f17);
            Register<char[]>(-0x7f18);
            Register<List<char>>(-0x7f19);


            Register<DateTime>(-0x7f1a);
            Register<DateTime[]>(-0x7f1b);
            Register<List<DateTime>>(-0x7f1c);

            Register<Remoting.RPC.MethodCall>(-0x7f1d);
            Register<Remoting.RPC.MethodResult>(-0x7f1e);
        }

        public void Register(short value, Type type)
        {
            mValues[type] = value;
            mTypes[value] = type;
        }
        public void Register<T>(short value)
        {
            mValues[typeof(T)] = value;
            mTypes[value] = typeof(T);
        }
        public short GetValue(object obj)
        {
            return GetValue(obj.GetType());
        }
        public short GetValue(Type type)
        {
            short result = 0;
            mValues.TryGetValue(type, out result);
            return result;
        }
        public Type GetType(short value)
        {
            Type result = null;
            mTypes.TryGetValue(value, out result);
            return result;
        }
    }
}
