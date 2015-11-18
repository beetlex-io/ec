using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EC.Remoting.Script
{
    class ScriptFactory
    {
        private AssemblyLoader mLoader = new AssemblyLoader();

        public ScriptFactory()
        {

            mLoader.LoadAssembly(System.AppDomain.CurrentDomain.BaseDirectory);
         
        }

       
        public void LoadCSFile(params string[] files)
        {
            foreach (string file in files)
            {
                mLoader.LoadCS(file);
            }
        }

        public void LoadVBFile(params string[] files)
        {
            foreach (string file in files)
            {
                mLoader.LoadVB(file);
            }
        }

        public Assembly LoadCSCode(params string[] sourceCode)
        {
           return mLoader.FromSourceCode(".cs", sourceCode);
        }

        public Assembly LoadVBCode(params string[] sourceCode)
        {
           return mLoader.FromSourceCode(".vb", sourceCode);
        }
        
        public Type GetTypeWithName(string typeName)
        {
            foreach (System.Reflection.Assembly item in mLoader.ComplierAssemblies)
            {
               Type type = item.GetType(typeName);
               if (type != null)
                   return type;
            }
            return null;
        }

        public object CreateInstance(string typeName)
        {
            Type type = GetTypeWithName(typeName);
          
            if (type != null)
                return Activator.CreateInstance(type);
            return null;
        }

        public object Invoke(string method,params object[] parameters)
        {
            object result = null;
            string[] info = method.Split(new char[]{ ':'}, StringSplitOptions.RemoveEmptyEntries);
            Type type = GetTypeWithName(info[0]);
            if (type == null)
                throw new Exception(info[0] + " type notfound!");
            Type[] ptype;
            if (parameters != null && parameters.Length > 0)
            {
                ptype = new Type[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    ptype[i] = parameters[i].GetType();
                }
            }
            else
            {
                ptype = new Type[0];
            }
            MethodInfo invoker = type.GetMethod(info[1], ptype);
            if (invoker == null)
                invoker = type.GetMethod(info[1], BindingFlags.NonPublic | BindingFlags.Instance| BindingFlags.Static| BindingFlags.Public);
            if(invoker ==null)
                throw new Exception(string.Format("{0} type's {1} notfound!",info[0],info[1]));
            if (invoker.IsStatic)
            {
                invoker.Invoke(null, parameters);
            }
            else
            {
                return invoker.Invoke(Activator.CreateInstance(type), parameters);
            }
            return result;
        }
    }
}
