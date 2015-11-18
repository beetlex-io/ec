using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
namespace EC.Remoting
{
    class ProxyBuilder
    {
        public ProxyBuilder(Type type)
        {
            mClassName = type.Name + "_impl";
            mInterfaceType = type;
            BuilderClass();
        }

        private Type mInterfaceType;

        private StringBuilder mCode = new StringBuilder();

        private string mClassName;

        private Script.ScriptFactory mScriptFactory = new Script.ScriptFactory();

        private void BuilderClass()
        {
            mCode.AppendLine("using System;");
            mCode.AppendLine("using EC.Remoting;");
            mCode.AppendLine("using EC.Clients;");
            mCode.AppendFormat("public class {0}:{1},ICommunicationObject\r\n", mClassName, mInterfaceType.FullName);
            mCode.AppendLine("{");
            mCode.AppendLine("public IClient Client { get; set; }");
           
            foreach (System.Reflection.MethodInfo method in mInterfaceType.GetMethods())
            {
                BuilderMethod(method);
            }
            mCode.AppendLine("}");
            mScriptFactory.LoadCSCode(mCode.ToString());
        }

        private string GetTypeName(Type type)
        {
            if (type.HasElementType)
                type = type.GetElementType();
            if (type.IsGenericType)
            {
                Type[] gtypes = type.GetGenericArguments();
                string name = type.Namespace + "." + type.Name.Substring(0,type.Name.IndexOf('`')) + "<";
                for (int i = 0; i < gtypes.Length; i++)
                {
                    if (i > 0)
                        name += ",";
                    name += gtypes[0].FullName;
                }
                name += "> ";
                return name;
            }
            else
            {
                return type.Namespace+"."+type.Name;
            }
            
        }

        private void BuilderMethod(System.Reflection.MethodInfo method)
        {
            List<string> ps = new List<string>();
            List<string> tps = new List<string>();
            ParameterInfo[] pis = method.GetParameters();
            foreach (ParameterInfo pi in method.GetParameters())
            {
                tps.Add(pi.Name);
                string pt = "";
               if (pi.IsRetval)
                    pt = "ref";
                if (pi.IsOut)
                    pt = "out";
                ps.Add(string.Format(" {0} {1} {2}", pt, GetTypeName(pi.ParameterType), pi.Name));
            }
            mCode.AppendFormat("public {0} {1}({2})\r\n", method.ReturnType.FullName == "System.Void" ? "void" :GetTypeName( method.ReturnType),
                method.Name, ps.Count == 0 ? "" : string.Join(",", ps.ToArray()));
            mCode.AppendLine("{");
            foreach (ParameterInfo pi in method.GetParameters())
            {
                if (pi.IsOut)
                    mCode.AppendFormat("{0}=default({1});\r\n", pi.Name,  GetTypeName( pi.ParameterType));
            }
            mCode.AppendFormat("Result result = ProxyFactory.CursorFactory.Execute(this,\"{1}\",System.Reflection.MethodInfo.GetCurrentMethod(),{0});",
                tps.Count == 0 ? "new object[0]" : string.Join(",", tps.ToArray()),mInterfaceType.Name);
            for (int i = 0; i < ps.Count; i++)
            {
                if (ps[i].IndexOf("ref") >= 0 || ps[i].IndexOf("out")>=0)
                {
                    mCode.AppendFormat("{0}=({1})result[\"{0}\"];", tps[i], GetTypeName( pis[i].ParameterType));
                }
            }
            if (method.ReturnType.FullName != "System.Void")
            {
                mCode.AppendFormat("return ({0})result.Data;\r\n",GetTypeName( method.ReturnType));
            }
            mCode.AppendLine("}");
        }

        public object CreateInstance()
        {
           return mScriptFactory.CreateInstance(mClassName);
        }
    }
}
