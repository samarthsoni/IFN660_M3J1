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
            CompilationUnit complationunit = new CompilationUnit()
            {
                TypeDeclarations = new List<TypeDeclaration>()
                {
                    new NormalClassDeclaration()
                    {
                        Identifier = new Identifier()
                        {
                            Name = "HelloWorld"
                        },
                        ClassModifiers = new List<ClassModifier>() {ClassModifier.Public},
                        ClassMemberDeclarations = new List<ClassMemberDeclaration>()
                        {
                            new ClassMemberDeclaration()
                            {
                                MethodDeclaration = new MethodDeclaration()
                                {
                                    MethodModifier = new List<MethodModifier>() { MethodModifier.Public, MethodModifier.Static},
                                    Result = new VoidResult(),
                                    MethodDeclarator = new MethodDeclarator()
                                    {
                                        Identifier = new Identifier()
                                        {
                                            Name = "main"
                                        },
                                        
                                    }
                                }
                            }
                        }
                    }

                }
            };
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter() );
            Console.Write(JsonConvert.SerializeObject(complationunit , Formatting.Indented, jsonSerializerSettings));
            Console.ReadLine();
        }
    }
}


