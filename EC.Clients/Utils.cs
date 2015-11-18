using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EC.Import;
namespace EC
{
    class Utils
    {
        static Utils()
        {
            
        }

        private static List<System.Reflection.Assembly> mAssemblies =null;

        public static void LoadAssembly(Action<System.Reflection.Assembly> handler)
        {
            if (mAssemblies == null)
            {
                mAssemblies = new List<System.Reflection.Assembly>();
                foreach (string dll in System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll"))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(dll);
                    try
                    {
                        mAssemblies.Add(System.Reflection.Assembly.LoadFile(dll));
                        
                    }
                    catch (Exception e_)
                    {
                       
                    }
                }
                foreach (string dll in System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.exe"))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(dll);
                    try
                    {
                        mAssemblies.Add(System.Reflection.Assembly.LoadFile(dll));
                       
                    }
                    catch (Exception e_)
                    {
                       
                    }
                }
            }
            foreach (System.Reflection.Assembly a in mAssemblies)
            {
                handler(a);
            }
        }


        private static Implement.TypeMapper mTypeMapper = null;

        public static Implement.TypeMapper GetMessageMapping()
        {
            if (mTypeMapper == null)
            {
                mTypeMapper = new Implement.TypeMapper();

                LoadAssembly(a =>
                {
                    foreach (Type type in a.GetTypes())
                    {
                        MessageIDAttribute[] msgid = IKendeCore.GetTypeAttributes<MessageIDAttribute>(type, false);
                        if (msgid.Length > 0)
                        {
                            
                            mTypeMapper.Register(msgid[0].ID, type);
                            Type lstType = Type.GetType("System.Collections.Generic.List`1");
                            if (lstType != null)
                            {
                                Type gLstType = lstType.MakeGenericType(type);
                                mTypeMapper.Register((short)(0 - msgid[0].ID), gLstType);
                            }
                            
                        }
                        foreach (TypeMappingAttribute tm in IKendeCore.GetTypeAttributes<TypeMappingAttribute>(type, false))
                        {
                            mTypeMapper.Register(tm.MessageID, tm.Type);
                        }
                    }
                });
            }
            return mTypeMapper;
        }

    }
    public static class StringExtensions
    {

       
        public static void ThrowError<E>(this string str, Exception innerError = null) where E : Exception
        {
            Exception error;
            if (innerError == null)
                error = (Exception)Activator.CreateInstance(typeof(E), str);
            else
                error = (Exception)Activator.CreateInstance(typeof(E), str, innerError);
            throw error;

        }

        public static void ThrowError<E>(this string str, params object[] parameters) where E : Exception
        {
            ThrowError<E>(string.Format(str, parameters));
        }

        public static void ThrowError<E>(this string str, Exception innerError = null, params object[] parameters) where E : Exception
        {
            ThrowError<E>(string.Format(str, parameters), innerError);
        }
    }
}
