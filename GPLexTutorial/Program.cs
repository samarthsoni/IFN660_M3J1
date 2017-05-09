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
            try
            {
                Scanner scanner = new Scanner(
                    new FileStream(args[0], FileMode.Open));
                Parser parser = new Parser(scanner);
                parser.Parse();
                parser.RootNode.ResolveNames(null);
                parser.RootNode.TypeCheck();
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.All
                };
                jsonSerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                Console.Write(JsonConvert.SerializeObject(parser.RootNode, Formatting.Indented, jsonSerializerSettings));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}


