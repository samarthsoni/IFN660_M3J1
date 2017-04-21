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

            //IntegerLiteralExpression intLiteral = new IntegerLiteralExpression(42);
            //IdentifierExpression identExp = new IdentifierExpression(new Identifier("x"));
            //AssignmentExpression assgnExp = new AssignmentExpression(identExp, intLiteral);
            //ExpressionStatement expStmt = new ExpressionStatement(assgnExp);
            //List<Statement> blockStmt = new List<Statement>();
            //blockStmt.Add(expStmt);

            //List<Expression> variableList = new List<Expression>();
            //variableList.Add(identExp);
            //NamedType integralType = new NamedType("INT");
            //VariableDeclarationStatement dec = new VariableDeclarationStatement(integralType, variableList,null);
            //blockStmt.Add(dec);
            
            //NamedType strName = new NamedType("String");
            //UnannArrayType strArray = new UnannArrayType(strName, null);
            //ParameterDeclarationStatement pds = new ParameterDeclarationStatement(strArray, new IdentifierExpression(new Identifier("args")));
            //List<Statement> parameterList = new List<Statement>() { pds };
            //MethodDeclarator methodDeclarator = new MethodDeclarator(new Identifier("main"), parameterList);
            //MethodHeader methodHeader = new MethodHeader(null, methodDeclarator);
            //MethodDeclaration methodDeclaration = new MethodDeclaration(new List<MethodModifier>() { MethodModifier.Public }, methodDeclarator, blockStmt);
            //NormalClassDeclaration classDeclaration = new NormalClassDeclaration(new List<ClassModifier>() { ClassModifier.Public },new Identifier("classname"),new List<MemberDeclaration>() { methodDeclaration });
            //CompilationUnit cu = new CompilationUnit(new List<TypeDeclaration>() { classDeclaration });

            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.All
            };
            jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            Console.Write(JsonConvert.SerializeObject(parser.RootNode, Formatting.Indented, jsonSerializerSettings));
            Console.ReadLine();
        }
    }
}


