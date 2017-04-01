using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class FormalParameter
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public VariableModifier VariableModifier { get; set; }
        public UnannType UnannType { get; set; }
        public Identifier VariableDeclarator { get; set; }
    }
}