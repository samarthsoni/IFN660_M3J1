using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class FormalParameter
    {
        public VariableModifier? VariableModifier { get; set; }
        public Type Type { get; set; }
        public Identifier VariableDeclaratorId { get; set; }
        public FormalParameter(VariableModifier variableModifier, Type unannType, Identifier identifier)
        {
            VariableModifier = variableModifier;
            Type = unannType;
            VariableDeclaratorId = identifier;
        }
    }
}