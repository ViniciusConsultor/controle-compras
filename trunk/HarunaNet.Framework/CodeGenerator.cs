using System;
using System.Collections;
using System.Collections.Generic;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Gerador de códigos dinamicos.
    /// </summary>
    public class CodeGenerator
    {
        private CodeDomProvider m_provider;
        private string m_source;

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="source">Código fonte para criação do assempbly na memoria.</param>
        public CodeGenerator(string source)
            : this(source, "C#")
        {

        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="source">Código fonte para criação do assempbly na memoria.</param>
        /// <param name="language">Linguagem desejada.</param>
        public CodeGenerator(string source, string language)
        {
            this.m_provider = CodeDomProvider.CreateProvider(language);
            this.m_source = source;
        }


        /// <summary>
        /// Creawte parameters for compiling
        /// </summary>
        /// <returns>Parametros de compilação definidos.</returns>
        private CompilerParameters CreateCompilerParameters()
        {
            //add compiler parameters and assembly references
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.CompilerOptions = "/target:library /optimize";
            compilerParams.GenerateExecutable = false;
            compilerParams.GenerateInMemory = true;
            compilerParams.IncludeDebugInformation = false;
            compilerParams.ReferencedAssemblies.Add("mscorlib.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add("System.Windows.Forms.dll");

            return compilerParams;
        }

        /// <summary>
        /// Compiles the code from the code string
        /// </summary>
        /// <returns>Resultado da compilação.</returns>
        private CompilerResults CompileCode()
        {
            CompilerParameters parms = CreateCompilerParameters();
            //actually compile the code
            CompilerResults results = m_provider.CompileAssemblyFromSource(
                                        parms, this.m_source);

            //Do we have any compiler errors?
            if (results.Errors.Count > 0)
            {
                StringBuilder errors = new StringBuilder("Compiler errors:\r\n");
                foreach (CompilerError error in results.Errors)
                {
                    errors.AppendLine(error.ErrorText);
                }
                throw new CompilerException(errors.ToString());
            }

            return results;
        }

        /// <summary>
        /// Compila e executa o código informado.
        /// </summary>
        /// <param name="methodName">Nome do método a ser executado.</param>
        /// <returns>Resultado do método.</returns>
        public object RunCode(string methodName)
        {
            CompilerResults results = CompileCode();
            Assembly executingAssembly = results.CompiledAssembly;
            try
            {
                //cant call the entry method if the assembly is null
                if (executingAssembly != null)
                {
                    object assemblyInstance = executingAssembly.CreateInstance("ExpressionEvaluator.Calculator");
                    //Use reflection to call the static Main function

                    Module[] modules = executingAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the entry point method
                    foreach (Type type in types)
                    {
                        MethodInfo[] mis = type.GetMethods();
                        foreach (MethodInfo mi in mis)
                        {
                            if (mi.Name == methodName)
                            {
                                return mi.Invoke(assemblyInstance, null);
                            }
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
            return null;
        }
    }

    /// <summary>
    /// Classe de exceção para o compilador.
    /// </summary>
    public class CompilerException : ApplicationException
    {
        /// <summary>
        /// Construtor da classe de exceção do compilador.
        /// </summary>
        /// <param name="message"></param>
        public CompilerException(string message)
            : base(message)
        {

        }
    }
}
