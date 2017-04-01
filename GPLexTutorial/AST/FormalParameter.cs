using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class FormalParameter
    {
        public VariableModifier? VariableModifier { get; set; }
        public UnannType UnannType { get; set; }
        public Identifier VariableDeclaratorId { get; set; }
    }
}