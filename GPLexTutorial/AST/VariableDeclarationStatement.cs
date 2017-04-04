namespace GPLexTutorial.AST
{
    public class VariableDeclarationStatement : Statement
    {
        public Type Type { get; set; }
        public Identifier Identifier { get; set; }
        public Dims Dims { get; set; }
        public VariableDeclarationStatement(Type type, Identifier identifier, Dims dims)
        {
            Type = type;
            Identifier = identifier;
            Dims = dims;
        }
    }
}