using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EC
{
    class Utils
    {
        static Utils()
        {
            log4net.Config.XmlConfigurator.Configure();
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
                        "load {0} assembly success".Log4Info(file.Name);
                    }
                    catch (Exception e_)
                    {
                        "load {0} assembly error".Log4Error(e_, file.Name);
                    }
                }
                foreach (string dll in System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.exe"))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(dll);
                    try
                    {
                        mAssemblies.Add(System.Reflection.Assembly.LoadFile(dll));
                        "load {0} assembly success".Log4Info(file.Name);
                    }
                    catch (Exception e_)
                    {
                        "load {0} assembly error".Log4Error(e_, file.Name);
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
                        MessageIDAttribute[] msgid = IKende.IKendeCore.GetTypeAttributes<MessageIDAttribute>(type, false);
                        if (msgid.Length > 0)
                        {
                            mTypeMapper.Register(msgid[0].ID, type);
                            Type lstType = Type.GetType("System.Collections.Generic.List`1");
                            "{0} register to {1}".Log4Info(type, msgid[0].ID);
                            if (lstType != null)
                            {
                                Type gLstType = lstType.MakeGenericType(type);
                                mTypeMapper.Register((short)(0 - msgid[0].ID), gLstType);
                                "{0} register to {1}".Log4Info(gLstType, msgid[0].ID);
                            }
                        }
                        foreach (TypeMappingAttribute tm in IKende.IKendeCore.GetTypeAttributes<TypeMappingAttribute>(type, false))
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

        private static log4net.ILog Log()
        {
            return log4net.LogManager.GetLogger("EC");
        }

        public static void Log4Error(this String str)
        {
            Log().Error(str);

        }



        public static void Log4Fatal(this String str, Exception e)
        {
            Log().Fatal(str, e);
        }

        public static void Log4Fatal(this String str, params object[] parameters)
        {
            Log4Fatal(string.Format(str, parameters));
        }

        public static void Log4Fatal(this String str, Exception e, params object[] parameters)
        {
            Log4Fatal(string.Format(str, parameters), e);
        }

        public static void Log4Error(this String str, Exception e)
        {
            Log().Error(str, e);
        }

        public static void Log4Error(this String str, params object[] parameters)
        {
            Log4Error(string.Format(str, parameters));
        }

        public static void Log4Error(this String str, Exception e, params object[] parameters)
        {
            Log4Error(string.Format(str, parameters), e);
        }

        public static void Log4Info(this string str)
        {
            Log().Info(str);

        }

        public static void Log4Info(this string str, params object[] parameters)
        {
            Log4Info(string.Format(str, parameters));
        }

        public static void Log4Debug(this string str)
        {
            Log().Debug(str);

        }

        public static void Log4Debug(this string str, params object[] parameters)
        {
            Log4Debug(string.Format(str, parameters));
        }

        public static void Log4Warn(this string str)
        {
            Log().Warn(str);

        }

        public static void Log4Warn(this string str, params object[] parameters)
        {
            Log4Warn(string.Format(str, parameters));
        }

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
