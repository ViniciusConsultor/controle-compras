using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

using Microsoft.CSharp;

namespace HarunaNet.Framework.Utils
{
    /// <summary>
    /// Calcula expressões matematicas usando incluindo operções contidas na classe Math.
    /// </summary>
    public class ExpressionCalculator
    {
        private string m_expression;
        private Hashtable m_mathMembersMap;
        private ArrayList m_mathMembers;

        /// <summary>
        /// Expressão.
        /// </summary>
        public string Expression
        {
            get { return this.m_expression; }
            set { this.m_expression = value; }
        }

        /// <summary>
        /// Construtor da classe.
        /// </summary>
        /// <param name="expression">Expressão informada</param>
        public ExpressionCalculator(string expression)
        {
            this.m_expression = expression;
            this.m_mathMembersMap = new Hashtable();
            this.m_mathMembers = new ArrayList();
            GetMathMemberNames();
        }

        /// <summary>
        /// Executa a expressão informada.
        /// </summary>
        /// <returns>Resultado da expressão.</returns>
        public double Execute()
        {
            string source = BuildClass();
            CodeGenerator code = new CodeGenerator(source);
            object result = code.RunCode("Calculate");
            return null != result ? Convert.ToDouble(result) : double.MinValue;
        }

        #region Generate expression calculator code
        private void GetMathMemberNames()
        {
            // get a reflected assembly of the System assembly
            Assembly systemAssembly = Assembly.GetAssembly(typeof(System.Math));
            try
            {
                //cant call the entry method if the assembly is null
                if (systemAssembly != null)
                {
                    //Use reflection to get a reference to the Math class

                    Module[] modules = systemAssembly.GetModules(false);
                    Type[] types = modules[0].GetTypes();

                    //loop through each class that was defined and look for the first occurrance of the Math class
                    foreach (Type type in types)
                    {
                        if (type.Name == "Math")
                        {
                            // get all of the members of the math class and map them to the same member
                            // name in uppercase
                            MemberInfo[] mis = type.GetMembers();
                            foreach (MemberInfo mi in mis)
                            {
                                this.m_mathMembers.Add(mi.Name);
                                this.m_mathMembersMap[mi.Name.ToUpper()] = mi.Name;
                            }
                        }
                        //if the entry point method does return in Int32, then capture it and return it
                    }
                    //if it got here, then there was no entry point method defined.  Tell user about it
                }
            }
            catch
            {
                throw;
            }
        }

        private CodeMemberField FieldVariable(string fieldName, string typeName, MemberAttributes accessLevel)
        {
            CodeMemberField field = new CodeMemberField(typeName, fieldName);
            field.Attributes = accessLevel;
            return field;
        }
        private CodeMemberField FieldVariable(string fieldName, Type type, MemberAttributes accessLevel)
        {
            CodeMemberField field = new CodeMemberField(type, fieldName);
            field.Attributes = accessLevel;
            return field;
        }

        private CodeMemberProperty MakeProperty(string propertyName, string internalName, Type type)
        {
            CodeMemberProperty myProperty = new CodeMemberProperty();
            myProperty.Name = propertyName;
            myProperty.Comments.Add(new CodeCommentStatement(String.Format("The {0} property is the returned result", propertyName)));
            myProperty.Attributes = MemberAttributes.Public;
            myProperty.Type = new CodeTypeReference(type);
            myProperty.HasGet = true;
            myProperty.GetStatements.Add(
                new CodeMethodReturnStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName)));

            myProperty.HasSet = true;
            myProperty.SetStatements.Add(
                new CodeAssignStatement(
                    new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), internalName),
                    new CodePropertySetValueReferenceExpression()));

            return myProperty;
        }


        /// <summary>
        /// Need to change eval string to use .NET Math library
        /// </summary>
        /// <param name="eval">evaluation expression</param>
        /// <returns></returns>
        private string RefineEvaluationString(string eval)
        {
            // look for regular expressions with only letters
            Regex regularExpression = new Regex("[a-zA-Z_]+");

            // track all functions and constants in the evaluation expression we already replaced
            ArrayList replacelist = new ArrayList();

            // find all alpha words inside the evaluation function that are possible functions
            MatchCollection matches = regularExpression.Matches(eval);
            foreach (Match m in matches)
            {
                // if the word is found in the math member map, add a Math prefix to it
                bool isContainedInMathLibrary = this.m_mathMembersMap[m.Value.ToUpper()] != null;
                if (replacelist.Contains(m.Value) == false && isContainedInMathLibrary)
                {
                    eval = eval.Replace(m.Value, "Math." + this.m_mathMembersMap[m.Value.ToUpper()]);
                }

                // we matched it already, so don't allow us to replace it again
                replacelist.Add(m.Value);
            }

            // return the modified evaluation string
            return eval;
        }

        /// <summary>
        /// Converte uma "if" feito na logica do Excel - SE ( comparção_logica ; se_verdadeiro ; se_falso ) - 
        /// para um "if" do C# - comparação_logica ? se_verdadeiro : se_falso.
        /// </summary>
        /// <param name="expression">Expressão a ser usada.</param>
        /// <returns>Expressão convertida.</returns>
        private string ConvertToIf(string expression)
        {
            int indexOf = expression.IndexOf("se");
            //Length da palavra se
            int lengthOfKeyWord = 2;
            while (-1 != indexOf)
            {
                    int startIndex = indexOf + lengthOfKeyWord;
                    int endIndex = GetEndIndexFormIfExpression(expression.Substring(startIndex), startIndex);
                    int length = (endIndex - startIndex) + 1;

                    string newExpression = ChangeCharacters(expression.Substring(startIndex,length));
                    expression = expression.Remove(indexOf, length + lengthOfKeyWord);
                    expression = expression.Insert(indexOf, newExpression);

                    indexOf = expression.IndexOf("se");
            }
            return expression;
        }

        private string ChangeCharacters(string expression)
        {
            int indexOf = expression.IndexOf(";");
            while (-1 != indexOf)
            {
                expression = expression.Remove(indexOf, 1);
                expression = expression.Insert(indexOf, GetCharacterToInsert(expression));
                indexOf = expression.IndexOf(";");
            }
            return expression.Replace("=","==");
        }

        private string GetCharacterToInsert(string expression)
        {
            return -1 == expression.IndexOf("?") ? "?" : ":";
        }

        private int GetEndIndexFormIfExpression(string expression, int startIndex)
        {
            string expressionTemp = expression.Trim();
            int start = expressionTemp.IndexOf("(");            
            char[] chars = expressionTemp.ToCharArray();

            int count = 0;            
            int i = 0;

            for (i = start; i < chars.Length; i++)
            {
                char c = chars[i];
                if ('(' == c)
                {
                    count++;
                }
                else if (')' == c)
                {
                    count--;
                }
                if (0 == count)
                {
                    return i + startIndex;
                }
            }

            return -1;
        }


        /// <summary>
        /// Main driving routine for building a class
        /// </summary>
        private string BuildClass()
        {
            this.m_expression = RefineEvaluationString(this.m_expression);
            this.m_expression = this.m_expression.Replace("SE","se").Replace("Se","se");
            this.m_expression = ConvertToIf(this.m_expression).Replace("se", string.Empty);
            

            // need a string to put the code into
            StringBuilder source = new StringBuilder();
            using (StringWriter sw = new StringWriter(source))
            {
                //Declare your provider and generator
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                ICodeGenerator generator = codeProvider.CreateGenerator(sw);
                CodeGeneratorOptions codeOpts = new CodeGeneratorOptions();

                CodeNamespace myNamespace = new CodeNamespace("ExpressionEvaluator");
                myNamespace.Imports.Add(new CodeNamespaceImport("System"));
                myNamespace.Imports.Add(new CodeNamespaceImport("System.Windows.Forms"));

                //Build the class declaration and member variables			
                CodeTypeDeclaration classDeclaration = new CodeTypeDeclaration();
                classDeclaration.IsClass = true;
                classDeclaration.Name = "Calculator";
                classDeclaration.Attributes = MemberAttributes.Public;
                classDeclaration.Members.Add(FieldVariable("answer", typeof(double), MemberAttributes.Private));

                //default constructor
                CodeConstructor defaultConstructor = new CodeConstructor();
                defaultConstructor.Attributes = MemberAttributes.Public;
                defaultConstructor.Comments.Add(new CodeCommentStatement("Default Constructor for class", true));
                defaultConstructor.Statements.Add(new CodeSnippetStatement("//TODO: implement default constructor"));
                classDeclaration.Members.Add(defaultConstructor);

                //property
                classDeclaration.Members.Add(this.MakeProperty("Answer", "answer", typeof(double)));

                //Our Calculate Method
                CodeMemberMethod myMethod = new CodeMemberMethod();
                myMethod.Name = "Calculate";
                myMethod.ReturnType = new CodeTypeReference(typeof(double));
                myMethod.Comments.Add(new CodeCommentStatement("Calculate an expression", true));
                myMethod.Attributes = MemberAttributes.Public;
                myMethod.Statements.Add(new CodeAssignStatement(new CodeSnippetExpression("Answer"), new CodeSnippetExpression(this.m_expression)));
                myMethod.Statements.Add(
                    new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "Answer")));
                classDeclaration.Members.Add(myMethod);
                //write code
                myNamespace.Types.Add(classDeclaration);
                generator.GenerateCodeFromNamespace(myNamespace, sw, codeOpts);
                sw.Flush();
                sw.Close();
            }
            return source.ToString();
        }

        private string ReplaceCommaToDot(string expression)
        {
            return expression.Replace(".",string.Empty).Replace(",",".");
        }
        #endregion
    }
}
