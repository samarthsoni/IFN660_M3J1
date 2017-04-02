using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GPLexTutorial.AST
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ClassModifier
    {
        Public,
        Private,
        Protected,
        Static,
        Final,
        Abstract
    }
}