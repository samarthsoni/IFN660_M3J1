using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    public class FormalParameter
    {
        public VariableModifier? VariableModifier { get; set; }
        public UnannType UnannType { get; set; }
        public Identifier VariableDeclaratorId { get; set; }
        public FormalParameter(VariableModifier variableModifier, UnannType unannType, Identifier identifier)
        {
            VariableModifier = variableModifier;
            UnannType = unannType;
            VariableDeclaratorId = identifier;
        }
    }
}