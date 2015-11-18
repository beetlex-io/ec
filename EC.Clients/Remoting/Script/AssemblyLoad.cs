using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EC.Remoting.Script
{
    class FileCompiler
    {
        private CompilerErrorCollection compilerErrors = null;

        public Assembly CreateAssembly(string filename)
        {
            return CreateAssembly(filename, new ArrayList());
        }
        public Assembly CreateAssemblyFromSourceCode(string extension, params string[] sourcecode)
        {
            return CreateAssemblyFromSourceCode(extension, new ArrayList(), sourcecode);
        }
        public Assembly CreateAssemblyFromSourceCode(string extension, IList references, params string[] sourcecode)
        {
            compilerErrors = null;


            CodeDomProvider codeProvider = null;
            switch (extension.ToLower())
            {
                case ".cs":
                    codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
                case ".vb":
                    codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
                default:
                    throw new InvalidOperationException("Script files must have a .cs or .vb.");
            }

            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;

            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");


            foreach (string reference in references)
            {
                if (!compilerParams.ReferencedAssemblies.Contains(reference))
                {
                    compilerParams.ReferencedAssemblies.Add(reference);
                }
            }
            CompilerResults results = codeProvider.CompileAssemblyFromSource(compilerParams, sourcecode);


            if (results.Errors.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (CompilerError item in results.Errors)
                {
                    sb.AppendFormat("{0} line:{1}   {2}\r\n", item.FileName, item.Line, item.ErrorText);
                }
                compilerErrors = results.Errors;
                throw new Exception(
                    "Compiler error(s)\r\n" + sb.ToString());
            }

            Assembly createdAssembly = results.CompiledAssembly;

            return createdAssembly;
        }
        public Assembly CreateAssembly(string filename, IList references)
        {

            compilerErrors = null;

            string extension = Path.GetExtension(filename);
            CodeDomProvider codeProvider = null;
            switch (extension)
            {
                case ".cs":
                    codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
                case ".vb":
                    codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
                default:
                    throw new InvalidOperationException("Script files must have a .cs or .vb.");
            }

            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;

            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");


            foreach (string reference in references)
            {
                if (!compilerParams.ReferencedAssemblies.Contains(reference))
                {
                    compilerParams.ReferencedAssemblies.Add(reference);
                }
            }

            CompilerResults results = codeProvider.CompileAssemblyFromFile(compilerParams,
                filename);

            if (results.Errors.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (CompilerError item in results.Errors)
                {
                    sb.AppendFormat("{0} line:{1}   {2}\r\n", item.FileName, item.Line, item.ErrorText);
                }
                compilerErrors = results.Errors;
                throw new Exception(
                    "Compiler error(s)\r\n" + sb.ToString());
            }

            Assembly createdAssembly = results.CompiledAssembly;

            return createdAssembly;
        }


        public Assembly CreateAssembly(IList filenames)
        {
            return CreateAssembly(filenames, new ArrayList());
        }

        public Assembly CreateAssembly(IList filenames, IList references)
        {
            string fileType = null;
            foreach (string filename in filenames)
            {
                string extension = Path.GetExtension(filename);
                if (fileType == null)
                {
                    fileType = extension;
                }
                else if (fileType != extension)
                {
                    throw new ArgumentException("All files in the file list must be of the same type.");
                }
            }


            compilerErrors = null;


            CodeDomProvider codeProvider = null;
            switch (fileType)
            {
                case ".cs":
                    codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
                case ".vb":
                    codeProvider = new Microsoft.CSharp.CSharpCodeProvider();
                    break;
                default:
                    throw new InvalidOperationException("Script files must have a .cs, .vb, or .js extension, for C#, Visual Basic.NET, or JScript respectively.");
            }



            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");


            foreach (string reference in references)
            {
                if (!compilerParams.ReferencedAssemblies.Contains(reference))
                {
                    compilerParams.ReferencedAssemblies.Add(reference);
                }
            }


            CompilerResults results = codeProvider.CompileAssemblyFromFile(
                compilerParams, (string[])ArrayList.Adapter(filenames).ToArray(typeof(string)));


            if (results.Errors.Count > 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (CompilerError item in results.Errors)
                {
                    sb.AppendFormat("{0} line:{1}   {2}\r\n", item.FileName, item.Line, item.ErrorText);
                }
                compilerErrors = results.Errors;
                throw new Exception(
                    "Compiler error(s)\r\n" + sb.ToString());
            }

            Assembly createdAssembly = results.CompiledAssembly;
            return createdAssembly;
        }

        public CompilerErrorCollection CompilerErrors
        {
            get
            {
                return compilerErrors;
            }
        }
    }

    class AssemblyLoader : MarshalByRefObject
    {
        private List<string> mRefAssembly = new List<string>();

        private List<Assembly> mCompilerAssembly = new List<Assembly>();

        private FileCompiler mFileCompiler = new FileCompiler();

        public AssemblyLoader()
        {

            AddReference("Accessibility.dll");
            AddReference("System.Configuration.dll");
            AddReference("System.Configuration.Install.dll");
            AddReference("System.Data.dll");
            AddReference("System.Design.dll");
            AddReference("System.DirectoryServices.dll");
            AddReference("System.Drawing.Design.dll");
            AddReference("System.Drawing.dll");
            AddReference("System.EnterpriseServices.dll");
            AddReference("System.Management.dll");
            AddReference("System.Runtime.Remoting.dll");
            AddReference("System.Runtime.Serialization.Formatters.Soap.dll");
            AddReference("System.Security.dll");
            AddReference("System.ServiceProcess.dll");
            AddReference("System.Web.dll");
            AddReference("System.Web.RegularExpressions.dll");
            AddReference("System.Web.Services.dll");
            AddReference("System.Windows.Forms.Dll");
            AddReference("System.Xml.Linq.dll");
            AddReference("System.XML.dll");
            AddReference("System.Core.dll");
        }

        public IList<Assembly> ComplierAssemblies
        {
            get
            {
                return mCompilerAssembly;
            }
        }

        private void AddReference(string referenceToDll)
        {
            if (!mRefAssembly.Contains(referenceToDll))
            {
                mRefAssembly.Add(referenceToDll);
            }
        }


        public void LoadAssembly(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            foreach (FileInfo item in directory.GetFiles("*.dll"))
            {
                try
                {
                    string filename = Path.GetFileNameWithoutExtension(item.FullName);
                    Assembly assembly = Assembly.Load(filename);
                    AddReference(item.FullName);
                    mCompilerAssembly.Add(assembly);
                }

                catch (Exception e_)
                {

                }
            }
            foreach (FileInfo item in directory.GetFiles("*.exe"))
            {
                try
                {
                    string filename = Path.GetFileNameWithoutExtension(item.FullName);
                    Assembly assembly = Assembly.Load(filename);
                    AddReference(item.FullName);
                    mCompilerAssembly.Add(assembly);
                }

                catch (Exception e_)
                {

                }
            }
            LoadVB(path);
            LoadCS(path);
        }
        public void LoadVB(string path)
        {
            string[] files = System.IO.Directory.GetFiles(path, "*.vb");
            if (files.Length > 0)
            {
                Assembly assembly = mFileCompiler.CreateAssembly(files, mRefAssembly);
                mCompilerAssembly.Add(assembly);

            }
        }

        public void LoadCS(string path)
        {
            string[] files = System.IO.Directory.GetFiles(path, "*.cs");
            if (files.Length > 0)
            {

                Assembly assembly = mFileCompiler.CreateAssembly(files, mRefAssembly);
                mCompilerAssembly.Add(assembly);
            }
        }
        public Assembly FromSourceCode(string extension, params string[] sourcecode)
        {
            Assembly assembly = mFileCompiler.CreateAssemblyFromSourceCode(extension,mRefAssembly, sourcecode);
            mCompilerAssembly.Add(assembly);
            return assembly;
        }
    }
}
