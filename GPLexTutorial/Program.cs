using System;
using System.Collections.Generic;
using System.IO;
using GPLexTutorial.AST;
using Newtonsoft.Json;

namespace GPLexTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Scanner scanner = new Scanner(
                new FileStream(args[0], FileMode.Open));
            Parser parser = new Parser(scanner);
            parser.Parse();
            //CompilationUnit complationunit = new CompilationUnit()
            //{
            //    TypeDeclarations = new List<TypeDeclaration>()
            //    {
            //        new NormalClassDeclaration()
            //        {
            //            //Identifier = new Identifier()
            //            //{
            //            //    Name = "HelloWorld"
            //            //},
            //            ClassModifiers = new List<ClassModifier>() {ClassModifier.Public},
            //            ClassMemberDeclarations = new List<ClassMemberDeclaration>()
            //            {
            //                new ClassMemberDeclaration()
            //                {
            //                    MethodDeclaration = new MethodDeclaration()
            //                    {
            //                        MethodModifier = new List<MethodModifier>() { MethodModifier.Public, MethodModifier.Static},
            //                        Result = new VoidResult(),
            //                        MethodDeclarator = new MethodDeclarator()
            //                        {
            //                            //Identifier = new Identifier()
            //                            //{
            //                            //    Name = "main"
            //                            //},
            //                            FormalParameterList = new List<FormalParameter>() {new FormalParameter()
            //                            {
            //                                VariableModifier = null,
            //                                //VariableDeclaratorId = new Identifier()
            //                                //{
            //                                //    Name = "args"
            //                                //},
            //                                //UnannType = new UnannReferenceType()
            //                                //{
            //                                //    Dims = null,
            //                                //    UnannClassOrInterfaceType = new UnannClassType()
            //                                //    {
            //                                //        Identifier = new Identifier()
            //                                //        {
            //                                //            Name = "String"
            //                                //        }
            //                                //    }
            //                                //}

            //                            }


            //                            },
            //                            MethodBody = new MethodBody()
            //                            {
            //                                BlockStatements = new List<BlockStatement>()
            //                                {
            //                                    //new LocalVariableDeclarationStatement()
            //                                    //{
            //                                    //    UnannType = new UnnanPrimitiveType()
            //                                    //    {
            //                                    //        IntegralType = IntegralType.INT
            //                                    //    },
            //                                    //    VariableDeclaratorId = new VariableDeclaratorId()
            //                                    //    {
            //                                    //        Identifier = new Identifier()
            //                                    //        {
            //                                    //            Name = "x"
            //                                    //        },
            //                                    //        Dims = null
            //                                    //    }
            //                                    //},
            //                                    //new ExpressionStatement()
            //                                    //{
            //                                    //  Assignment  = new Assignment()
            //                                    //  {
            //                                    //      LeftHandSide = new LeftHandSide()
            //                                    //      {
            //                                    //          Identifier = new Identifier()
            //                                    //          {
            //                                    //              Name = "x"
            //                                    //          }
            //                                    //      },
            //                                    //      AssignmentOperator = '=',
            //                                    //      AssignmentExpression = new AssignmentExpression()
            //                                    //      {
            //                                    //          IntegerLiteral = new IntegerLiteral()
            //                                    //          {
            //                                    //              Value = 42
            //                                    //          }
            //                                    //      }
            //                                    //  }
            //                                    //}
            //                                }


            //                            }

            //                        },
            //                    }
            //                }
            //            }
            //        }

            //    }
            //};
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            //Console.Write(JsonConvert.SerializeObject(complationunit, Formatting.Indented, jsonSerializerSettings));
            Console.ReadLine();
        }
    }
}


